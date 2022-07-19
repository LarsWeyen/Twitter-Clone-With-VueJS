using ClassLibrary.Settings;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibTeam01.Data.Framework
{
    public abstract class SqlCommands
    {
        private SqlConnection sqlConn;

        public SqlCommands(string tableName)
        {
            TableName = tableName;
            sqlConn = new SqlConnection(Settings.Database.ProjectConnectionstring);
        }

        protected BaseResult BaseResult { get; set; }
        protected string TableName { get; set; }

        #region Select

        protected void SelectRecords()
        {
            try
            {
                string query = $"Select * from {TableName}";
                SelectRecords(query);
            }
            catch (Exception ex)
            {
                BaseResult.AddErrors(ex.Message);
            }
        }

        protected void SelectRecords(string query)
        {
            try
            {
                BaseResult = new SelectResult();
                using (sqlConn)
                {
                    sqlConn.Open();
                    var sqlCommand = new SqlCommand(query, sqlConn);
                    var adapter = new SqlDataAdapter(sqlCommand);
                    BaseResult.DataTable = new DataTable();
                    BaseResult.Rows = adapter.Fill(BaseResult.DataTable);
                    sqlConn.Close();
                }
                BaseResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                BaseResult.AddErrors(ex.Message);
            }
        }

        //protected void SelectRecords(string query)
        //{
        //    try
        //    {
        //        using (SqlCommand sqlComm = new SqlCommand(query))
        //        {
        //            SelectRecords(sqlComm);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        BaseResult.AddErrors(ex.Message);
        //    }
        //}
        protected void SelectRecords(SqlCommand selectCommand)
        {
            try
            {
                BaseResult = new SelectResult();
                using (sqlConn)
                {
                    sqlConn.Open();
                    var adapter = new SqlDataAdapter(selectCommand);
                    BaseResult.DataTable = new DataTable();
                    BaseResult.Rows = adapter.Fill(BaseResult.DataTable);
                    sqlConn.Close();
                }
                BaseResult.Succeeded = true;
            }
            catch (Exception ex)
            {
                BaseResult.AddErrors(ex.Message);
            }
        }

        #endregion Select

        protected InsertResult InsertRecord(SqlCommand insertCommand)
        {
            var result = new InsertResult();
            try
            {
                using (sqlConn)
                {
                    insertCommand.CommandText += "SET @new_id = SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.Connection = sqlConn;
                    sqlConn.Open();
                    insertCommand.ExecuteNonQuery();
                    int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                    result.NewId = newId;
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        protected UpdateResult UpdateRecord(SqlCommand updateCommand)
        {
            var result = new UpdateResult();
            try
            {
                using (sqlConn)
                {
                    updateCommand.Connection = sqlConn;
                    sqlConn.Open();
                    updateCommand.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        protected DeleteResullt DeleteRecord(SqlCommand deleteCommand)
        {
            var result = new DeleteResullt();
            try
            {
                using (sqlConn)
                {
                    deleteCommand.Connection = sqlConn;
                    sqlConn.Open();
                    deleteCommand.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}