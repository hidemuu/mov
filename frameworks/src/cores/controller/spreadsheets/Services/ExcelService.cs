using DocumentFormat.OpenXml.Spreadsheet;
using Mov.Core.SpreadSheets.Models;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Mov.Core.SpreadSheets.Services
{
	public class ExcelService
	{
		#region field

		private SLDocument _spreadSheet;

		#endregion field

		#region constructor

		public ExcelService()
		{
			_spreadSheet = new SLDocument();
		}

		#endregion constructor

		private void Add(WorkSheet sheet, WorkTable table)
		{
			DataTable dataTable = new DataTable(sheet.Name);

			// カラム名の追加
			foreach(var column in table.Columns)
			{
				dataTable.Columns.Add(column.Name, column.Type);
			}

			// Rows.Addメソッドを使ってデータを追加
			for(var i = sheet.FirstRow; i <= sheet.LastRow; i++)
			{
				var cells = sheet.GetRow(i);
				dataTable.Rows.Add(cells.Select(x => x.Value));
			}

			// セルのデータ入力
			_spreadSheet.ImportDataTable("A1", dataTable, true);
			//_spreadSheet.SetCellValue("E1", "(単位  千人)");

			// セルの書式設定
			SLStyle style = null;
			style = _spreadSheet.CreateStyle();
			_spreadSheet.SetColumnWidth(2, 5, 12);
			style.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
			style.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
			style.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
			style.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black);
			_spreadSheet.SetCellStyle("B2", "E49", style);

			style = _spreadSheet.CreateStyle();
			style.SetBottomBorder(BorderStyleValues.Double, System.Drawing.Color.Black);
			style.Fill.SetPatternType(PatternValues.Solid);
			style.Fill.SetPatternForegroundColor(System.Drawing.Color.FromArgb(215, 228, 242));
			_spreadSheet.SetCellStyle("B2", "E2", style);
		}
	}
}
