using System.IO;
using System;

namespace Calc
{
    public class FileLogger : IDisposable
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
    }
}