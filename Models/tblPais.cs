using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
    public class tblPais{
        
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int CodPais { get; set; }
        public string DescPais { get; set; }
        [NotMapped]
        public virtual List<tblCliente> clientes { get; set; }
    }
}