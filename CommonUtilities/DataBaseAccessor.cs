﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CommonUtil {
    public class DataBaseAccessor {

        #region Fields
        private string _connectionString { get; set; }
        #endregion (Fields)
        
        #region Constructor
        public DataBaseAccessor() {
            IConfiguration oConfig = ContainerAccess.Get<IConfiguration>();
            //var config = prov.GetService<IConfiguration>();
            var section = oConfig.GetSection("DataSource");
            _connectionString = oConfig["DataSource:ConnectionString"];
            string s = section["ConnectionString"];
        }

        public DataBaseAccessor(string tsConnectionString) {
            this._connectionString = tsConnectionString;
        }
        #endregion (Constructor)

        public SqlConnection GetConnection() {
            SqlConnection connection = new SqlConnection(this._connectionString);
            return connection;
        }

        protected DbCommand GetCommand(DbConnection tcConnection, string commandText, CommandType commandType) {
            SqlCommand command = new SqlCommand(commandText, (SqlConnection)tcConnection);
            command.CommandType = commandType;
            return command;
        }

        protected SqlParameter GetParameter(string parameter, object value) {
            SqlParameter parameterObject = new SqlParameter(parameter, value != null ? value : DBNull.Value);
            parameterObject.Direction = ParameterDirection.Input;
            return parameterObject;
        }

        protected SqlParameter GetParameterOut(string parameter, SqlDbType type, object value = null, ParameterDirection parameterDirection = ParameterDirection.InputOutput) {
            SqlParameter parameterObject = new SqlParameter(parameter, type); ;

            if (type == SqlDbType.NVarChar || type == SqlDbType.VarChar || type == SqlDbType.NText || type == SqlDbType.Text) {
                parameterObject.Size = -1;
            }

            parameterObject.Direction = parameterDirection;

            if (value != null) {
                parameterObject.Value = value;
            } else {
                parameterObject.Value = DBNull.Value;
            }

            return parameterObject;
        }

        public int ExecuteNonQuery(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure) {
            int returnValue = -1;

            try {
                using (SqlConnection connection = this.GetConnection()) {
                    DbCommand cmd = this.GetCommand(connection, procedureName, commandType);

                    if (parameters != null && parameters.Count > 0) {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }
                    returnValue = cmd.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                //LogException("Failed to ExecuteNonQuery for " + procedureName, ex, parameters);
                throw;
            }

            return returnValue;
        }

        protected object ExecuteScalar(string procedureName, List<SqlParameter> parameters) {
            object returnValue = null;

            try {
                using (DbConnection connection = this.GetConnection()) {
                    DbCommand cmd = this.GetCommand(connection, procedureName, CommandType.StoredProcedure);

                    if (parameters != null && parameters.Count > 0) {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }

                    returnValue = cmd.ExecuteScalar();
                }
            } catch (Exception ex) {
                //LogException("Failed to ExecuteScalar for " + procedureName, ex, parameters);
                throw;
            }

            return returnValue;
        }

        protected DbDataReader GetDataReader(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure) {
            DbDataReader ds;

            try {
                DbConnection connection = this.GetConnection();
                {
                    DbCommand cmd = this.GetCommand(connection, procedureName, commandType);
                    if (parameters != null && parameters.Count > 0) {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }

                    ds = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            } catch (Exception ex) {
                //LogException("Failed to GetDataReader for " + procedureName, ex, parameters);
                throw;
            }

            return ds;
        }
    }
}