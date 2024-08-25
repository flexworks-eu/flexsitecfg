using System.Collections.Generic;
using System.Text;
using flexsitecfg.Models;

namespace flexsitecfg.Services {
    public static class NginxConfigGenerator {
        public static string GenerateConfig(Dictionary<string, Backend> backends) {
            var sb = new StringBuilder();

            foreach (var backend in backends) {
                Console.WriteLine($"Backend ID: {backend.Key}");
                Console.WriteLine($"Description: {backend.Value.Description}");
                sb.AppendLine($"# {backend.Value.Description}");
                sb.AppendLine($"upstream {backend.Key} {{");
                foreach (var server in backend.Value.BackendServers)
                {
                    sb.AppendLine($"    server {server.ServerName}:{server.Port};");
                }
                sb.AppendLine("}");
                sb.AppendLine(); // Add an extra line between upstream blocks
            }

            return sb.ToString();
        }
    }
}
