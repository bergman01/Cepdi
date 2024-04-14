using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;
using System.Diagnostics.Contracts;

namespace CRUDCORE.Datos
{
    public class UsuarioDatos
    {

        public List<UsuarioModel> Listar() { 
        
            var oLista = new List<UsuarioModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL())) { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("select * from v_usuarios", conexion);
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader()) {

                    while (dr.Read()) {
                        oLista.Add(new UsuarioModel() {
                            Id = Convert.ToInt32(dr["idusuario"]),
                            Nombre = dr["nombre"].ToString(),
                            FechaCreacion = dr["fechacreacion"].ToString(),
                            Usuario = dr["usuario"].ToString(),
                            IdPerfil = Convert.ToInt32(dr["idperfil"]),
                            Estatus = dr["estatus"].ToString(),
                        });

                    }
                }
            }

            return oLista;
        }

        public UsuarioModel Obtener(int Id)
        {

            var oUsuario = new UsuarioModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener_Usuario", conexion);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oUsuario.Id = Convert.ToInt32(dr["idusuario"]);
                        oUsuario.Nombre = dr["nombre"].ToString();
                        oUsuario.FechaCreacion = dr["fechacreacion"].ToString();
                        oUsuario.Usuario = dr["usuario"].ToString();
                        oUsuario.Password = dr["password"].ToString();
                        oUsuario.IdPerfil = Convert.ToInt32(dr["idperfil"]);
                        oUsuario.Estatus = dr["estatus"].ToString();
                        oUsuario.IdEstatus = Convert.ToInt32(dr["idestatus"]);
                    }
                }
            }

            return oUsuario;
        }

        public bool Guardar(UsuarioModel oUsuario) {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
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


        public bool Editar(UsuarioModel oUsuario)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Id", oUsuario.Id);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.Nombre);
                    cmd.Parameters.AddWithValue("Usuario", oUsuario.Usuario);
                    cmd.Parameters.AddWithValue("Password", oUsuario.Password);
                    cmd.Parameters.AddWithValue("IdPerfil", oUsuario.IdPerfil);
                    cmd.Parameters.AddWithValue("IdEstatus", oUsuario.IdEstatus);
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
                    SqlCommand cmd = new SqlCommand("sp_Eliminar_Usuario", conexion);
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
