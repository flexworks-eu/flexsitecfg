using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace flexsitecfg.Models {
    public class BackendServer {
        [JsonPropertyName("servername")]
        public string ServerName { get; set; } = string.Empty;
        [JsonPropertyName("port")]
        public int Port { get; set; }
    }

    public class Backend {

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("backend_servers")]
        public List<BackendServer> BackendServers { get; set; } = new();
    }

    public class BackendConfig {
        public Dictionary<string, Backend> Backends { get; set; } = new();
    }
}
