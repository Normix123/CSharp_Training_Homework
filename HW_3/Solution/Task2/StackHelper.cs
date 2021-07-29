using System;

public static class StackHelper
{
    public static Stack<T> Reverse<T>(this IStack<T> interfaceStack) where T : struct
    {
        if(interfaceStack is null || interfaceStack.IsEmpty()) throw new ArgumentNullException();

        Stack<T> stackClone = interfaceStack.Clone();
        Stack<T> @new = new Stack<T>();

        while(!stackClone.IsEmpty()) @new.Push(stackClone.Pop());

        return @new;
    }
}

