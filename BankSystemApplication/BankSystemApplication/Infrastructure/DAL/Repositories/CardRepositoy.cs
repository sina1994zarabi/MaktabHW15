using BankSystemApplication.Core.Contracts.Repository;
using BankSystemApplication.Core.Entity;
using BankSystemApplication.DAL;
using BankSystemApplication.DAL.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.DAL.Repositories
{
    public class CardRepositoy : ICardRepository
    {
        AppDbContext _dbContext = new AppDbContext();
        

        public void Add(Card newCard)
        {
            _dbContext.Cards.Add(newCard);
            _dbContext.SaveChanges();
        }

        public Card GetCard(int id)
        {
            return _dbContext.Cards.FirstOrDefault(c => c.Id == id);
        }




        public void UpdateCard(int cardNumberId, Card updatedCard)
        {
            var cardToUpdate = _dbContext.Cards.FirstOrDefault(c => c.Id == cardNumberId);
            if (cardToUpdate != null)
            {
                cardToUpdate.CardNumber = updatedCard.CardNumber;
                cardToUpdate.Balance = updatedCard.Balance;
                cardToUpdate.IsActive = updatedCard.IsActive;
            }
        }

        public void DeleteCard(int id)
        {
            var cardToDelete = _dbContext.Cards.FirstOrDefault(c => c.Id == id);
            _dbContext.Remove(cardToDelete);
            _dbContext.SaveChanges();
        }

        public Card GetByCardNumber(string cardNumber)
        {
            return _dbContext.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
        }

        public void Save() { _dbContext.SaveChanges(); }

    }
}
