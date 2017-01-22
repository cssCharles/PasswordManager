using System.Collections.ObjectModel;
using PasswordManager.DataAccess;

namespace PasswordManager.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{
		readonly PasswordRepository _passwordRepository;

		ObservableCollection<ViewModelBase> _viewModels;

		public MainWindowViewModel()
		{
			_passwordRepository = new PasswordRepository();
			PasswordListViewModel viewModel = new PasswordListViewModel(_passwordRepository);
			this.ViewModels.Add(viewModel);
		}

		public ObservableCollection<ViewModelBase> ViewModels
		{
			get
			{
				if (_viewModels == null)
				{
					_viewModels = new ObservableCollection<ViewModelBase>();
				}
				return _viewModels;
			}
		}
	}
}
