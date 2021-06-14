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

        // Campos incluidos no exercicio 1 - ASP.NET C# - 14/06 - Pedro Furlan
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        
        [NotMapped]
        public virtual tblPais pais { get; set; }
        [NotMapped]
        public virtual tblSexo sexo { get; set; }
        [NotMapped]
        public virtual List<tblPedido> pedidos { get; set; }
        [NotMapped]
        public virtual List<tblResposta> respostas { get; set; }
    }
}