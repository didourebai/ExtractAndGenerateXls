using System.Collections.Generic;
using System.Net;
using HtmlAgilityPack;

namespace ExtractArticleGenerateExcel.Helpers
{
   public static class ExtractDataHelper
    {
 
       public static IList<Article> LoadAndExtract(string uri)
       {
           var articles  = new List<Article>();
           HtmlWeb web = new HtmlWeb();
           HtmlDocument doc = web.Load(uri);



           var nodes =
               doc.DocumentNode.SelectNodes(
                   "//div[@class='product-container']");

           foreach (var node in nodes)
           {
               string nodeHtml = node.InnerHtml;
               HtmlDocument doc1 = new HtmlDocument();
               doc1.LoadHtml(nodeHtml);
               HtmlNode node1 = doc1.DocumentNode.SelectSingleNode(
                 "//a[@class='product-name']");
               HtmlNode node2 = doc1.DocumentNode.SelectSingleNode(
                 "//div[@class='right-block']//div[@class='content_price']//span[@class='price product-price']");
               if (node2 == null)
               {
                   node2 = doc1.DocumentNode.SelectSingleNode("//span[@class='price_promo_display']");
               }
               var article = new Article { ProductName = WebUtility.HtmlDecode(node1.InnerText), ProductPrice = WebUtility.HtmlDecode(node2.InnerText) };
               articles.Add(article);
           }
         
           return articles;
       }
    

    }
}
