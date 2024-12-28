using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Entity
{
    public class AuthenticationResult
    {
        public bool IsSucced { get; set; }
        public string Message { get; set; }
        public int IncorrectPasswordExit { get; set; }
        public User Currentuser { get; set; }

        public AuthenticationResult(bool isSucced,string messege, int incorrectPasswordExit = 0, User currentuser = null)
        {
            IsSucced = isSucced;
            Message = messege;
            IncorrectPasswordExit = incorrectPasswordExit;
            Currentuser = currentuser;
        }
    }
}
