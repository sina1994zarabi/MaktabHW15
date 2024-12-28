using BankSystemApplication.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemApplication.Configurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SourceCard).
                WithMany(x => x.SourceTransactions).
                HasForeignKey(x => x.SourceCardId).
                OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.DestinationCard).
                WithMany(x => x.DestTransactions).
                HasForeignKey(x => x.DestinationCardId).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
