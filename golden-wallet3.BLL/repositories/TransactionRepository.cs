using golden_wallet3.MODEL;
using golden_wallet3.DAL.DBContext;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golden_wallet3.BLL.repositories
{
    public class TransacaoRepository
    {
        public static void Add(Transacao _Transacao)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Add(_Transacao);
                ContaRepository.UpdateTotal(_Transacao);
                dbContext.SaveChanges();
                Console.WriteLine("adicionou transacao");
            }
        }
        public static Transacao GetByid(int id)
        {
            using (var dbContext = new DbContext())
            {
                var Transacao = dbContext.Transacoes.FirstOrDefault(u => u.Id == id);
                return Transacao;
            }
        }

        public static List<Transacao> GetAll()
        {
            using (var dbContext = new DbContext())
            {
                var Transacao = dbContext.Transacoes.ToList();
                return Transacao;
            }
        }

        public static void Update(Transacao _Transacao)
        {
            using (var dbContext = new DbContext())
            {
                var Transacao = dbContext.Transacoes.Single(u => u.Id == _Transacao.Id);
                Transacao.Tipo = _Transacao.Tipo;
                Transacao.Valor = _Transacao.Valor;
                dbContext.SaveChanges();
            }
        }

        public static void Delete(Transacao _Transacao)
        {
            using (var dbContext = new DbContext())
            {
                var Transacao = dbContext.Transacoes.Single(u => u.Id == _Transacao.Id);
                dbContext.Transacoes.Remove(Transacao);
                dbContext.SaveChanges();
            }
        }
    }
}
