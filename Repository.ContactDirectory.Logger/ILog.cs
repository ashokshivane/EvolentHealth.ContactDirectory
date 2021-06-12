using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ContactDirectory.Logger
{
    public interface ILog
    {
        void LogException(string message);
    }
}
