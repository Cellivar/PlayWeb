namespace PlayWeb.DAL
{
	/// <summary>
	/// User object data access layer. Talk to the DB through these accessor functions
	/// </summary>
	public static class UserDAL
	{
		/// <summary>
		/// Get a User object from the database by known userID
		/// </summary>
		/// <param name="userID"></param>
		/// <returns>User from DB</returns>
		public static Types.User GetUser(int userID)
		{
			var db = new StacDataContext();
			string displayName = "", email = "", imageUrl = "";
			db.Users_GetFromID(userID, ref displayName, ref email, ref imageUrl);

			return new Types.User(userID, displayName, imageUrl, email);
		}

		/// <summary>
		/// Get or Create a user from an email
		/// </summary>
		/// <param name="email"></param>
		/// <returns>New User from DB</returns>
		public static Types.User GetOrCreateUser(string email)
		{
			var db = new StacDataContext();
			string displayName = "", imageUrl = "";
			int? id = 0;
			var result = db.Users_GetFromEmail(email, ref id, ref displayName, ref imageUrl);

			// ReSharper disable once PossibleInvalidOperationException
			return result == 1 ? CreateUser(new Types.User(0, displayName, imageUrl, email)) : new Types.User((int)id, displayName, imageUrl, email);
		}

		/// <summary>
		/// Insert a user into the DB
		/// </summary>
		/// <param name="user"></param>
		/// <returns>New user from DB</returns>
		public static Types.User CreateUser(Types.User user)
		{
			var db = new StacDataContext();
			var userID = db.Users_Create(user.DisplayName, user.Email, user.ImageUrl);

			user.ID = userID;

			return user;
		}
	}
}