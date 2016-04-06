﻿using System;
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
using System.Windows.Shapes;
using DungeonMasterHelper.ViewModels;

namespace DungeonMasterHelper
{
    /// <summary>
    /// Interaction logic for CityGenerator.xaml
    /// </summary>
    public partial class CityGeneratorView : Window
    {

        private CityGeneratorViewModel ViewModel {
            get { return DataContext as CityGeneratorViewModel; }
        }

        public CityGeneratorView()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e) {
            ViewModel.Save();
            this.Close();
        }
    }
}
