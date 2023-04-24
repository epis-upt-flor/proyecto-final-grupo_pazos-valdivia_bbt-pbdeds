using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BBT_Plataforma_Establecimientos_De_Salud.Models;
using BBT_Plataforma_Establecimientos_De_Salud.Models.DB;

namespace BBT_Plataforma_Establecimientos_De_Salud.ViewModel
{
    public class EstablecimientoDeSaludViewModel
    {
        public EstablecimientoDeSalud estSalud { get; set; }
        public Valoracion valoracion { get; set; }
        public List<Valoracion> listValoracion { get; set; }
        public int TotalValoraciones { get; set; }
    }
}