using System;

public struct Key: IComparable
{
    public Octave Octave { private set; get; }
    public Note Note { private set; get; }
    public Accidental Accidental { private set; get; }
    public Key(Octave octave, Note note, Accidental accidental = Accidental.WhithoutSign)
    {
        Octave = octave > Octave.Fiveth || octave < Octave.Subcontra ? throw new ArgumentOutOfRangeException() : octave;
        Note = note > Note.B || note < Note.C ? throw new ArgumentOutOfRangeException() : note;
        Accidental = accidental > Accidental.Flat || accidental < Accidental.WhithoutSign? throw new ArgumentOutOfRangeException() : accidental;
    }
    public int CompareTo(object obj)
    {
        if (obj is Key key) return (ValueOfKey() - key.ValueOfKey());
        else throw new ArgumentException();
    }
    public override bool Equals(object obj)  
    {
        if (obj is Key key) return (ValueOfKey() == key.ValueOfKey());
        else return false; 
    }
    private int ValueOfKey() // Value of note 
    {
        if (!isKeyEmpty())
        {
            double value = (int)Note;
            var k = (int)Octave;

            if (Note == Note.C && Accidental == Accidental.Flat)
            {
                k--;
                value = (int)Note.B + 0.5;
            }
            else
            {
                if (Note == Note.E && Accidental == Accidental.Sharp) value++;
                else
                {
                    if (Note == Note.F && Accidental == Accidental.Flat) value--;
                    else
                    {
                        if (Accidental == Accidental.Sharp) value += 0.5;
                        if (Accidental == Accidental.Flat) value -= 0.5;
                    }
                }
            }
            return (int)value * k * 10;
        }
        return -1;
    }
    public override string ToString()
    {
        if (!isKeyEmpty())
        {
            string str = Accidental == Accidental.Sharp ? "#" : Accidental == Accidental.Flat ? "b" : string.Empty;
            return $"{Note}{str}";
        }
        else return string.Empty;
    }
    private bool isKeyEmpty() =>
    Octave.ToString() == "_" || Note.ToString() == "_" || Accidental.ToString() == "_";
}

