using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

namespace Test{
    public class Database : MonoBehaviour
    {
        private string conn;
        IDbConnection dbConnection;
        private string sqlQuery;

        public void Start() {
            conn = "URI=file:" + Application.dataPath + "/Database.db";
            dbConnection = (IDbConnection) new SqliteConnection(conn);
            dbConnection.Open();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            sqlQuery = "SELECT Id, Name, Description FROM Items";
            dbCommand.CommandText = sqlQuery;
            IDataReader reader = dbCommand.ExecuteReader();

            while (reader.Read())
            {
                int value = reader.GetInt32(0);
                string name = reader.GetString(1);
                string descriptions = reader.GetString(2);
                
                Debug.Log("Id = " + value + " name = " + name + " description = " + descriptions);
            }
            reader.Close();
            reader = null;
            dbCommand.Dispose();
            dbCommand = null;
            dbConnection.Close();
            dbConnection = null;
        }
    }
}

