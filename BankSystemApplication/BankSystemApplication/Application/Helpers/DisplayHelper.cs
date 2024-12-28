using BankSystemApplication.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BankSystemApplication.Infrastructure.DAL.DTOs;

namespace BankSystemApplication.Application.Helpers
{
    public class DisplayHelper
    {
        public void DisplayTransactionHistory(List<TransactionWithCardDto> transactionWithCards)
        {
            foreach (var transaction in transactionWithCards)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId}");
                Console.WriteLine($"Source Card Number: {transaction.SourceCardNumber}");
                Console.WriteLine($"Destination Card Number: {transaction.DestinationCardNumber}");
                Console.WriteLine($"Amount: {transaction.Amount}");
                Console.WriteLine($"Date: {transaction.TransactionDate}");
                Console.WriteLine($"Successful: {transaction.IsSuccessful}");
                Console.WriteLine("---------------");
            }
        }
    }
}
