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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CountColonies {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		string baseTitle_ = "コロニーを数えよう";

		public MainWindow() {
			InitializeComponent();
			Title = baseTitle_;
		}

		private void Window_DragEnter(object sender, DragEventArgs e) {
			if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effects = DragDropEffects.Copy;
			}
		}

		private void Window_Drop(object sender, DragEventArgs e) {
			if(!e.Data.GetDataPresent(DataFormats.FileDrop)) {
				return;
			}

			string fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
			BitmapImage bitmap = new BitmapImage(new Uri(fileName));
			coloniesImage.Source = bitmap;

			Title = System.IO.Path.GetFileName(fileName) + " | " + baseTitle_;
		}
	}
}