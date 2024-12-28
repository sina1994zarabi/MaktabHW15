using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Infrastructure.DAL.Configurations
{
    public static class ConfigureConnection
    {
        public static string _connectionString;

        static ConfigureConnection()
        {
            _connectionString = "Server=localhost\\SQLEXPRESS;Database=BankDb;Trusted_Connection=True;Encrypt=False";
        }
    }
}
