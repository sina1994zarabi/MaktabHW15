using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankSystemApplication.Core.Entity;

namespace BankSystemApplication.Configurations
{
    public class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey( x => x.Id);
            builder.HasOne( x => x.User).WithMany(x=>x.Cards).HasForeignKey(x=>x.UserId);

            builder.HasData(new Card
            {
                Id = 1,
                CardNumber = "5859831033589507",
                UserId = 1,
                Passsword = "1234",
                Balance = 1000.00m,
            },
            new Card
            {
                Id=2,
                CardNumber = "1111222233334444",
                UserId = 2,
                Passsword = "5678",
                Balance = 100000.00m,
            }
            );
        }
    }
}
