using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemApplication.Core.Entity;
using BankSystemApplication.Infrastructure.DAL.DTOs;

namespace BankSystemApplication.Core.Contracts.Repository
{
    public interface ITransactionRepository
    {
        void Add(Transaction newTransaction);

        List<TransactionWithCardDto> GetAllTransaction(int id);

        void Update(int id, Transaction updatedTransaction);

        void Delete(int id);
    }
}
