using System;

public sealed class Segment
{
    private readonly int[] _coordinates;            

    public Segment(int a = 0, int b = 0)
    {
        if (a > b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        _coordinates = new[] { a, b };
    }

    public int Lenght => _coordinates[1] - _coordinates[0];

    public int Left
    { 
        get => _coordinates[0]; 
    }

    public int Right
    {
        get => _coordinates[1];
    }

    public override bool Equals(object obj)
    {
        if (!(obj is  Segment s) || s._coordinates.Length != _coordinates.Length)
        {
            return false;
        }

        for (var i = 0; i < _coordinates.Length; i++)
        {
            if (_coordinates[i] != s._coordinates[i])
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode() 
    {
        unchecked
        {
            var hash = 0;

            foreach (var element in _coordinates)
                hash += element;

            return hash.GetHashCode();
        }
    }

    public override string ToString() =>
    $"a = {_coordinates[0]}\t b = {_coordinates[1]}";

    public static Segment operator + (Segment a, Segment b)  => new Segment(a.Left + b.Left, a.Right + b.Right );

    public static explicit operator uint (Segment segment) => (uint)segment.Lenght;

    public static implicit operator (int a, int b) (Segment segment) => (segment.Left, segment.Right);
}


