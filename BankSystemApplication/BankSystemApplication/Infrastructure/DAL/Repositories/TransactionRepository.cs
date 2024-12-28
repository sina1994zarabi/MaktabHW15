using BankSystemApplication.Core.Contracts.Repository;
using BankSystemApplication.Core.Entity;
using BankSystemApplication.DAL.DataBase;
using BankSystemApplication.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        AppDbContext _dbContext = new AppDbContext();

        public void Add(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var transactionsToDelete = _dbContext.Transactions.Where(t => t.Id == id);
            _dbContext.RemoveRange(transactionsToDelete);
            _dbContext.SaveChanges();
        }

        public List<TransactionWithCardDto> GetAllTransaction(int id)
        {
            return _dbContext.Transactions.Select( t => new TransactionWithCardDto
            {
                                                   TransactionId = t.Id,
                                                   SourceCardNumber = t.SourceCard.CardNumber,
                                                   DestinationCardNumber = t.DestinationCard.CardNumber,
                                                   Amount = t.Amount,
                                                   TransactionDate = t.TransactionDate,
                                                   IsSuccessful = t.IsSucced}).ToList();
        }

        public void Update(int id,Transaction updatedTransaction)
        {
            var transactionToUpdate = _dbContext.Transactions.FirstOrDefault( t=> t.Id == id);
            if (transactionToUpdate != null)
            {
                transactionToUpdate.SourceCardId = updatedTransaction.SourceCardId;
                transactionToUpdate.DestinationCardId = updatedTransaction.DestinationCardId;
                transactionToUpdate.TransactionDate = updatedTransaction.TransactionDate;
                transactionToUpdate.Amount = updatedTransaction.Amount;
                transactionToUpdate.IsSucced = updatedTransaction.IsSucced;
                _dbContext.SaveChanges();
            }
        }
    }
}
