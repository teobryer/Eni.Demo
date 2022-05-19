using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eni.TP_Pizza.Extensions
{
    public static class HtmlHelperExtension
    {

        public static HtmlString CustomSubmit(this IHtmlHelper helper, string text)
        {
            return new HtmlString($" <input type=\"submit\" value=\"{text}\" class=\"btn btn-primary\" />");
        }
    }
}
