using System;
using System.Collections.Generic;
using System.Text;

namespace System.Application.Interface
{
    public interface ILogTextLog4Net
    {
        void LogInformation(string message);
        void LogWanning(string message);
        void LogError(string message, Exception exception);
        void LogError(Exception exception);
    }
}
