using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblTipoHomolo
    {
        public TblTipoHomolo()
        {
            TblHomologacions = new HashSet<TblHomologacion>();
        }

        public int IdtipoHomolo { get; set; }
        public string? TipoHomolo { get; set; }

        public virtual ICollection<TblHomologacion> TblHomologacions { get; set; }
    }
}
