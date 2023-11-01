using System;
using System.Collections.Generic;

namespace golden_wallet3.MODEL;

public partial class Conta
{
    public int Id { get; set; }

    public decimal Total { get; set; }

    public int IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<Transacao> Transacos { get; set; } = new List<Transacao>();
}
