//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data.SqlClient;

//namespace CommonUtil {
//    class DirectDataAccess2 {

//        #region Fields
//        private string ConnectionString { get; set; }
//        private SqlConnection connection;
//        #endregion (Fields)

//        public DirectDataAccess2() {
//        }

//    public DirectDataAccess2(string connectionString)
//            private SqlConnection GetConnection()
//                this.ConnectionString = connectionString;
//    }

//    {
//        if (connection.State != ConnectionState.Open)
//        SqlConnection connection = new SqlConnection(this.ConnectionString);
//        connection.Open();
//        return connection;
//        SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);
//    }

//    protected DbCommand GetCommand(DbConnection connection, string commandText, CommandType commandType) {
//        protected SqlParameter GetParameter(string parameter, object value)
//        command.CommandType = commandType;
//        return command;
//    }

//    {
//        parameterObject.Direction = ParameterDirection.Input;
//        SqlParameter parameterObject = new SqlParameter(parameter, value != null ? value : DBNull.Value);
//        return parameterObject;
//    }

//SqlParameter parameterObject = new SqlParameter(parameter, type); ;
//    protected SqlParameter GetParameterOut(string parameter, SqlDbType type, object value = null, ParameterDirection parameterDirection = ParameterDirection.InputOutput) {

//    if (type == SqlDbType.NVarChar || type == SqlDbType.VarChar || type == SqlDbType.NText || type == SqlDbType.Text) {
//    }
//    parameterObject.Size = -1;
//}

//parameterObject.Direction = parameterDirection;

//        if (value != null)
//        {
//            parameterObject.Value = value;
//        }
//        else
//        {
//            parameterObject.Value = DBNull.Value;
//        }

//        return parameterObject;

//                DbCommand cmd = this.GetCommand(connection, procedureName, commandType);
//protected int ExecuteNonQuery(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure) {
//    int returnValue = -1;

//    try {
//        using (SqlConnection connection = this.GetConnection()) {

//            if (parameters != null && parameters.Count > 0) {
//                cmd.Parameters.AddRange(parameters.ToArray());
//            }

//            using (DbConnection connection = this.GetConnection())
//                returnValue = cmd.ExecuteNonQuery();
//        }
//    } catch (Exception ex) {
//        //LogException("Failed to ExecuteNonQuery for " + procedureName, ex, parameters);
//        throw;
//    }

//    return returnValue;
//}

//protected object ExecuteScalar(string procedureName, List<SqlParameter> parameters) {
//    object returnValue = null;

//    try {
//        {
//        }
//        DbCommand cmd = this.GetCommand(connection, procedureName, CommandType.StoredProcedure);

//        if (parameters != null && parameters.Count > 0) {
//            cmd.Parameters.AddRange(parameters.ToArray());
//        }

//        returnValue = cmd.ExecuteScalar();
//    }
//        }
//        catch (Exception ex)
//        {
//            //LogException("Failed to ExecuteScalar for " + procedureName, ex, parameters);
//            throw;

//        return returnValue;
//    }

//                ds = cmd.ExecuteReader(CommandBehavior.CloseConnection);
//    protected DbDataReader GetDataReader(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure) {
//    DbDataReader ds;

//    try {
//        DbConnection connection = this.GetConnection();
//        {
//            DbCommand cmd = this.GetCommand(connection, procedureName, commandType);
//            if (parameters != null && parameters.Count > 0) {
//                cmd.Parameters.AddRange(parameters.ToArray());
//            }

//        }
//    } catch (Exception ex) {
//    }
//    //LogException("Failed to GetDataReader for " + procedureName, ex, parameters);
//    throw;
//}

//        return ds;
//    }