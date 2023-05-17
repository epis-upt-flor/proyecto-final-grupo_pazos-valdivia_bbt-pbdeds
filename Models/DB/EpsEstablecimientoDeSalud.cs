using System;
using System.Collections.Generic;

namespace BBT_EstablecimientosDeSalud.Models.DB;

public partial class EpsEstablecimientoDeSalud
{
    public int Id { get; set; }

    public int EpsId { get; set; }

    public int EstablecimientoId { get; set; }

    public virtual Ep Eps { get; set; } = null!;

    public virtual EstablecimientoDeSalud Establecimiento { get; set; } = null!;
}
