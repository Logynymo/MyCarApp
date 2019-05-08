﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using BIZ;
using REPO;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ CB = new ClassBIZ();
        ClassBIZ CBTemp = new ClassBIZ();

        public MainWindow()
        {
            InitializeComponent();
            gridMain.DataContext = CB;
            CB.MakeDataBase();
        }

        private void ButtonCreateCar_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Tag.ToString() == "1")
            {
                CB.selectedCar = new Car();
            }

            buttonCreateCar.Visibility = Visibility.Collapsed;
            buttonEditCar.Visibility = Visibility.Collapsed;
            buttonDeleteCar.Visibility = Visibility.Collapsed;

            buttonSaveCar.Visibility = Visibility.Visible;
            buttonDiscardChanges.Visibility = Visibility.Visible;

            textBoxCarModel.IsEnabled = true;
            comboBoxCarLogo.IsEnabled = true;
            comboBoxCarPropellant.IsEnabled = true;
            textBoxLicenseplate.IsEnabled = true;
            listViewCars.IsEnabled = false;

            CopyCar(CBTemp, CB);
            gridInfo.DataContext = CBTemp;
        }

        private void ButtonDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (CB.selectedCar.carID != 0)
            {
                CB.DeleteCar();
            }
        }

        private void ButtonSaveCar_Click(object sender, RoutedEventArgs e)
        {
            CopyCar(CB, CBTemp);
            CB.SaveCar();
            gridInfo.DataContext = CB;

            buttonCreateCar.Visibility = Visibility.Visible;
            buttonEditCar.Visibility = Visibility.Visible;
            buttonDeleteCar.Visibility = Visibility.Visible;

            buttonSaveCar.Visibility = Visibility.Collapsed;
            buttonDiscardChanges.Visibility = Visibility.Collapsed;

            textBoxCarModel.IsEnabled = false;
            comboBoxCarLogo.IsEnabled = false;
            comboBoxCarPropellant.IsEnabled = false;
            textBoxLicenseplate.IsEnabled = false;
            listViewCars.IsEnabled = true;
        }

        private void ButtonDiscardChanges_Click(object sender, RoutedEventArgs e)
        {
            gridInfo.DataContext = CB;

            buttonCreateCar.Visibility = Visibility.Visible;
            buttonEditCar.Visibility = Visibility.Visible;
            buttonDeleteCar.Visibility = Visibility.Visible;

            buttonSaveCar.Visibility = Visibility.Collapsed;
            buttonDiscardChanges.Visibility = Visibility.Collapsed;

            textBoxCarModel.IsEnabled = false;
            comboBoxCarLogo.IsEnabled = false;
            comboBoxCarPropellant.IsEnabled = false;
            textBoxLicenseplate.IsEnabled = false;
            listViewCars.IsEnabled = true;
        }

        private void ListViewCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.SelectedItem != null)
            {
                CB.selectedCar = null;
                CB.selectedCar = (Car)lv.SelectedItem;
            }
        }

        private void CopyCar(ClassBIZ toBIZ, ClassBIZ fromBIZ)
        {
            toBIZ.selectedCar = (Car)fromBIZ.selectedCar.Clone();
        }
    }
}
