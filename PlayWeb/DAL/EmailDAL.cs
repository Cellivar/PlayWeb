using System.Linq;

namespace PlayWeb.DAL
{
	public static class EmailDAL
	{
		/// <summary>
		/// Return an email address based on ID
		/// </summary>
		/// <param name="emailID"></param>
		/// <returns></returns>
		public static Email GetEmail(int emailID)
		{
			return new StacDataContext().Emails.Single(e => e.ID == emailID);
		}
		/// <summary>
		/// Get or Create an email address in the DB
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public static Email GetOrCreateEmail(string email)
		{
			return new StacDataContext().Emails.FindOrCreate
				(e => e.Email1 == email
				, e => CreateEmail(email)
				);
		}
		/// <summary>
		/// Create a new Email entry in the database
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public static Email CreateEmail(string email)
		{
			var db = new StacDataContext();

			var newEmail = new Email { Email1 = email };

			db.Emails.InsertOnSubmit(newEmail);
			db.SubmitChanges();

			// Email will have it's ID field populated automagically
			// Did I mention I love Linq?
			return newEmail;
		}
		/// <summary>
		/// Remove an email entry
		/// </summary>
		/// <param name="email"></param>
		public static void DeleteEmail(Email email)
		{
			var db = new StacDataContext();
			db.Emails.DeleteOnSubmit(email);
			db.SubmitChanges();
		}
	}
}