/*
 * Дата         Задание     Ответственный       Комментарий
 * 2012-06-28   S-0002      Герасимов           Получение коннекта из файл-настроек
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OracleClient;
using System.Data;

namespace HardX.Utils
{
    public class DBConnection
    {
        public OracleConnection Connection;
        public DBConnection()
        {
            Connection = new OracleConnection();
            Configuration();
        }
        //получение строки соединения с базой данных 
        public static string GetConnectionString()
        {            
            string SID = "HARDX";
            string USER = "hardx";
            string PASSWORD = "zaq12wsx";
            
            string path = "SERVER = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.198.7.22)(PORT = 1521))(CONNECT_DATA = (SID = "+ SID +"))); uid = "+ USER.ToString()+ "; pwd = "+ PASSWORD.ToString()+ ""; //"Data Source=" + SID + "; User ID=" + USER + "; Password=" + PASSWORD + ";Unicode=true";

            return path ;
        }
        //Определение Коннеста к базе 
        public void Configuration()
        {

            Connection.ConnectionString = GetConnectionString();

        }
        //Открытие соединения
        public void Open()
        {
            Connection.Open();
        }
        //Закрытие соединения
        public void Close()
        {
            Connection.Close();
        }
        //Выполнение команды выборки и помещение в таблицу данных
        public void ExecQuerySelect(string Query, ref DataTable Table)
        {
            OracleCommand cmdSelect = new OracleCommand(Query, Connection);
            OracleDataAdapter DataAdapter = new OracleDataAdapter(cmdSelect);
            DataAdapter.Fill(Table);
        }
        //Выполнение команды вставки 
        public void ExecQueryInsert(string Query)
        {
            OracleCommand cmdInsert = new OracleCommand(Query, Connection);
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.ExecuteNonQuery();
        }
        //Выполнение команды обновление
        public void ExecQueryUpdate(string Query)
        {
            ExecQueryInsert(Query);
        }
        //Выполнение команды удаление
        public void ExecQueryDelete(string Query)
        {
            ExecQueryInsert(Query);
        }


    }
}
