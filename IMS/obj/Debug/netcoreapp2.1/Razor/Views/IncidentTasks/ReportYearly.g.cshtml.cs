#pragma checksum "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11caf889812710dcc1408dcb0c63858c8435e8fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncidentTasks_ReportYearly), @"mvc.1.0.view", @"/Views/IncidentTasks/ReportYearly.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IncidentTasks/ReportYearly.cshtml", typeof(AspNetCore.Views_IncidentTasks_ReportYearly))]
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
#line 1 "C:\Users\alvin\Documents\IMS\IMS\Views\_ViewImports.cshtml"
using IMS;

#line default
#line hidden
#line 2 "C:\Users\alvin\Documents\IMS\IMS\Views\_ViewImports.cshtml"
using IMS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11caf889812710dcc1408dcb0c63858c8435e8fe", @"/Views/IncidentTasks/ReportYearly.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6df59e5360885ccecce3fcc6b6b86058f6baaadb", @"/Views/_ViewImports.cshtml")]
    public class Views_IncidentTasks_ReportYearly : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IMS.Models.IncidentTask>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "IncidentTasks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckFeedback", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
  
    ViewData["Title"] = "ReportYearly";
    int tempID = 120000;
    int x = 0;
    int y = 0;
    int z = 0; int s = 0;

#line default
#line hidden
            BeginContext(178, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(185, 12, false);
#line 10 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
Write(ViewBag.Year);

#line default
#line hidden
            EndContext();
            BeginContext(197, 530, true);
            WriteLiteral(@" Report</h2>

<div class=""col-md-12 animated fadeIn"">
    <div class=""card"">
        <div class=""card-body"">
            <table id=""bootstrap-data-table-export"" class=""table table-striped"">
                <thead class=""thead-dark"">
                    <tr>
                        <th>
                            Incident ID
                        </th>
                        <th>
                            Incident Name
                        </th>
                        <th>
                            ");
            EndContext();
            BeginContext(728, 44, false);
#line 25 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                       Write(Html.DisplayNameFor(model => model.Category));

#line default
#line hidden
            EndContext();
            BeginContext(772, 187, true);
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            Count\r\n                        </th>\r\n                        <th>\r\n                            ");
            EndContext();
            BeginContext(960, 49, false);
#line 31 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                       Write(Html.DisplayNameFor(model => model.Satisfication));

#line default
#line hidden
            EndContext();
            BeginContext(1009, 146, true);
            WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 37 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                     foreach (var item in Model)
                    {
                        x = 0;
                        y= 0; z = 0;
                        if (item.IID != tempID)
                        {
                            tempID = item.IID;
                            

#line default
#line hidden
#line 44 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                             foreach (var item1 in Model)
                            {
                                if (tempID == item1.IID)
                                {
                                    x++;
                                }
                            }

#line default
#line hidden
#line 52 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                             foreach (var item2 in Model)
                            {
                                if (tempID == item2.IID && item2.Satisfication == "Satisfied")
                                {
                                   y++;
                                }
                            }

#line default
#line hidden
#line 58 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                             
                            z = y*100/x;

#line default
#line hidden
            BeginContext(2085, 108, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2194, 38, false);
#line 62 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                               Write(Html.DisplayFor(modelItem => item.IID));

#line default
#line hidden
            EndContext();
            BeginContext(2232, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2348, 40, false);
#line 65 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Iname));

#line default
#line hidden
            EndContext();
            BeginContext(2388, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2504, 43, false);
#line 68 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Category));

#line default
#line hidden
            EndContext();
            BeginContext(2547, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2663, 12, false);
#line 71 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                               Write(x.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2675, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2791, 12, false);
#line 74 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                               Write(z.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(2803, 116, true);
            WriteLiteral("%\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2919, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8917fb6d495b466993ccc0d1a14b317a", async() => {
                BeginContext(3026, 25, true);
                WriteLiteral("<i class=\"fa fa-eye\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 77 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                                                                                                                        WriteLiteral(item.IID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3055, 76, true);
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 80 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\ReportYearly.cshtml"
                        }
                    }

#line default
#line hidden
            BeginContext(3181, 84, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IMS.Models.IncidentTask>> Html { get; private set; }
    }
}
#pragma warning restore 1591
