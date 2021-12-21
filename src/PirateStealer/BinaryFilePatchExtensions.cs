using System;
using System.Text;

namespace PirateStealer
{
	// Token: 0x02000005 RID: 5
	public static class BinaryFilePatchExtensions
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000025D4 File Offset: 0x000007D4
		public static string BytesToString(this byte[] bytes, string addBetween = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte value in bytes)
			{
				stringBuilder.Append(value).Append(addBetween);
			}
			StringBuilder stringBuilder2 = stringBuilder;
			int i = stringBuilder2.Length;
			stringBuilder2.Length = i - 1;
			return stringBuilder.ToString();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002620 File Offset: 0x00000820
		public static byte[] HexStringToBytes(this string hex)
		{
			try
			{
				hex = hex.CleanHexString();
				if (hex.Length % 2 == 1)
				{
					return new byte[0];
				}
				byte[] array = new byte[hex.Length >> 1];
				for (int i = 0; i < hex.Length >> 1; i++)
				{
					array[i] = (byte)((hex[i << 1].GetHexVal() << 4) + hex[(i << 1) + 1].GetHexVal());
				}
				return array;
			}
			catch (Exception)
			{
			}
			return new byte[0];
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000207C File Offset: 0x0000027C
		public static int GetHexVal(this char hex)
		{
			return (int)(hex - ((hex < ':') ? '0' : '7'));
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000026B0 File Offset: 0x000008B0
		public static string CleanHexString(this string hexString)
		{
			foreach (string oldValue in BinaryFilePatchExtensions.hexSeparators)
			{
				hexString = hexString.Replace(oldValue, string.Empty);
			}
			return hexString.ToUpper();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000026EC File Offset: 0x000008EC
		public static string FormatHexString(this string hexString, string placeBetweenEachHex)
		{
			string text = hexString.CleanHexString();
			for (int i = text.Length - 2; i > 1; i -= 2)
			{
				text = text.Insert(i, placeBetweenEachHex);
			}
			return text;
		}

		// Token: 0x04000008 RID: 8
		public static readonly string[] hexSeparators = new string[]
		{
			" ",
			"0x",
			"x",
			":",
			"-"
		};
	}
}
