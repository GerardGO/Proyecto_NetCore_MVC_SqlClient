using ProyAspNetCoreMVC_CRUD.Models;
using Microsoft.Data.SqlClient;
using ProyAspNetCoreMVC_CRUD.Interfaces;

namespace ProyAspNetCoreMVC_CRUD.Dao
{
    public class DistritoDao:IDistritoDao
    {
        //crear variable d solo lectura
        private readonly DBHelper dbHelper;

        public DistritoDao(DBHelper db)
        {
            dbHelper = db;
        }

        public List<Distrito> ListarDistritos()
        {
            var lista = new List<Distrito>();

            SqlDataReader dr = dbHelper.EjecutarSPDataReader("SP_LISTAR_DISTRITOS");

            while (dr.Read())
            {
                lista.Add(new Distrito()
                {
                    cod_dist = dr.GetInt32(0),
                    nom_dist = dr.GetString(1)
                });
            }
            dr.Close();

            return lista;
        }
    }
}
