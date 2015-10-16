using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace NPU.DataAccess
{
    public class Repository<TDomainObject>
    {
        public int TimeOut = 300;
        public String ConnectionString { get; set; }

        public SqlDatabase Database { get; set; }

        public DbTransaction Transaction { get; set; }

        public DbConnection Connection { get; set; }

        public Repository()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            Database = new SqlDatabase(ConnectionString);
            
        }

        public Repository(SqlDatabase pSqlDatabase)
        {
            this.Database = pSqlDatabase;
        }

        #region CRUD Methods

        public void BeginTransaction()
        {
            Connection = Database.CreateConnection();
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Transaction.Commit();
            Connection.Close();
            Connection.Dispose();
            Transaction.Dispose();
        }

        public void RollbackTransaction()
        {
            Transaction.Rollback();
            Connection.Close();
            Connection.Dispose();
            Transaction.Dispose();
        }

        protected int FindPagedCount(DbCommand pCommand)
        {
            int results = 0;

            try
            {
              //  Database.AddInParameter(pCommand, "SearchString", DbType.String, (pSearchString ?? ""));

                //if (!pDoNotCurrentUserId)
                //    Database.AddInParameter(pCommand, "CurrentUserId", DbType.Guid, CurrentUser.SystemUserId);
                pCommand.CommandTimeout = TimeOut;pCommand.CommandTimeout = TimeOut;
                object result = null;

                if (this.Transaction != null)
                    result = Database.ExecuteScalar(pCommand, this.Transaction);
                else
                    result = Database.ExecuteScalar(pCommand);

                if (result != null)
                    int.TryParse(result.ToString(), out results);

            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
            }

            return results;
        }

        protected XmlDocument FindXMLDoc(DbCommand pCommand)
        {
            XmlReader rdr = null;
            try
            {
                //if (!pDoNotCurrentUserId)
                //    Database.AddInParameter(pCommand, "CurrentUserId", DbType.Guid, CurrentUser.SystemUserId);
                pCommand.CommandTimeout = TimeOut;
                XmlDocument doc = null;

                rdr = Database.ExecuteXmlReader(pCommand);

                while (rdr.Read())
                {
                    doc = new XmlDocument();
                    doc.LoadXml(rdr.ReadOuterXml());

                }
                rdr.Close();
                return doc;


            }
            catch (SqlException)
            {
                if (rdr != null)
                    rdr.Close();
            }

            return null;
        }
  
        protected String FindScalarValue(DbCommand pCommand)
        {
            String results = string.Empty;

            try
            {
                //if (!pDoNotCurrentUserId)
                //    Database.AddInParameter(pCommand, "CurrentUserId", DbType.Guid, CurrentUser.SystemUserId);
                pCommand.CommandTimeout = TimeOut;
                if (this.Transaction != null)
                {
                    using (IDataReader rdr = Database.ExecuteReader(pCommand, this.Transaction))
                    {
                        while (rdr.Read())
                        {
                            results += rdr[0].ToString();
                        }
                    }
                }
                else
                {
                    using (IDataReader rdr = Database.ExecuteReader(pCommand))
                    {
                        while (rdr.Read())
                        {
                            results += rdr[0].ToString();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
            }

            return results;
        }

        protected DataSet ExecuteDataSet(DbCommand pCommand)
        {
            DataSet results = null;

            try
            {
                pCommand.CommandTimeout = TimeOut;
                //if (!pDoNotCurrentUserId)
                //    Database.AddInParameter(pCommand, "CurrentUserId", DbType.Guid, CurrentUser.SystemUserId);

                results = new DataSet();
                results = Database.ExecuteDataSet(pCommand);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
            }

            return results;
        }

        protected List<TDomainObject> FindSorted(DbCommand pCommand, IDomainObjectFactory<TDomainObject> pDomainObjectFactory, String pSortBy )
        {
            List<TDomainObject> results = new List<TDomainObject>();

            try
            {
                pCommand.CommandTimeout = TimeOut;
                Database.AddInParameter(pCommand, "SortBy", DbType.String, pSortBy);               
              
                if (this.Transaction != null)
                {
                    using (IDataReader rdr = Database.ExecuteReader(pCommand, this.Transaction))
                    {
                        while (rdr.Read())
                        {
                            results.Add(pDomainObjectFactory.Construct(rdr));
                        }
                    }
                }
                else
                {
                    using (IDataReader rdr = Database.ExecuteReader(pCommand))
                    {
                        while (rdr.Read())
                        {
                            results.Add(pDomainObjectFactory.Construct(rdr));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
            }

            return results;
        }

        protected List<TDomainObject> Find(DbCommand pCommand, IDomainObjectFactory<TDomainObject> pDomainObjectFactory )
        {
            List<TDomainObject> results = new List<TDomainObject>();

            try
            {
                //if (!pDoNotCurrentUserId)
                //    Database.AddInParameter(pCommand, "CurrentUserId", DbType.Guid, CurrentUser.SystemUserId);
                pCommand.CommandTimeout = TimeOut;
                if (this.Transaction != null)
                {
                    using (IDataReader rdr = Database.ExecuteReader(pCommand, this.Transaction))
                    {
                        while (rdr.Read())
                        {
                            results.Add(pDomainObjectFactory.Construct(rdr));
                        }
                    }
                }
                else
                {
                    using (IDataReader rdr = Database.ExecuteReader(pCommand))
                    {
                        while (rdr.Read())
                        {
                            results.Add(pDomainObjectFactory.Construct(rdr));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
            }

            return results;
        }

        protected TDomainObject FindOne(DbCommand pCommand, IDomainObjectFactory<TDomainObject> pDomainObjectFactory)
        {
            TDomainObject result = default(TDomainObject);

            try
            {
                //if (!pDoNotCurrentUserId)
                //    Database.AddInParameter(pCommand, "CurrentUserId", DbType.Guid, CurrentUser.SystemUserId);
                pCommand.CommandTimeout = TimeOut;
                if (this.Transaction != null)
                {
                    using (IDataReader rdr = Database.ExecuteReader(pCommand, this.Transaction))
                    {
                        if (rdr.Read())
                        {
                            result = pDomainObjectFactory.Construct(rdr);
                        }
                    }
                }
                else
                {
                    using (IDataReader rdr = Database.ExecuteReader(pCommand))
                    {
                        if (rdr.Read())
                        {
                            result = pDomainObjectFactory.Construct(rdr);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);

            }

            return result;
        }

        protected bool Remove(DbCommand pCommand)
        {
            bool result = false;

            try
            {
                //if (!pDoNotCurrentUserId)
                //    Database.AddInParameter(pCommand, "CurrentUserId", DbType.Guid, CurrentUser.SystemUserId);
                pCommand.CommandTimeout = TimeOut;
                if (this.Transaction != null)
                    Database.ExecuteNonQuery(pCommand, this.Transaction);
                else
                    Database.ExecuteNonQuery(pCommand);

                result = true;
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
            }

            return result;
        }

        protected object Add(DbCommand pCommand, String pOutParameter)
        {
            object result = -1;

            try
            {
                pCommand.CommandTimeout = TimeOut;
                if (this.Transaction != null)
                    Database.ExecuteNonQuery(pCommand, this.Transaction);
                else
                    Database.ExecuteNonQuery(pCommand);

                if (pOutParameter.Substring(1, 1) != "@")
                    pOutParameter = "@" + pOutParameter;

                if (pCommand.Parameters[pOutParameter].DbType == DbType.Int16)
                    result = Convert.ToInt16(pCommand.Parameters[pOutParameter].Value);
                else if (pCommand.Parameters[pOutParameter].DbType == DbType.Int32)
                    result = Convert.ToInt32(pCommand.Parameters[pOutParameter].Value);
                else if (pCommand.Parameters[pOutParameter].DbType == DbType.Guid)
                    result = new Guid(pCommand.Parameters[pOutParameter].Value.ToString());
                else
                    result = Convert.ToInt64(pCommand.Parameters[pOutParameter].Value);

                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }           
        }

        protected object Save(DbCommand pCommand, String pOutParameter)
        {
            object result = -1;

            try
            {
                pCommand.CommandTimeout = TimeOut;         
                if (this.Transaction != null)
                    Database.ExecuteNonQuery(pCommand, this.Transaction);
                else
                    Database.ExecuteNonQuery(pCommand);

                if (pOutParameter.Substring(1, 1) != "@")
                    pOutParameter = "@" + pOutParameter;

                if (pCommand.Parameters[pOutParameter].DbType == DbType.Int16)
                    result = Convert.ToInt16(pCommand.Parameters[pOutParameter].Value);
                else if (pCommand.Parameters[pOutParameter].DbType == DbType.Int32)
                    result = Convert.ToInt32(pCommand.Parameters[pOutParameter].Value);
                else if (pCommand.Parameters[pOutParameter].DbType == DbType.Guid)
                    result = new Guid(pCommand.Parameters[pOutParameter].Value.ToString());
                else
                    result = Convert.ToInt64(pCommand.Parameters[pOutParameter].Value);

                return result;
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
            }

            return result;
        }

        protected bool Save(DbCommand pCommand)
        {
            bool result = false;

            try
            {
                pCommand.CommandTimeout = TimeOut;
                if (this.Transaction != null)
                    Database.ExecuteNonQuery(pCommand, this.Transaction);
                else
                    Database.ExecuteNonQuery(pCommand);

                result = true;
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
            }

            return result;
        }


        #endregion


        //protected void Execute(DbCommand pCommand)
        //{
        //    try
        //    {
        //        //if (!pDoNotCurrentUserId)
        //        //    Database.AddInParameter(pCommand, "CurrentUserId", DbType.Guid, CurrentUser.SystemUserId);

        //        if (this.Transaction != null)
        //            Database.ExecuteNonQuery(pCommand, this.Transaction);
        //        else
        //            Database.ExecuteNonQuery(pCommand);
        //    }
        //    catch (SqlException ex)
        //    {
        //        HandleSqlException(ex);
        //    }

        //}

        public void HandleSqlException(SqlException pEx)
        {
            LogException(pEx);
        }

        public void LogException(Exception pEx)
        {
            //System.Diagnostics.Debugger.Break();
            throw pEx;

        }

    }
}