using sistemaVabel_AppMovil.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemaVabel_AppMovil.Data
{
    public class ServicioGasto
    {
        SQLiteConnection conn;
        public ServicioGasto()
        {
            conn = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, "VabelData.db"));
            conn.CreateTable<GastoModelo>();
        }
        public void insertarGasto(GastoModelo gasto)
        {
            conn.Insert(gasto);
        }
        public void modificar(GastoModelo gasto)
        {
            conn.Update(gasto);
        }
        public void eliminar(GastoModelo gasto)
        {
            if (gasto != null)
            {
                conn.Delete(gasto);
            }
        }
        public GastoModelo buscar(string descripcion)
        {
            List<GastoModelo> lista = conn.Table<GastoModelo>().ToList();
            foreach (GastoModelo c in lista)
            {
                if (c.descripcion == descripcion)
                    return c;
            }
            return null;
        }
        public List<GastoModelo> listarGastos()
        {
            return conn.Table<GastoModelo>().ToList();
        }
    }
}
