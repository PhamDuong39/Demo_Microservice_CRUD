using Product.Model.Options;
using Serilog.Core;
using Serilog.Events;
using Serilog;

namespace Product.CoreAPI.RegisterModules
{
    public class SerilogRegister
    {
        public static void Initialize(IConfigurationRoot configuration)
        {
            var logModelOption = configuration.GetSection(LogOption.Position).Get<LogOption>();

            if (logModelOption?.File?.Path == null || logModelOption.Kafka == null)
                throw new Exception("Has not define log information yet!!!");

            var levelSwitch = new LoggingLevelSwitch();


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    logModelOption.File.Path,
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();

            if (logModelOption.LogLevel?.SwitchLevelLog != null &&
                Enum.TryParse<LogEventLevel>(logModelOption.LogLevel.SwitchLevelLog, out var level))
                levelSwitch.MinimumLevel = level;

            LoggerFactory
                .Create(builder => builder.AddSerilog(dispose: true));
        }
    }
}
