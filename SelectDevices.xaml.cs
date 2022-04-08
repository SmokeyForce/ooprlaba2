﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfTilt
{
    /// <summary>
    /// Логика взаимодействия для SelectDevices.xaml
    /// </summary>
    public partial class SelectDevices : Window
    {
        public static Monitor selMon;
        public static Mouse selMouse;
		List<Monitor> monitors;
		List<Mouse> mouses;
		public SelectDevices()
		{
			InitializeComponent();
			StreamReader  sr = new StreamReader("monitors.txt");
			monitors = new List < Monitor > ();
			while (!sr.EndOfStream)
			{
				Monitor  m = new Monitor();
				m.readFromFile(sr);
				monitors.Add(m);
				monitorList.Items.Add(m);
			}
			sr.Close();
			sr = new StreamReader("mouses.txt");
			mouses = new List < Mouse > ();
			while (!sr.EndOfStream)
			{
				Mouse  mo = new Mouse();
				mo.readFromFile(sr);
				mouses.Add(mo);
				mouseList.Items.Add(mo);
			}
			sr.Close();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			this.Close();
		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void monitorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			selMon = this.monitors[monitorList.SelectedIndex];
		}

        private void mouseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			selMouse = this.mouses[mouseList.SelectedIndex];
		}
    }
}
