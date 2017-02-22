using System;
using System.Collections.Generic;
using System.Data;
using ExtractArticleGenerateExcel.Helpers;
using NPOI.XSSF.UserModel;

namespace ExtractArticleGenerateExcel
{
    class Program
    {
        static DataSet dataSet1 = new DataSet();
        public static void Main(string[] args)
        {
            IList<Article> articles = ExtractDataHelper.LoadAndExtract();


            ExcelGeneratorHelper.ExportToExcelFile(articles, @"D:\articles.xls");
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
