using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using System.IO;

namespace BLL
{
   public class importDataFromExcelManager
    {
        private ImportDataFromExcel service = new ImportDataFromExcel();

        /// <summary>
        /// 根据文件类型获取不同的连接字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public TableModel<T> GetDataFromExcel<T>(string filePath)
        {
            string connString = string.Empty;
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Exists)
            {
                throw new Exception("文件不存在！");
            }
            string extension = fi.Extension;
            switch (extension)
            {
                case".xls":
                    connString= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
                case ".xlsx":
                    connString= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    break;
                default:
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                    break;
            }
            return service.GetDataFromExcel<T>(connString);
        }
    }
}
