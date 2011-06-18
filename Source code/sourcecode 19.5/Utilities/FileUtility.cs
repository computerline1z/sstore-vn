using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace Utilities
{
    public class FileUtility
    {
        private static int attachmentFileNameSeed;
        private static int MAX_SEED;
        private static string SEED_MUTEX;

        static FileUtility()
        {
            attachmentFileNameSeed = 0;
            MAX_SEED = 100;
            SEED_MUTEX = "SEED_MUTEX";
        }
        public static void CreateFolder(string path)
        {
            try
            {
                string PathOfFolder = HttpContext.Current.Request.PhysicalApplicationPath + path;
                DirectoryInfo dir = new DirectoryInfo(PathOfFolder);
                if (!dir.Exists)
                    dir.Create();
            }
            catch (Exception ex)
            {
                Logger.Log.error("FileUtility CreateFolder err: " + ex.Message);
            }
        }
        public static void DeleteFolder(string dir)
        {
            try
            {
                string PathOfDirectory = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, dir);
                bool flag = !Directory.Exists(PathOfDirectory);
                if (!flag)
                    Directory.Delete(PathOfDirectory, true);
            }
            catch (Exception ex)
            {
                Logger.Log.error("FileUtility DeleteFolder err: " + ex.Message);
            }
        }
        public static void DeleteFile(string path)
        {
            try
            {
                string PathOfFile = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, path);
                bool flag = !File.Exists(PathOfFile);
                if (!flag)
                    File.Delete(PathOfFile);
            }
            catch(Exception ex)
            {
                Logger.Log.error("FileUtility DeleteFile err: " + ex.Message);
            }
        }

        public static string GenerateDataFileName()
        {
            DateTime dateTime = DateTime.Now;
            long l = dateTime.Ticks;
            return String.Format("{0}_{1}.data", l, GetSeed());
        }
        private static int GetSeed()
        {
            int i;
            lock (SEED_MUTEX)
            {
                attachmentFileNameSeed = ++attachmentFileNameSeed % MAX_SEED;
                i = attachmentFileNameSeed;
            }
            return i;
        }

        public static bool IsValidFileName(string fileName)
        {
            //bool flag2 = (fileName != null) && !fileName.Equals("");
            //if (!flag2)
            //    throw new ArgumentException("T\u00EAn t\u1EADp tin kh\u00F4ng \u0111\u01B0\u1EE3c ph\u00E9p r\u1ED7ng");
            Regex r = new Regex("^[0-9a-z \\._-]*[0-9a-z_-]+$", RegexOptions.IgnoreCase);
            return r.IsMatch(fileName) && (fileName.Length <= 256);
        }
       
        public static FileStream GetAttachFileStream(string folderPath, string storagePath)
        {
            try
            {
                string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, folderPath);
                return File.OpenRead(Path.Combine(path, storagePath));
            }
            catch(Exception ex)
            {
                Logger.Log.error("FileUtility GetAttachFileStream err: " + ex.Message);
                return null;
            }
        }
        private static void WriteFile(Stream stream, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.CreateNew);
            try
            {
                bool flag = (int)stream.Length <= 0;
                if (!flag)
                {
                    byte[] buffers = new byte[stream.Length];
                    stream.Read(buffers, 0, (int)stream.Length);
                    fs.Write(buffers, 0, (int)stream.Length);
                    fs.Flush();
                }
            }
            finally
            {
                fs.Close();
            }
        }
        public static void SaveAttachFile(Stream stream, string FolderPath, int FolderID, string StoragePath)
        {
            string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath + FolderPath, FolderID.ToString());

            bool flag = Directory.Exists(path);
            if (!flag)
                Directory.CreateDirectory(path);
            WriteFile(stream, Path.Combine(path, StoragePath));
            
        }
        
    }
}
