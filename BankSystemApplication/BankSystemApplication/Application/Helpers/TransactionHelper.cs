using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Application.Helpers
{
    public class TransactionHelper
    {
        private const string filePath = "\\code.txt";

        public int GenerateCode()
        {
            Random rnd = new Random();
            return rnd.Next(10000, 100000);
        }
        public void SaveCode(int code)
        {
            var timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string text = $"{timeStamp} - {code}";
            File.WriteAllText(filePath, text);
        }
    }
}
