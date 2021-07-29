using System;

try
{
    Stack<int> stack = new Stack<int>();

    stack.Push(25);
    stack.Push(35);
    stack.Push(45);
    stack.Push(55);
    Stack<int> @new = stack.Reverse();

    while (!stack.IsEmpty())
        Console.WriteLine(stack.Pop());

    Console.WriteLine(new string('-',25));

    while (!@new.IsEmpty())
        Console.WriteLine(@new.Pop());
}
catch (Exception ex) { Console.WriteLine($"{ex.Message}"); } 
