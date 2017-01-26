using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using PasswordManager.Model;
using PasswordManager.DataAccess;

namespace PasswordManager.ViewModel
{
	class CreatePasswordViewModel : SettingsViewModelBase
	{
		public override string SettingName
		{
			get { return "CreateNew"; }
		}


		//public Password password = new Password();

		private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}
		private EntryType _entryType;
		public EntryType EntryType
		{
			get
			{
				return _entryType;
			}
			set
			{
				_entryType = value;
				OnPropertyChanged("EntryType");
			}
		}
		private string _userId;
		public string UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
				OnPropertyChanged("UserId");
			}
		}
		private string _userPassword;
		public string UserPassword
		{
			get
			{
				return _userPassword;
			}
			set
			{
				_userPassword = value;
				OnPropertyChanged("UserPassword");
			}
		}

		private string _memo;
		public string Memo
		{
			get
			{
				return _memo;
			}
			set
			{
				_memo = value;
				OnPropertyChanged("Memo");
			}
		}

		private string _url;
		public string Url
		{
			get
			{
				return _url;
			}
			set
			{
				_url = value;
				OnPropertyChanged("Url");
			}
		}


		RelayCommand _savePassword;
		public ICommand SavePassword
		{
			get
			{
				if (_savePassword == null)
				{
					_savePassword = new RelayCommand(param => SavePasswordExecute(), param => SavePasswordCanExecute);
				}
				return _savePassword;
			}

		}

		void SavePasswordExecute()
		{
			//TODO: Code for saving to database
			var password = new Password();

			password.Name = this.Name;
			password.EntryType = Model.EntryType.Business;
			password.UserId = this.UserId;
			password.UserPassword = this.UserPassword;
			password.Memo = this.Memo;
			password.Url = this.Url;

			var repository = new PasswordRepository();
			repository.SavePasswordEntry(password);

			this.Name = string.Empty;
			this.UserId = string.Empty;
			this.UserPassword = string.Empty;
			this.Memo = string.Empty;
			this.Url = string.Empty;
		}

		public bool SavePasswordCanExecute
		{
			get
			{
				if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(UserPassword))
				{
					return false;
				}
				return true;
			}
		}
	}
}
