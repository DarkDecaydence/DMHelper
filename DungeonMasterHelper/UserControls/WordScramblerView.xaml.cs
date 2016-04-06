using System;
using System.Collections.Generic;
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
using DungeonMasterHelper.ViewModels;

namespace DungeonMasterHelper
{
    /// <summary>
    /// Interaction logic for WordScrambler.xaml
    /// </summary>
    public partial class WordScramblerView : UserControl
    {
        public WordScramblerViewModel ViewModel
        {
            get { return DataContext as WordScramblerViewModel; }
        }

        public WordScramblerView()
        {
            InitializeComponent();
        }

        private void Scramble_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.ScrambleText();
        }
    }
}
