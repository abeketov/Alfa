using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Alfa
{
	class Program
	{
		static void Main(string[] args)
		{
			XLWorkbook Book = new XLWorkbook();
			var Page = Book.Worksheets.Add("Page1");

			Page.Columns(1, 3).Width = 30;

			Page.Cell(1, 1).SetValue("Lowest + Highest")
				.CellBelow().SetValue(1)
				.CellBelow().SetValue(10)
				.CellBelow().SetValue(100);
			Page.RangeUsed().AddConditionalFormat().DataBar(XLColor.Gray).LowestValue().HighestValue();

			Page.Cell(1, 2).SetValue("Number + Number")
				.CellBelow().SetValue(1)
				.CellBelow().SetValue(10)
				.CellBelow().SetValue(100);
			Page.RangeUsed().AddConditionalFormat().DataBar(XLColor.Gray).Minimum(XLCFContentType.Number, 0).Maximum(XLCFContentType.Number, 100);

			Page.Cell(1, 3).SetValue("Manual")
				.CellBelow().SetValue(1)
				.CellBelow().SetValue(10)
				.CellBelow().SetValue(100);

			var FileName = "DataBar.xlsx";
            Book.SaveAs(FileName);
			System.Diagnostics.Process.Start(FileName);
		}
	}
}
