using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace AsCartS
{
    public class DataBase
    {
        public static void CriarDiretório()
        {
            // Specify the directory you want to manipulate.
            string path = @"c:\ASRelatorio";

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    CriaBancoSQLite();
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                CriaBancoSQLite();


            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }

        }
        private static SQLiteConnection DBConnection()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=c:\\ASRelatorio\\Database.db; Version=3;");
            conn.Open();
            return conn;
        }

        public static void CriaBancoSQLite()
        {
            try
            {
                var cmd = DBConnection().CreateCommand();
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS RELATORIOS (ID INTEGER PRIMARY KEY AUTOINCREMENT, REMESSA TEXT NOT NULL, PROTESTO TEXT NOT NULL, CERTIDAO INTEGER NOT NULL, QUANTIDADE INTEGER NOT NULL, DATA TEXT NOT NULL, VALOR REAL NOT NULL )";
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static DataTable GetpProtestoAll()
        {
            SQLiteDataAdapter sQLiteData = null;
            DataTable dt = new DataTable();
            try
            {
                var cmd = DBConnection().CreateCommand();
                cmd.CommandText = "SELECT * FROM RELATORIOS";
                sQLiteData = new SQLiteDataAdapter(cmd.CommandText, DBConnection());
                sQLiteData.Fill(dt);
                return dt;
            }
            catch (Exception ex) 
            {
                throw;
            }

        }
        public static DataTable GetProtestoId(int id)
        {
            SQLiteDataAdapter sQLiteData = null;
            DataTable dt = new DataTable();
            try
            {
                var cmd = DBConnection().CreateCommand();
                cmd.CommandText = "SELECT * FROM RELATORIOS WHERE ID =" + id;
                sQLiteData = new SQLiteDataAdapter(cmd.CommandText, DBConnection());
                sQLiteData.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public static void AddProtesto(Relatorio relatorio)
        {
            try
            {
                var cmd = DBConnection().CreateCommand();
                cmd.CommandText = "INSERT INTO RELATORIOS (CERTIDAO, REMESSA, PROTESTO, QUANTIDADE, DATA, VALOR) VALUES ( @CERTIDAO, @REMESSA, @PROTESTO, @QUANTIDADE, @DATA, @VALOR )";;
                cmd.Parameters.AddWithValue("@CERTIDAO", relatorio.Certidao);
                cmd.Parameters.AddWithValue("@REMESSA", relatorio.Remessa);
                cmd.Parameters.AddWithValue("@PROTESTO", relatorio.Protesto);
                cmd.Parameters.AddWithValue("@QUANTIDADE", relatorio.Quantidade);
                cmd.Parameters.AddWithValue("@DATA", relatorio.Data);
                cmd.Parameters.AddWithValue("@VALOR", relatorio.Valor);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetpProtestoData(DateTime datainicial, DateTime datafinal)
        {
            
            SQLiteDataAdapter sQLiteData = null;
            DataTable dt = new DataTable();
            try
            {
                var cmd = DBConnection().CreateCommand();
                cmd.CommandText = "SELECT * FROM RELATORIOS WHERE DATA >=  '"+ datainicial.ToString("dd/MM/yyyy") + "' AND DATA <= '"+ datafinal.ToString("dd/MM/yyyy") + "'";
                
                sQLiteData = new SQLiteDataAdapter(cmd.CommandText, DBConnection());
                
                sQLiteData.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static DataTable GetpProtestoDataAdd(DateTime datainicial)
        {

            SQLiteDataAdapter sQLiteData = null;
            DataTable dt = new DataTable();
            try
            {
                var cmd = DBConnection().CreateCommand();
                cmd.CommandText = "SELECT * FROM RELATORIOS WHERE DATA =  '" + datainicial.ToString("dd/MM/yyyy") + "'";

                sQLiteData = new SQLiteDataAdapter(cmd.CommandText, DBConnection());

                sQLiteData.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
