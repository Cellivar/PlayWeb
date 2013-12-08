using System;
using System.Data.Linq;
using System.Drawing;
using System.Linq;

namespace PlayWeb.DAL
{
	public static class DALExtensionMethods
	{
		#region LINQ Extension Methods
		/// <summary>
		/// Find or Create a resource from a SQL datasource
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="table"></param>
		/// <param name="find"></param>
		/// <param name="create"></param>
		/// <example>
		/// var invoiceDb = ctx.Invoices.FindOrCreate(a => a.InvoicerId == InvoicerId && a.Number == invoiceNumber);
		/// invoiceDb.Number = invoiceNumber;
		/// </example>
		/// <example>
		/// var invoiceDb = ctx.Invoices.FindOrCreate(a => a.InvoicerId == InvoicerId &&
		///													a.Number == invoicerNumber,
		///												a => a.Number = invoiceNumber);
		/// </example>
		/// <returns>Object being looked for</returns>
		public static T FindOrCreate<T>(this Table<T> table, Func<T, bool> find, Func<T, T> create) where T : class, new()
		{
			T val = table.FirstOrDefault(find);
			if (val == null)
			{
				val = new T();
				val = create(val) ?? val;
				table.InsertOnSubmit(val);
			}
			return val;
		}
		/// <summary>
		/// Find a resource from a SQL datasource
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="table"></param>
		/// <param name="find"></param>
		/// <example>
		/// var invoiceDb = ctx.Invoices.FindOrCreate(a => a.InvoicerId == InvoicerId && a.Number == invoiceNumber);
		/// invoiceDb.Number = invoiceNumber;
		/// </example>
		/// <returns></returns>
		public static T FindOrCreate<T>(this Table<T> table, Func<T, bool> find) where T : class, new()
		{
			return FindOrCreate(table, find, a => null);
		}
		#endregion

		#region ColorEnum Extension Methods
		/// <summary>
		/// Get a Color object from stored ARGB int value
		/// </summary>
		/// <param name="colorEnum">ColorEnum to translate</param>
		/// <returns>Color represented</returns>
		public static Color GetColor(this ColorEnum colorEnum)
		{
			return Color.FromArgb(colorEnum.Value);
		}
		/// <summary>
		/// Set color of ColorEnum from Color object
		/// </summary>
		/// <param name="colorEnum">ColorEnum to modify</param>
		/// <param name="color">Color to set to</param>
		public static void SetColor(this ColorEnum colorEnum, Color color)
		{
			colorEnum.Value = color.ToArgb();
		}
		#endregion
	}
}