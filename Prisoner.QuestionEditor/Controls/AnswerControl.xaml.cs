using Prisoner.Test;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prisoner.QuestionEditor.Controls
{
    /// <summary>
    /// Логика взаимодействия для AnswerControl.xaml
    /// </summary>
    public partial class AnswerControl : UserControl
    {
        private Answer _answer;

        public Answer Answer {
            get => _answer;
            set
            {
                _answer = value;
                idTextBox.Text = Convert.ToString(_answer.Id);
                answerTextBox.Text = _answer.Text;
                if (_answer.NextQuestion != null) nextQuestionTextBox.Text = Convert.ToString(_answer.NextQuestion.Id);
                else nextQuestionTextBox.Text = String.Empty;
                resultComboBox.SelectedValue = _answer.Result;
                
            }
        }

        public AnswerControl()
        {
            InitializeComponent();
            Answer = new Answer();
        }

        public AnswerControl(Answer answer)
        {
            InitializeComponent();
            try
            {
                App.TestContext.Results.Load();
                resultComboBox.ItemsSource = App.TestContext.Results.ToList();
                resultComboBox.DisplayMemberPath = "Name";
                resultComboBox.SelectedValuePath = "Id";
            }
            catch { }
            Answer = answer;
        }
    }
}
