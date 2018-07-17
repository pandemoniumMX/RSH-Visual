using MySql.Data.MySqlClient;

namespace Electronica
{
	internal class ConexionBD
	{
		public static MySqlConnection ObtenerConexion()
		{
			return new MySqlConnection("Server =192.168.1.79;port=3306; database = electronicax ; Userid = root; password =; sslmode=none;Allow Zero Datetime=True;Convert Zero Datetime=True;");
		}
	}
}
