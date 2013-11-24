using System.Collections.Generic;
using System.Linq;

namespace PlayWeb.DAL
{
	public static class TaskDAL
	{
		/// <summary>
		/// Get a task from the TaskID
		/// </summary>
		/// <param name="taskID"></param>
		/// <returns></returns>
		public static Task GetTask(int taskID)
		{
			return new StacDataContext().Tasks.Single(t => t.ID == taskID);
		}
		/// <summary>
		/// Get a list of tasks from a UserID
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public static IList<Task> GetTasksByUserID(int userID)
		{
			var db = new StacDataContext();

			var tasks = from t in db.Tasks
						where t.User.ID == userID
						select t;

			return tasks.ToList();
		}
		/// <summary>
		/// Create a new Task entry in the database
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public static Task CreateTask(Task task)
		{
			var db = new StacDataContext();

			db.Tasks.InsertOnSubmit(task);
			db.SubmitChanges();

			return task;
		}
		/// <summary>
		/// Delete a task entry in the database
		/// </summary>
		/// <param name="task"></param>
		public static void DeleteTask(Task task)
		{
			var db = new StacDataContext();
			db.Tasks.DeleteOnSubmit(task);
			db.SubmitChanges();
		}
	}
}