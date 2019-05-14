#pragma checksum "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93968e491d11b63f51b513f3d1a95e50b1a5f2a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncidentTasks_Reports), @"mvc.1.0.view", @"/Views/IncidentTasks/Reports.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IncidentTasks/Reports.cshtml", typeof(AspNetCore.Views_IncidentTasks_Reports))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93968e491d11b63f51b513f3d1a95e50b1a5f2a1", @"/Views/IncidentTasks/Reports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6df59e5360885ccecce3fcc6b6b86058f6baaadb", @"/Views/_ViewImports.cshtml")]
    public class Views_IncidentTasks_Reports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IMS.Models.IncidentTask>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendors/chart.js/dist/Chart.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
  
    ViewData["Title"] = "Reports";

#line default
#line hidden
            BeginContext(90, 1051, true);
            WriteLiteral(@"
<h2>7day Reports Overview</h2>
<div class=""col-md-12"">
    <div class=""card"">
        <div class=""card-body"">
            <div class=""chartjs-size-monitor"" style=""position: absolute; left: 0px; top: 0px; right: 0px; bottom: 0px; overflow: hidden; pointer-events: none; visibility: hidden; z-index: -1;""><div class=""chartjs-size-monitor-expand"" style=""position:absolute;left:0;top:0;right:0;bottom:0;overflow:hidden;pointer-events:none;visibility:hidden;z-index:-1;""><div style=""position:absolute;width:1000000px;height:1000000px;left:0;top:0""></div></div><div class=""chartjs-size-monitor-shrink"" style=""position:absolute;left:0;top:0;right:0;bottom:0;overflow:hidden;pointer-events:none;visibility:hidden;z-index:-1;""><div style=""position:absolute;width:200%;height:200%;left:0; top:0""></div></div></div>
            <h4 class=""mb-3"">Bar chart </h4>
            <canvas id=""barChart"" width=""1442"" height=""720"" class=""chartjs-render-monitor"" style=""display: block; width: 721px; height: 360px;""></canvas>
        </d");
            WriteLiteral("iv>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(1141, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "76631bc02fee4566a46a4752d106c81a", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1208, 254, true);
            WriteLiteral("\r\n<script>\r\n    ( function ( $ ) {\r\n    \"use strict\";\r\n    //bar chart\r\n    var ctx = document.getElementById( \"barChart\" );\r\n    //    ctx.height = 200;\r\n    var myChart = new Chart( ctx, {\r\n        type: \'bar\',\r\n        data: {\r\n            labels: [ \"");
            EndContext();
            BeginContext(1463, 12, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                  Write(ViewBag.Day7);

#line default
#line hidden
            EndContext();
            BeginContext(1475, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1477, 13, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                Write(ViewBag.Date7);

#line default
#line hidden
            EndContext();
            BeginContext(1490, 4, true);
            WriteLiteral("\", \"");
            EndContext();
            BeginContext(1495, 12, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                  Write(ViewBag.Day6);

#line default
#line hidden
            EndContext();
            BeginContext(1507, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1509, 13, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                Write(ViewBag.Date6);

#line default
#line hidden
            EndContext();
            BeginContext(1522, 4, true);
            WriteLiteral("\", \"");
            EndContext();
            BeginContext(1527, 12, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                  Write(ViewBag.Day5);

#line default
#line hidden
            EndContext();
            BeginContext(1539, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1541, 13, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                Write(ViewBag.Date5);

#line default
#line hidden
            EndContext();
            BeginContext(1554, 4, true);
            WriteLiteral("\", \"");
            EndContext();
            BeginContext(1559, 12, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                                  Write(ViewBag.Day4);

#line default
#line hidden
            EndContext();
            BeginContext(1571, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1573, 13, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                                                Write(ViewBag.Date4);

#line default
#line hidden
            EndContext();
            BeginContext(1586, 4, true);
            WriteLiteral("\", \"");
            EndContext();
            BeginContext(1591, 12, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                                                                  Write(ViewBag.Day3);

#line default
#line hidden
            EndContext();
            BeginContext(1603, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1605, 13, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                                                                                Write(ViewBag.Date3);

#line default
#line hidden
            EndContext();
            BeginContext(1618, 4, true);
            WriteLiteral("\", \"");
            EndContext();
            BeginContext(1623, 12, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                                                                                                  Write(ViewBag.Day2);

#line default
#line hidden
            EndContext();
            BeginContext(1635, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1637, 13, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                                                                                                                Write(ViewBag.Date2);

#line default
#line hidden
            EndContext();
            BeginContext(1650, 4, true);
            WriteLiteral("\", \"");
            EndContext();
            BeginContext(1655, 12, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                                                                                                                                  Write(ViewBag.Day1);

#line default
#line hidden
            EndContext();
            BeginContext(1667, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1669, 13, false);
#line 28 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                                                                                                                                                                                Write(ViewBag.Date1);

#line default
#line hidden
            EndContext();
            BeginContext(1682, 142, true);
            WriteLiteral("\" ],\r\n            datasets: [\r\n                {\r\n                    label: \"Escalated Incident\",\r\n                    data: [13, 5, 8, 13,  ");
            EndContext();
            BeginContext(1825, 13, false);
#line 32 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                     Write(ViewBag.Task3);

#line default
#line hidden
            EndContext();
            BeginContext(1838, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(1841, 13, false);
#line 32 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                     Write(ViewBag.Task2);

#line default
#line hidden
            EndContext();
            BeginContext(1854, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(1857, 13, false);
#line 32 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                     Write(ViewBag.Task1);

#line default
#line hidden
            EndContext();
            BeginContext(1870, 274, true);
            WriteLiteral(@" ],
                    borderColor: ""black"",
                    borderWidth: ""0"",
                    backgroundColor: ""#272c33""
                            },
                {
                    label: ""Solved Incident"",
                    data: [13, 3, 8, 13, ");
            EndContext();
            BeginContext(2145, 14, false);
#line 39 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                    Write(ViewBag.TaskD3);

#line default
#line hidden
            EndContext();
            BeginContext(2159, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(2162, 14, false);
#line 39 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                     Write(ViewBag.TaskD2);

#line default
#line hidden
            EndContext();
            BeginContext(2176, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(2179, 14, false);
#line 39 "C:\Users\alvin\Documents\IMS\IMS\Views\IncidentTasks\Reports.cshtml"
                                                                      Write(ViewBag.TaskD1);

#line default
#line hidden
            EndContext();
            BeginContext(2193, 493, true);
            WriteLiteral(@" ],
                    borderColor: ""rgba(0,0,0,0.09)"",
                    borderWidth: ""0"",
                    backgroundColor: ""cadetblue""
                            }
                        ]
        },
        options: {
            scales: {
                yAxes: [ {
                    ticks: {
                        beginAtZero: true
                    }
                                } ]
            }
        }
    } );




} )( jQuery );
</script>
");
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