using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace db
{
	/// <summary>
	/// Represents records in the Exporters table
	/// </summary>
	/// <remarks>Modified from norm</remarks>
	public class Exporter : DBBase
	{
		private string name;
		private int regionID;
		private int accountManagerUserID;
		private int accountStatusID;
		private DateTime dateAdded;
		private string dOCAccountNumber;
		private string website;
		private string productDescription;
		private string uDF1;
		private string uDF2;
		private string uDF3;
		private DateTime? previousGKDate;
		private string uSEACLocation;
		private string uSEACSpecialistName;
		private bool isSeekingExclusiveRepresentation;
		private string prospectQualifications;
		private string specialFeatures;
		private string requestedCompanies;
		private bool isCurrentlyRepresented;
		private bool isCurrentDistributerAwareOfAdditionalRepresentation;
		private string desiredLocations;
		private DateTime? desiredGKStartDate;
		private DateTime? desiredGKEndDate;
		private DateTime? alternateGKStartDate;
		private DateTime? alternateGKEndDate;
		private bool isFeatured;
		private string specialistName;
		private string specialistLocation;


		/// <summary>
		/// default constuctor initializes several fields
		/// </summary>
		public Exporter()
		{
			dateAdded = DateTime.Now;
			previousGKDate = new DateTime(2001, 1, 1);
			desiredGKStartDate = new DateTime(2001, 1, 1);
			desiredGKEndDate = new DateTime(2001, 1, 1);
			alternateGKStartDate = new DateTime(2001, 1, 1);
			alternateGKEndDate = new DateTime(2001, 1, 1);
			dOCAccountNumber = "";
			website = "";
			productDescription = "";
			uDF1 = "";
			uDF2 = "";
			uDF3 = "";
			uSEACLocation = "";
			uSEACSpecialistName = "";
			prospectQualifications = "";
			specialFeatures = "";
			requestedCompanies = "";
			desiredLocations = "";
			specialistName = "";
			specialistLocation = "";
		}

		/// <summary>
		/// loads values from the database for this object
		/// </summary>
		/// <param name="id">the ID of the record to use</param>
		public Exporter(int id)
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select ExporterID,Name,RegionID,AccountManagerUserID,AccountStatusID,DateAdded,DOCAccountNumber,Website,ProductDescription,UDF1,UDF2,UDF3,PreviousGKDate,USEACLocation,USEACSpecialistName,IsSeekingExclusiveRepresentation,ProspectQualifications,SpecialFeatures,RequestedCompanies,IsCurrentlyRepresented,IsCurrentDistributerAwareOfAdditionalRepresentation,DesiredLocations,DesiredGKStartDate,DesiredGKEndDate,AlternateGKStartDate,AlternateGKEndDate,IsFeatured,SpecialistName,SpecialistLocation from viewExporters where ExporterID = @id", conn);
			command.Parameters.AddWithValue("@id", id);

			conn.Open();

			SqlDataReader rs = command.ExecuteReader();

			if (rs.Read())
			{
				this.id = Convert.ToInt32(rs["ExporterID"]);
				this.name = Convert.ToString(rs["Name"]);
				this.regionID = Convert.ToInt32(rs["RegionID"]);
				this.accountManagerUserID = Convert.ToInt32(rs["AccountManagerUserID"]);
				this.accountStatusID = Convert.ToInt32(rs["AccountStatusID"]);
				this.dateAdded = Convert.ToDateTime(rs["DateAdded"]);
				this.dOCAccountNumber = Convert.ToString(rs["DOCAccountNumber"]);
				this.website = Convert.ToString(rs["Website"]);
				this.productDescription = Convert.ToString(rs["ProductDescription"]);
				this.uDF1 = Convert.ToString(rs["UDF1"]);
				this.uDF2 = Convert.ToString(rs["UDF2"]);
				this.uDF3 = Convert.ToString(rs["UDF3"]);
				if (rs["PreviousGKDate"] != Convert.DBNull)
				{
					this.previousGKDate = Convert.ToDateTime(rs["PreviousGKDate"]);
				}
				else
				{
					this.previousGKDate = null;
				}				
				this.uSEACLocation = Convert.ToString(rs["USEACLocation"]);
				this.uSEACSpecialistName = Convert.ToString(rs["USEACSpecialistName"]);
				this.isSeekingExclusiveRepresentation = Convert.ToBoolean(rs["IsSeekingExclusiveRepresentation"]);
				this.prospectQualifications = Convert.ToString(rs["ProspectQualifications"]);
				this.specialFeatures = Convert.ToString(rs["SpecialFeatures"]);
				this.requestedCompanies = Convert.ToString(rs["RequestedCompanies"]);
				this.isCurrentlyRepresented = Convert.ToBoolean(rs["IsCurrentlyRepresented"]);
				this.isCurrentDistributerAwareOfAdditionalRepresentation = Convert.ToBoolean(rs["IsCurrentDistributerAwareOfAdditionalRepresentation"]);
				this.desiredLocations = Convert.ToString(rs["DesiredLocations"]);
				if (rs["DesiredGKStartDate"] != Convert.DBNull)
				{
					this.desiredGKStartDate = Convert.ToDateTime(rs["DesiredGKStartDate"]);
				}
				else
				{
					this.desiredGKStartDate = null;
				}
				if (rs["DesiredGKEndDate"] != Convert.DBNull)
				{
					this.desiredGKEndDate = Convert.ToDateTime(rs["DesiredGKEndDate"]);
				}
				else
				{
					this.desiredGKEndDate = null;
				}
				if (rs["AlternateGKStartDate"] != Convert.DBNull)
				{
					this.alternateGKStartDate = Convert.ToDateTime(rs["AlternateGKStartDate"]);
				}
				else
				{
					this.alternateGKStartDate = null;
				}
				if (rs["AlternateGKEndDate"] != Convert.DBNull)
				{
					this.alternateGKEndDate = Convert.ToDateTime(rs["AlternateGKEndDate"]);
				}
				else
				{
					this.alternateGKEndDate = null;
				}
				this.isFeatured = Convert.ToBoolean(rs["IsFeatured"]);
				this.specialistName = Convert.ToString(rs["SpecialistName"]);
				this.specialistLocation = Convert.ToString(rs["SpecialistLocation"]);
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
			SqlCommand command = new SqlCommand("ExportersINSERT", conn);
			command.CommandType = System.Data.CommandType.StoredProcedure;

			SqlParameter param1 = new SqlParameter("Name", SqlDbType.VarChar, 50);
			param1.Value = this.name;
			command.Parameters.Add(param1);

			SqlParameter param2 = new SqlParameter("RegionID", SqlDbType.Int);
			param2.Value = this.regionID;
			command.Parameters.Add(param2);

			SqlParameter param3 = new SqlParameter("AccountManagerUserID", SqlDbType.Int);
			param3.Value = this.accountManagerUserID;
			command.Parameters.Add(param3);

			SqlParameter param4 = new SqlParameter("AccountStatusID", SqlDbType.Int);
			param4.Value = this.accountStatusID;
			command.Parameters.Add(param4);

			SqlParameter param5 = new SqlParameter("DateAdded", SqlDbType.DateTime);
			param5.Value = this.dateAdded;
			command.Parameters.Add(param5);

			SqlParameter param6 = new SqlParameter("DOCAccountNumber", SqlDbType.VarChar, 50);
			param6.Value = this.dOCAccountNumber;
			command.Parameters.Add(param6);

			SqlParameter param7 = new SqlParameter("Website", SqlDbType.VarChar, 200);
			param7.Value = this.website;
			command.Parameters.Add(param7);

			SqlParameter param8 = new SqlParameter("ProductDescription", SqlDbType.VarChar, 500);
			param8.Value = this.productDescription;
			command.Parameters.Add(param8);

			SqlParameter param9 = new SqlParameter("UDF1", SqlDbType.VarChar, 500);
			param9.Value = this.uDF1;
			command.Parameters.Add(param9);

			SqlParameter param10 = new SqlParameter("UDF2", SqlDbType.VarChar, 500);
			param10.Value = this.uDF2;
			command.Parameters.Add(param10);

			SqlParameter param11 = new SqlParameter("UDF3", SqlDbType.VarChar, 500);
			param11.Value = this.uDF3;
			command.Parameters.Add(param11);			

			SqlParameter param14 = new SqlParameter("USEACLocation", SqlDbType.VarChar, 50);
			param14.Value = this.uSEACLocation;
			command.Parameters.Add(param14);

			SqlParameter param15 = new SqlParameter("USEACSpecialistName", SqlDbType.VarChar, 50);
			param15.Value = this.uSEACSpecialistName;
			command.Parameters.Add(param15);

			SqlParameter param16 = new SqlParameter("IsSeekingExclusiveRepresentation", SqlDbType.Bit);
			param16.Value = this.isSeekingExclusiveRepresentation;
			command.Parameters.Add(param16);

			SqlParameter param17 = new SqlParameter("ProspectQualifications", SqlDbType.VarChar, 1000);
			param17.Value = this.prospectQualifications;
			command.Parameters.Add(param17);

			SqlParameter param18 = new SqlParameter("SpecialFeatures", SqlDbType.VarChar, 1000);
			param18.Value = this.specialFeatures;
			command.Parameters.Add(param18);

			SqlParameter param19 = new SqlParameter("RequestedCompanies", SqlDbType.VarChar, 500);
			param19.Value = this.requestedCompanies;
			command.Parameters.Add(param19);

			SqlParameter param20 = new SqlParameter("IsCurrentlyRepresented", SqlDbType.Bit);
			param20.Value = this.isCurrentlyRepresented;
			command.Parameters.Add(param20);

			SqlParameter param21 = new SqlParameter("IsCurrentDistributerAwareOfAdditionalRepresentation", SqlDbType.Bit);
			param21.Value = this.isCurrentDistributerAwareOfAdditionalRepresentation;
			command.Parameters.Add(param21);

			SqlParameter param22 = new SqlParameter("DesiredLocations", SqlDbType.VarChar, 500);
			param22.Value = this.desiredLocations;
			command.Parameters.Add(param22);

			SqlParameter param27 = new SqlParameter("IsFeatured", SqlDbType.Bit);
			param27.Value = this.isFeatured;
			command.Parameters.Add(param27);

			SqlParameter param29 = new SqlParameter("SpecialistName", SqlDbType.VarChar, 150);
			param29.Value = this.specialistName;
			command.Parameters.Add(param29);

			SqlParameter param28 = new SqlParameter("SpecialistLocation", SqlDbType.VarChar, 150);
			param28.Value = this.specialistLocation;
			command.Parameters.Add(param28);


			SqlParameter param23 = new SqlParameter("DesiredGKStartDate", SqlDbType.DateTime);
			if (this.desiredGKStartDate != null)
			{
				param23.Value = this.desiredGKStartDate;
			}
			else
			{
				param23.Value = Convert.DBNull;
			}
			command.Parameters.Add(param23);

			SqlParameter param24 = new SqlParameter("DesiredGKEndDate", SqlDbType.DateTime);
			if (this.desiredGKEndDate != null)
			{
				param24.Value = this.desiredGKEndDate;
			}
			else
			{
				param24.Value = Convert.DBNull;
			}
			command.Parameters.Add(param24);

			SqlParameter param25 = new SqlParameter("AlternateGKStartDate", SqlDbType.DateTime);
			if (this.alternateGKStartDate != null)
			{
				param25.Value = this.alternateGKStartDate;
			}
			else
			{
				param25.Value = Convert.DBNull;
			}
			command.Parameters.Add(param25);

			SqlParameter param26 = new SqlParameter("AlternateGKEndDate", SqlDbType.DateTime);
			if (this.alternateGKEndDate != null)
			{
				param26.Value = this.alternateGKEndDate;
			}
			else
			{
				param26.Value = Convert.DBNull;
			}
			command.Parameters.Add(param26);

			SqlParameter param12 = new SqlParameter("PreviousGKDate", SqlDbType.DateTime);
			if (this.previousGKDate != null)
			{
				param12.Value = this.previousGKDate;
			}
			else
			{
				param12.Value = Convert.DBNull;
			}
			command.Parameters.Add(param12);

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
			SqlCommand command = new SqlCommand("ExportersUPDATE", conn);
			command.CommandType = System.Data.CommandType.StoredProcedure;

			SqlParameter param1 = new SqlParameter("Name", SqlDbType.VarChar, 50);
			param1.Value = this.name;
			command.Parameters.Add(param1);

			SqlParameter param2 = new SqlParameter("RegionID", SqlDbType.Int);
			param2.Value = this.regionID;
			command.Parameters.Add(param2);

			SqlParameter param3 = new SqlParameter("AccountManagerUserID", SqlDbType.Int);
			param3.Value = this.accountManagerUserID;
			command.Parameters.Add(param3);

			SqlParameter param4 = new SqlParameter("AccountStatusID", SqlDbType.Int);
			param4.Value = this.accountStatusID;
			command.Parameters.Add(param4);

			SqlParameter param5 = new SqlParameter("DateAdded", SqlDbType.DateTime);
			param5.Value = this.dateAdded;
			command.Parameters.Add(param5);

			SqlParameter param6 = new SqlParameter("DOCAccountNumber", SqlDbType.VarChar, 50);
			param6.Value = this.dOCAccountNumber;
			command.Parameters.Add(param6);

			SqlParameter param7 = new SqlParameter("Website", SqlDbType.VarChar, 200);
			param7.Value = this.website;
			command.Parameters.Add(param7);

			SqlParameter param8 = new SqlParameter("ProductDescription", SqlDbType.VarChar, 500);
			param8.Value = this.productDescription;
			command.Parameters.Add(param8);

			SqlParameter param9 = new SqlParameter("UDF1", SqlDbType.VarChar, 500);
			param9.Value = this.uDF1;
			command.Parameters.Add(param9);

			SqlParameter param10 = new SqlParameter("UDF2", SqlDbType.VarChar, 500);
			param10.Value = this.uDF2;
			command.Parameters.Add(param10);

			SqlParameter param11 = new SqlParameter("UDF3", SqlDbType.VarChar, 500);
			param11.Value = this.uDF3;
			command.Parameters.Add(param11);			

			SqlParameter param14 = new SqlParameter("USEACLocation", SqlDbType.VarChar, 50);
			param14.Value = this.uSEACLocation;
			command.Parameters.Add(param14);

			SqlParameter param15 = new SqlParameter("USEACSpecialistName", SqlDbType.VarChar, 50);
			param15.Value = this.uSEACSpecialistName;
			command.Parameters.Add(param15);

			SqlParameter param16 = new SqlParameter("IsSeekingExclusiveRepresentation", SqlDbType.Bit);
			param16.Value = this.isSeekingExclusiveRepresentation;
			command.Parameters.Add(param16);

			SqlParameter param17 = new SqlParameter("ProspectQualifications", SqlDbType.VarChar, 1000);
			param17.Value = this.prospectQualifications;
			command.Parameters.Add(param17);

			SqlParameter param18 = new SqlParameter("SpecialFeatures", SqlDbType.VarChar, 1000);
			param18.Value = this.specialFeatures;
			command.Parameters.Add(param18);

			SqlParameter param19 = new SqlParameter("RequestedCompanies", SqlDbType.VarChar, 500);
			param19.Value = this.requestedCompanies;
			command.Parameters.Add(param19);

			SqlParameter param20 = new SqlParameter("IsCurrentlyRepresented", SqlDbType.Bit);
			param20.Value = this.isCurrentlyRepresented;
			command.Parameters.Add(param20);

			SqlParameter param21 = new SqlParameter("IsCurrentDistributerAwareOfAdditionalRepresentation", SqlDbType.Bit);
			param21.Value = this.isCurrentDistributerAwareOfAdditionalRepresentation;
			command.Parameters.Add(param21);

			SqlParameter param22 = new SqlParameter("DesiredLocations", SqlDbType.VarChar, 500);
			param22.Value = this.desiredLocations;
			command.Parameters.Add(param22);

			SqlParameter param27 = new SqlParameter("IsFeatured", SqlDbType.Bit);
			param27.Value = this.isFeatured;
			command.Parameters.Add(param27);

			SqlParameter param29 = new SqlParameter("SpecialistName", SqlDbType.VarChar, 150);
			param29.Value = this.specialistName;
			command.Parameters.Add(param29);

			SqlParameter param28 = new SqlParameter("SpecialistLocation", SqlDbType.VarChar, 150);
			param28.Value = this.specialistLocation;
			command.Parameters.Add(param28);


			SqlParameter param23 = new SqlParameter("DesiredGKStartDate", SqlDbType.DateTime);
			if (this.desiredGKStartDate != null)
			{
				param23.Value = this.desiredGKStartDate;
			}
			else
			{
				param23.Value = Convert.DBNull;
			}
			command.Parameters.Add(param23);

			SqlParameter param24 = new SqlParameter("DesiredGKEndDate", SqlDbType.DateTime);
			if (this.desiredGKEndDate != null)
			{
				param24.Value = this.desiredGKEndDate;
			}
			else
			{
				param24.Value = Convert.DBNull;
			}
			command.Parameters.Add(param24);

			SqlParameter param25 = new SqlParameter("AlternateGKStartDate", SqlDbType.DateTime);
			if (this.alternateGKStartDate != null)
			{
				param25.Value = this.alternateGKStartDate;
			}
			else
			{
				param25.Value = Convert.DBNull;
			}
			command.Parameters.Add(param25);

			SqlParameter param26 = new SqlParameter("AlternateGKEndDate", SqlDbType.DateTime);
			if (this.alternateGKEndDate != null)
			{
				param26.Value = this.alternateGKEndDate;
			}
			else
			{
				param26.Value = Convert.DBNull;
			}			
			command.Parameters.Add(param26);

			SqlParameter param12 = new SqlParameter("PreviousGKDate", SqlDbType.DateTime);
			if (this.previousGKDate != null)
			{
				param12.Value = this.previousGKDate;
			}
			else
			{
				param12.Value = Convert.DBNull;
			}			
			command.Parameters.Add(param12);


			SqlParameter paramq = new SqlParameter("ExporterID", SqlDbType.Int);
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
			SqlCommand command = new SqlCommand("ExportersDELETE", conn);
			command.CommandType = System.Data.CommandType.StoredProcedure;

			SqlParameter param1 = new SqlParameter("ExporterID", SqlDbType.Int);
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
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}
		public int RegionID
		{
			get
			{
				return this.regionID;
			}
			set
			{
				this.regionID = value;
			}
		}
		public int AccountManagerUserID
		{
			get
			{
				return this.accountManagerUserID;
			}
			set
			{
				this.accountManagerUserID = value;
			}
		}
		public int AccountStatusID
		{
			get
			{
				return this.accountStatusID;
			}
			set
			{
				this.accountStatusID = value;
			}
		}
		public DateTime DateAdded
		{
			get
			{
				return this.dateAdded;
			}
			set
			{
				this.dateAdded = value;
			}
		}
		public string DOCAccountNumber
		{
			get
			{
				return this.dOCAccountNumber;
			}
			set
			{
				this.dOCAccountNumber = value;
			}
		}
		public string Website
		{
			get
			{
				return this.website;
			}
			set
			{
				this.website = value;
			}
		}
		public string ProductDescription
		{
			get
			{
				return this.productDescription;
			}
			set
			{
				this.productDescription = value;
			}
		}
		public string UDF1
		{
			get
			{
				return this.uDF1;
			}
			set
			{
				this.uDF1 = value;
			}
		}
		public string UDF2
		{
			get
			{
				return this.uDF2;
			}
			set
			{
				this.uDF2 = value;
			}
		}
		public string UDF3
		{
			get
			{
				return this.uDF3;
			}
			set
			{
				this.uDF3 = value;
			}
		}
		public DateTime? PreviousGKDate
		{
			get
			{
				return this.previousGKDate;
			}
			set
			{
				this.previousGKDate = value;
			}
		}
		public string USEACLocation
		{
			get
			{
				return this.uSEACLocation;
			}
			set
			{
				this.uSEACLocation = value;
			}
		}
		public string USEACSpecialistName
		{
			get
			{
				return this.uSEACSpecialistName;
			}
			set
			{
				this.uSEACSpecialistName = value;
			}
		}
		public bool IsSeekingExclusiveRepresentation
		{
			get
			{
				return this.isSeekingExclusiveRepresentation;
			}
			set
			{
				this.isSeekingExclusiveRepresentation = value;
			}
		}
		public string ProspectQualifications
		{
			get
			{
				return this.prospectQualifications;
			}
			set
			{
				this.prospectQualifications = value;
			}
		}
		public string SpecialFeatures
		{
			get
			{
				return this.specialFeatures;
			}
			set
			{
				this.specialFeatures = value;
			}
		}
		public string RequestedCompanies
		{
			get
			{
				return this.requestedCompanies;
			}
			set
			{
				this.requestedCompanies = value;
			}
		}
		public bool IsCurrentlyRepresented
		{
			get
			{
				return this.isCurrentlyRepresented;
			}
			set
			{
				this.isCurrentlyRepresented = value;
			}
		}
		public bool IsCurrentDistributerAwareOfAdditionalRepresentation
		{
			get
			{
				return this.isCurrentDistributerAwareOfAdditionalRepresentation;
			}
			set
			{
				this.isCurrentDistributerAwareOfAdditionalRepresentation = value;
			}
		}
		public string DesiredLocations
		{
			get
			{
				return this.desiredLocations;
			}
			set
			{
				this.desiredLocations = value;
			}
		}
		public DateTime? DesiredGKStartDate
		{
			get
			{
				return this.desiredGKStartDate;
			}
			set
			{
				this.desiredGKStartDate = value;
			}
		}
		public DateTime? DesiredGKEndDate
		{
			get
			{
				return this.desiredGKEndDate;
			}
			set
			{
				this.desiredGKEndDate = value;
			}
		}
		public DateTime? AlternateGKStartDate
		{
			get
			{
				return this.alternateGKStartDate;
			}
			set
			{
				this.alternateGKStartDate = value;
			}
		}
		public DateTime? AlternateGKEndDate
		{
			get
			{
				return this.alternateGKEndDate;
			}
			set
			{
				this.alternateGKEndDate = value;
			}
		}
		public bool IsFeatured
		{
			get
			{
				return this.isFeatured;
			}
			set
			{
				this.isFeatured = value;
			}
		}
		public string SpecialistName
		{
			get
			{
				return this.specialistName;
			}
			set
			{
				this.specialistName = value;
			}
		}
		public string SpecialistLocation
		{
			get
			{
				return this.specialistLocation;
			}
			set
			{
				this.specialistLocation = value;
			}
		}
		public bool HasCurrentMembersip
		{
			get
			{
				bool retVal = false;
				List<Membership> Ms = Membership.GetByExporterID(this.id);
				foreach (Membership M in Ms)
				{
					if (M.MembershipStartDate <= DateTime.Now && M.MembershipEndDate >= DateTime.Now)
					{
						retVal = true;
					}
				}
				return retVal;
			}
		}
		#endregion

		#region collection methods
		public static List<Exporter> GetAllWithWebsiteAndDescription()
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select ExporterID,Name,RegionID,AccountManagerUserID,AccountStatusID,DateAdded,DOCAccountNumber,Website,ProductDescription,UDF1,UDF2,UDF3,PreviousGKDate,USEACLocation,USEACSpecialistName,IsSeekingExclusiveRepresentation,ProspectQualifications,SpecialFeatures,RequestedCompanies,IsCurrentlyRepresented,IsCurrentDistributerAwareOfAdditionalRepresentation,DesiredLocations,DesiredGKStartDate,DesiredGKEndDate,AlternateGKStartDate,AlternateGKEndDate,IsFeatured,SpecialistName,SpecialistLocation from viewExporters where Website != '' and ProductDescription != ''", conn);

			return baseCollectionCreator(command);
		}

		public static List<Exporter> GetFeatured()
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select ExporterID,Name,RegionID,AccountManagerUserID,AccountStatusID,DateAdded,DOCAccountNumber,Website,ProductDescription,UDF1,UDF2,UDF3,PreviousGKDate,USEACLocation,USEACSpecialistName,IsSeekingExclusiveRepresentation,ProspectQualifications,SpecialFeatures,RequestedCompanies,IsCurrentlyRepresented,IsCurrentDistributerAwareOfAdditionalRepresentation,DesiredLocations,DesiredGKStartDate,DesiredGKEndDate,AlternateGKStartDate,AlternateGKEndDate,IsFeatured,SpecialistName,SpecialistLocation from viewExporters where IsFeatured = 1", conn);

			return baseCollectionCreator(command);
		}

		/// <summary>
		/// gets exporters with the specified string in their names
		/// </summary>
		/// <param name="search">the string to look for in the exporter name</param>
		/// <returns>exporters with the specified string in their names</returns>
		public static List<Exporter> GetBySearchString(string search)
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select ExporterID,Name,RegionID,AccountManagerUserID,AccountStatusID,DateAdded,DOCAccountNumber,Website,ProductDescription,UDF1,UDF2,UDF3,PreviousGKDate,USEACLocation,USEACSpecialistName,IsSeekingExclusiveRepresentation,ProspectQualifications,SpecialFeatures,RequestedCompanies,IsCurrentlyRepresented,IsCurrentDistributerAwareOfAdditionalRepresentation,DesiredLocations,DesiredGKStartDate,DesiredGKEndDate,AlternateGKStartDate,AlternateGKEndDate,IsFeatured,SpecialistName,SpecialistLocation from viewExporters where Name like @search", conn);
			command.Parameters.AddWithValue("@search", "%"+search+"%");

			return baseCollectionCreator(command);
		}

		/// <summary>
		/// Gets a collection containing all records from Exporters in the database
		/// </summary>
		/// <returns>a collection containing all records from Exporters in the database</returns>
		public static List<Exporter> GetAll()
		{
			SqlConnection conn = ConnectionHelper.GetSQLConnection();
			SqlCommand command = new SqlCommand("select ExporterID,Name,RegionID,AccountManagerUserID,AccountStatusID,DateAdded,DOCAccountNumber,Website,ProductDescription,UDF1,UDF2,UDF3,PreviousGKDate,USEACLocation,USEACSpecialistName,IsSeekingExclusiveRepresentation,ProspectQualifications,SpecialFeatures,RequestedCompanies,IsCurrentlyRepresented,IsCurrentDistributerAwareOfAdditionalRepresentation,DesiredLocations,DesiredGKStartDate,DesiredGKEndDate,AlternateGKStartDate,AlternateGKEndDate,IsFeatured,SpecialistName,SpecialistLocation from viewExporters", conn);

			return baseCollectionCreator(command);
		}

		/// <summary>
		/// Generic code that executes a sql statement and formats the results
		/// </summary>
		/// <param name="SqlCommand">The SQL command to be run</param>
		/// <returns>A collection of objects that corrispond to results of the SQL Statement</returns>
		private static List<Exporter> baseCollectionCreator(SqlCommand command)
		{
			List<Exporter> retVal = new List<Exporter>();

			command.Connection.Open();

			SqlDataReader rs = command.ExecuteReader();

			while (rs.Read())
			{
				Exporter SN = new Exporter();

				SN.id = Convert.ToInt32(rs["ExporterID"]);
				SN.name = Convert.ToString(rs["Name"]);
				SN.regionID = Convert.ToInt32(rs["RegionID"]);
				SN.accountManagerUserID = Convert.ToInt32(rs["AccountManagerUserID"]);
				SN.accountStatusID = Convert.ToInt32(rs["AccountStatusID"]);
				SN.dateAdded = Convert.ToDateTime(rs["DateAdded"]);
				SN.dOCAccountNumber = Convert.ToString(rs["DOCAccountNumber"]);
				SN.website = Convert.ToString(rs["Website"]);
				SN.productDescription = Convert.ToString(rs["ProductDescription"]);
				SN.uDF1 = Convert.ToString(rs["UDF1"]);
				SN.uDF2 = Convert.ToString(rs["UDF2"]);
				SN.uDF3 = Convert.ToString(rs["UDF3"]);
				if (rs["PreviousGKDate"] != Convert.DBNull)
				{
					SN.previousGKDate = Convert.ToDateTime(rs["PreviousGKDate"]);
				}
				else
				{
					SN.previousGKDate = null;
				}
				SN.uSEACLocation = Convert.ToString(rs["USEACLocation"]);
				SN.uSEACSpecialistName = Convert.ToString(rs["USEACSpecialistName"]);
				SN.isSeekingExclusiveRepresentation = Convert.ToBoolean(rs["IsSeekingExclusiveRepresentation"]);
				SN.prospectQualifications = Convert.ToString(rs["ProspectQualifications"]);
				SN.specialFeatures = Convert.ToString(rs["SpecialFeatures"]);
				SN.requestedCompanies = Convert.ToString(rs["RequestedCompanies"]);
				SN.isCurrentlyRepresented = Convert.ToBoolean(rs["IsCurrentlyRepresented"]);
				SN.isCurrentDistributerAwareOfAdditionalRepresentation = Convert.ToBoolean(rs["IsCurrentDistributerAwareOfAdditionalRepresentation"]);
				SN.desiredLocations = Convert.ToString(rs["DesiredLocations"]);
				if (rs["DesiredGKStartDate"] != Convert.DBNull)
				{
					SN.desiredGKStartDate = Convert.ToDateTime(rs["DesiredGKStartDate"]);
				}
				else
				{
					SN.desiredGKStartDate = null;
				}
				if (rs["DesiredGKEndDate"] != Convert.DBNull)
				{
					SN.desiredGKEndDate = Convert.ToDateTime(rs["DesiredGKEndDate"]);
				}
				else
				{
					SN.desiredGKEndDate = null;
				}
				if (rs["AlternateGKStartDate"] != Convert.DBNull)
				{
					SN.alternateGKStartDate = Convert.ToDateTime(rs["AlternateGKStartDate"]);
				}
				else
				{
					SN.alternateGKStartDate = null;
				}
				if (rs["AlternateGKEndDate"] != Convert.DBNull)
				{
					SN.alternateGKEndDate = Convert.ToDateTime(rs["AlternateGKEndDate"]);
				}
				else
				{
					SN.alternateGKEndDate = null;
				}
				SN.isFeatured = Convert.ToBoolean(rs["IsFeatured"]);
				SN.specialistName = Convert.ToString(rs["SpecialistName"]);
				SN.specialistLocation = Convert.ToString(rs["SpecialistLocation"]);
				retVal.Add(SN);
			}
			rs.Close();
			command.Connection.Close();

			return retVal;
		}
		#endregion

		#region sorting
		/// <summary>
		/// impliments IComparer so that we can sort collections of objects of type Exporter
		/// </summary>
		public class AscendingNameSorter : IComparer<Exporter>
		{
			public int Compare(Exporter x, Exporter y)
			{
				Exporter e1 = (Exporter)x;
				IComparable ic1 = (IComparable)e1.name;

				Exporter e2 = (Exporter)y;
				IComparable ic2 = (IComparable)e2.name;

				return ic1.CompareTo(ic2);
			}
		}
		#endregion
	}
}