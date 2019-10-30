using System;
using System.Collections.Generic;

namespace RPNLibrary
{
    public class RPN
    {
        private Stack<decimal> Stack { get; set; }

        public RPN()
        {
            this.Stack = new Stack<decimal>();
        }

        public string Input(string input)
        {
            var inputs = input.Split(' ');
            string result = "";
            foreach (var item in inputs)
            {
                result = Calculate(item);
            }
            return result;
        }

        private string Calculate(string arg)
        {
            decimal num;
            bool isNum = decimal.TryParse(arg, out num);
            if (isNum)
                Stack.Push(num);
            else
            {
                decimal second;
                switch (arg)
                {
                    case "+":
                        Stack.Push(Stack.Pop() + Stack.Pop());
                        break;
                    case "*":
                        Stack.Push(Stack.Pop() * Stack.Pop());
                        break;
                    case "-":
                        second = Stack.Pop();
                        Stack.Push(Stack.Pop() - second);
                        break;
                    case "/":
                        second = Stack.Pop();
                        if (second != 0.0M)
                            Stack.Push(Stack.Pop() / second);
                        else
                            throw new InvalidOperationException("Arithmetic error: Division by zero");
                        break;
                    default:
                        throw new ArgumentException("ERROR. Unknown command.");
                }
            }
            return Stack.Peek().ToString(); ;
        }
    }
}
