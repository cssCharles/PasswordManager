using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager
{
	public class WPFMessageBoxService : IMessageBoxService
	{
		public bool ShowMessage(string text, string caption)
		{
			MessageBoxResult result = MessageBox.Show(text, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				return true;
			}
			return false;
		}
	}
}
