using PasswordManager.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Model
{


	public class Password : ViewModelBase
	{
		public int		 Id { get; set; }
		public EntryType EntryType { get; set; }
		private string name;
		public string Name
		{
			get { return name; }
			set { 
				name = value;
				//OnPropertyChanged("Name");
			}
		}		
		public string	 UserId { get; set; }
		public string	 UserPassword { get; set; }
		public string	 Memo { get; set; }
		public string	 Url { get; set; }

		



		
		
	}
}
