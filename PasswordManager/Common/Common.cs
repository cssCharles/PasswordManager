﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{

	public enum EntryType
	{
		Personal,
		Business
	}	

	public static class Common
	{
		public static string conString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=S:\!!DriveD Backup\Charlie\PasswordsDB.accdb";

	}
}
