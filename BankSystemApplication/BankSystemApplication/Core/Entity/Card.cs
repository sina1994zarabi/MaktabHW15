using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Entity
{
    public class Card
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 16)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string Passsword { get; set; }
        [Required]
        [Range(50,double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public bool IsActive { get; set; } = true;

        // ForeignKey Property
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        // navigation property
        public List<Transaction> SourceTransactions { get; set; }
        public List<Transaction> DestTransactions { get; set; }
    }
}
