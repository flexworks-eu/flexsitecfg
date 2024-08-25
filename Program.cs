using FlexSiteConfig.Services;

namespace FlexSiteConfig {
    class Program {
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Usage: FlexSiteConfig --config <path_to_json> --output <path_to_nginx_config>");
                return;
            }

            string? configFilePath = null;
            string? outputFilePath = null;

            // named arguments
            for (int i = 0; i < args.Length; i++) {
                switch (args[i]) {
                    case "--config":
                        if (i + 1 < args.Length) {
                            configFilePath = args[++i];
                        }
                        break;
                    case "--output":
                        if (i + 1 < args.Length) {
                            outputFilePath = args[++i];
                        }
                        break;
                }
            }

            if (configFilePath == null || outputFilePath == null) {
                Console.WriteLine("Please provide both --config and --output arguments.");
                return;
            }

            try {
                var upstreamConfigs = JsonParserService.ParseConfigFile(configFilePath);
                var nginxConfig = NginxConfigGenerator.GenerateConfig(upstreamConfigs);
                
                File.WriteAllText(outputFilePath, nginxConfig);
                
                Console.WriteLine($"NGINX config generated and saved to: {outputFilePath}");
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}