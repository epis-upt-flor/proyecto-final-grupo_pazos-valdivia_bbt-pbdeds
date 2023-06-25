using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BBT_EstablecimientosDeSalud.Models.DB;

public partial class Busquedum
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string TerminoBusqueda { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public void Registrar()
    {
        try
        {
            using (var db = new Models.DB.BbtEstablecimientosDeSaludContext())
            {
                db.Entry(this).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public List<Busquedum> ListarBusqueda()
    {
        List<Busquedum> objBus = new List<Busquedum>();
        try
        {
            using (var db = new Models.DB.BbtEstablecimientosDeSaludContext())
            {
                var Bus = from datos in db.Busqueda select datos;
                objBus = Bus.ToList();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return objBus;
    }
}
