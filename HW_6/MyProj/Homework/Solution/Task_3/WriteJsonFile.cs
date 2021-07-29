using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Task_3
{
    public static class WriteJsonFile // Class for writing data
    {
        public static void Write(IEnumerable<object> data, string fileName, string destination)
        {
            if (!Directory.Exists(destination)) throw new DirectoryNotFoundException(nameof(Directory));

            if (!File.Exists(@$"{destination}\{fileName}")) File.Delete(@$"{destination}\{fileName}");

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };

            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(@$"{destination}\{fileName}", json);
        }
    }
}
