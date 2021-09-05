using System;

namespace WebApplication.Exceptions
{
    public class ManagerException: Exception
    {
        public ManagerException(string message): base(message)
        {
        }
    }
}
