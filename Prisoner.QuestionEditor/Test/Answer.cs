using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prisoner.Test
{
    
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public string Text { get; set; }
        public int? NextQuestionId { get; set; }
        public virtual Question NextQuestion { get; set; }
        public int? Result { get; set; }
        public string ResultText { get; set; }
    }
}
