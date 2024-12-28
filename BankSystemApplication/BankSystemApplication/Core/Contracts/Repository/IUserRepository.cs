using BankSystemApplication.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Core.Contracts.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetById(int id);
        User GetByUsername(string username);
        User GetByCardNumber(string cardNumber);
        void Update(int id, User newUser);
        void Delete(int id);
        void Save();
    }
}
