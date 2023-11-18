using System;
using System.Collections.Generic;

namespace moseros.Models;

public partial class Mosa
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Edad { get; set; }

    public string? Algo { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<RelacionAmanteMosa> RelacionAmanteMosas { get; set; } = new List<RelacionAmanteMosa>();
}
