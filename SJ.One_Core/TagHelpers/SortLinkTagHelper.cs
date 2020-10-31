using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SJ.One_Core.Service.Filters;
using System;

namespace SJ.One_Core.TagHelpers
{
    public class SortLinkTagHelper : TagHelper
    {
        private HttpRequest Request => ViewContext.HttpContext.Request;
        private string RouteDataAction => ViewContext.RouteData.Values["action"].ToString();

        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public string Text { get; set; }
        public string Expression { get; set; }
        public string AspController { get; set; }
        public string AspAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            SortDirection sortDirection = SortDirection.Ascending;
            string direction = Request.Query["SortDirection"];
            string expression = Request.Query["SortExpression"];
            string link = $"/{AspController}/{AspAction}?SortExpression={Expression}&SortDirection=";
            string sortLink = link + $"{sortDirection}";
            output.Content.SetContent(Text);
            if (!string.IsNullOrEmpty(direction) && expression == Expression)
            {
                SortDirection sD;
                if (Enum.TryParse(direction, out sD))
                {
                    sortDirection = sD;
                }
                if (sortDirection == SortDirection.Ascending)
                {
                    sortLink = link + $"{SortDirection.Descending}";
                    output.Attributes.SetAttribute("href", sortLink);
                    output.Content.AppendHtml(@"<span class=""fa fa-caret-down""></span>");
                }
                else
                {
                    sortLink = link + $"{SortDirection.Ascending}";
                    output.Attributes.SetAttribute("href", sortLink);
                    output.Content.AppendHtml(@"<span class=""fa fa-caret-up""></span>");
                }
            }
            else
            {
                output.Attributes.SetAttribute("href", sortLink);
            }
        }
    }
}
