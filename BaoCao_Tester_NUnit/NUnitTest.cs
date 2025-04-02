using nu = NUnit.Framework;
using mic = Microsoft.VisualStudio.TestTools.UnitTesting;
using BaoCao_KTPM_GK;
using System;
using System.Collections.Generic;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace BaoCao_Tester_NUnit
{
    [nu.TestFixture]
    public class UnitTest1
    {
        public static IEnumerable<nu.TestCaseData> DocDuLieuTuExcel()
        {
            string filePath = Path.Combine(nu.TestContext.CurrentContext.TestDirectory, "Data", "TestData.xlsx");

            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Open(filePath);
            var worksheet = (Excel.Worksheet)workbook.Sheets[1];
            var usedRange = worksheet.UsedRange;

            int soLuongDong = usedRange.Rows.Count;

            for (int dong = 2; dong <= soLuongDong; dong++) // Bỏ qua tiêu đề
            {
                double x1 = (double)(usedRange.Cells[dong, 1] as Excel.Range).Value2;
                double y1 = (double)(usedRange.Cells[dong, 2] as Excel.Range).Value2;
                double x2 = (double)(usedRange.Cells[dong, 3] as Excel.Range).Value2;
                double y2 = (double)(usedRange.Cells[dong, 4] as Excel.Range).Value2;
                double x3 = (double)(usedRange.Cells[dong, 5] as Excel.Range).Value2;
                double y3 = (double)(usedRange.Cells[dong, 6] as Excel.Range).Value2;
                double x4 = (double)(usedRange.Cells[dong, 7] as Excel.Range).Value2;
                double y4 = (double)(usedRange.Cells[dong, 8] as Excel.Range).Value2;
                double dienTichKyVong = (double)(usedRange.Cells[dong, 9] as Excel.Range).Value2;

                yield return new nu.TestCaseData(x1, y1, x2, y2, x3, y3, x4, y4).Returns(dienTichKyVong);
            }

            workbook.Close(false);
            excelApp.Quit();
        }

        [nu.Test, nu.TestCaseSource(nameof(DocDuLieuTuExcel))]
        public double KiemThuTinhDienTich(double x1, double y1, double x2, double y2,
                                          double x3, double y3, double x4, double y4)
        {
            return HinhChuNhat.TinhDienTich(x1, y1, x2, y2, x3, y3, x4, y4);
        }
    }
}
