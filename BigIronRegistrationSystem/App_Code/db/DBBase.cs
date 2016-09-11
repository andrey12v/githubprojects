using System;
using System.Collections;
using System.Text;

namespace db
{

	/// <summary>
	/// Base class for all DB objects
	/// </summary>
	public class DBBase
	{
		protected int id;

		public DBBase()
		{
		}

		#region properties
		public int ID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}
		#endregion
	}
}
