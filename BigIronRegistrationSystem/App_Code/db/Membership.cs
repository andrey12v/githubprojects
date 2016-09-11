using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace db
{
	/// <summary>
	/// Represents records in the Memberships table
	/// </summary>
	public class Membership : DBBase
	{
		private int exporterID;
		private int eSPID;
		private double membershipAmount;
		private DateTime? membershipDate;
		private double pledgeAmount;
		private DateTime? pledgeDate;
		private DateTime? membershipStartDate;
		private DateTime? membershipEndDate;
		private int refferedCount;
		private int satisfactionScore;


		/// <summary>
		/// default constuctor initializes several fields
		/// </summary>
		public Membership()
		{
		}

		/// <summary>
		/// loads values from the database for this object
		/// </summary>
		/// <param name="id">the ID of the record to use</param>
		public Membership(int id)
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select MembershipID,ExporterID,ESPID,MembershipAmount,MembershipDate,PledgeAmount,PledgeDate,MembershipStartDate,MembershipEndDate,RefferedCount,SatisfactionScore from viewMemberships where MembershipID = @id", conn);
			command.Parameters.AddWithValue("@id", id);

			conn.Open();

			SqlDataReader rs = command.ExecuteReader();

			if (rs.Read())
			{
				this.id = Convert.ToInt32(rs["MembershipID"]);
				this.exporterID = Convert.ToInt32(rs["ExporterID"]);
				this.eSPID = Convert.ToInt32(rs["ESPID"]);
				this.membershipAmount = Convert.ToDouble(rs["MembershipAmount"]);
				if (rs["MembershipDate"] != Convert.DBNull)
				{
					this.membershipDate = Convert.ToDateTime(rs["MembershipDate"]);
				}
				else
				{
					this.membershipDate = null;
				}				
				this.pledgeAmount = Convert.ToDouble(rs["PledgeAmount"]);
				if (rs["PledgeDate"] != Convert.DBNull)
				{
					this.pledgeDate = Convert.ToDateTime(rs["PledgeDate"]);
				}
				else
				{
					this.pledgeDate = null;
				}
				if (rs["MembershipStartDate"] != Convert.DBNull)
				{
					this.membershipStartDate = Convert.ToDateTime(rs["MembershipStartDate"]);
				}
				else
				{
					this.membershipStartDate = null;
				}
				if (rs["MembershipEndDate"] != Convert.DBNull)
				{
					this.membershipEndDate = Convert.ToDateTime(rs["MembershipEndDate"]);
				}
				else
				{
					this.membershipEndDate = null;
				}				
				this.refferedCount = Convert.ToInt32(rs["RefferedCount"]);
				this.satisfactionScore = Convert.ToInt32(rs["SatisfactionScore"]);

			}
			rs.Close();
			conn.Close();
		}

		/// <summary>
		/// inserts this object into the database
		/// </summary>
		/// <returns>The ID of the record in the database on success, 0 on fail</returns>
		public int Insert()
		{
			int retVal = 0;

			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("MembershipsINSERT", conn);
			command.CommandType = System.Data.CommandType.StoredProcedure;

			SqlParameter param1 = new SqlParameter("ExporterID", SqlDbType.Int);
			param1.Value = this.exporterID;
			command.Parameters.Add(param1);

			SqlParameter param2 = new SqlParameter("ESPID", SqlDbType.Int);
			param2.Value = this.eSPID;
			command.Parameters.Add(param2);

			SqlParameter param3 = new SqlParameter("MembershipAmount", SqlDbType.Money);
			param3.Value = this.membershipAmount;
			command.Parameters.Add(param3);
		
			SqlParameter param5 = new SqlParameter("PledgeAmount", SqlDbType.Money);
			param5.Value = this.pledgeAmount;
			command.Parameters.Add(param5);

			SqlParameter param9 = new SqlParameter("RefferedCount", SqlDbType.Int);
			param9.Value = this.refferedCount;
			command.Parameters.Add(param9);

			SqlParameter param10 = new SqlParameter("SatisfactionScore", SqlDbType.Int);
			param10.Value = this.satisfactionScore;
			command.Parameters.Add(param10);


			SqlParameter param4 = new SqlParameter("MembershipDate", SqlDbType.DateTime);
			if (this.membershipDate != null)
			{
				param4.Value = this.membershipDate;
			}
			else
			{
				param4.Value = Convert.DBNull;
			}			
			command.Parameters.Add(param4);

			SqlParameter param6 = new SqlParameter("PledgeDate", SqlDbType.DateTime);
			if (this.pledgeDate != null)
			{
				param6.Value = this.pledgeDate;
			}
			else
			{
				param6.Value = Convert.DBNull;
			}				
			command.Parameters.Add(param6);

			SqlParameter param7 = new SqlParameter("MembershipStartDate", SqlDbType.DateTime);
			if (this.membershipStartDate != null)
			{
				param7.Value = this.membershipStartDate;
			}
			else
			{
				param7.Value = Convert.DBNull;
			}				
			command.Parameters.Add(param7);

			SqlParameter param8 = new SqlParameter("MembershipEndDate", SqlDbType.DateTime);
			if (this.membershipEndDate != null)
			{
				param8.Value = this.membershipEndDate;
			}
			else
			{
				param8.Value = Convert.DBNull;
			}				
			command.Parameters.Add(param8);


			conn.Open();

			SqlDataReader rs = command.ExecuteReader();
			rs.Read();
			int sqlRetVal = Convert.ToInt32(rs["retVal"]);
			if (sqlRetVal == 0)
			{
				retVal = 0;
			}
			else
			{
				this.id = Convert.ToInt32(rs["id"]);
				retVal = this.id;
			}
			rs.Close();
			conn.Close();

			return retVal;
		}

		/// <summary>
		/// Updates a record in the database
		/// </summary>
		/// <returns>True on success, false on fail or record not found</returns>
		public bool Update()
		{
			bool retVal = false;


			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("MembershipsUPDATE", conn);
			command.CommandType = System.Data.CommandType.StoredProcedure;

			SqlParameter param1 = new SqlParameter("ExporterID", SqlDbType.Int);
			param1.Value = this.exporterID;
			command.Parameters.Add(param1);

			SqlParameter param2 = new SqlParameter("ESPID", SqlDbType.Int);
			param2.Value = this.eSPID;
			command.Parameters.Add(param2);

			SqlParameter param3 = new SqlParameter("MembershipAmount", SqlDbType.Money);
			param3.Value = this.membershipAmount;
			command.Parameters.Add(param3);

			SqlParameter param5 = new SqlParameter("PledgeAmount", SqlDbType.Money);
			param5.Value = this.pledgeAmount;
			command.Parameters.Add(param5);

			SqlParameter param9 = new SqlParameter("RefferedCount", SqlDbType.Int);
			param9.Value = this.refferedCount;
			command.Parameters.Add(param9);

			SqlParameter param10 = new SqlParameter("SatisfactionScore", SqlDbType.Int);
			param10.Value = this.satisfactionScore;
			command.Parameters.Add(param10);


			SqlParameter param4 = new SqlParameter("MembershipDate", SqlDbType.DateTime);
			if (this.membershipDate != null)
			{
				param4.Value = this.membershipDate;
			}
			else
			{
				param4.Value = Convert.DBNull;
			}
			command.Parameters.Add(param4);

			SqlParameter param6 = new SqlParameter("PledgeDate", SqlDbType.DateTime);
			if (this.pledgeDate != null)
			{
				param6.Value = this.pledgeDate;
			}
			else
			{
				param6.Value = Convert.DBNull;
			}
			command.Parameters.Add(param6);

			SqlParameter param7 = new SqlParameter("MembershipStartDate", SqlDbType.DateTime);
			if (this.membershipStartDate != null)
			{
				param7.Value = this.membershipStartDate;
			}
			else
			{
				param7.Value = Convert.DBNull;
			}
			command.Parameters.Add(param7);

			SqlParameter param8 = new SqlParameter("MembershipEndDate", SqlDbType.DateTime);
			if (this.membershipEndDate != null)
			{
				param8.Value = this.membershipEndDate;
			}
			else
			{
				param8.Value = Convert.DBNull;
			}
			command.Parameters.Add(param8);


			SqlParameter paramq = new SqlParameter("MembershipID", SqlDbType.Int);
			paramq.Value = this.id;
			command.Parameters.Add(paramq);

			conn.Open();

			SqlDataReader rs = command.ExecuteReader();
			rs.Read();
			int sqlRetVal = Convert.ToInt32(rs["retVal"]);
			if (sqlRetVal == 1)
			{
				retVal = true;
			}
			rs.Close();
			conn.Close();

			return retVal;
		}

		/// <summary>
		/// deletes a record from the database based on it's ID
		/// </summary>
		/// <param name="id">The ID of the record to delete</param>
		/// <returns>True on success, false on fail</returns>
		public static bool Delete(int id)
		{
			bool retVal = false;

			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("MembershipsDELETE", conn);
			command.CommandType = System.Data.CommandType.StoredProcedure;

			SqlParameter param1 = new SqlParameter("MembershipID", SqlDbType.Int);
			param1.Value = id;
			command.Parameters.Add(param1);

			conn.Open();

			SqlDataReader rs = command.ExecuteReader();
			rs.Read();
			int sqlRetVal = Convert.ToInt32(rs["retVal"]);
			if (sqlRetVal == 1)
			{
				retVal = true;
			}
			rs.Close();
			conn.Close();

			return retVal;
		}

		#region properties
		public int ExporterID
		{
			get
			{
				return this.exporterID;
			}
			set
			{
				this.exporterID = value;
			}
		}
		public int ESPID
		{
			get
			{
				return this.eSPID;
			}
			set
			{
				this.eSPID = value;
			}
		}
		public double MembershipAmount
		{
			get
			{
				return this.membershipAmount;
			}
			set
			{
				this.membershipAmount = value;
			}
		}
		public DateTime? MembershipDate
		{
			get
			{
				return this.membershipDate;
			}
			set
			{
				this.membershipDate = value;
			}
		}
		public double PledgeAmount
		{
			get
			{
				return this.pledgeAmount;
			}
			set
			{
				this.pledgeAmount = value;
			}
		}
		public DateTime? PledgeDate
		{
			get
			{
				return this.pledgeDate;
			}
			set
			{
				this.pledgeDate = value;
			}
		}
		public DateTime? MembershipStartDate
		{
			get
			{
				return this.membershipStartDate;
			}
			set
			{
				this.membershipStartDate = value;
			}
		}
		public DateTime? MembershipEndDate
		{
			get
			{
				return this.membershipEndDate;
			}
			set
			{
				this.membershipEndDate = value;
			}
		}
		public int RefferedCount
		{
			get
			{
				return this.refferedCount;
			}
			set
			{
				this.refferedCount = value;
			}
		}
		public int SatisfactionScore
		{
			get
			{
				return this.satisfactionScore;
			}
			set
			{
				this.satisfactionScore = value;
			}
		}

		#endregion

		#region collection methods
		/// <summary>
		/// Gets a collection containing all records from Memberships in the database
		/// </summary>
		/// <returns>a collection containing all records from Memberships in the database</returns>
		public static List<Membership> GetAll()
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select MembershipID,ExporterID,ESPID,MembershipAmount,MembershipDate,PledgeAmount,PledgeDate,MembershipStartDate,MembershipEndDate,RefferedCount,SatisfactionScore from viewMemberships", conn);

			return baseCollectionCreator(command);
		}

		public static List<Membership> GetByExporterID(int ExporterID)
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select MembershipID,ExporterID,ESPID,MembershipAmount,MembershipDate,PledgeAmount,PledgeDate,MembershipStartDate,MembershipEndDate,RefferedCount,SatisfactionScore from viewMemberships where ExporterID = @id", conn);
			command.Parameters.AddWithValue("@id", ExporterID);

			return baseCollectionCreator(command);
		}

		public static List<Membership> GetByESPID(int ESPID)
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select MembershipID,ExporterID,ESPID,MembershipAmount,MembershipDate,PledgeAmount,PledgeDate,MembershipStartDate,MembershipEndDate,RefferedCount,SatisfactionScore from viewMemberships where ESPID = @id", conn);
			command.Parameters.AddWithValue("@id", ESPID);

			return baseCollectionCreator(command);
		}

		/// <summary>
		/// Generic code that executes a sql statement and formats the results
		/// </summary>
		/// <param name="SqlCommand">The SQL command to be run</param>
		/// <returns>A collection of objects that corrispond to results of the SQL Statement</returns>
		private static List<Membership> baseCollectionCreator(SqlCommand command)
		{
			List<Membership> retVal = new List<Membership>();

			command.Connection.Open();

			SqlDataReader rs = command.ExecuteReader();

			while (rs.Read())
			{
				Membership SN = new Membership();

				SN.id = Convert.ToInt32(rs["MembershipID"]);
				SN.exporterID = Convert.ToInt32(rs["ExporterID"]);
				SN.eSPID = Convert.ToInt32(rs["ESPID"]);
				SN.membershipAmount = Convert.ToDouble(rs["MembershipAmount"]);
				if (rs["MembershipDate"] != Convert.DBNull)
				{
					SN.membershipDate = Convert.ToDateTime(rs["MembershipDate"]);
				}
				else
				{
					SN.membershipDate = null;
				}
				SN.pledgeAmount = Convert.ToDouble(rs["PledgeAmount"]);
				if (rs["PledgeDate"] != Convert.DBNull)
				{
					SN.pledgeDate = Convert.ToDateTime(rs["PledgeDate"]);
				}
				else
				{
					SN.pledgeDate = null;
				}
				if (rs["MembershipStartDate"] != Convert.DBNull)
				{
					SN.membershipStartDate = Convert.ToDateTime(rs["MembershipStartDate"]);
				}
				else
				{
					SN.membershipStartDate = null;
				}
				if (rs["MembershipEndDate"] != Convert.DBNull)
				{
					SN.membershipEndDate = Convert.ToDateTime(rs["MembershipEndDate"]);
				}
				else
				{
					SN.membershipEndDate = null;
				}
				SN.refferedCount = Convert.ToInt32(rs["RefferedCount"]);
				SN.satisfactionScore = Convert.ToInt32(rs["SatisfactionScore"]);


				retVal.Add(SN);
			}
			rs.Close();
			command.Connection.Close();

			return retVal;
		}
		#endregion

		#region sorting

		#endregion
	}
}