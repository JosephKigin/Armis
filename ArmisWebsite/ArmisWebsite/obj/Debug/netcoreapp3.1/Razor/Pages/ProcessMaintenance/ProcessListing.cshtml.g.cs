#pragma checksum "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af450e01e6e5b7e27a6886b4644c950cfea81b4a"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af450e01e6e5b7e27a6886b4644c950cfea81b4a", @"/Pages/ProcessMaintenance/ProcessListing.cshtml")]
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "af450e01e6e5b7e27a6886b4644c950cfea81b4a4203", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "af450e01e6e5b7e27a6886b4644c950cfea81b4a4465", async() => {
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
            WriteLiteral(@"

<h1>Process Listing</h1>
<div id=""stepList"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <div class=""input-group my-1"">
                <input id=""searchProcesses"" class=""form-control border-right-0"" onkeyup=""searchProcessList()"" />
                <span class=""input-group-append bg-white border-left-0"">
                    <span class=""input-group-text bg-transparent""><i class=""fa fa-search""></i></span>
                </span>
            </div>
            <ul id=""processList"" class=""list-group"" style=""max-height: 42em; overflow:scroll;"">
");
#nullable restore
#line 22 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                 foreach (var process in Model.Processes)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"list-group-item\"");
            BeginWriteAttribute("id", " id=\"", 911, "\"", 942, 2);
            WriteAttributeValue("", 916, "process-", 916, 8, true);
#nullable restore
#line 24 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
WriteAttributeValue("", 924, process.ProcessId, 924, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h4><b>");
#nullable restore
#line 25 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                          Write(process.ProcessId);

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 25 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                                              Write(process.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n\r\n");
#nullable restore
#line 27 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                         if (process.Revisions != null && process.Revisions.Any())
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>Current Revision: ");
#nullable restore
#line 28 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                                         Write(process.Revisions.Last().ProcessRevId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
#nullable restore
#line 28 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("id", " id=\"", 1224, "\"", 1247, 1);
#nullable restore
#line 29 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
WriteAttributeValue("", 1229, process.ProcessId, 1229, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"fa fa-info-circle float-right\"");
            BeginWriteAttribute("onmousedown", " onmousedown=\"", 1286, "\"", 1346, 6);
            WriteAttributeValue("", 1300, "loadSteps(", 1300, 10, true);
#nullable restore
#line 29 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
WriteAttributeValue("", 1310, process.ProcessId, 1310, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1328, ",", 1328, 1, true);
            WriteAttributeValue(" ", 1329, "\'", 1330, 2, true);
#nullable restore
#line 29 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
WriteAttributeValue("", 1331, process.Name, 1331, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1344, "\')", 1344, 2, true);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n\r\n                    </li>\r\n");
#nullable restore
#line 32 "C:\Users\jkigin\source\repos\ArmisApi\ArmisWebsite\ArmisWebsite\Pages\ProcessMaintenance\ProcessListing.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </ul>
        </div>

        <div class=""col-lg-6"">
            <h5 id=""stepTitle""></h5>
            <ul id=""stepsPlaceholder"" class=""list-group"">
            </ul>
        </div>

    </div>
</div>

<script>
    function searchProcessList() {
        var searchTerm = document.getElementById(""searchProcesses"").value.toUpperCase();
        var processList = document.getElementById(""processList"");
        var processListItems = processList.getElementsByTagName(""li"");

        for (var i = 0; i < processListItems.length; i++) {
            if (!processListItems[i].textContent.toUpperCase().includes(searchTerm)) {
                processListItems[i].style.display = ""none"";
            }
            else {
                processListItems[i].style.display = ""block"";
            }
        }
    }

    function loadSteps(aProcessId, aProcessName) {
        if (aProcessId > 0) {
            var xhr = new XMLHttpRequest();
            xhr.open('GET', 'https://localhost:44316");
            WriteLiteral(@"/api/processes/GetHydratedProcessRevision/' + aProcessId, true);
            xhr.send();

            xhr.onload = function () {
                var rev = JSON.parse(xhr.responseText);
                var stepItemsHtml = '';

                for (var i = 0; i < rev.Steps.length; i++) {
                    var signOffReqHtml = '';
                    if (rev.Steps[i].SignOffIsRequired == true) {
                        signOffReqHtml = `<p class=""text-danger"">Sign-Off Required</p>`;
                    }
                    stepItemsHtml +=

                        `<li class=""list-group-item"">
                                                <a data-toggle=""collapse"" href=""#stepItem` + i + `"">` + rev.Steps[i].StepName + `</a>
                                                <div id=""stepItem` + i + `"" class=""collapse"">
                                                    <div class=""card card-body"">`+
                        signOffReqHtml +
                        `<p>` + rev.Steps[i].Instruc");
            WriteLiteral(@"tions + `</p>
                                                    </div>
                                                </div>
                                            </li>`
                };

                document.getElementById(""stepsPlaceholder"").innerHTML = stepItemsHtml;
                document.getElementById(""stepTitle"").innerHTML = aProcessName.toString();
            }
        }
    }
</script>");
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
