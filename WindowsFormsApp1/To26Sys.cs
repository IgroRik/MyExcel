using System;
using System.Text;

namespace OOP_2
{
	static class To26Sys
	{
		public static string TO(int i)
		{
			string res = "";
			byte[] b = new byte[i + 1];
			int j = 0;
			i += 1;
			i *= 26;
			do
			{
				i = i / 26 - 1;
				b[j] = (byte)(i % 26 + 65);

				j++;
			}
			while (i > 0);


			res = Encoding.ASCII.GetString(b).Trim().Replace("\0", "").Replace("@", "");
			res = reverse.Reverse(res);
			return res;
		}
		public static int FROM(string i)
		{
			int res = 0;
			i = reverse.Reverse(i);
			for (int j = i.Length - 1; j >= 0; j--)
			{
				res += (int)((i[j] - 64) * Math.Pow(26.0, j));
			}

			return res - 1;
		}
	}
	static class reverse
	{
		public static string Reverse(string a)
		{
			string res1 = "";
			char[] res = new char[a.Length];
			for (int i = 0; i < a.Length; i++)
			{
				res[i] = a[a.Length - i - 1];
				res1 += res[i];
			}

			return (res1);
		}
	}
}