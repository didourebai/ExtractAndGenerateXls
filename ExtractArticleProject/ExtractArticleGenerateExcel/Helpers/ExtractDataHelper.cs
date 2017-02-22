using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ExtractArticleGenerateExcel.Helpers
{
   public static class ExtractDataHelper
    {


       public static void LoadFromUrl(string url)
       {
           HtmlWeb web = new HtmlWeb();
           HtmlDocument doc = web.Load("http://brico-direct.tn/63-quincaillerie-en-ligne?id_category=63&n=275");

           // ParseErrors is an ArrayList containing any errors from the Load statement
           if (doc.ParseErrors != null && doc.ParseErrors.Any())
           {
               // Handle any parse errors as required

           }
           else
           {
               if (doc.DocumentNode != null)
               {
                   HtmlAgilityPack.HtmlNode bodyNode = doc.DocumentNode.SelectSingleNode("//body");

                   if (bodyNode != null)
                   {
                       HtmlNode RootNode = null, FirstDivNode = null, HeaderNode = null; 
                       //declares and instantiates htmlNode needed

                       RootNode = doc.DocumentNode; //Gets the root node of the document and passes to the RootNode
                       //select the first div in the root node or document
FirstDivNode = RootNode.SelectSingleNode(&quot;//div&quot;);

                   }
               }
           }
       }
       public static IList<Article> LoadAndExtract()
       {
           var articles  = new List<Article>();
           HtmlWeb web = new HtmlWeb();
           HtmlDocument doc = web.Load("http://brico-direct.tn/63-quincaillerie-en-ligne?id_category=63&n=275");

           HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class='product-container']");
           HtmlNodeCollection parentNodes = doc.DocumentNode.SelectNodes("//ul[@class='product_list row grid']");
          
           foreach (HtmlNode node in nodes)
           {
              Article article = new Article();
               var childs = node.ChildNodes;
               HtmlNode spanNode = node.SelectSingleNode("//span[@class='price product-price']");
               Console.WriteLine(spanNode.InnerText);
               article.ProductPrice = spanNode.InnerText;

               HtmlNode aherefNode = node.SelectSingleNode("//a[@class='product-name']");

               var title = aherefNode.Attributes["title"].Value;


               article.ProductName = title;

               articles.Add(article);

               Console.WriteLine(aherefNode.InnerText);
           }

          
           
           return articles;
       }
    

    }
}
