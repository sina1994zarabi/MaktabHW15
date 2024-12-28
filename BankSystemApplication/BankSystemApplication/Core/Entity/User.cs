using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Entity
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(16,MinimumLength = 8)]
        public string Password { get; set; }
        public int FailedLoginAttempts { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public DateTime? LockTime { get; set; }

        // navigation property
        public List<Card> Cards { get; set; }

    }
}
