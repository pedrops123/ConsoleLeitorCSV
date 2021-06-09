using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models{
    public class tblResposta{
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int CodResposta { get; set; }
        public int CodCliente { get; set; }
        public int CodQuestaoOpcao { get; set; }

        public virtual tblCliente cliente { get; set; }
        public virtual tblQuestaoOpcao opcao { get; set; }
        public virtual List<tblResposta> respostas {get;set;}
    }    
}