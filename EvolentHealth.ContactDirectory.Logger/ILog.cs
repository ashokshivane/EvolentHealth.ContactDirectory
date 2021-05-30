using System;
using System.Collections.Generic;
using System.Text;

namespace EvolentHealth.ContactDirectory.Logger
{
    public interface ILog
    {
        void LogException(string message);
    }
}
