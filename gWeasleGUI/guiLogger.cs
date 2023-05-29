using System;

namespace gWeasleGUI
{
    public class GuiLogger : ILogger
    {
        Action<string> displayWriter;

        public GuiLogger(Action<string> displayWriter) 
        {
            this.displayWriter = displayWriter;
        }

        public void Error(string message, Exception ex)
        {
            this.displayWriter($"{message} with exception {ex.Message}");
        }

        public void Info(string message)
        {
            this.displayWriter(message);
        }
    }
}
