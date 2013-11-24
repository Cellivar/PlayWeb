
using System.Collections.Generic;
using System.Linq;

namespace PlayWeb.DAL
{
	public static class ColorEnumDAL
	{
		/// <summary>
		/// Get a ColorEnum based on a Color ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static ColorEnum GetColorEnum(int id)
		{
			return new StacDataContext().ColorEnums.Single
				(c => c.ID == id);
		}
		/// <summary>
		/// Get a ColorEnum based on the name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static ColorEnum GetColorEnum(string name)
		{
			return new StacDataContext().ColorEnums.Single
				(c => c.Name == name);
		}
		/// <summary>
		/// Get all available ColorEnums
		/// </summary>
		/// <returns></returns>
		public static IList<ColorEnum> GetColorEnums()
		{
			return new StacDataContext().ColorEnums.ToList();
		}
	}
}