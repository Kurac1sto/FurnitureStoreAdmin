using System;
using System.Text;
using System.Web.Mvc;
using FurnitureStoreAdmin.BLL.Models;

namespace FurnitureStoreAdmin.Helpers
{
    /// <summary>
    /// Хелпер пагинации
    /// </summary>
    public static class PagingHelper
    {
        public static MvcHtmlString Pages(this HtmlHelper html,
            PageInfo info, Func<int, string> pageUrl)
        {
            StringBuilder builder = new StringBuilder();

            int start = 1;
            int num1 = info.TotalPages;
            int count = num1;
            
            int pageCount = info.TotalPages;
            int? numbersToDisplay = 10;
            if ((pageCount <= numbersToDisplay.GetValueOrDefault() ? 0 : (numbersToDisplay.HasValue ? 1 : 0)) != 0)
            {
                int num2 = numbersToDisplay.Value;
                start = info.PageNumber - num2 / 2;
                if (start < 1)
                    start = 1;
                count = num2;
                num1 = start + count - 1;
                if (num1 > info.TotalPages)
                {
                    start = info.TotalPages - num2 + 1;
                    num1 = info.TotalPages;
                }
            }
            
            TagBuilder firstPage = new TagBuilder("a");
            firstPage.MergeAttribute("href", pageUrl(1));
            firstPage.InnerHtml = "1";
            
            if (info.PageNumber == 1)
            {
                firstPage.AddCssClass("selected");
                firstPage.AddCssClass("btn-primary");
            }
            
            firstPage.AddCssClass("btn btn-default"); 
            builder.Append(firstPage);
            
            for (var i = start; i <= num1; i++)
            {
                if (i != 1 && i != info.TotalPages)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();

                    if (i == info.PageNumber)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                
                    tag.AddCssClass("btn btn-default");
                    builder.Append(tag);   
                }
            }
            
            TagBuilder lastPage = new TagBuilder("a");
            lastPage.MergeAttribute("href", pageUrl(info.TotalPages));
            lastPage.InnerHtml = info.TotalPages.ToString();
            lastPage.AddCssClass("btn btn-default");

            if (info.PageNumber == info.TotalPages)
            {
                lastPage.AddCssClass("selected");
                lastPage.AddCssClass("btn-primary");
            }
            
            builder.Append(lastPage);

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}