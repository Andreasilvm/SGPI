using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblGenero
    {
        public TblGenero()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int Idgenero { get; set; }
        public string? Genero { get; set; }

        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
