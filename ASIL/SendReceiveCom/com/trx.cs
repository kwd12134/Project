using System;
using System.IO;
using System.Xml.Serialization;

namespace SendReceiveCom.com
{
	// Token: 0x0200000F RID: 15
	public class trx
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000FF RID: 255 RVA: 0x0000FCEA File Offset: 0x0000DEEA
		// (set) Token: 0x06000100 RID: 256 RVA: 0x0000FCF2 File Offset: 0x0000DEF2
		public string trx_name { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000101 RID: 257 RVA: 0x0000FCFB File Offset: 0x0000DEFB
		// (set) Token: 0x06000102 RID: 258 RVA: 0x0000FD03 File Offset: 0x0000DF03
		public string ln_user { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000103 RID: 259 RVA: 0x0000FD0C File Offset: 0x0000DF0C
		// (set) Token: 0x06000104 RID: 260 RVA: 0x0000FD14 File Offset: 0x0000DF14
		public string ln_time { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000105 RID: 261 RVA: 0x0000FD1D File Offset: 0x0000DF1D
		// (set) Token: 0x06000106 RID: 262 RVA: 0x0000FD25 File Offset: 0x0000DF25
		public string message_id { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0000FD2E File Offset: 0x0000DF2E
		// (set) Token: 0x06000108 RID: 264 RVA: 0x0000FD36 File Offset: 0x0000DF36
		public string unifornity { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000FD3F File Offset: 0x0000DF3F
		// (set) Token: 0x0600010A RID: 266 RVA: 0x0000FD47 File Offset: 0x0000DF47
		public string max_lumi { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000FD50 File Offset: 0x0000DF50
		// (set) Token: 0x0600010C RID: 268 RVA: 0x0000FD58 File Offset: 0x0000DF58
		public string type_id { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600010D RID: 269 RVA: 0x0000FD61 File Offset: 0x0000DF61
		// (set) Token: 0x0600010E RID: 270 RVA: 0x0000FD69 File Offset: 0x0000DF69
		public string log_id { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600010F RID: 271 RVA: 0x0000FD72 File Offset: 0x0000DF72
		// (set) Token: 0x06000110 RID: 272 RVA: 0x0000FD7A File Offset: 0x0000DF7A
		public string unique_id { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000111 RID: 273 RVA: 0x0000FD83 File Offset: 0x0000DF83
		// (set) Token: 0x06000112 RID: 274 RVA: 0x0000FD8B File Offset: 0x0000DF8B
		public string jig_id { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000113 RID: 275 RVA: 0x0000FD94 File Offset: 0x0000DF94
		// (set) Token: 0x06000114 RID: 276 RVA: 0x0000FD9C File Offset: 0x0000DF9C
		public string station_id { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000115 RID: 277 RVA: 0x0000FDA5 File Offset: 0x0000DFA5
		// (set) Token: 0x06000116 RID: 278 RVA: 0x0000FDAD File Offset: 0x0000DFAD
		public string test_result { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000117 RID: 279 RVA: 0x0000FDB6 File Offset: 0x0000DFB6
		// (set) Token: 0x06000118 RID: 280 RVA: 0x0000FDBE File Offset: 0x0000DFBE
		public string test_time { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000119 RID: 281 RVA: 0x0000FDC7 File Offset: 0x0000DFC7
		// (set) Token: 0x0600011A RID: 282 RVA: 0x0000FDCF File Offset: 0x0000DFCF
		public string part_no { get; set; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600011B RID: 283 RVA: 0x0000FDD8 File Offset: 0x0000DFD8
		// (set) Token: 0x0600011C RID: 284 RVA: 0x0000FDE0 File Offset: 0x0000DFE0
		public string feedback_io_01 { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600011D RID: 285 RVA: 0x0000FDE9 File Offset: 0x0000DFE9
		// (set) Token: 0x0600011E RID: 286 RVA: 0x0000FDF1 File Offset: 0x0000DFF1
		public string feedback_io_02 { get; set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0000FDFA File Offset: 0x0000DFFA
		// (set) Token: 0x06000120 RID: 288 RVA: 0x0000FE02 File Offset: 0x0000E002
		public string feedback_io_03 { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000121 RID: 289 RVA: 0x0000FE0B File Offset: 0x0000E00B
		// (set) Token: 0x06000122 RID: 290 RVA: 0x0000FE13 File Offset: 0x0000E013
		public string feedback_io_04 { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000123 RID: 291 RVA: 0x0000FE1C File Offset: 0x0000E01C
		// (set) Token: 0x06000124 RID: 292 RVA: 0x0000FE24 File Offset: 0x0000E024
		public string feedback_io_05 { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000125 RID: 293 RVA: 0x0000FE2D File Offset: 0x0000E02D
		// (set) Token: 0x06000126 RID: 294 RVA: 0x0000FE35 File Offset: 0x0000E035
		public string feedback_io_06 { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000127 RID: 295 RVA: 0x0000FE3E File Offset: 0x0000E03E
		// (set) Token: 0x06000128 RID: 296 RVA: 0x0000FE46 File Offset: 0x0000E046
		public string feedback_io_07 { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000129 RID: 297 RVA: 0x0000FE4F File Offset: 0x0000E04F
		// (set) Token: 0x0600012A RID: 298 RVA: 0x0000FE57 File Offset: 0x0000E057
		public string feedback_io_08 { get; set; }

		// Token: 0x0600012C RID: 300 RVA: 0x0000FE60 File Offset: 0x0000E060
		public static void Serialize<T>(T value)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			xmlSerializer.Serialize(File.Open("AsilData", FileMode.OpenOrCreate), value);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000FE98 File Offset: 0x0000E098
		public static string Seriaize<T>(T value)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			StringWriter sw = new StringWriter();
			xmlSerializer.Serialize(sw, value);
			return sw.ToString();
		}
	}
}
