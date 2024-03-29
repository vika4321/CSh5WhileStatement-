﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace WhileStatement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private OpenFileDialog openFileDialog = null;

        public MainWindow()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.FileOk += openFileDialogFileOk;
        }

        private void openFileClick(object sender, RoutedEventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialogFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fullPathname = openFileDialog.FileName;
            FileInfo src = new FileInfo(fullPathname);
            fileName.Text = src.Name;

			source.Text = "";
			TextReader reader = src.OpenText();
			string line = reader.ReadLine();

			while (line != null)
			{
				source.Text += line + '\n';
				line = reader.ReadLine();
			}
			reader.Close();
        }
    }
}