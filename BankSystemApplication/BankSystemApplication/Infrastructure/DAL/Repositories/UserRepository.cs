using BankSystemApplication.Contracts.Repository;
using BankSystemApplication.Core.Entity;
using BankSystemApplication.Infrastructure.DAL.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Infrastructure.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _dbContext = new AppDbContext();

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public User GetByCardNumber(string cardNumber)
        {
            return _dbContext.Users
                             .Include(x => x.Cards)
                             .Where(x => x.Cards.Any(card => card.CardNumber == cardNumber))
                             .FirstOrDefault();
        }



        public User GetById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Username == username);
        }

        public void Update(int id, User updatedUser)
        {
            var userToUpdate = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            userToUpdate.Name = updatedUser.Name;
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.Password = updatedUser.Password;
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
