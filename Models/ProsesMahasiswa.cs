using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace latihan1.Models
{
    public class ProsesMahasiswa
    {
        koneksiDB db=null;
        public ProsesMahasiswa(){
            db=new koneksiDB();           
        }
        public List<DataMahasiswa> getMahasiswa(){
            List<DataMahasiswa> mhs=new List<DataMahasiswa>();
            using(MySqlConnection con=db.openConection())
            {
                string query="Select * from tbl_mhs";
                using(MySqlCommand command=new MySqlCommand(query))
                {
                    command.Connection=con;
                    con.Open();
                    using(MySqlDataReader sdr=command.ExecuteReader())
                    {
                        while(sdr.Read())
                        {
                            mhs.Add(new DataMahasiswa
                            {
                                Id=Convert.ToInt32(sdr["id"]),
                                Nim=sdr["nim"].ToString(),
                                Nama=sdr["nama"].ToString(),
                                Kelas=sdr["kelas"].ToString(),
                                Jurusan=sdr["jurusan"].ToString(),

                            });
                        }
                    }
                    con.Close();

                }
            }
            return mhs;
        }
        public DataMahasiswa GetDataMahasiswaById(string id){
            DataMahasiswa mahasiswa=new DataMahasiswa();
            using(MySqlConnection connection=db.openConection()){
                using(MySqlCommand command=new MySqlCommand()){
                    command.Connection=connection;
                    command.CommandText="select * form tbl_mhs where id=@id";
                    command.Parameters.Add("id",MySqlDbType.Int32).Value=Int32.Parse(id);
                    connection.Open();
                    using(MySqlDataReader reader=command.ExecuteReader()){
                        while(reader.Read()){
                            mahasiswa=new DataMahasiswa{
                                Id=Convert.ToInt32(reader["id"]),
                                Nim=reader["nim"].ToString(),
                                Nama=reader["nama"].ToString(),
                                Kelas=reader["kelas"].ToString(),
                                Jurusan=reader["jurusan"].ToString()
                            };
                        }
                    }
                    connection.Close();
                }
            }
            return mahasiswa;
        }

        public bool updateMahasiswa(DataMahasiswa mahasiswa){
            bool hasil=false;
            using(MySqlConnection connection=db.openConection()){
                using(MySqlCommand command=new MySqlCommand()){
                    command.Connection=connection;
                    connection.Open();
                    command.CommandText="update tbl_mhs set nim=@nim,nama=@nama,kelas=@kls,jusuran=@jrs where id=@id";
                    command.Parameters.Add("nim",MySqlDbType.VarChar).Value=mahasiswa.Nim;
                    command.Parameters.Add("nama",MySqlDbType.VarChar).Value=mahasiswa.Nama;
                    command.Parameters.Add("kls",MySqlDbType.VarChar).Value=mahasiswa.Kelas;
                    command.Parameters.Add("jrs",MySqlDbType.VarChar).Value=mahasiswa.Jurusan;
                    command.Parameters.Add("id",MySqlDbType.Int32).Value=mahasiswa.Id;
                    command.ExecuteNonQuery();
                    connection.Close();
                    hasil=true;
                }
            }
            return hasil;
        }
        public bool deleteMahasiswa(string id){
            bool hasil=false;
            using(MySqlConnection connection=db.openConection()){
                using(MySqlCommand command=new MySqlCommand()){
                    command.Connection=connection;
                    connection.Open();
                    command.CommandText="delete from tbl_mhs where id=@id";
                   
                    command.Parameters.Add("id",MySqlDbType.Int32).Value=Int32.Parse(id);
                    command.ExecuteNonQuery();
                    connection.Close();
                    hasil=true;
                }
            }
            return hasil;
        }
        public bool saveMahasiswa(DataMahasiswa mahasiswa){
            bool hasil=false;
            using(MySqlConnection connection=db.openConection())
            {
                using(MySqlCommand command=new MySqlCommand())
                {
                    command.Connection=connection;
                    connection.Open();
                    command.CommandText="insert into tbl_mhs(nim,nama,kelas,jurusan)"+
                                        "values(@Nim,@Nama,@Kelas,@Jurusan)";
                    command.Parameters.Add("Nim",MySqlDbType.VarChar).Value=mahasiswa.Nim;
                    command.Parameters.Add("Nama",MySqlDbType.VarChar).Value=mahasiswa.Nama;
                    command.Parameters.Add("Kelas",MySqlDbType.VarChar).Value=mahasiswa.Kelas;
                    command.Parameters.Add("jurusan",MySqlDbType.VarChar).Value=mahasiswa.Jurusan;
                    command.ExecuteNonQuery();
                    connection.Close();
                    hasil=true;
                }
            }
            return hasil;
        }
    }
}