using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FlexSiteConfig.Models;

namespace FlexSiteConfig.Services {
    public static class JsonParserService {
        public static Dictionary<string, Backend> ParseConfigFile(string filePath) {

            var jsonContent = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            };

            var sString = JsonSerializer.Deserialize<Dictionary<string, Backend>>(jsonContent, options) ?? new Dictionary<string, Backend>();
            Console.WriteLine("serialized: ", sString);
            return sString;
        }
    }
}
