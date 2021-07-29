using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Task_2
{
    public class TextRepository
    {
        public static async Task<Entities> LoadEntities(string path)
        {
            var lines = await File.ReadAllLinesAsync(path);

            var entities = lines.Select(l => l.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)).AsParallel()
                .Select(split => new Entity
                {
                    Name = split[0],
                    Position = (double.Parse(split[1].Replace(".", ",")), double.Parse(split[2].Replace(".", ",")))
                });

            return new Entities(entities);
        }

        public static bool IsFileExistOrNotEmpty(string path)
        {
            return File.Exists(path) && new FileInfo(path).Length > 0;
        }
    }
}