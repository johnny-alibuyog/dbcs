using System.Windows.Forms;
using CooperativeSystem.Service.Utilities.Logs;

namespace CooperativeSystem.UI.Views.Utilities
{
    public class TabControlHelper
    {
        private ErrorLogger _errorLogger;
        private TabControl _tabControl;

        public TabControlHelper() 
        {
            _errorLogger = new ErrorLogger();
        }

        public TabControlHelper(TabControl tabControl) : this()
        {
            _tabControl = tabControl;
        }

        #region TabControlHelper Public Members

        public TabControl TabControl
        {
            get { return _tabControl; }
            set { _tabControl = value; }
        }

        public bool IsVisible(TabPage tabPage)
        {
            return TabControl.TabPages.Contains(tabPage);
        }

        public void HideTabPage(TabPage tabPage)
        {
            if (TabControl.TabPages.Contains(tabPage))
                TabControl.TabPages.Remove(tabPage);
        }

        public void ShowTabPage(TabPage tabPage)
        {
            ShowTabPage(tabPage, TabControl.TabPages.Count);
        }

        public void ShowTabPage(TabPage tabPage, int index)
        {
            if (!TabControl.TabPages.Contains(tabPage))
                InsertTabPage(tabPage, index);
        }

        public void InsertTabPage(TabPage tabpage, int index)
        {
            if (index < 0 || index > TabControl.TabCount)
            {
                _errorLogger.Log(string.Format("Index {0} is out of Range for tab {1}.",
                    index.ToString(), tabpage.Name));
                return;
            }

            TabControl.TabPages.Add(tabpage);
            if (index < TabControl.TabCount - 1)
            {
                do
                {
                    SwapTabPages(tabpage, (TabControl.TabPages[TabControl.TabPages.IndexOf(tabpage) - 1]));
                }
                while (TabControl.TabPages.IndexOf(tabpage) != index);
            }

            TabControl.SelectedTab = tabpage;
        }

        public void SwapTabPages(TabPage tabPage1, TabPage tabPage2)
        {
            //if (!TabControl.TabPages.Contains(tabPage1) || !TabControl.TabPages.Contains(tabPage2))
            //    throw new ArgumentException("TabPages must be in the TabControls TabPageCollection.");

            if (!TabControl.TabPages.Contains(tabPage1))
            {
                _errorLogger.Log(string.Format("{0} does not contain {1}.", TabControl.Name, tabPage1.Name));
                return;
            }

            if (!TabControl.TabPages.Contains(tabPage2))
            {
                _errorLogger.Log(string.Format("{0} does not contain {1}.", TabControl.Name, tabPage2.Name));
                return;
            }

            int Index1 = TabControl.TabPages.IndexOf(tabPage1);
            int Index2 = TabControl.TabPages.IndexOf(tabPage2);

            TabControl.TabPages[Index1] = tabPage2;
            TabControl.TabPages[Index2] = tabPage1;

            //Uncomment the following section to overcome bugs in the Compact Framework
            //TabControl.SelectedIndex = TabControl.SelectedIndex;
            //string tabPage1Text = tabPage1.Text;
            //string tabPage2Text = tabPage2.Text;
            //tabPage1.Text = tabPage1Text;
            //tabPage2.Text = tabPage2Text;
        }

        #endregion
    }
}
