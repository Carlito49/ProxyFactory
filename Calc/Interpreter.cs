﻿using Calc.SyntaxNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Interpreter : IVisitor, IDisposable, IInterpreter
    {
        private readonly Stack<int> _stack = new Stack<int>();

        private ILogger _logger;

        public int Result => _stack.Pop();

        public Interpreter() {}

        public Interpreter(ILogger logger)
        {
            _logger = logger;
        }

        public virtual void Visit(ArithmeticOperation operation)
        {
            var r = _stack.Pop();
            var l = _stack.Pop();

            switch(operation.Operator)
            {
                case Operator.Add:
                    _stack.Push(l + r);
                    break;
                case Operator.Substract:
                    _stack.Push(l - r);
                    break;
                case Operator.Multiply:
                    _stack.Push(l * r);
                    break;
                case Operator.Divide:
                    _stack.Push(l / r);
                    break;
            }
        }

        public virtual void Visit(Constant constant)
        {
            _stack.Push(constant.Value);
        }

        public void Dispose()
        {

        }

        public int Interpret(string expression)
        {
            var interpreter = InterpreterFactory.CreateInterpreter();
            var ast = new Parser().Parse(new Tokenizer().Tokenize(expression));
            ast.Accept(interpreter);
            _logger.WriteLog(expression);
            _logger.WriteLog(interpreter.Result.ToString());
            return interpreter.Result;
        }
    }
}
