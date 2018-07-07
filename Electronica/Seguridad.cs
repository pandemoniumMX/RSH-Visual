using System;
using System.Text;

namespace Electronica
{
	public static class Seguridad
	{
		public static string Encriptar(this string _cadenaAencriptar)
		{
			string result = string.Empty;
			byte[] encryted = Encoding.Unicode.GetBytes(_cadenaAencriptar);
			return Convert.ToBase64String(encryted);
		}

		public static string DesEncriptar(this string _cadenaAdesencriptar)
		{
			string result = string.Empty;
			byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
			return Encoding.Unicode.GetString(decryted);
		}
	}
}
