using System;
using Oracle.ManagedDataAccess.Client;

namespace Data.Connection
{
    /// <summary>
    /// Properties class of connection.
    /// </summary>
    public class Properties
    {
        /// <summary>
        /// String connection.
        /// </summary>
        public string strConex;

        /// <summary>
        /// Oracle connection init.
        /// </summary>
        public OracleConnection oracleConnection;

        /// <summary>
        /// Class of properties conecction.
        /// </summary>
        /// <param name="strConex">string connection.</param>
        public Properties(string strConex)
        {
            this.strConex = strConex;
        }

        /// <summary>
        /// Open conecction and set string connection.
        /// </summary>
        public void Open()
        {
            this.oracleConnection = new OracleConnection
            {
                ConnectionString = this.strConex
            };
            this.oracleConnection.Open();
        }

        /// <summary>
        /// Close connection.
        /// </summary>
        public void Close()
        {
            this.oracleConnection.Close();
            this.oracleConnection.Dispose();
        }
    }
}
