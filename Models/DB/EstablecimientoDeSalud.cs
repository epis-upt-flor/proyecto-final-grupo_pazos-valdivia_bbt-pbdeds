using System;
using System.Collections.Generic;

namespace BBT_EstablecimientosDeSalud.Models.DB;

public partial class EstablecimientoDeSalud
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public decimal Longitud { get; set; }

    public decimal Latitud { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<EpsEstablecimientoDeSalud> EpsEstablecimientoDeSaluds { get; set; } = new List<EpsEstablecimientoDeSalud>();

    public List<EstablecimientoDeSalud> Buscar(string criterio)
    {
        List<EstablecimientoDeSalud> ListEst = new List<EstablecimientoDeSalud>();
        try
        {
            using (var db = new Models.DB.BbtEstablecimientosDeSaludContext())
            {
                var EstSalud = from datos in db.EstablecimientoDeSaluds select datos;
                ListEst = EstSalud.Where(e => e.Nombre.ToLower().Contains(criterio.ToLower()) || e.Descripcion.ToLower().Contains(criterio.ToLower())).ToList();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return ListEst;
    }
    public EstablecimientoDeSalud BuscarId(int EstId)
    {
        EstablecimientoDeSalud objEst = new EstablecimientoDeSalud();
        try
        {
            using (var db = new Models.DB.BbtEstablecimientosDeSaludContext())
            {
                var EstSalud = from datos in db.EstablecimientoDeSaluds select datos;
                objEst = EstSalud.Where(e => e.Id == EstId).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return objEst;
    }
    public List<EstablecimientoDeSalud> Listar()
    {
        List<EstablecimientoDeSalud> objEst = new List<EstablecimientoDeSalud>();
        try
        {
            using (var db = new Models.DB.BbtEstablecimientosDeSaludContext())
            {
                var EstSalud = from datos in db.EstablecimientoDeSaluds select datos;
                objEst = EstSalud.ToList();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return objEst;
    }
}
