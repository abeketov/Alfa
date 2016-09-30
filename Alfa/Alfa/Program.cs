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
			Page.Cell(1, 1).Value = 1;
			Page.Cell(2, 1).Value = 10;
			Page.Cell(3, 1).Value = 100;

			Page.Column(1).Width = 20;
			Page.Range(1, 1, 3, 1).AddConditionalFormat().DataBar(XLColor.Gray).LowestValue().HighestValue();

			var FileName = "DataBar.xlsx";
            Book.SaveAs(FileName);
			System.Diagnostics.Process.Start(FileName);
		}
	}
}
