using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewWEB.Areas.Identity.Data;

namespace NewWEB.Models
{
    public class NewWEBContext : IdentityDbContext<NewWEBUser>
    {
        public NewWEBContext(DbContextOptions<NewWEBContext> options)
            : base(options)
        {
        }
        public DbSet<User_Login> User_Login { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User_Login>(entity =>
            {
                entity.HasKey(e => e.User_Login_ID);//主键
                entity.Property(e => e.User_Login_ID).ValueGeneratedOnAdd();//在生成的值添加

                entity.Property(e => e.User_Login_Name).HasMaxLength(20);

                entity.Property(e => e.User_Login_PassWord).HasMaxLength(20);

                entity.Property(e => e.User_Login_Right).IsRequired();//不能为空

                entity.Property(e => e.User_Login_Sex).HasMaxLength(5);

                entity.Property(e => e.User_Login_State).IsRequired();

                entity.Property(e => e.User_Login_Guid).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.User_Login_CreatDT).HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.User_Login_EmailAddress).HasColumnType("varchar(200)");

                entity.HasData(new User_Login { User_Login_ID = 1, User_Login_Name = "Administrator", User_Login_EmailAddress = "2351592225@qq.com", User_Login_PassWord = "Administrator", User_Login_Right = 0, User_Login_Sex = "男", User_Login_State = false, User_Login_Guid = Guid.NewGuid(), User_Login_CreatDT = DateTime.Now });
            });
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
