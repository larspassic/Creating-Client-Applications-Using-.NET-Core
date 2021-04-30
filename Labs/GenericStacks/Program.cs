using System;

namespace GenericStacks
{
    public class MyStack<T>
    {
        T[] stack;
        int sp;

        public void Push(T item)
        {
            stack[sp++] = item;
        }

        public T Pop()
        {
            return stack[--sp];
        }

        //Exercise - make a method IsEmpty to check if the stack is empty
        public bool IsEmpty()
        {
            bool result = false;
            
            if(sp == 0)
            {
                result = true;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(2);

            while (!stack.IsEmpty)
            {
                int number = stack.Pop();
                Console.WriteLine("Last value popped = {0}", number);
            }

            Console.ReadLine();
        }
    }
}
