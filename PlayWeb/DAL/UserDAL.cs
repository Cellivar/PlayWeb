using System.Linq;

namespace PlayWeb.DAL
{
	/// <summary>
	/// User object data access layer.
	/// </summary>
	public static class UserDAL
	{
		/// <summary>
		/// Get a user based on a User's ID
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public static User GetUser(int userID)
		{
			return new StacDataContext().Users.FindOrCreate
				(u => u.ID == userID);
		}
		/// <summary>
		/// Get a user based on a user's Email address
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public static User GetUser(string email)
		{
			return new StacDataContext().Users.Single
				(u => u.Email.Email1 == email);
		}
		/// <summary>
		/// Get or Create a user based on a User object
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static User GetOrCreateUser(User user)
		{
			return new StacDataContext().Users.FindOrCreate
				(u => u.Email.Email1 == user.Email.Email1
				, u => CreateUser(user)
				);
		}
		/// <summary>
		/// Insert a user into the DB
		/// </summary>
		/// <param name="user"></param>
		/// <returns>New user from DB</returns>
		public static User CreateUser(User user)
		{
			var db = new StacDataContext();

			// First we get an email ID
			var email = EmailDAL.GetOrCreateEmail(user.Email.Email1);

			// Update the user object with the new email ID
			user.EmailID = email.ID;

			// Now we can insert the User object into the DB
			db.Users.InsertOnSubmit(user);
			db.SubmitChanges();

			// Return the user we just inserted, which will have an updated ID
			return user;
		}
		/// <summary>
		/// Delete a user account. Also remove email associated with account if
		/// it is not in use on any other accounts.
		/// </summary>
		/// <param name="user"></param>
		public static void DeleteUser(User user)
		{
			var db = new StacDataContext();

			// Get count of emails
			var emailCount = (from e in db.Users
							  where e.EmailID == user.EmailID
							  select e).Count();

			if (emailCount == 1)
			{
				// We have precisely 1 account associated with this email. 
				// Therefore, we're safe to remove this email with this account.
				EmailDAL.DeleteEmail(user.Email);
			}
			// TODO: Figure out some way of letting the user know the email is
			// still in use by some other account? Should be taken care of when
			// we encounter multiple accounts with separate emails in the
			// future, as I'm still not sure what would cause that to happen
			// but it's there just in case.

			db.Users.DeleteOnSubmit(user);
			db.SubmitChanges();
		}
	}
}