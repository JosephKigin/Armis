#pragma checksum "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a8ccf4a67ca184097584020bb5e4c247d42d0e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ArmisWebsite.Pages.ProcessMaintenance.Pages_ProcessMaintenance_ProcessListing), @"mvc.1.0.razor-page", @"/Pages/ProcessMaintenance/ProcessListing.cshtml")]
namespace ArmisWebsite.Pages.ProcessMaintenance
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\_ViewImports.cshtml"
using ArmisWebsite;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a8ccf4a67ca184097584020bb5e4c247d42d0e3", @"/Pages/ProcessMaintenance/ProcessListing.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"546999f83c72dc97ee30de02f6d585bc65bf4faf", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ProcessMaintenance_ProcessListing : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/fontawesome-free-5.12.0-web/css/all.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
  
    ViewData["Title"] = "ProcessListing";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a8ccf4a67ca184097584020bb5e4c247d42d0e34168", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\" src=\"https://cdn.jsdelivr.net/npm/sortablejs@latest/Sortable.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4a8ccf4a67ca184097584020bb5e4c247d42d0e34551", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<h1>Process Listing</h1>\r\n\r\n<div id=\"sortable\" class=\"list-group\" style=\"max-height: 42em; overflow:scroll;\">\r\n");
#nullable restore
#line 14 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
     foreach (var process in Model.Processes)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"list-group-item\"");
            BeginWriteAttribute("id", " id=\"", 521, "\"", 544, 1);
#nullable restore
#line 16 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
WriteAttributeValue("", 526, process.ProcessId, 526, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <p><i class=\"fa fa-arrows-alt handle\"></i><b>");
#nullable restore
#line 17 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                                                    Write(process.ProcessId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                                                                       Write(process.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n            <p>Most Recent Revision: ");
#nullable restore
#line 18 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                                Write(process.Revisions.Last().ProcessRevId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 20 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n\r\n\r\n    <script>\r\n        new Sortable(sortable,\r\n            {\r\n                handle: \'.handle\',\r\n                animation: 150,\r\n                ghostClass: \'bg-warning\'\r\n            });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ArmisWebsite.ProcessListingModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ArmisWebsite.ProcessListingModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ArmisWebsite.ProcessListingModel>)PageContext?.ViewData;
        public ArmisWebsite.ProcessListingModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
