using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sistemaVabel_AppMovil.Modelo;

namespace sistemaVabel_AppMovil.Control
{
    /*internal class ServicioDB
    {
    }*/

    public class ServicioDB
    {
        string _dbPath;
        SQLiteConnection conn;
        public void crear()
        {
            _dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "sistemaVabelDB.db3");
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<GastoModelo>();
        }
    }
}
