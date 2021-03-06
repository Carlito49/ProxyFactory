using System.Configuration;

namespace Calc
{
    public class InterpreterFactory
    {
        public static Interpreter CreateInterpreter(ILogger logger)
        {
            if (ConfigurationManager.AppSettings["Log"].Contains("True")) 
            {
                return new LogInterpreter(logger);

            }
            return new Interpreter(logger);
        }
    }
}