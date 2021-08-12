using System;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using Javasdt.Scrape;

namespace Javasdt.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = DbHandler.GetHtml("https://www.n53i.com/");
            //Console.WriteLine(a);

            //<ul class="user_match clear">
            //    <li>年龄：21～30之间</li>
            //    <li>婚史：未婚</li>
            //    <li>地区：不限</li>
            //    <li>身高：175～185厘米之间</li>
            //    <li>学历：不限</li>
            //    <li>职业：不限</li>
            //    <li>月薪：不限</li>
            //    <li>住房：不限</li>
            //    <li>购车：不限</li>
            //</ul>


            WebClient wc = new WebClient();
            wc.BaseAddress = "http://www.juedui100.com/";
            wc.Encoding = Encoding.UTF8;
            HtmlDocument doc = new HtmlDocument();
            string html = "//<ul class=\"user_match clear\">\r\n" +
                "<li>年龄：21～30之间</li>\r\n" +
                "<li>婚史：未婚</li>\r\n" +
                "<li>地区：不限</li>\r\n" +
                "<li>身高：175～185厘米之间</li>\r\n" +
                "<li>学历：不限</li>\r\n" +
                "<li>职业：不限</li>\r\n" +
                "<li>月薪：不限</li>\r\n" +
                "<li>住房：不限</li>\r\n" +
                "<li>购车：不限</li>\r\n" +
                "</ul>";
            doc.LoadHtml(html);
            HtmlNode node = doc.DocumentNode.SelectSingleNode("/ul[1]");     //根据XPath查找节点，跟XmlNode差不多
            Console.WriteLine(node.InnerText);  //输出节点内容      年龄：21～30之间 婚史：未婚 ......      与InnerHtml的区别在于，它不会输出HTML代码
            Console.WriteLine(node.InnerHtml);  //输出节点Html <li>年龄：21～30之间</li> <li>婚史：未婚</li> ....
            Console.WriteLine(node.Name);       //输出 ul    Html元素名 

            HtmlAttributeCollection attrs = node.Attributes;
            foreach (var item in attrs)
            {
                Console.WriteLine(item.Name + " : " + item.Value);    //输出 class ：user_match clear
            }

            HtmlNodeCollection CNodes = node.ChildNodes;    //所有的子节点
            foreach (HtmlNode item in CNodes)
            {
                Console.WriteLine(item.Name + "-" + item.InnerText);  //输出 li-年龄：21～30之间#text-   li-婚史：未婚#text-     .......  别忘了文本节点也算
            }

            Console.WriteLine(node.Closed);     //输出True    //当前的元素节点是否已封闭

            Console.WriteLine("================================");

            HtmlAttributeCollection attrs1 = node.ClosingAttributes;    //获取在结束标记的 HTML 属性的集合。  例如</ul class="">
            Console.WriteLine(attrs1.Count);    //输出0

            HtmlNode node1 = node.FirstChild;   //悲剧了ul的第一个节点是一个 \n 换行文本节点 第二个节点才到第一个li
            Console.WriteLine(node1.NodeType);  //输出Text 文本节点
            HtmlNode node3 = node.LastChild;    //同样最后一个节点一样是 \n 文本节点
            Console.WriteLine(node3.NodeType);  //输出Text 文本节点

            HtmlNode node2 = node.SelectSingleNode("child::li[1]");     //获取当前节点的第一个子li节点
            Console.WriteLine(node2.XPath);     //根据节点生成XPath表达式  /html/body/div[4]/div[1]/div[2]/ul[1]/li[1]   妈了个B，强大

            Console.WriteLine(node.HasAttributes);          //输出 True   判断节点是否含有属性
            Console.WriteLine(node.HasChildNodes);          //输出 True   判断节点是否含有子节点
            Console.WriteLine(node.HasClosingAttributes);   //False     判断节点结束标记是否含有属性

            Console.WriteLine(node.Line);           //输出 155  该节点开始标记位于页面代码的第几行
            Console.WriteLine(node.LinePosition);   //输出 1   该节点开始标记位于第几列2
            Console.WriteLine(node.NodeType);       //输出 Element   该节点类型 此处为元素节点            
            Console.WriteLine(node.OriginalName);   //输出 ul
            HtmlNode node4 = node.SelectSingleNode("child::li[1]");
            Console.WriteLine(node4.InnerText);     //输出 年龄：21～30之间
            HtmlNode node5 = node4.NextSibling.NextSibling;     //获取下一个兄弟元素 因为有一个换行符的文本节点，因此要两次，跳过换行那个文本节点
            Console.WriteLine(node5.InnerText);     //输出 婚史:未婚
            HtmlNode node6 = node5.PreviousSibling.PreviousSibling;     //同样两次以跳过换行文本节点
            Console.WriteLine(node6.InnerText);     //输出 年龄：21～30之间
            HtmlNode node7 = node6.ParentNode;      //获取父节点
            Console.WriteLine(node7.Name);          //输出 ul
            string str = node.OuterHtml;
            Console.WriteLine(str);     //输出整个ul代码class="user_match clear"><li>年龄：21～30之间</li>...</ul>
            Console.WriteLine(node.StreamPosition); //输出7331    获取此节点的流位置在文档中，相对于整个文档(Html页面源代码)的开始。
            HtmlDocument doc1 = node.OwnerDocument;
            doc1.Save(@"D:\123.html");

            HtmlNode node8 = doc.DocumentNode.SelectSingleNode("//*[@id=\"coll_add_aid59710701\"]");
            //<a id="coll_add_aid59710701" style="display:block" class="coll_fix needlogin" href="javascript:coll_add(5971070)">收藏</a>
            Console.WriteLine(node8.Id);    //输出 coll_add_aid59710701   获取Id属性的内容

            Console.ReadKey();
        }
    }
}
