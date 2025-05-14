using System;
using System.Windows.Forms;

namespace SendReceiveCom
{
	// Token: 0x02000007 RID: 7
	internal static class Program
	{
		// Token: 0x06000062 RID: 98 RVA: 0x000092E0 File Offset: 0x000074E0
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ComAssistance());
		}

		//// Token: 0x04000071 RID: 113
		//public static string IpPlc { get; set; } = string.Empty;

		//// Token: 0x04000072 RID: 114
		//public static string Port { get; set; } = string.Empty;

		//// Token: 0x04000073 RID: 115
		//public static string Header { get; set; } = string.Empty;

		//// Token: 0x04000074 RID: 116
		//public static string Data { get; set; } = string.Empty;

		//// Token: 0x04000075 RID: 117
		//public static string CheckMode { get; set; } = string.Empty;

		//// Token: 0x04000076 RID: 118
		//public static int CheckNum { get; set; }

  //      // Token: 0x04000077 RID: 119
  //      public static string EndByte { get; set; }

  //      // Token: 0x04000078 RID: 120
  //      public static int EndByteSg { get; set; }

  //      // Token: 0x04000079 RID: 121
  //      public static string Send { get; set; }

  //      // Token: 0x0400007A RID: 122
  //      public static int count { get; set; }

  //      // Token: 0x0400007B RID: 123
  //      public static byte[] imbuffer { get; set; } = new byte[500];

		//// Token: 0x0400007C RID: 124
		//public static byte[] ombuffer { get; set; } = new byte[300];

		//// Token: 0x0400007D RID: 125
		//public static string TempStr { get; set; }

  //      // Token: 0x0400007E RID: 126
  //      public static byte[] TempByte { get; set; } = new byte[300];

		//// Token: 0x0400007F RID: 127
		//public static string Mac { get; set; }

  //      // Token: 0x04000080 RID: 128
  //      public static string Licenses { get; set; }

		//// Token: 0x04000081 RID: 129
		//public static bool IsReg { get; set; } = false;

		//// Token: 0x04000082 RID: 130
		//public static bool Runable { get; set; } = false;
	}
}
