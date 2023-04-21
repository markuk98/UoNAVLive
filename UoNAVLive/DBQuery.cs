using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Diagnostics;


namespace UoNAVLive

{
    class QueryDataBase
    {
        //string Connection = @"Data Source=\\\\Yangtzee\shared4\INS\IS_Info\A_Service Strategy\Teams\Service Delivery\Audio Visual and Events\Loan Database\StudentLaptops Live.db";

        string Connection = @"Data Source=\\\northampton\shared\INS\IS_Info\A_Service Strategy\Teams\Service Delivery\Audio Visual and Events\Loan Database\UoNAVLive\UoNWaterSideLiveV1.0.db";

        public string DBSingleRead(string SQLString)
        {
            string ReturnString = "";

            using (System.Data.SQLite.SQLiteConnection Conn = new System.Data.SQLite.SQLiteConnection(Connection))
            {
                using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(Conn))
                {
                    try
                    {
                        Debug.WriteLine("DBSingleRead: " + SQLString);
                        Conn.Open();
                        cmd.CommandText = SQLString;

                        Debug.WriteLine("DBSingleRead DataType: " + cmd.ExecuteScalar().GetType().ToString());
                        if (cmd.ExecuteScalar().GetType() == typeof(DBNull))
                        {
                            ReturnString = "";
                        }
                        else
                        {
                            ReturnString = cmd.ExecuteScalar().ToString();
                        }                        
                        Conn.Close();
                    }
                    catch { }
                }
            }

            return ReturnString;
        }

        public int DBCount(string SQLString)
        {
            Int32 count = 0;

            using (System.Data.SQLite.SQLiteConnection Conn = new System.Data.SQLite.SQLiteConnection(Connection))
            {
                using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(Conn))
                {
                    try
                    {
                        Debug.WriteLine("DBCount: " + SQLString);
                        Conn.Open();
                        cmd.CommandText = SQLString;

                        count = Convert.ToInt32(cmd.ExecuteScalar());
                        Conn.Close();
                    }
                    catch { }
                }
            }

            return count;
        }

        public DataTable DBGetDataSet(string SQLString)
        {
            // Requires using System.Data;
            Debug.WriteLine("DBDBGetDataSetCount: " + SQLString);

            DataTable ReturnData = new DataTable();

            using (var c = new SQLiteConnection(Connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(SQLString, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        Debug.WriteLine("DBSingleRead DataType: " + rdr.GetType().ToString());
                        try { ReturnData.Load(rdr); } catch { }
                    }
                }
                c.Close();
            }

            return ReturnData;
        }

        public void DBWright(string SQLString)
        {
            using (System.Data.SQLite.SQLiteConnection Conn = new System.Data.SQLite.SQLiteConnection(Connection))
            {
                using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(Conn))
                {
                    Debug.WriteLine("DBWright: " + SQLString);
                    Conn.Open();

                    cmd.CommandText = SQLString;
                    //try { cmd.ExecuteNonQuery(); } catch { }
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }
            }
        }




    }


}
