using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblProgramacion
    {
        public int Idprogramacion { get; set; }
        public string? PeriodoAcademico { get; set; }
        public int? Idprograma { get; set; }
        public string? Sala { get; set; }
        public int? Idasignatura { get; set; }
        public int? Idusuario { get; set; }

        public virtual TblAsignatura? IdasignaturaNavigation { get; set; }
        public virtual TblPrograma? IdprogramaNavigation { get; set; }
        public virtual TblUsuario? IdusuarioNavigation { get; set; }
    }
}
