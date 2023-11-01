using golden_wallet3.BLL.repositories;
using golden_wallet3.MODEL;

User user1 = new User();
Conta conta1 = new Conta();
Transacao transacao1 = new Transacao();

user1.Nome = "thiago";
user1.Senha = "123456";
user1.Id = UserRepository.GetAll().Count();
/*UserRepository.Add(user1);*/

conta1.Total = (decimal)0.0;
conta1.IdUser = user1.Id;
conta1.Id = ContaRepository.GetAll().Count();
/*ContaRepository.Add(conta1);*/

transacao1.Valor = (decimal)15000.0;
transacao1.Tipo = "renda";
transacao1.IdConta = conta1.Id;
transacao1.Id = TransacaoRepository.GetAll().Count();
/*TransacaoRepository.Add(transacao1);*/


/*foreach (User u in UserRepository.GetAll())
{
    Console.WriteLine(u.Nome);
}*/

foreach (Conta conta in ContaRepository.GetAll())
{
    Console.WriteLine(UserRepository.GetByid(conta.IdUser).Nome+" possui: R$"+conta.Total);
}

Console.WriteLine("final");
