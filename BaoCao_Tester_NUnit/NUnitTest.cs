using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Excel = Microsoft.Office.Interop.Excel;
using BaoCao_KTPM_GK;
using static BaoCao_KTPM_GK.Form1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Legacy;

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

    [TestClass]
    public class UnitTest_HCNGiaoNhau_51_Dat
    {

        public bool GiaoNhau(Diem_51_Dat left1_51_Dat, Diem_51_Dat right1_51_Dat,
                                Diem_51_Dat left2_51_Dat, Diem_51_Dat right2_51_Dat)
        {
            if (left1_51_Dat.x_51_Dat > right2_51_Dat.x_51_Dat || left2_51_Dat.x_51_Dat > right1_51_Dat.x_51_Dat)
                return false;
            if (right1_51_Dat.y_51_Dat > left2_51_Dat.y_51_Dat || right2_51_Dat.y_51_Dat > left1_51_Dat.y_51_Dat)
                return false;
            return true;
        }

        // Fail test cases
        [TestCase(3, 4, 6, 2, 7, 3, 10, 1, false)] // Hoan toan ben trai
        [TestCase(7, 8, 9, 5, 2, 8, 4, 6, false)] // Hoan toan ben phai
        [TestCase(3, 4, 6, 2, 2, 8, 4, 6, false)] // Hoan toan ben tren
        [TestCase(2, 8, 4, 6, 3, 4, 6, 2, false)] // Hoan toan ben duoi
                                                  // Special pass test cases
        [TestCase(1, 4, 3, 2, 3, 4, 6, 2, true)] // Canh A cham trai B
        [TestCase(3, 4, 6, 2, 3, 6, 6, 4, true)] // Canh A cham canh tren B
        [TestCase(2, 8, 3, 6, 3, 6, 6, 4, true)] // Tiep xuc tai 1 diem
        [TestCase(2, 6, 5, 4, 1, 7, 6, 2, true)] // Nam long trong nhau
                                                 // Normal pass test cases
        [TestCase(1, 1, 1, 1, 1, 1, 1, 1, true)] // Trung nhau hoan toan
        [TestCase(0, 10, 10, 0, 5, 5, 15, 0, true)] // Giao nhau hoan toan
        [TestCase(4, 4, 8, 2, 7, 3, 10, 1, true)] // Giao nhau binh thuong

        public void TCHCN_51_Dat(int x1, int y1, int x2, int y2, int x3, int y3,
                                int x4, int y4, bool expected)
        {
            Diem_51_Dat left1_51_Dat = new Diem_51_Dat(x1, y1);
            Diem_51_Dat right1_51_Dat = new Diem_51_Dat(x2, y2);
            Diem_51_Dat left2_51_Dat = new Diem_51_Dat(x3, y3);
            Diem_51_Dat right2_51_Dat = new Diem_51_Dat(x4, y4);

            bool actual = GiaoNhau(left1_51_Dat, right1_51_Dat,
                                    left2_51_Dat, right2_51_Dat);

            ClassicAssert.AreEqual(expected, actual);
        }

        //Set up to read file
        public static IEnumerable<object[]> TestWithDataSource()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\ASUS\Downloads\HocKy2-Nam3\testingAgain\UnitTestProject1\PlayingBook.xlsx");
            Excel._Worksheet xlWorksheet;
            xlWorksheet = xlWorkbook.Sheets[1];

            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                Diem_51_Dat left1_51_Dat = new Diem_51_Dat((int)xlRange.Cells[i, 1].Value2, (int)xlRange.Cells[i, 2].Value2);
                Diem_51_Dat right1_51_Dat = new Diem_51_Dat((int)xlRange.Cells[i, 3].Value2, (int)xlRange.Cells[i, 4].Value2);
                Diem_51_Dat left2_51_Dat = new Diem_51_Dat((int)xlRange.Cells[i, 5].Value2, (int)xlRange.Cells[i, 6].Value2);
                Diem_51_Dat right2_51_Dat = new Diem_51_Dat((int)xlRange.Cells[i, 7].Value2, (int)xlRange.Cells[i, 8].Value2);
                bool expected = (bool)xlRange.Cells[i, 9].Value2;

                yield return new object[] { left1_51_Dat, right1_51_Dat, left2_51_Dat, right2_51_Dat, expected };
            }

            xlWorkbook.Close();
            xlApp.Quit();
        }

        [TestMethod]
        [DynamicData(nameof(TestWithDataSource), DynamicDataSourceType.Method)]
        public void HCNwithDataSource_51_Dat(Diem_51_Dat left1_51_Dat, Diem_51_Dat right1_51_Dat,
                                             Diem_51_Dat left2_51_Dat, Diem_51_Dat right2_51_Dat, bool expected)
        {
            bool actual = GiaoNhau(left1_51_Dat, right1_51_Dat,
                                    left2_51_Dat, right2_51_Dat);

            ClassicAssert.AreEqual(expected, actual);
        }
    }


}
