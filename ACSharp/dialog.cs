using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ACSharp
{
	class dialog
	{
		public static List<string> getUri = new List<string>();
		public static void open(Menu MainMenu, TextBox txtBox)
		{
			createSome some = new createSome(MainMenu, txtBox);
			// Create OpenFileDialog 
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
			{
				// Set filter for file extension and default file extension 
				DefaultExt = ".txt",
				Title = "Open new file",
				Filter = "textFiles|*.acs; *.txt|All files (*.*)|*.*"
			};


			// Display OpenFileDialog by calling ShowDialog method 
			Nullable<bool> result = dlg.ShowDialog();

			if (result == true)
			{
				// Open document 
				string filename = dlg.FileName;
				
				if (getUri.Contains(filename))
				{
					MessageBox.Show(getUri.IndexOf(filename).ToString(), filename, MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					string[] filenamer = filename.Split(@"\");
					getUri.Add(filename);

					some.makeMenuItem(filenamer[^1], filename);

					MainWindow.getName = filename;
					txtBox.Text = File.ReadAllText(MainWindow.getName);
					MainWindow.getStatusSave = true;
				}
			}
		}
		public static void SaveAs(Menu MainMenu, TextBox txtBox)
		{
			createSome some = new createSome(MainMenu, txtBox);

			Microsoft.Win32.SaveFileDialog saveAs = new Microsoft.Win32.SaveFileDialog
			{
				DefaultExt = ".txt",
				Title = "Save new text file",
				Filter = "textFiles|*.acs; *.txt|All files (*.*)|*.*"
			};


			Nullable<bool> result = saveAs.ShowDialog();
			if (result == true)
			{
				var filename = saveAs.FileName;
				txtBox.Clear();
				File.WriteAllText(filename, txtBox.Text);
				if (getUri.Contains(filename))
				{
					MessageBox.Show(getUri.IndexOf(filename).ToString(), filename, MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					string[] filenamer = filename.Split(@"\");
					getUri.Add(filename);

					some.makeMenuItem(filenamer[^1], filename);

					MainWindow.getName = filename;
					
					txtBox.Text = File.ReadAllText(MainWindow.getName);
					MainWindow.getStatusSave = true;

				}
			}
		}
	}
}
