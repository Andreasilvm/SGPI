using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblTipoDocumento
    {
        public TblTipoDocumento()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int Iddoc { get; set; }
        public string? TipoDocumento { get; set; }

        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
