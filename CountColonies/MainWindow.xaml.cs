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

namespace CountColonies {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		string baseTitle_ = "コロニーを数えよう";

		public MainWindow() {
			InitializeComponent();
			Title = baseTitle_ + " (コロニーの写真をドラッグアンドドロップしてね)";
			numberOfColonies.Text = "0";
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

			canvas.Children.Clear();
			numberOfColonies.Text = "0";
		}
		
		private void canvas_MouseUp(object sender, MouseButtonEventArgs e) {
			Ellipse ellipse = new Ellipse();
			ellipse.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
			ellipse.Height = 2;
			ellipse.Width = 2;
			Canvas.SetTop(ellipse, e.GetPosition(this).Y - 20);
			Canvas.SetLeft(ellipse, e.GetPosition(this).X - 1);
			canvas.Children.Add(ellipse);

			numberOfColonies.Text = canvas.Children.Count.ToString();
		}

		private void Button_Click(object sender, RoutedEventArgs e) {
			if(canvas.Children.Count == 0) {
				return;
			}

			canvas.Children.RemoveAt(canvas.Children.Count - 1);
			numberOfColonies.Text = canvas.Children.Count.ToString();
		}
	}
}
