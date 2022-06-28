using System.Configuration;

namespace Calc
{
    public class InterpreterFactory
    {
        public static Interpreter CreateInterpreter()
        {
            if (ConfigurationManager.AppSettings["Log"].Contains("True")) 
            {
                return new LogInterpreter();

            }
            return new Interpreter();
        }
    }
}