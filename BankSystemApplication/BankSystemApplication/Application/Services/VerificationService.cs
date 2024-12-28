using BankSystemApplication.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemApplication.Entity;

namespace BankSystemApplication.Application.Services
{
    public class VerificationService
    {

        private const string filePath = "C:\\Users\\dell\\Desktop\\BackEnd Development\\ASP.NET Developer\\BackEnd C Sharp\\Mini Projects\\9- BankSystemApplication\\BankSystemApplication\\code.txt";

        public int GenerateCode()
        {
            Random random = new Random();
            return random.Next(10000, 100000);
        }

        public void SaveCode(string code)
        {
            string messege = $"Verification Code: {code} - Date: {DateTime.Now}\n";
            File.WriteAllText(filePath, messege);
        }
    }
}
