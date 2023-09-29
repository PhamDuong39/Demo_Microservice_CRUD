using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Model.Options
{
    public class LogOption
    {
        /// <summary>
        ///    Position in appsettings.json
        /// </summary>
        public const string Position = "Logging";

        public LogLevel? LogLevel { get; set; }

        /// <summary>
        ///     File options
        /// </summary>
        public File? File { get; set; }

        public Kafka? Kafka { get; set; }
    }

    public class LogLevel
    {
        public string? Default { get; set; }
        public string? Microsoft { get; set; }
        public string? SwitchLevelLog { get; set; }
    }

    public class File
    {
        public string? Path { get; set; }
    }

    public class Kafka
    {
        public string? BootstrapServers { get; set; }
        public string? Topic { get; set; }
    }
}
