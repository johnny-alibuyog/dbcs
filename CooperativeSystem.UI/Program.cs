using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CooperativeSystem.UI
{
    internal class ApplicationData
    {
        public virtual string UserID { get; set; }
        public virtual string OrganizationName { get; set; }
        public virtual string TelephoneNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual IList<string> Roles { get; set; }

        public ApplicationData()
        {
            Roles = new List<string>();
        }
    }

    internal static class Program
    {
        public static ApplicationData AppData { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var x = 0.01M;

            Console.WriteLine(x);
            Console.WriteLine(decimal.Round(x));
            Console.WriteLine(x);

            AppData = new ApplicationData();

            var createdNew = false;
            var mutex = new Mutex(true, Application.ProductName, out createdNew);

            // allow single instance
            if (!createdNew)
            {
                var caption = Application.CompanyName;
                var message = string.Format("{0} is already running.", Application.ProductName);
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CooperativeSystem.UI.Views.MainView());

            GC.KeepAlive(mutex);
        }
    }
}
