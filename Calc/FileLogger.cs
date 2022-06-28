using System.IO;
using System;

namespace Calc
{
    public class FileLogger : ILogger, IDisposable
    {
        private StreamWriter _writer;

        public FileLogger()
        {
            _writer = new("log.txt");
        }

        public void Dispose()
        {
            _writer.Dispose();
        }

        public void WriteLog(string message)
        {
            _writer.WriteLine(message);
            _writer.Close();
            Dispose();
        }
    }
}