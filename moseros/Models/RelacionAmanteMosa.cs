using System;
using System.Collections.Generic;

namespace moseros.Models;

public partial class RelacionAmanteMosa
{
    public int Id { get; set; }

    public int? IdAmamte { get; set; }

    public int? IdMosa { get; set; }

    public virtual Amante? IdAmamteNavigation { get; set; }

    public virtual Mosa? IdMosaNavigation { get; set; }
}
