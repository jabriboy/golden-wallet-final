using System;
using System.Collections.Generic;

namespace golden_wallet3.MODEL;

public partial class User
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual ICollection<Conta> Conta { get; set; } = new List<Conta>();
}
