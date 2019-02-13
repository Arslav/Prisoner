using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prisoner.Test
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int? State { get; set; }
        public string Picture { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
