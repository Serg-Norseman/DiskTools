using System;

namespace FileChecker
{
    public interface IUserForm
    {
        void ReportLog(string msg);
        void ReportProgress(ThreadFileObj fileObj);
        void ReportHash(ThreadFileObj fileObj);
        void ReportStart(ThreadFileObj fileObj);
    }

    public class ThreadFileObj
    {
        public readonly int Index;
        public readonly int Core;
        public readonly string FileName;
        public readonly IUserForm UserForm;

        public int Progress;
        public byte[] Hash;

        public ThreadFileObj(int index, int core, string fileName, IUserForm userForm)
        {
            Index = index;
            Core = core;
            FileName = fileName;
            UserForm = userForm;
        }
    }
}
