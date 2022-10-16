using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblPrograma
    {
        public TblPrograma()
        {
            TblAsignaturas = new HashSet<TblAsignatura>();
            TblHomologacions = new HashSet<TblHomologacion>();
            TblProgramacions = new HashSet<TblProgramacion>();
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int Idprograma { get; set; }
        public string? Programa { get; set; }

        public virtual ICollection<TblAsignatura> TblAsignaturas { get; set; }
        public virtual ICollection<TblHomologacion> TblHomologacions { get; set; }
        public virtual ICollection<TblProgramacion> TblProgramacions { get; set; }
        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
