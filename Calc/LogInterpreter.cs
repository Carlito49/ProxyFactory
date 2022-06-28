using System.IO;
using System;
using Calc.SyntaxNodes;

namespace Calc 
{
    public class LogInterpreter : Interpreter, IDisposable 
    {
        private StreamWriter _logWritter;

        public LogInterpreter()
        {
            _logWritter = new("log.txt");
        }

        new public void Dispose()
        {
            _logWritter.Dispose();
        }

        public override void Visit(ArithmeticOperation operation)
        {
            base.Visit(operation);
            _logWritter.WriteLine(operation.ToString());
        }

        public override void Visit(Constant constant)
        {
            base.Visit(constant);
            _logWritter.WriteLine(constant.ToString());
        }
    }
}