using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Model
{
	public enum EntryType
	{
		Personal,
		Business
	}	

	public class Password
	{
		public int		 Id { get; set; }
		public EntryType EntryType { get; set; }
		public string	 Name { get; set; }
		public string	 UserId { get; set; }
		public string	 UserPassword { get; set; }
		public string	 Memo { get; set; }
		public string	 Url { get; set; }
	}
}
