﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PasswordManager.ViewModel;

namespace PasswordManager
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			//TODO: Might need to get rid of this
			base.OnStartup(e);
			MainWindow window = new MainWindow();
			var viewModel = new MainWindowViewModel();
			window.DataContext = viewModel;
			window.Show();
		}
	}
}
