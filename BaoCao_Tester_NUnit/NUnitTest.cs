using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Excel = Microsoft.Office.Interop.Excel;
using BaoCao_KTPM_GK;
using static BaoCao_KTPM_GK.Form1;

namespace BaoCao_Tester_NUnit
{
    [TestFixture]
    public class UnitTest1_62_Trung
    {
        public static IEnumerable<TestCaseData> DocDuLieuTuExcel_62_Trung()
        {
            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Open(@"C:\KTPM\GK\BaoCao_KTPM_GK\BaoCao_Tester_NUnit\Data_62_Trung\TestData_Excel.xlsx");
            var worksheet = (Excel.Worksheet)workbook.Sheets[1];
            var usedRange = worksheet.UsedRange;

            int soLuongDong_62_Trung = usedRange.Rows.Count;

            for (int dong_62_Trung = 2; dong_62_Trung <= soLuongDong_62_Trung; dong_62_Trung++) // Bỏ qua tiêu đề
            {
                double x1_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 1] as Excel.Range).Value2;
                double y1_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 2] as Excel.Range).Value2;
                double x2_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 3] as Excel.Range).Value2;
                double y2_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 4] as Excel.Range).Value2;
                double x3_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 5] as Excel.Range).Value2;
                double y3_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 6] as Excel.Range).Value2;
                double x4_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 7] as Excel.Range).Value2;
                double y4_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 8] as Excel.Range).Value2;
                double dienTichKyVong_62_Trung = (double)(usedRange.Cells[dong_62_Trung, 9] as Excel.Range).Value2;

                yield return new TestCaseData(x1_62_Trung, y1_62_Trung, x2_62_Trung, y2_62_Trung, x3_62_Trung, y3_62_Trung, x4_62_Trung, y4_62_Trung).Returns(dienTichKyVong_62_Trung);
            }

            workbook.Close(false);
            excelApp.Quit();
        }

        [Test, TestCaseSource(nameof(DocDuLieuTuExcel_62_Trung))]
        public double KiemThuTinhDienTich_62_Trung(double x1_62_Trung, double y1_62_Trung, double x2_62_Trung, double y2_62_Trung,
                                                   double x3_62_Trung, double y3_62_Trung, double x4_62_Trung, double y4_62_Trung)
        {
            return Rectangle_62_Trung.CalculateArea_62_Trung(x1_62_Trung, y1_62_Trung, x2_62_Trung, y2_62_Trung, x3_62_Trung, y3_62_Trung, x4_62_Trung, y4_62_Trung);
        }
    }
}
