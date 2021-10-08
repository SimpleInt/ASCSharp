using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ACSharp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			txtFontSize.Text = txtBox.FontSize.ToString();
			txtBox.AcceptsReturn = true;
			getName = string.Empty;
		}
		public static string getName { get; set; }
		public static bool getStatusSave { get; set; }
		private void saveText_Click(object sender, RoutedEventArgs e)
		{
			save.saveUtils(txtBox.Text);
		}
		private void openText_Click(object sender, RoutedEventArgs e)
		{
			dialog.open(MainMenu, txtBox);
		}
		private void btnSaveAs(object sender, RoutedEventArgs e)
		{
			dialog.SaveAs(MainMenu,txtBox);
		}
		private void trim_Click(object sender, RoutedEventArgs e)
		{
			txtBox.Text = txtBox.Text.Replace(" ", String.Empty);
		}
		private void clear_Click(object sender, RoutedEventArgs e)
		{
			txtBox.Clear();
		}
		private void options_Click(object sender, RoutedEventArgs e)
		{
			if (cnvConfig.IsEnabled == true)
			{
				cnvConfig.Visibility = Visibility.Hidden;
				cnvConfig.IsEnabled = false;
			}
			else
			{
				cnvConfig.Visibility = Visibility.Visible;
				cnvConfig.IsEnabled = true;
			}
		}
		private void saveConfig(object sender, RoutedEventArgs e)
		{
			try
			{
				var bc = new BrushConverter();
				try
				{
					txtBox.Foreground = (Brush)bc.ConvertFrom($"{txtHex.Text}");
				}
				catch
				{
					txtBox.Foreground = (Brush)bc.ConvertFrom($"#{txtHex.Text}");
				}

				txtBox.FontSize = double.Parse(txtFontSize.Text);
			}
			catch (Exception)
			{
				MessageBox.Show("Has escrito algo que no es un numero.");
			}
		}
		private void commands(object sender, KeyEventArgs e)
		{
			if (Keyboard.Modifiers == ModifierKeys.Control)
			{
				switch (e.Key)
				{
					case Key.Add:
						txtBox.FontSize += 2;
						break;
					case Key.Subtract:
						try { txtBox.FontSize -= 2; }
						catch { txtBox.FontSize = 2; }
						break;
					case Key.S:
						save.saveUtils(txtBox.Text);
						break;
					default:
						break;
				}
				txtFontSize.Text = txtBox.FontSize.ToString();
			}
		}
	}
}
