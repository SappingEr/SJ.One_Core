using Microsoft.AspNetCore.Razor.TagHelpers;
using SJ.One_Core.Service.Filters;

namespace SJ.One_Core.Service.TagHelpers
{
    public class SortLinkHelper : TagHelper
    {
        public FetchOptions options {get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
        }
    }
}
