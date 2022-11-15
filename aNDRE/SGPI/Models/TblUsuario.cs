using System;
using System.Collections.Generic;

namespace SGPI.Models
{
    public partial class TblUsuario
    {
        public TblUsuario()
        {
            TblEntrevista = new HashSet<TblEntrevistum>();
            TblEstudiantes = new HashSet<TblEstudiante>();
            TblProgramacions = new HashSet<TblProgramacion>();
        }

        public int Idusuario { get; set; }
        public string? NumeroDocumento { get; set; }
        public int? Iddoc { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public int? Idgenero { get; set; }
        public string? Email { get; set; }
        public int? Idrol { get; set; }
        public string? VcPassword { get; set; }
        public int? Idprograma { get; set; }

        public virtual TblTipoDocumento? IddocNavigation { get; set; }
        public virtual TblGenero? IdgeneroNavigation { get; set; }
        public virtual TblPrograma? IdprogramaNavigation { get; set; }
        public virtual TblRol? IdrolNavigation { get; set; }
        public virtual ICollection<TblEntrevistum> TblEntrevista { get; set; }
        public virtual ICollection<TblEstudiante> TblEstudiantes { get; set; }
        public virtual ICollection<TblProgramacion> TblProgramacions { get; set; }
    }
}
