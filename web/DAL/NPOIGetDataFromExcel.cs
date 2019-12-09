using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using System.Data;
using System.Web;

namespace DAL
{
   public class NPOIGetDataFromExcel
    {

        /// <summary>
        /// 将Excel中的数据读取到Dataset中
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataSet GetDataFromExcel(string filePath)
        {
            List<Recruitment> list = new List<Recruitment>();
            IWorkbook workBook = null;
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                if (filePath.IndexOf(".xlsx") > 0)//2007以上版本
                {
                    workBook = new XSSFWorkbook(fs);
                }
                else if (filePath.IndexOf(".xls") > 0)//2003版本
                {
                    workBook = new HSSFWorkbook(fs);
                }
                ISheet sheet = workBook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                //生成标题行
                for (int i = headerRow.FirstCellNum; i < headerRow.LastCellNum; i++)
                {
                    if (headerRow.GetCell(i) != null)
                    {
                        DataColumn header = new DataColumn(headerRow.GetCell(i).ToString());
                        dt.Columns.Add(header);
                    }
                }
                //生成表数据
                for (int i = sheet.FirstRowNum + 1; i < sheet.LastRowNum + 1; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = dt.NewRow();
                    if (row != null)
                    {
                        for (int j = row.FirstCellNum; j < headerRow.LastCellNum; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                ICell cell = row.GetCell(j);
                                if (cell.CellType==CellType.Numeric&&DateUtil.IsCellDateFormatted(cell))
                                {
                                    dataRow[j] = cell.DateCellValue.ToString("yyyy/MM/dd");
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }                               
                            }
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                LogFile(ex.ToString());
                throw ex;
            }
          
           
        }


        public void LogFile(string ex)
        {
            StreamWriter stream;
            //写入日志内容
            string path = AppDomain.CurrentDomain.BaseDirectory;
            //检查上传的物理路径是否存在，不存在则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            stream = new StreamWriter(path + "\\log.txt", true, Encoding.Default);
            stream.Write(DateTime.Now.ToString() + ":" + ex);
            stream.Write("\r\n");
            stream.Flush();
            stream.Close();

        }

       
    }
}
