using System.Collections.Generic;
using System.Text;
using FlexSiteConfig.Models;


namespace FlexSiteConfig.Services {
    public static class NginxConfigGenerator {
        public static string GenerateConfig(Dictionary<string, Backend> backends) {
            var sb = new StringBuilder();
            var backendServerBlock = new StringBuilder();
            backendServerBlock.AppendLine("upstream backend_servers {");

            foreach (var backend in backends) {
                Console.WriteLine($"Backend ID: {backend.Key}");
                Console.WriteLine($"Description: {backend.Value.Description}");
                sb.AppendLine($"# {backend.Value.Description}");
                sb.AppendLine($"upstream {backend.Key} {{");
                foreach (var server in backend.Value.BackendServers)
                {
                    sb.AppendLine($"    server {server.ServerName}:{server.Port}  max_fails=3 fail_timeout=30;");
                    backendServerBlock.AppendLine($"    server {server.ServerName}:{server.Port} max_fails=3 fail_timeout=30s;");
                }
                sb.AppendLine("}");
                sb.AppendLine(); 
            }

            backendServerBlock.AppendLine("}");
            sb.AppendLine(backendServerBlock.ToString());
            sb.AppendLine(); 
            return sb.ToString();
        }
    }
}
