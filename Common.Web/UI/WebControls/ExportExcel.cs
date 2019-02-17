﻿using System.IO;

namespace System.Web.UI.WebControls
{
    public class ExportExcel
    {
        /// <summary>
        /// 将整个网页导出来Excel
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="FileName"></param>
        protected void ExportData(string strContent, string FileName)
        {
            FileName = FileName + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "gb2312";
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            //this.Page.EnableViewState = false;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ".xls");
            // 把文件流发送到客户端
            HttpContext.Current.Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">");
            HttpContext.Current.Response.Write(strContent);

            HttpContext.Current.Response.Write("</body></html>");
            // 停止页面的执行
            //Response.End();
        }

        /// <summary>
        /// 将GridView数据导出Excel
        /// </summary>
        /// <param name="obj"></param>
        public void ExportData(GridView obj)
        {
            try
            {
                var style = obj.Rows.Count > 0 ? @"<style> .text { mso-number-format:\@; } </script> " : "no data.";
                HttpContext.Current.Response.ClearContent();
                var dt = DateTime.Now;
                var filename = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour.ToString() + dt.Minute.ToString() + dt.Second.ToString();
                HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=ExportData" + filename + ".xls");
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.Charset = "GB2312";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
                var sw = new StringWriter();
                var htw = new HtmlTextWriter(sw);
                obj.RenderControl(htw);
                HttpContext.Current.Response.Write(style);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
            catch
            {
            }
        }
    }
}