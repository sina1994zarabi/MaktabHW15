using BankSystemApplication.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystemApplication.Contracts.Repository;
using BankSystemApplication.DAL.DataBase;
using BankSystemApplication.Contracts.Services;
using BankSystemApplication.Core.Entity;

namespace BankSystemApplication.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        ICardRepository _cardRepository;
        IUserRepository _userRepository;

        public AuthenticationService()
        {
            _cardRepository = new CardRepositoy();
            _userRepository = new UserRepository();
        }


        public AuthenticationResult Login(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    if (user.IsLocked)
                    {
                        if (user.LockTime.Value.AddMinutes(15) > DateTime.Now)
                            return new AuthenticationResult(true, "Successfully logged In", currentuser: user);
                        else return new AuthenticationResult(false, "You Are Temporarily Locked");
                    }
                    else
                    {
                        user.FailedLoginAttempts = 0;
                        _userRepository.Save();
                        return new AuthenticationResult(true, "Successfully logged In", currentuser: user);
                    }
                }
                else
                {
                    user.FailedLoginAttempts++;
                    if (user.FailedLoginAttempts == 3)
                    {
                        user.IsLocked = true;
                        user.LockTime = DateTime.Now;
                        _userRepository.Save();
                        return new AuthenticationResult(false, "Try Logging In Again After 15 minutes");
                    }
                    return new AuthenticationResult(false, "Incorrect Password");
                }
            }
            else return new AuthenticationResult(false, "User Not Found");
        }
    }
}
