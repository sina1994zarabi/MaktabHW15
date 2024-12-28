using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Entity
{

    public class Transaction
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SourceCardId { get; set; }
        public Card SourceCard { get; set; }
        [Required]
        public int DestinationCardId { get; set; }
        public Card DestinationCard { get; set; }
        [Required]
        [Range(50, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public bool IsSucced { get; set; } = true;
    }
}
