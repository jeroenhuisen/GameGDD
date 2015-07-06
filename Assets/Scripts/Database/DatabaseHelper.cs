using UnityEngine;
using System.Collections;
using System.IO;



public class DatabaseHelper
{
    private SqliteDatabase sqlDB;
    public DatabaseHelper(){
        try
        {
            sqlDB = new SqliteDatabase("database.db");
            //string query = "INSERT INTO Records(map, car, time, playerName) VALUES( 'Map', 'Car', '0:00:00', 'Player')";
            //sqlDB.ExecuteNonQuery(query);
            string selectQuery = "SELECT * FROM Records";
            DataTable result = sqlDB.ExecuteQuery(selectQuery);
            result.Columns.GetEnumerator();
            foreach (var pair in result.Columns)
            {
                Debug.Log("Column: " + pair);
            }
            foreach (var pair in result.Rows)
            {
                foreach (var pair2 in pair.Keys)
                {
                    Debug.Log("par2K: " + pair2);
                }
                foreach (var pair2 in pair.Values)
                {
                    Debug.Log("par2V: " + pair2);
                }
            }
        }
        catch (SqliteException e)
        {
            Debug.LogError(e.ToString());
        }
    }

    public void insertNewRoundTime(string map, string car, string time, string playerName)
    {
        string query = "INSERT INTO Records(map, car, time, playerName) VALUES( '" + map +"' , '"+ car + "', '"+ time +"', '"+ playerName + "')";
        sqlDB.ExecuteNonQuery(query);
    }

    public string getPersonalBest(string map, string playerName)
    {
        string query = "SELECT MIN(time) AS time FROM Records where map=" + map + " AND playerName=" + playerName;
        DataTable result  = sqlDB.ExecuteQuery(query);
        if (result.Rows.Count > 0)
        {
            string pbTime = "";
            foreach (var pair2 in result.Rows[1].Values)
            {
                Debug.Log("par2V: " + pair2);
                pbTime = pair2.ToString();
            }
            return pbTime;
        }
        else
        {
            return "--:--:--";
        }
    }

    public string getBest(string map)
    {
        string query = "SELECT MIN(time) AS time FROM Records where map=" + map;
        DataTable result = sqlDB.ExecuteQuery(query);
        if (result.Rows.Count > 0)
        {
            string pbTime = "";
            foreach (var pair2 in result.Rows[1].Values)
            {
                Debug.Log("par2V: " + pair2);
                pbTime = pair2.ToString();
            }
            return pbTime;
        }
        else
        {
            return "--:--:--";
        }
    }
}
