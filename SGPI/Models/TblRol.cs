using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblRol
    {
        public TblRol()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int Idrol { get; set; }
        public string? Rol { get; set; }

        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
