using System.Reflection;
using System.Text;

namespace Task_2
{
    public class Test
    {
        private string _string;
        private double _data;

        public int Info { get; }

        public string Auto { get; set; }

        public double Number { get; set; }
        public int Number2 { get; set; }

        private string String { get; set; }

        // It could have been shorter, but this overload is universal to test
        // For example adding/removing fields and properties
        public override string ToString()
        {
            var builder = new StringBuilder();
            var type = typeof(Test);

            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance ;

            foreach (var fieldInfo in type.GetFields(flags))
            {
                var msg = $"{fieldInfo.Name} = {fieldInfo.GetValue(this)}";
                builder.AppendLine(msg);
            }

            foreach (var propertyInfo in type.GetProperties())
            {
                var msg = $"{propertyInfo.Name} = {propertyInfo.GetValue(this)}";
                builder.AppendLine(msg);
            }

            return builder.ToString();
        }
    }
}