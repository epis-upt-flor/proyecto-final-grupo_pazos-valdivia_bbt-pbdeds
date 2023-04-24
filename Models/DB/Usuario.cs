using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BBT_Plataforma_Establecimientos_De_Salud.Models.DB;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? Imagen { get; set; }

    public virtual ICollection<Busquedum> Busqueda { get; set; } = new List<Busquedum>();

    public virtual ICollection<Valoracion> Valoracions { get; set; } = new List<Valoracion>();
    //Metodos
    //Registrar
    public void Registrar()
    {
        try
        {
            using (var db = new Models.DB.BbtEstablecimientosDeSaludContext())
            {
                if (this.Id > 0)
                {
                    db.Entry(this).State = EntityState.Modified;
                }
                else
                {
                    db.Entry(this).State = EntityState.Added;
                }
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    //Login
    public Usuario Login(string user, string pass)
    {
        Usuario usuario = new Usuario();
        try
        {
            using (var db = new Models.DB.BbtEstablecimientosDeSaludContext())
            {
                var usuarios = from datos in db.Usuarios select datos;
                usuario = usuarios.Where(u => u.Email == user && u.Contrasena == pass).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        return usuario;
    }
}
