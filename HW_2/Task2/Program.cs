using System;

Lecture lecture = new Lecture();
lecture.setDescription("This is lecture");
lecture.Theme = "This is theme";


PracticalTask practicalTask = new PracticalTask();
practicalTask.setDescription("This is practical task");
practicalTask.ReferenceToSolution = "This is reference to solution";
practicalTask.ReferenceToTask = "This is reference to task";


object[] objects = new object[] { lecture, practicalTask };

Training training = new Training(objects);
training.setDescription("This is training");

Console.Write("Description of training: ");
training.Display();

Console.WriteLine("Training contains:\n");

for (var i = 0; i < training.Size; i++) 
{
    if(training[i] is Lecture value1) value1.Display();
    if (training[i] is PracticalTask value2) value2.Display();
    Console.WriteLine(new string('-', 30));
}
Console.WriteLine();


Training cloneTraining = training.Clone();
Console.Write("Description of training: ");
cloneTraining.Display();
Console.WriteLine("After clone and addition training contains:\n");
cloneTraining.Add(practicalTask);

for (var i = 0; i < cloneTraining.Size; i++)
{
    if (cloneTraining[i] is Lecture value1) value1.Display();
    if (cloneTraining[i] is PracticalTask value2) value2.Display();
    Console.WriteLine(new string('-', 30));
}

if(cloneTraining[0] is Lecture lk) lk.setDescription("This is qwew in clone");


for (var i = 0; i < training.Size; i++)
{
    if (training[i] is Lecture value1) value1.Display();
    if (training[i] is PracticalTask value2) value2.Display();
    Console.WriteLine(new string('-', 30));
}
Console.WriteLine();

Console.WriteLine("\nIs clone practical: "+ cloneTraining.isPractical());

