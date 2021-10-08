using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ACSharp
{
	public class createSome
	{
		//Create properties :D
		
		Menu MainMenu { get; set; }
		TextBox txtBox { get; set; }

		public createSome(Menu menu, TextBox txt)
		{
			MainMenu = menu;
			txtBox = txt;
		}
		public void makeMenuItem(string fileName, string urlFile)
		{
			
			try
			{
				MenuItem newMenuItem1 = new MenuItem
				{
					Header = fileName.Substring(0, 3) + fileName.Substring(fileName.LastIndexOf('.')),
					FontSize = 14
				};
				newMenuItem1.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler((object sender, RoutedEventArgs e) =>
				{
					txtBox.Text = File.ReadAllText(urlFile);
					MainWindow.getName = urlFile;
				}));
				
				MenuItem exit = new MenuItem
				{
					Width = 30,
					Icon = new Image
					{
						Source = new BitmapImage(new Uri("remove-button.png", UriKind.Relative))
					}
				};

				exit.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler((object sender, RoutedEventArgs e) =>
				{
					dialog.getUri.RemoveAt(dialog.getUri.IndexOf(urlFile));
					MainMenu.Items.Remove(newMenuItem1);
					MainMenu.Items.Remove(exit);
					MainWindow.getName = string.Empty;
					txtBox.Clear();
				}));

				MainMenu.Items.Add(newMenuItem1);
				MainMenu.Items.Add(exit);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			
		}
	}
}
