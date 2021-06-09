using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
    public class tblSexo {
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int CodSexo { get; set; }
        public string DescSexo { get; set; }

        public virtual List<tblCliente> clientes {get;set;}
    }
}