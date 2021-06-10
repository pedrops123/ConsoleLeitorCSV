using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models {
    public class tblQuestao {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int CodQuestao { get; set; }
        public string DescQuestao { get; set; }
        [NotMapped]
        public virtual List<tblQuestaoOpcao> opcoes { get; set; }
    } 
}