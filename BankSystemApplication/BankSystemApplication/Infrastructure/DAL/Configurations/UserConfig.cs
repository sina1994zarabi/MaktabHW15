using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankSystemApplication.Core.Entity;

namespace BankSystemApplication.DAL.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Cards).WithOne(x => x.User);
            builder.ToTable("Customers");

            builder.HasData(new User
            {
                Id = 1,
                Name = "User1Name",
                Email = "User1Email@gmail.com",
                Username = "User1IdNumber",
                Password = "User1Pass"
            },
                            new User
                            {
                                Id = 2,
                                Name = "User2Name",
                                Email = "User2Email@gmail.com",
                                Username = "User2IdNumber",
                                Password = "User2Pass"
                            });
        }
    }
}
