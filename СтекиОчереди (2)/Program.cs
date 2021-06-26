using System;
using System.Collections.Generic;

namespace СтекиОчереди__2_
{
    class Queue<T>
    {
        Stack<T> stack = new Stack<T>();
        Stack<T> reversStack = new Stack<T>();

        public void Enqueue(T element)
        {
            if (stack.CheckStack())
            {
                stack.Push(element);
                reversStack.Push(element);
            }
            else
            {
                stack.Push(element);
                reversStack.ClearStack();

                List<T> tempory = new List<T>();
                tempory.AddRange(stack.CopeStack().ToArray());

                while (!stack.CheckStack())
                {
                   reversStack.Push(stack.Pop());
                }

                stack.AcceptStack(tempory);
            }

        }

        public T Dequeue()
        {
           return reversStack.Pop();
        }
    }
    class Stack<T>
    {
        List<T> stack = new List<T>();

        public void Push(T e, bool isReversStack = false)
        {
            stack.Add(e);
        }

        public T Pop(bool isReversStack = false)
        {
            var res = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return res;
        }

        public bool CheckStack()
        {
            return stack.Count == 0;
        }

        public void ClearStack()
        {
             stack.Clear();
        }

        public List<T> CopeStack()
        {
            return stack;
        }

        public void AcceptStack(List<T> list)
        {
            stack.AddRange(list.ToArray());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Queue<int>();
            stack.Enqueue(1);
            stack.Enqueue(2);
            stack.Enqueue(3);
            stack.Enqueue(4);

            Console.WriteLine(stack.Dequeue());
            Console.WriteLine(stack.Dequeue());
            Console.WriteLine(stack.Dequeue());
            Console.WriteLine(stack.Dequeue());
        }
    }
}
