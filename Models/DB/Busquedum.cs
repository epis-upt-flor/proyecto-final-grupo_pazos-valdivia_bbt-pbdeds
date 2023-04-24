using System;
using System.Collections.Generic;

namespace BBT_Plataforma_Establecimientos_De_Salud.Models.DB;

public partial class Busquedum
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int EstablecimientoId { get; set; }

    public string TerminoBusqueda { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual EstablecimientoDeSalud Establecimiento { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
