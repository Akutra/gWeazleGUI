using System;

namespace gWeasleGUI
{
    public interface ILogger
    {
        void Info(string message);
        void Error(string message, Exception ex);
    }
}
