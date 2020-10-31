using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LoginCrud
{
    public class ExceptionChecking
    {
        public static bool WriteErrorLogInFile(Exception excep, string Application, string Controllers, string Action, string Location, string URL, string UserID)
        {
            bool flag = false;
            try
            {
                string ErrorMessgage = excep.Message;
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(excep, true);
                string pagename = trace.GetFrame((trace.FrameCount - 1)).GetFileName();
                string method = trace.GetFrame((trace.FrameCount - 1)).GetMethod().ToString();
                Int32 lineNumber = trace.GetFrame((trace.FrameCount - 1)).GetFileLineNumber();
                //string path = "E://MVC//LoginCrud//LoginCrud//Blob_Storage//ErrorLog";
                //string path = "~//Blob_Storage//ErrorLog";
                string path = AppDomain.CurrentDomain.BaseDirectory + "Blob_Storage\\ErrorLog";
                // check if directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + "\\ERROR_" + DateTime.Today.ToString("dd-MMM-yyyy") + ".log";
                // check if file exist
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                // log the error now
                using (StreamWriter writer = File.AppendText(path))
                {
                    string error = DateTime.Now.ToString() + "-Application:" + Application + ",Controller:" + Controllers + ",Action:" + Action + ",Location:" + Location + ",UserID:" + UserID + ",UserID:" + UserID + ",Message:" + excep.Message + ",URL:" + URL;
                    writer.WriteLine(error);
                    writer.Flush();
                    writer.Close();
                }
                flag = true;
            }
            catch (Exception EXC)
            { }
            return flag;
        }
    }
}