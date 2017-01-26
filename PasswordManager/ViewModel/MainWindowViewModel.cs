using System.Collections.ObjectModel;
using PasswordManager.DataAccess;

namespace PasswordManager.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{

		private readonly PasswordRepository _passwordRepository;

		private readonly ObservableCollection<SettingsViewModelBase> settings;
		public ObservableCollection<SettingsViewModelBase> Settings
		{
			get { return this.settings; }
		}

		public MainWindowViewModel()
		{
			_passwordRepository = new PasswordRepository();

			this.settings = new ObservableCollection<SettingsViewModelBase>();

			this.settings.Add(new PasswordListViewModel(_passwordRepository));
			this.settings.Add(new CreatePasswordViewModel());
		    
		}
		//readonly PasswordRepository _passwordRepository;

		//ObservableCollection<ViewModelBase> _viewModels;

		//public MainWindowViewModel()
		//{
		//	_passwordRepository = new PasswordRepository();
		//	PasswordListViewModel viewModel = new PasswordListViewModel(_passwordRepository);
		//	this.ViewModels.Add(viewModel);
		//}

		//public ObservableCollection<ViewModelBase> ViewModels
		//{
		//	get
		//	{
		//		if (_viewModels == null)
		//		{
		//			_viewModels = new ObservableCollection<ViewModelBase>();
		//		}
		//		return _viewModels;
		//	}
		//}
	}
}
