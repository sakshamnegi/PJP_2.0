#pragma checksum "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4da7ce7d7663ec867f3103c0ec7f40450ab9cb63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Result_Index), @"mvc.1.0.view", @"/Views/Result/Index.cshtml")]
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
#nullable restore
#line 1 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\_ViewImports.cshtml"
using DateTimeCalculator_MVC_Webapp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\_ViewImports.cshtml"
using DateTimeCalculator_MVC_Webapp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4da7ce7d7663ec867f3103c0ec7f40450ab9cb63", @"/Views/Result/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa068fc676d43b66f78d940102f26ddffdae733b", @"/Views/_ViewImports.cshtml")]
    public class Views_Result_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
  
    bool? showingResults = ViewBag.showingResults ?? false;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Results </h3>\r\n\r\n");
#nullable restore
#line 8 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
 using (Html.BeginForm("GetResults", "Result"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <strong>Select Type :</strong><br>\r\n");
#nullable restore
#line 11 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
Write(Html.RadioButton("ResultType","Session",true));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>Session Results </span><br>\r\n");
#nullable restore
#line 12 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
Write(Html.RadioButton("ResultType","All"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>All Results </span>\r\n    <hr>\r\n    <strong>Filter by operation :</strong><br>\r\n");
#nullable restore
#line 15 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
Write(Html.RadioButton("FilterType","All", true));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>Show All </span><br>\r\n");
#nullable restore
#line 16 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
Write(Html.RadioButton("FilterType","Add"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>Add </span><br>\r\n");
#nullable restore
#line 17 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
Write(Html.RadioButton("FilterType","Subtract"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>Subtract </span><br>\r\n");
#nullable restore
#line 18 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
Write(Html.RadioButton("FilterType","Day"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>Day of the week </span><br>\r\n");
#nullable restore
#line 19 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
Write(Html.RadioButton("FilterType","WeekNumber"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>Week of the year </span>\r\n    <hr>\r\n    <div>\r\n       <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n    </div>\r\n");
#nullable restore
#line 24 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"


}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 29 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
 if((bool) showingResults)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <br>
    <table class=""table"">
        <thead class=""thead-dark"">   
            <th>ID</th>  
            <th>TimeStamp</th>  
            <th>Date Operated On</th>  
            <th>ParamDays</th>  
            <th>ParamWeeks</th>  
            <th>ParamMonths</th>  
            <th>ParamYears</th>  
            <th>Operation</th>  
            <th>Result</th>  
        </thead>

");
#nullable restore
#line 45 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
         foreach (var result in ViewBag.results as IEnumerable<OutputModel>)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 48 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 49 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.Timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 50 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.Date.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 51 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.ParamDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 52 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.ParamWeeks);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 53 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.ParamMonths);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 54 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.ParamYears);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 55 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.Operation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 56 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
               Write(result.Result);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 58 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 60 "D:\Sapient_Learning\PJP_2.0\C#_week 4\DateTimeCalculator_MVC_Webapp\Views\Result\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
