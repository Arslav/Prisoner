using Prisoner.Test;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Prisoner.QuestionEditor
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static TestContext TestContext { get; private set; }
        public App()
        {
            TestContext = new TestContext();
        }
    }
}
