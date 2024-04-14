using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;
using System.Diagnostics.Contracts;

namespace CRUDCORE.Datos
{
    public class ContactoDatos
    {

        public List<ContactoModel> Listar() { 
        
            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select * from v_medicamentos", conexion);
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new ContactoModel() {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString(),
                            Concentracion = dr["Concentracion"].ToString(),
                            IdFormaFarmaceutica = Convert.ToInt32(dr["IdFormaFarmaceutica"]),
                            FormasFarmaceuticas = dr["FormasFarmaceuticas"].ToString(),
                            Precio = dr["Precio"].ToString(),
                            Stock = dr["Stock"].ToString(),
                            Presentacion = dr["Presentacion"].ToString(),
                            Estatus = dr["Estatus"].ToString(),

                        });

                    }
                }
            }

            return oLista;
        }

        public ContactoModel Obtener(int Id)
        {

            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oContacto.Id = Convert.ToInt32(dr["Id"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Concentracion = dr["Concentracion"].ToString();
                        oContacto.IdFormaFarmaceutica = Convert.ToInt32(dr["IdFormaFarmaceutica"]);
                        oContacto.FormasFarmaceuticas = dr["FormasFarmaceuticas"].ToString();
                        oContacto.Precio = dr["Precio"].ToString();
                        oContacto.Stock = dr["Stock"].ToString();
                        oContacto.Presentacion = dr["Presentacion"].ToString();
                        oContacto.Estatus = dr["Estatus"].ToString();
                        oContacto.IdEstatus = Convert.ToInt32(dr["IdEstatus"]);
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactoModel ocontacto) {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e) {

                string error = e.Message;
                rpta = false;
            }



            return rpta;
        }


        public bool Editar(ContactoModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id", ocontacto.Id);
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Concentracion", ocontacto.Concentracion);
                    cmd.Parameters.AddWithValue("IdFormaFarmeceutica", ocontacto.IdFormaFarmaceutica);
                    cmd.Parameters.AddWithValue("Precio", ocontacto.Precio);
                    cmd.Parameters.AddWithValue("Stock", ocontacto.Stock);
                    cmd.Parameters.AddWithValue("IdEstatus", ocontacto.IdEstatus);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int Id)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;


            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


    }
}
