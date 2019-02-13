using Prisoner.QuestionEditor.Controls;
using Prisoner.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Prisoner.QuestionEditor
{
    class AnswerQuestionLine
    {
        public QuestionControl Question1 { get; set; }
        public QuestionControl Question2 { get; set; }
        public Answer Answer { get; set; }
        public Line Line { get; set; }
    }
}
