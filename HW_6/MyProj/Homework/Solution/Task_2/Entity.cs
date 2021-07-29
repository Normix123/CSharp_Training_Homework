namespace Task_2
{
    public class Entity
    {
        public string Name { get; set; }

        public (double, double) Position { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Position.Item1} {Position.Item2})";
        }
    }
}