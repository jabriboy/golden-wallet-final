using golden_wallet3.MODEL;
using golden_wallet3.DAL.DBContext;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golden_wallet3.BLL.repositories
{
    public class UserRepository
    {
        public static void Add(User _user)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Add(_user);
                dbContext.SaveChanges();
                Console.WriteLine("adicionou usuario");
            }
        }
        public static User GetByid(int id)
        {
            using (var dbContext = new DbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Id == id);
                return user;
            }
        }

        public static List<User> GetAll()
        {
            using (var dbContext = new DbContext())
            {
                var User = dbContext.Users.ToList();
                return User;
            }
        }

        public static void Update(User _user)
        {
            using (var dbContext = new DbContext())
            {
                var user = dbContext.Users.Single(u => u.Id == _user.Id);
                user.Nome = _user.Nome;
                user.Senha = _user.Senha;
                dbContext.SaveChanges();
            }
        }

        public static void Delete(User _user)
        {
            using (var dbContext = new DbContext())
            {
                var user = dbContext.Users.Single(u => u.Id == _user.Id);
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }
    }
}
