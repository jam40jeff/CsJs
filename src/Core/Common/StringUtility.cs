using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MorseCode.CsJs.Common
{
	public static class StringUtility
	{
		private const string KeyString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

		public static string ToBase64(IEnumerable<byte> bytes)
		{
			if (bytes == null)
			{
				return null;
			}

			string output = string.Empty;
			int n = 0;
			int chr1 = 0;
			int chr2 = 0;
			foreach (byte b in bytes)
			{
				switch (n)
				{
					case 0:
						chr1 = b;
						break;
					case 1:
						chr2 = b;
						break;
					case 2:
						{
							int chr3 = b;

							int enc1 = chr1 >> 2;
							int enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
							int enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
							int enc4 = chr3 & 63;

							output = output + KeyString.CharAt(enc1) + KeyString.CharAt(enc2) + KeyString.CharAt(enc3) + KeyString.CharAt(enc4);
						}
						break;
				}

				n++;
				n %= 3;
			}

			if (n > 0)
			{
				if (n < 2)
				{
					chr2 = 0;
				}

				int enc1 = chr1 >> 2;
				int enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
				int enc3 = ((chr2 & 15) << 2);

				if (n < 2)
				{
					enc3 = 64;
				}

				output = output + KeyString.CharAt(enc1) + KeyString.CharAt(enc2) + KeyString.CharAt(enc3) + KeyString.CharAt(64);
			}
			return output;
		}

		public static string ToBase64(string s)
		{
			return ToBase64(Utf8Encode(s));
		}

		private static IEnumerable<byte> Utf8Encode(string s)
		{
			if (s == null)
			{
				return null;
			}

			s = s.Replace(new Regex("\\r\\n", "g"), "\\n");
			List<byte> bytes = new List<byte>();

			for (int i = 0; i < s.Length; i++)
			{
				char c = s.CharCodeAt(i);

				if (c < 128)
				{
					bytes.Add(Script.Reinterpret<byte>((int)c));
				}
				else if ((c > 127) && (c < 2048))
				{
					bytes.Add(Script.Reinterpret<byte>((c >> 6) | 192));
					bytes.Add(Script.Reinterpret<byte>((c & 63) | 128));
				}
				else
				{
					bytes.Add(Script.Reinterpret<byte>((c >> 12) | 224));
					bytes.Add(Script.Reinterpret<byte>(((c >> 6) & 63) | 128));
					bytes.Add(Script.Reinterpret<byte>((c & 63) | 128));
				}
			}

			return bytes;
		}

		public static byte[] FromBase64ToByteArray(string s)
		{
			if (s == null)
			{
				return null;
			}

			s = s.Replace(new Regex("[^A-Za-z0-9\\+\\/\\=]", "g"), string.Empty);
			List<byte> bytes = new List<byte>();

			int n = 0;
			while (n < s.Length)
			{
				// ReSharper disable StringIndexOfIsCultureSpecific.1
				int enc1 = KeyString.IndexOf(s.CharAt(n++));
				int enc2 = KeyString.IndexOf(s.CharAt(n++));
				int enc3 = KeyString.IndexOf(s.CharAt(n++));
				int enc4 = KeyString.IndexOf(s.CharAt(n++));
				// ReSharper restore StringIndexOfIsCultureSpecific.1

				int chr1 = (enc1 << 2) | (enc2 >> 4);
				int chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
				int chr3 = ((enc3 & 3) << 6) | enc4;

				bytes.Add(Script.Reinterpret<byte>(chr1));

				if (enc3 != 64)
				{
					bytes.Add(Script.Reinterpret<byte>(chr2));
				}
				if (enc4 != 64)
				{
					bytes.Add(Script.Reinterpret<byte>(chr3));
				}
			}

			return Script.Reinterpret<byte[]>(bytes);
		}

		public static string FromBase64ToString(string s)
		{
			return Utf8Decode(FromBase64ToByteArray(s));
		}

		private static string Utf8Decode(byte[] bytes)
		{
			string s = string.Empty;

			int n = 0;
			while (n < bytes.Length)
			{
				byte c = bytes[n];

				if (c < 128)
				{
					s += string.FromCharCode(Script.Reinterpret<char>(c));
					n++;
				}
				else if ((c > 191) && (c < 224))
				{
					byte c2 = bytes[n + 1];
					s += string.FromCharCode(Script.Reinterpret<char>(((c & 31) << 6) | (c2 & 63)));
					n += 2;
				}
				else
				{
					byte c2 = bytes[n + 1];
					byte c3 = bytes[n + 2];
					s += string.FromCharCode(Script.Reinterpret<char>(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63)));
					n += 3;
				}
			}

			return s;
		}
	}
}