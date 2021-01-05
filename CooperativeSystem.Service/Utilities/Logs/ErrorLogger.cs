using System;
using System.IO;

namespace CooperativeSystem.Service.Utilities.Logs
{
    public class ErrorLogger : ILogger
    {
        private string FilePath
        {
            get { return Directory.GetCurrentDirectory() + "\\ErrorLogs\\"; } 
        }

        private string FileName
        {
            get { return FilePath + DateTime.Today.ToString("yyyyMMdd") + ".log"; }
        }

        //private void TestRx()
        //{
        //    var fs = new FileStream(@"d:\temp\test.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1, true);
        //    var data = new byte[fs.Length];
        //    fs.BeginRead(data, 0, data.Length, (result) =>
        //    {
        //        var bytesRead = fs.EndRead(result);
        //        Console.WriteLine("{0} bytes read.", bytesRead);
        //    }, null); 
        //}

        //private void TestRx2()
        //{
        //    var fs = new FileStream(@"d:\temp\test.txt", FileMode.Open, FileAccess.Read, FileShare.Read, 1, true);
        //    var data = new byte[fs.Length];
        //    var asyncRead = Observable.FromAsyncPattern<byte[], int, int, int>(
        //      fs.BeginRead, iasyncResult => fs.EndRead(iasyncResult));
        //    var result = asyncRead(data, 0, data.Length);
        //    result.Subscribe(bytesRead => Console.WriteLine("{0} bytes read.", bytesRead)); 

        //}


        #region ILogger Members

        public void Log(string message)
        {
            try
            {
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);

                // append if text file already exist
                bool append = File.Exists(FileName);
                using (StreamWriter sw = new StreamWriter(FileName, append))
                {
                    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " " + message);
                    sw.Flush();
                }
            }
            catch { } // ignore
        }

        #endregion
    }
}
