
using System.Collections.Generic;
using System.Linq;

namespace PlayWeb.DAL
{
	public static class ReminderTypeEnumDAL
	{
		/// <summary>
		/// Get a ReminderTypeEnum by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static ReminderTypeEnum GetPriorityEnum(int id)
		{
			return new StacDataContext().ReminderTypeEnums.Single
				(p => p.ID == id);
		}
		/// <summary>
		/// Get a ReminderTypeEnum by Name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static ReminderTypeEnum GetPriorityEnum(string name)
		{
			return new StacDataContext().ReminderTypeEnums.Single
				(p => p.Name == name);
		}
		/// <summary>
		/// Get a full list of all ReminderTypeEnum
		/// </summary>
		/// <returns></returns>
		public static IList<ReminderTypeEnum> GetPriorityEnums()
		{
			return new StacDataContext().ReminderTypeEnums.ToList();
		}
	}
}