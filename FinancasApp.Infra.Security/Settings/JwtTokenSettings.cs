using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Security.Settings
{
    public class JwtTokenSettings
    {
        public static string SecretKey => "4CED04AE-3B8D-45B5-B28E-47D3BE3F8DED";
        public static int ExpirationInHours => 1;

    }
}
