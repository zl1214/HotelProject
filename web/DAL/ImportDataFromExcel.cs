using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Models;

namespace DAL
{
   public class ImportDataFromExcel
    {
        /// <summary>
        /// 连接Excel的方法
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        public DataSet GetDataSetFromExcel(string sql, string connString)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql,conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }      

        }

        /// <summary>
        ///从Excel中获取可以被layui识别的实体数据集合
        /// </summary>
        /// <typeparam name="T">excel对应的数据库实体类名称</typeparam>
        /// <param name="filePath">文件的路径（保持工作簿与工作表的名称一致）</param>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        public TableModel<T> GetDataFromExcel<T>(string connString)
        {
            List<T> list = new List<T>();
            //string sheetName = filePath.Substring(filePath.LastIndexOf("/"),filePath.IndexOf(".")- filePath.LastIndexOf("/"));//根据路径获取表名称
            string sql = "select * from [Sheet1$]";//查询工作表中的所有数据
            DataSet ds = GetDataSetFromExcel(sql, connString);
            DataTable dt = ds.Tables[0];

            //使用反射给泛型类赋值
            Type classType = typeof(T);
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                T t = Activator.CreateInstance<T>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {                    
                    var property = classType.GetProperty(dt.Columns[j].ColumnName);
                    object value = dt.Rows[i][""+ dt.Columns[j].ColumnName + ""];
                    if (property!=null&&property.CanWrite)
                    {
                        property.SetValue(t, value, null);
                    }
                }
                list.Add(t);
            }

            TableModel<T> table = new TableModel<T>();
            table.code = 0;
            table.count = list.Count;
            table.data = list;
            return table;           
        }
    }
}
