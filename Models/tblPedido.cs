using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
    public class tblPedido {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int CodPedido { get; set; }
        public int CodCliente { get; set; }
        public int QtdPedidos { get; set; }
        public virtual tblCliente cliente { get; set; }
    }
}