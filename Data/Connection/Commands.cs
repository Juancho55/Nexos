using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.Connection
{
    public class Commands
    {
        private readonly Properties properties;

        /// <summary>
        /// Constructor by <Commands>;
        /// </summary>
        /// <param name="properties">First object configuration.</param>
        public Commands(Properties properties)
        {
            this.properties = properties;
        }

        /// <summary>
        /// Gets data by sp.
        /// </summary>
        /// <param name="sp">Name sp.</param>
        /// <param name="dtoConsult">Dictionary of consult filter.</param>
        /// <returns>A Datatable.</returns>
        public DataTable CommandsGetAny(string sp, IDictionary<string, object> dtoConsult = null)
        {
            DataTable dt = new DataTable();
            this.properties.Open();
            using (OracleConnection con = this.properties.oracleConnection)
            {                
                using (OracleCommand command = new OracleCommand(sp, con))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(parameterCollection(dtoConsult));
                        command.Parameters.Add("Result", OracleDbType.RefCursor, ParameterDirection.InputOutput);
                        OracleDataAdapter da = new OracleDataAdapter(command);
                        da.Fill(dt);

                        return dt;
                    }
                    catch (Exception)
                    {
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// Sets parameters by dictionary collection.
        /// </summary>
        /// <param name="dtoConsult">Dictionary of data.</param>
        /// <returns>A parameters collection.</returns>
        public OracleParameterCollection parameterCollection(IDictionary<string, object> dtoConsult)
        {
            OracleParameterCollection oracleParameterCollection = null;

            foreach (var item in dtoConsult)
            {
                var T = item.GetType();

                if (T.Equals(typeof(string)))
                    oracleParameterCollection.Add(item.Key, OracleDbType.Varchar2).Value = item.Value;
                if (T.Equals(typeof(Int32)))
                    oracleParameterCollection.Add(item.Key, OracleDbType.Int32).Value = item.Value;
                if (T.Equals(typeof(Int64)))
                    oracleParameterCollection.Add(item.Key, OracleDbType.Int64).Value = item.Value;
                if (T.Equals(typeof(bool)))
                    oracleParameterCollection.Add(item.Key, OracleDbType.Boolean).Value = item.Value;
                if (T.Equals(typeof(DateTime)))
                    oracleParameterCollection.Add(item.Key, OracleDbType.Date).Value = item.Value;

            }

            return oracleParameterCollection;
        }

        /// <summary>
        /// Sets acctions update, delete and insert.
        /// </summary>
        /// <param name="sp">Name sp.</param>
        /// <param name="dtoConsult">Dictionary parameters</param>
        /// <returns>A result command.</returns>
        public bool CommandActionsAny(string sp, IDictionary<string, object> dtoConsult)
        {            
            using (OracleConnection con = this.properties.oracleConnection)
            {
                using (OracleCommand command = new OracleCommand(sp, con))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(parameterCollection(dtoConsult));
                        OracleDataAdapter da = new OracleDataAdapter(command);
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
