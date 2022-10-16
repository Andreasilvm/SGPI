using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblPago
    {
        public TblPago()
        {
            TblEstudiantes = new HashSet<TblEstudiante>();
        }

        public int IdPagos { get; set; }
        public int? ValorPago { get; set; }
        public DateTime? Fecha { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<TblEstudiante> TblEstudiantes { get; set; }
    }
}
