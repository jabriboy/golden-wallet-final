using System;
using System.Collections.Generic;

namespace golden_wallet3.MODEL;

public partial class Transacao
{
    public int Id { get; set; }

    public decimal Valor { get; set; }

    public string Tipo { get; set; } = null!;

    public int IdConta { get; set; }

    public virtual Conta IdContaNavigation { get; set; } = null!;
}
