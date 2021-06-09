using System.ComponentModel.DataAnnotations.Schema;

namespace Models {

    public class tblQuestaoOpcao {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int CodQuestaoOpcao { get; set; }
        public int CodQuestao { get; set; }
        public int CodOpcao { get; set; }
        public string DescOpcao { get; set; }
        public virtual tblQuestao questao  { get; set; }

    }

}