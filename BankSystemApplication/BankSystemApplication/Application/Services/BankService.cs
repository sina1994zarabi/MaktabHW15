using BankSystemApplication.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemApplication.Contracts.Repository;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.SqlServer.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Extensions.Internal;
using System.Collections;
using BankSystemApplication.Core.Entity;
using BankSystemApplication.Infrastructure.DAL.DTOs;

namespace BankSystemApplication.Application.Services
{
    public class BankService
    {
        ICardRepository _cardRepository;
        ITransactionRepository _transactionRepository;
        IUserRepository _userRepository;



        public BankService()
        {
            _cardRepository = new CardRepositoy();
            _transactionRepository = new TransactionRepository();
            _userRepository = new UserRepository();
        }

        public User GetDistination(string cardNumber)
        {
            return _userRepository.GetByCardNumber(cardNumber);
        }


        public string Transfer(User currentUser, string destinationCardNumber, decimal amount)
        {

            var sourceCard = _cardRepository.GetCard(currentUser.Id);

            if (string.IsNullOrWhiteSpace(destinationCardNumber))
                throw new ArgumentException("Card numbers cannot be null or empty.");
            if (destinationCardNumber.Length != 16)
                throw new ArgumentException("Invalid source or destination number." +
                    "Card Numbers Must Be Exactly 16 digits");
            if (amount <= 0)
                throw new ArgumentException("Transfer amount must be greater than zero.");
            var destinationCard = _cardRepository.GetByCardNumber(destinationCardNumber);
            if (sourceCard == null)
                throw new InvalidOperationException("Source card not found.");
            if (destinationCard == null)
                throw new InvalidOperationException("Destination card not found.");
            if (!sourceCard.IsActive)
                throw new InvalidOperationException("Source card is not active.");
            if (sourceCard.Balance < amount)
                throw new InvalidOperationException("Insufficient balance in the source card.");


            var user = GetDistination(destinationCardNumber);
            Console.WriteLine($"Destination: \n {user.Name} \n Proceed (Y/N)?");
            string confimation = Console.ReadLine();
            if (confimation == "Y")
            {

                while (true)
                {
                    VerificationService verificationService = new VerificationService();
                    string verificationCode = verificationService.GenerateCode().ToString();
                    verificationService.SaveCode(verificationCode);
                    DateTime codeGeneratedTime = DateTime.Now;
                    Console.WriteLine("Enter Verification Code: ");
                    string prompt = string.Empty;
                    while ((DateTime.Now - codeGeneratedTime).TotalMinutes < 5)
                    {
                        prompt = Console.ReadLine();
                        if (prompt == verificationCode)
                        {
                            Console.WriteLine("Verification successfull!");
                            decimal amountToWithdraw = 0;
                            if (amount > 1000) amountToWithdraw = amount * 0.015m + amount;
                            if (amount <= 1000) amountToWithdraw = amount * 0.005m + amount;




                            sourceCard.Balance -= amountToWithdraw;
                            destinationCard.Balance += amount;

                            _cardRepository.Save();

                            var transaction = new Transaction
                            {
                                SourceCardId = sourceCard.Id,
                                DestinationCardId = destinationCard.Id,
                                Amount = amount,
                                TransactionDate = DateTime.Now,
                            };

                            _transactionRepository.Add(transaction);
                            return "Successfull Transaction";
                        }
                        else
                        {
                            Console.WriteLine("Wrong Verification code. Press Any Key To Try Again");
                            Console.ReadKey();
                        }
                    }
                    Console.WriteLine("Verification Code Expired. Press Any Key To Generate A new One");
                    Console.ReadLine();
                }
            }
            else return "Transaction Cancelled";
        }



        public List<TransactionWithCardDto> GetTransactionReport(int id)
        {
            return _transactionRepository.GetAllTransaction(id);
        }


        public Card ViewAccount(int id)
        {
            return _cardRepository.GetCard(id);
        }
    }
}
