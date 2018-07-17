using Microsoft.EntityFrameworkCore;
using NewWEBAPI.Interfaces;
using NewWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NewWEBAPI.ServiceLogic
{
    [Category("用户表接口 实现业务逻辑")]
    public class User_LoginRepository : IUser_LoginRepository
    {
        private NewWEBContext context;
        public User_LoginRepository(NewWEBContext _context)
        {
            context = _context;
        }
        public Task AddAsync(User_Login user_Login)
        {
            context.User_Login.Add(user_Login);
            return context.SaveChangesAsync();
        }

        public Task<User_Login> GetByIdAsync(int id)
        {
            return context.User_Login.FirstOrDefaultAsync(x => x.User_Login_ID == id);
        }

        public Task<List<User_Login>> ListAsync()
        {
            return context.User_Login.ToListAsync();
        }

        public Task UpdateAsync(User_Login user_Login)
        {
            context.Entry(user_Login).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }
    }
}
