using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblEstudiante
    {
        public TblEstudiante()
        {
            TblEntrevista = new HashSet<TblEntrevistum>();
            TblHomologacions = new HashSet<TblHomologacion>();
        }

        public int Idestudiante { get; set; }
        public string? Archivo { get; set; }
        public int? Idpago { get; set; }
        public int? Idusuario { get; set; }
        public bool? Egresado { get; set; }

        public virtual TblPago? IdpagoNavigation { get; set; }
        public virtual TblUsuario? IdusuarioNavigation { get; set; }
        public virtual ICollection<TblEntrevistum> TblEntrevista { get; set; }
        public virtual ICollection<TblHomologacion> TblHomologacions { get; set; }
    }
}
