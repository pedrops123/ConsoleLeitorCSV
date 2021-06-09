using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
    public class tblCliente {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int CodCliente { get; set; }
        public string DescCliente { get; set; }
        public int CodPais { get; set; }
        public string DDD { get; set; }
        public string Fone { get; set; }
        public int CodSexo { get; set; }
        public string Email { get; set; }
        public virtual tblPais pais { get; set; }
        public virtual tblSexo sexo { get; set; }
        public virtual List<tblPedido> pedidos { get; set; }
        public virtual List<tblResposta> respostas { get; set; }
    }
}