using System.Collections.Generic;
using System.Text;
using FlexSiteConfig.Models;


// upstream backend_servers {
//     server 192.168.0.2:3001 max_fails=3 fail_timeout=30s;
// #    server 192.168.0.198:3001 max_fails=3 fail_timeout=30s;
//     server 192.168.0.15:3002 max_fails=3 fail_timeout=30s;
//     server 192.168.0.246:3005 max_fails=3 fail_timeout=30s;
//     server 192.168.0.246:4001 max_fails=3 fail_timeout=30s;
//     server 192.168.0.15:4000 max_fails=3 fail_timeout=30s;
//     server 192.168.0.15:3003 max_fails=3 fail_timeout=30s;
// }


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
                    sb.AppendLine($"    server {server.ServerName}:{server.Port};");
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
