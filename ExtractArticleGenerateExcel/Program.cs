using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using ExtractArticleGenerateExcel.Helpers;

namespace ExtractArticleGenerateExcel
{
    class Program
    {
        static DataSet dataSet1 = new DataSet();
        static string _uri = ConfigurationManager.AppSettings["URI"];


        public static void Main(string[] args)
        {
            IList<Article> articles = ExtractDataHelper.LoadAndExtract(_uri);


            ExcelGeneratorHelper.ExportToExcelFile(articles, @"D:\articles.xls");
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
