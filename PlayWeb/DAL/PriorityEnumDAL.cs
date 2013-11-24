
using System.Collections.Generic;
using System.Linq;

namespace PlayWeb.DAL
{
	public static class PriorityEnumDAL
	{
		/// <summary>
		/// Get a PriorityEnum by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static PriorityEnum GetPriorityEnum(int id)
		{
			return new StacDataContext().PriorityEnums.Single
				(p => p.ID == id);
		}
		/// <summary>
		/// Get a PriorityEnum by Name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static PriorityEnum GetPriorityEnum(string name)
		{
			return new StacDataContext().PriorityEnums.Single
				(p => p.Name == name);
		}
		/// <summary>
		/// Get a full list of all Priority Enums
		/// </summary>
		/// <returns></returns>
		public static IList<PriorityEnum> GetPriorityEnums()
		{
			return new StacDataContext().PriorityEnums.ToList();
		}
	}
}