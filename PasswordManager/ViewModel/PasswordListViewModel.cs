using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManager.Model;
using System.Windows;

namespace PasswordManager.ViewModel
{
	public class PasswordListViewModel : SettingsViewModelBase
	{
		public override string SettingName
		{
			get { return "Passwords"; }
		}
		readonly PasswordRepository _passwordRepository;

		//Holds the selected Password Object from the listview 
		//used in the ListViews XAML for SelectedItem Binding
		public Password SelectedPassword { get; set; }

		public ObservableCollection<Model.Password> AllPasswords
		{
			get;
			private set;
		}

		public PasswordListViewModel(PasswordRepository passwordRepository)
		{

			if (passwordRepository == null)
			{
				throw new ArgumentNullException("passwordRepository");
			}
			_passwordRepository = passwordRepository;
			this.AllPasswords = new ObservableCollection<Model.Password>(_passwordRepository.GetPasswords());
		}

		protected override void OnDispose()
		{
			this.AllPasswords.Clear();
		}

		#region ICommand Implementation For DisplayPassword Button
		RelayCommand _displayCurrentPassword;
		public ICommand DisplayCurrentPassword
		{
			get
			{
				if (_displayCurrentPassword == null)
				{
					_displayCurrentPassword = new RelayCommand(param => DisplayCurrentPasswordExecute(), param => DisplayCurrentPasswordCanExecute);
				}
				return _displayCurrentPassword;
			}


		}

		void DisplayCurrentPasswordExecute()
		{
			//Here we need to look at decrypting passwords
			MessageBox.Show(SelectedPassword.Url);
			SelectedPassword = null;
		}

		public bool DisplayCurrentPasswordCanExecute
		{
			get
			{
				if (SelectedPassword == null)
				{
					return false;
				}
				return true;
			}
		}
		#endregion

		#region Remove contextmenuitem
		private ICommand _removeItem;
		public ICommand RemoveItem
		{
			get { return _removeItem ?? (_removeItem = new RelayCommand(p => RemoveItemCommand((Password)p))); }
		}

		private void RemoveItemCommand(Password item)
		{
			if (item == null) return;

			


			var msgBox = new WPFMessageBoxService();
			if (msgBox.ShowMessage("Are you sure you want to remove this entry?", "Confirm Removal"))

			{
				//MessageBoxResult result =
				//	MessageBox.Show("Confirm deletion of this item",
				//	"Delete Confirmation",
				//	MessageBoxButton.YesNo,
				//	MessageBoxImage.Question);

				//if (result == MessageBoxResult.No) return;

				var db = new PasswordRepository();
				db.DeletePassword(item.Id);
				AllPasswords.Remove(item);

			}
		}
		#endregion

	}
}
