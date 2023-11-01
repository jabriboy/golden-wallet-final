using golden_wallet3.MODEL;
using golden_wallet3.DAL.DBContext;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golden_wallet3.BLL.repositories
{
    public class ContaRepository
    {
        public static void Add(Conta _conta)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Add(_conta);
                dbContext.SaveChanges();
                Console.WriteLine("add conta");
            }
        }
        public static Conta GetByid(int id)
        {
            using (var dbContext = new DbContext())
            {
                var conta = dbContext.Contas.FirstOrDefault(u => u.Id == id);
                return conta;
            }
        }

        public static List<Conta> GetAll()
        {
            using (var dbContext = new DbContext())
            {
                var conta = dbContext.Contas.ToList();
                return conta;
            }
        }

        public static void Update(Conta _conta)
        {
            using (var dbContext = new DbContext())
            {
                var conta = dbContext.Contas.Single(u => u.Id == _conta.Id);
                conta.Total = _conta.Total;
                dbContext.SaveChanges();
            }
        }

        public static void UpdateTotal(Transacao _transaction)
        {
            using (var dbContext = new DbContext())
            {
                var conta = dbContext.Contas.Single(u => u.Id == _transaction.IdConta);
                if (_transaction.Tipo == "renda")
                {
                    conta.Total += _transaction.Valor;
                }
                else
                {
                    conta.Total -= _transaction.Valor;
                }
                dbContext.SaveChanges();
                Console.WriteLine("update total");
            }
        }

        public static void Delete(Conta _conta)
        {
            using (var dbContext = new DbContext())
            {
                var conta = dbContext.Contas.Single(u => u.Id == _conta.Id);
                dbContext.Contas.Remove(conta);
                dbContext.SaveChanges();
            }
        }
    }
}
