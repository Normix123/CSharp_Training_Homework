using System;

// ми-диез первой октавы
Key e = new Key(Octave.First, Note.E, Accidental.Sharp);
Console.WriteLine(e); // E# 

// фа первой октавы
Key f = new Key(Octave.First, Note.F);

Console.WriteLine(e.Equals(f));     // True
Console.WriteLine(e.CompareTo(f));  // 0
Console.WriteLine(f.CompareTo(e));  // 0
