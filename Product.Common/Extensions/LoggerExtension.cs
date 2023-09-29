using Newtonsoft.Json;
using Product.Model.CommonModel;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Product.Common.Extensions
{
    public static class LoggerExtension
    {
        /// <summary>
        ///  Generate log
        /// </summary>
        /// <param name="messageLog"></param>
        /// <param name="serviceName"></param>
        /// <param name="logEventLevel"></param>
        /// <returns></returns>
        public static string GeneratedLog(this string messageLog, string serviceName, LogEventLevel logEventLevel)
        {
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[0];
            var logModel = new LogModel
            {
                FullData = messageLog,
                Timestamp = DateTime.UtcNow.ToUnixTimeMilliseconds(),
                SourceIp = ipAddress.ToString(),
                ServiceName = serviceName,
                Level = logEventLevel.ToString(),
                CustomTimestamp = DateTime.UtcNow.AddHours(7).ToUnixTimeMilliseconds()
            };

            return JsonConvert.SerializeObject(logModel);
        }
    }
}
