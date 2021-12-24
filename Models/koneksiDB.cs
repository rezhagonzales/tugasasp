using MySql.Data.MySqlClient;

namespace latihan1.Models
{
    public class koneksiDB
    {
        private static string username="root";
        private static string password="";
        private static string server="localhost";
        private static string db="kampus1";
        string cs=@"server="+server+";userid="+username+";password="+password+";database="+db;
        private MySqlConnection conn;
        public MySqlConnection openConection(){
            if(conn!=null){
                return conn;
            }else{
                conn=new MySqlConnection(cs);
            }
            return conn;
        }
        public bool CheckConnection(){
            bool result=false;
            MySqlConnection connection=openConection();
            try{
                connection.Open();
                result=true;
                connection.Close();
            }catch(MySqlException ex){
                string err=ex.Message;
                result=false;
            }
            return result;
        }
    }
}