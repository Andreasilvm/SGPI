using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblAsignatura
    {
        public TblAsignatura()
        {
            TblHomologacions = new HashSet<TblHomologacion>();
            TblProgramacions = new HashSet<TblProgramacion>();
        }

        public int Idasignatura { get; set; }
        public string? Nombre { get; set; }
        public string? Cod { get; set; }
        public int? Idprograma { get; set; }
        public int? Nivel { get; set; }
        public int? Credito { get; set; }

        public virtual TblPrograma? IdprogramaNavigation { get; set; }
        public virtual ICollection<TblHomologacion> TblHomologacions { get; set; }
        public virtual ICollection<TblProgramacion> TblProgramacions { get; set; }
    }
}
