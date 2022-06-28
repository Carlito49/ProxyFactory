using System;

namespace Calc
{
    public class ConsoleCalc
    {
        private IInterpreter _interpreter;

        public ConsoleCalc(IInterpreter interpreter)
        {
            _interpreter = interpreter;
        }

        public void Run(string expression)
        {
            if (expression.Length == 0)
            {
                Console.WriteLine("You must provide a command line argument.");
                return;
            }

            Console.WriteLine(expression);
            
            _interpreter.Interpret(expression);
        }
    }
}