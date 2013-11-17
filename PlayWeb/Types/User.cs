
namespace PlayWeb.Types
{
	/// <summary>
	/// Represents a User
	/// </summary>
	public class User
	{
		public int ID { get; set; }
		public string DisplayName { get; set; }
		public string ImageUrl { get; set; }
		public string Email { get; set; }

		public User()
		{
			ID = 0;
		}

		/// <summary>
		/// Generate a User object supplying the appropriate parameters
		/// </summary>
		/// <param name="userID"></param>
		/// <param name="displayName"></param>
		/// <param name="imageUrl"></param>
		/// <param name="email"></param>
		public User(int userID, string displayName, string imageUrl, string email)
		{
			ID = userID;
			DisplayName = displayName;
			ImageUrl = imageUrl;
			Email = email;
		}
	}
}