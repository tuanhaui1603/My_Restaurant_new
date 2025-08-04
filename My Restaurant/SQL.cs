using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace My_Restaurant
{
    class SQL
    {
    }
    public class ketnoivathucthicoban
    {
        Boolean check = false;
        string conec = "";
        public string loaddata()
        {
            if (check == true)
            {
                return conec;
            }
            else
            {
                try
                {
                    string ip = "107.114.123.43";
                    string port = "1433";
                    string dataname = "MBO_Data";
                    string user = "sa";
                    string pass = "Abc13579";
                    conec = @"Data Source = 107.114.123.43,1433;Network Library = DBMSSOCN;Initial Catalog = MBO_Data; User ID = sa; Password = Abc13579";
                    try
                    {
                        string fs = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Config.ini";
                        var pathfolder = File.Open(fs, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        StreamReader sr = new StreamReader(pathfolder);
                        string[] st = new string[5];
                        int i = 0;
                        while (i < 5)
                        {
                            st[i] = sr.ReadLine();
                            i = i + 1;
                        }
                        sr.Close();
                        ip = st[0].Substring(10, st[0].Length - 10).Trim();
                        port = st[1].Substring(5, st[1].Length - 5).Trim();
                        dataname = st[2].Substring(10, st[2].Length - 10).Trim();
                        user = st[3].Substring(10, st[3].Length - 10).Trim();
                        pass = st[4].Substring(5, st[4].Length - 5).Trim();
                        conec = "Data Source = " + ip + "," + port + "; NetWork Library = DBMSSOCN; Initial Catalog = " + dataname + "; User ID = " + user + "; Password = " + pass;
                        check = true;
                        return (conec);
                    }
                    catch
                    {
                        //MessageBox.Show("" + e);
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public static SqlConnection ketnoi;
        public void moketnoi()
        {
            try
            {
                if (ketnoivathucthicoban.ketnoi == null)
                {
                    ketnoivathucthicoban.ketnoi = new SqlConnection(loaddata());
                }
                if (ketnoivathucthicoban.ketnoi.State != ConnectionState.Open)
                {
                    ketnoivathucthicoban.ketnoi.Open();
                }
            }
            catch
            {

            }
        }
        public void dongketnoi()
        {
            try
            {
                if (ketnoivathucthicoban.ketnoi == null)
                {
                    ketnoivathucthicoban.ketnoi = new SqlConnection(loaddata());
                }
                if (ketnoivathucthicoban.ketnoi.State == ConnectionState.Open)
                {
                    ketnoivathucthicoban.ketnoi.Close();
                }
            }
            catch
            {

            }
        }
        public void lenhthucthisql(string st)
        {
            try
            {
                moketnoi();
                SqlCommand lenh = new SqlCommand(st, ketnoi);
                lenh.ExecuteNonQuery();
                dongketnoi();
            }
            catch
            {

            }
        }
        public DataTable laybangdulieu(string st)
        {
            try
            {
                moketnoi();
                DataTable dt = new DataTable();
                SqlDataAdapter dap = new SqlDataAdapter(st, ketnoi);
                dap.Fill(dt);
                dongketnoi();
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public void Export_Excel(DataTable DTABLE, string SHEET_NAME, string FILE_EXCEL_XLSX)
        {
            //if (SHEET_NAME.Trim() == "")
            //{
            //    MessageBox.Show("Chưa chọn Sheetname");
            //}
            //if (FILE_EXCEL_XLSX.Trim() == "")
            //{
            //    MessageBox.Show("Chưa chọn Filename");
            //}
            //try
            //{
            //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
            //    int k = DTABLE.Rows.Count + 1;
            //    System.IO.FileStream XFile = new System.IO.FileStream(FILE_EXCEL_XLSX.Trim() + ".xlsx", System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //    using (OfficeOpenXml.ExcelPackage ExPCK = new OfficeOpenXml.ExcelPackage(XFile))
            //    {
            //        OfficeOpenXml.ExcelWorksheet EWS = ExPCK.Workbook.Worksheets.Add(SHEET_NAME.Trim());
            //        EWS.Cells[1, 1].LoadFromDataTable(DTABLE, true);
            //        var rang = EWS.Cells["A1:L" + k];
            //        rang.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            //        rang.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            //        rang.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            //        rang.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            //        EWS.Column(2).AutoFit();
            //        Color colo = System.Drawing.Color.FromArgb(192, 192, 100);
            //        EWS.Cells["A1:L1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            //        EWS.Cells["A1:L1"].Style.Fill.BackgroundColor.SetColor(colo);
            //        ExPCK.SaveAs(XFile);
            //    }
            //    XFile.Close();
            //    System.Diagnostics.Process.Start("Excel.exe", FILE_EXCEL_XLSX);
            //}
            //catch
            //{
            //    //MessageBox.Show("" + e);
            //}
        }
    }

    public static class bientoancuc
    {
        public static string name_aoi = "";
        public static string id_aoi = "";
        public static string tk = "";
    }
}
