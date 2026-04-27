using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;
using sistemaVabel_AppMovil.Models;

namespace sistemaVabel_AppMovil.Data
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _db;
        // Configuramos la ruta donde se guardará el archivo de la base de datos en el celular
        async Task Init()
        {
            if (_db != null) return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "VabelData.db");
            _db = new SQLiteAsyncConnection(databasePath);

            // Creamos las tablas basadas en tus clases
            await _db.CreateTableAsync<Producto>();
            await _db.CreateTableAsync<TransaccionFinanciera>();
        }

        // Ejemplo de método para obtener productos
        public async Task<List<Producto>> GetProductosAsync()
        {
            await Init();
            return await _db.Table<Producto>().ToListAsync();
        }
    }
}
