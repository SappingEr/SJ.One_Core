using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SJ.One_Core.Models;

namespace SJ.One_Core.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private HttpRequest Request => ViewContext.HttpContext.Request;

        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public PagingViewModel PagingModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (PagingModel == null)
            {
                return;
            }

            if (PagingModel.Count == 0)
            {
                return;
            }
            HttpRequest request = Request;
            string path = request.Path;
            string query = null;

            foreach (var key in request.Query.Keys)
            {
                if (key != "page")
                {
                    query += "&" + key + "=" + request.Query[key];
                }
            }

            int from = 1;
            int pages = PagingModel.Pages;

            output.TagName = "ul";
            output.Attributes.SetAttribute("class", "pagination");
            if (PagingModel.HasPrevious)
            {
                AddPageLink(output, path + $"?page={PagingModel.Index}" + query, "&laquo;");
            }
            for (var i = from; i <= pages; i++)
            {
                if (i == PagingModel.Index + 1)
                {
                    AddCurrentPageLink(output, i);
                }
                else
                {
                    AddPageLink(output, path + $"?page={i}" + query, i.ToString());
                }
            }
            if (PagingModel.HasNext)
            {
                AddPageLink(output, path + $"?page={PagingModel.Page + 1}" + query, "&raquo;");
            }
            output.Content.AppendHtml("</ul>");
        }

        private void AddPageLink(TagHelperOutput output, string url, string text)
        {
            output.Content.AppendHtml("<li class=\"page-item\"><a class=\"page-link\" href=\"");
            output.Content.AppendHtml(url);
            output.Content.AppendHtml("\">");
            output.Content.AppendHtml(text);
            output.Content.AppendHtml("</a>");
            output.Content.AppendHtml("</li>");
        }

        private void AddCurrentPageLink(TagHelperOutput output, int page)
        {
            output.Content.AppendHtml("<li class=\"page-item active\">");
            output.Content.AppendHtml("<span class=\"page-link\">");
            output.Content.AppendHtml(page.ToString());
            output.Content.AppendHtml("</span>");
            output.Content.AppendHtml("</li>");
        }
    }
}

