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
using System.Windows.Shapes;

namespace Prisoner.QuestionEditor
{
    /// <summary>
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.TestContext.Results.Load();
            resultDG.ItemsSource = App.TestContext.Results.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.TestContext.SaveChanges();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Ошибка", exp.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
