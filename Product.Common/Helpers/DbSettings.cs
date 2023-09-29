using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Common.Helpers
{
    public class DbSettings
    {
        public string Server { get; set; } = default!;

        public string Database { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
