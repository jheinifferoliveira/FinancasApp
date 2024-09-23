using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Settings
{
    public class SqlServerSettings
    {
        public static string ConnectionString => "Data Source=cotisqlserver.database.windows.net;Initial Catalog=bdcoti;User ID=usercoti;Password=Coti2024!;Encrypt=False";
       // public static string ConnectionString => @"Data Source=localhost,1433;User ID=sa;Password=Coti2024!;Encrypt=False";
    }
}
