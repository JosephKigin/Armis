#pragma checksum "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e63326f51e20d0ff65c4ccdbbf4673ad16d0879"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Processes_Index), @"mvc.1.0.view", @"/Views/Processes/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e63326f51e20d0ff65c4ccdbbf4673ad16d0879", @"/Views/Processes/Index.cshtml")]
    public class Views_Processes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Armis.Data.DatabaseContext.Entities.Process>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Cust));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 25 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 28 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cust.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 784, "\"", 814, 1);
#nullable restore
#line 34 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
WriteAttributeValue("", 799, item.ProcessId, 799, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 867, "\"", 897, 1);
#nullable restore
#line 35 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
WriteAttributeValue("", 882, item.ProcessId, 882, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 952, "\"", 982, 1);
#nullable restore
#line 36 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
WriteAttributeValue("", 967, item.ProcessId, 967, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 39 "C:\Users\jkigin\source\repos\ArmisApi\Armis.Api\Views\Processes\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Armis.Data.DatabaseContext.Entities.Process>> Html { get; private set; }
    }
}
#pragma warning restore 1591
