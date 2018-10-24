using System;

namespace FileChecker
{
    public interface IUserForm
    {
        void ReportProgress(int progress);
        void ReportHash(byte[] hashResult);
    }

    public class ThreadFileObj
    {
        public readonly string FileName;
        public readonly IUserForm UserForm;

        public ThreadFileObj(string fileName, IUserForm userForm)
        {
            FileName = fileName;
            UserForm = userForm;
        }
    }
}
