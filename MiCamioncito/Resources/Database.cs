using System.Data;
using System.Data.SqlClient;

namespace MiCamioncito.Resources
{
    public class database
    {
        public static string cadenaConexion = "Data Source=DESKTOP-N4JNAO5;Initial Catalog=MiCamioncito;Integrated Security=True";
        public static DataSet ListarTablas(string nombreProcedimiento, List<Parameter> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Name, parametro.Value);
                    }
                }
                DataSet tabla = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static DataTable Listar(string nombreProcedimiento, List<Parameter> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Name, parametro.Value);
                    }
                }
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);


                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static dynamic Ejecutar(string nombreProcedimiento, List<Parameter> parametros = null)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(parametro.Name, parametro.Value);
                    }
                }

                int i = cmd.ExecuteNonQuery();

                bool success = (i > 0) ? true : false;

                return new
                {
                    succes = success,
                    message = "Successfull"
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    succes = false,
                    message = ex.Message
                };
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
