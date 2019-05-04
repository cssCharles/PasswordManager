using System;
using System.Collections.Generic;
using PasswordManager.Model;
using System.Data.OleDb;
using System.Collections.ObjectModel;

namespace PasswordManager.DataAccess
{
	public class PasswordRepository
	{
		string sql = "SELECT * FROM Passwords ORDER BY EntryType";
		//readonly List<Password> _passwords;
        readonly ObservableCollection<Password> _passwords;
		public PasswordRepository()
		{
			if (_passwords == null)
			{
                //_passwords = new List<Password>();
                _passwords = new ObservableCollection<Password>();
            }
			using (var con = new OleDbConnection(Common.conString))
			using (var cmd = new OleDbCommand(sql, con))
			{
				con.Open();
				using (OleDbDataReader rdr = cmd.ExecuteReader())
				{
					while (rdr.Read())
					{
						var row = new Password();
						row.Id = (int)rdr["PasswordID"];
						row.EntryType = (EntryType) Enum.Parse(typeof(EntryType), rdr["EntryType"].ToString());
						row.Name = rdr["SiteName"].ToString();
						row.UserId = rdr["UserID"].ToString();
						row.UserPassword = rdr["Password"].ToString();
						row.Memo = rdr["Memo"].ToString();
						row.Url = rdr["Url"].ToString();

						_passwords.Add(row);

					}
				}
				con.Close();
			}
		}

		public ObservableCollection<Password> GetPasswords()
		{
			return new ObservableCollection<Password>(_passwords);
		}

		public void SavePasswordEntry(Password password)
		{
			string sql = "INSERT INTO Passwords " +
						 "(EntryType, SiteName, UserID, [Password], [Memo], [Url]) " +
						 "VALUES " +
						 "(@Type, @Name, @User, @PW, @Memo, @Url)";

			using (var con = new OleDbConnection(Common.conString))
			using (var cmd = new OleDbCommand(sql, con))
			{
				cmd.Parameters.AddWithValue("@Type", password.EntryType);
				cmd.Parameters.AddWithValue("@Name", password.Name);
				cmd.Parameters.AddWithValue("@User", password.UserId);
				cmd.Parameters.AddWithValue("@PW", password.UserPassword);
				cmd.Parameters.AddWithValue("@Memo", password.Memo + "");
				cmd.Parameters.AddWithValue("@Url", password.Url + "");
				try
				{
					con.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
			}
			_passwords.Add(password);
			//GetPasswords();


		}
		public void UpdatePasswordEntry(Password password)
		{
			string sql = "UPDATE Passwords SET " +
			 "EntryType = @Type, " +
			 "SiteName = @Name, " +
			 "UserID = @User, " +
			 "[Password] = @PW, " +
			 "[Memo] = @Memo, " +
			 "[URL] = @Url " +
			 "WHERE PasswordID = @ID";

			using (var con = new OleDbConnection(Common.conString))
			using (var cmd = new OleDbCommand(sql, con))
			{
				cmd.Parameters.AddWithValue("@Type", password.EntryType);
				cmd.Parameters.AddWithValue("@Name", password.Name);
				cmd.Parameters.AddWithValue("@User", password.UserId);
				cmd.Parameters.AddWithValue("@PW", password.UserPassword);
				cmd.Parameters.AddWithValue("@Memo", password.Memo);
				cmd.Parameters.AddWithValue("@Url", password.Url);
				cmd.Parameters.AddWithValue("@ID", password.Id);
				try
				{
					con.Open();
					cmd.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				//finally
				//{
				//	con.Close();
				//}
			}
		}

        public void DeletePassword(int id)
        {
            string sql = "DELETE FROM Passwords WHERE PasswordID = @ID";

            using (var con = new OleDbConnection(Common.conString))
            using (var cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                //finally
                //{
                //    con.Close();
                //}
            }
        }
	}
}
