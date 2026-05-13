using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ExcelLijstPrijs
    {
        public static void CreateDocument(string filePath, string sheetName, string[,] cellen)
        {
            File.Copy(@"C:\Leveringen\TemplatePrijsLijst.xlsx", filePath, true);

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, true))
            {
                WorkbookPart workbookPart = document.WorkbookPart;

                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                for (int rij = 0; rij < cellen.GetLength(0); rij++)
                {
                    Row row = sheetData.Elements<Row>().ElementAt<Row>(rij);

                    for (int kollom = 0; kollom < cellen.GetLength(1); kollom++)
                    {
                        Cell cell = row.Elements<Cell>().ElementAt<Cell>(kollom);

                        if (cellen[rij, kollom] != null)
                        {
                            if (cell.DataType != null)
                            {
                                cell.DataType = CellValues.String;
                                cell.CellValue.Text = cellen[rij, kollom];
                            }
                        }
                    }
                }
            }
        }

        private static string geefCellNaam(int rij, int kollom)
        {
            string r = (rij + 1).ToString();
            string k = ((char)(kollom + 65)).ToString();
            string naam = k + r;
            return naam;
        }
    }
}
