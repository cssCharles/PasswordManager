using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.ViewModel
{
	public abstract class SettingsViewModelBase : ViewModelBase
	{
		public abstract string SettingName { get; }
	}
}
