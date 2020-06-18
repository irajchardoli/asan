#pragma checksum "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "152fef62674854da293c7cbbbac1ff598969917f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Estate_Index), @"mvc.1.0.view", @"/Views/Estate/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Estate/Index.cshtml", typeof(AspNetCore.Views_Estate_Index))]
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
#line 1 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\_ViewImports.cshtml"
using ASAN.WebUI;

#line default
#line hidden
#line 2 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\_ViewImports.cshtml"
using ASAN.WebUI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"152fef62674854da293c7cbbbac1ff598969917f", @"/Views/Estate/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d57861c63318ec9ea719bbab42e954ff8138fde", @"/Views/_ViewImports.cshtml")]
    public class Views_Estate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASAN.Entities.Estate>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
  
    var viewName = "لیست املاک";
    ViewData["Title"] = viewName;

#line default
#line hidden
            BeginContext(120, 80, true);
            WriteLiteral("\r\n\r\n<div class=\"clearfix\">\r\n    <h4>\r\n        <label class=\"panel-header-label\">");
            EndContext();
            BeginContext(201, 8, false);
#line 11 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
                                     Write(viewName);

#line default
#line hidden
            EndContext();
            BeginContext(209, 20, true);
            WriteLiteral("</label>\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 229, "\"", 257, 1);
#line 12 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
WriteAttributeValue("", 236, Url.Action("Create"), 236, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(258, 587, true);
            WriteLiteral(@" class=""btn btn-default btn-sm pull-right""><span class=""glyphicon glyphicon-plus""></span></a>


    </h4>
</div>

<div class=""table-responsive"">
    <table class=""table table-bordered table-hover"">
        <thead>
            <tr class=""column-sortable"" data-enterkey-function=""fnGetBrands"">
                <th>Id</th>
                <th>Number</th>
                <th>Title</th>
                <th>Area</th>
                <th>Address</th>
                <th>OwnerName</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>

");
            EndContext();
#line 33 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
             foreach (var item in Model)
            {
                var ownerName = $"{item.Owner?.FirstName} {item.Owner?.LastName}";


#line default
#line hidden
            BeginContext(988, 53, true);
            WriteLiteral("            <tr>\r\n                <td data-name=\"Id\">");
            EndContext();
            BeginContext(1042, 7, false);
#line 38 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
                              Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1049, 46, true);
            WriteLiteral("</td>\r\n                <td data-name=\"Number\">");
            EndContext();
            BeginContext(1096, 11, false);
#line 39 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
                                  Write(item.Number);

#line default
#line hidden
            EndContext();
            BeginContext(1107, 45, true);
            WriteLiteral("</td>\r\n                <td data-name=\"Title\">");
            EndContext();
            BeginContext(1153, 10, false);
#line 40 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
                                 Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1163, 44, true);
            WriteLiteral("</td>\r\n                <td data-name=\"Area\">");
            EndContext();
            BeginContext(1208, 9, false);
#line 41 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
                                Write(item.Area);

#line default
#line hidden
            EndContext();
            BeginContext(1217, 47, true);
            WriteLiteral("</td>\r\n                <td data-name=\"Address\">");
            EndContext();
            BeginContext(1265, 12, false);
#line 42 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
                                   Write(item.Address);

#line default
#line hidden
            EndContext();
            BeginContext(1277, 49, true);
            WriteLiteral("</td>\r\n                <td data-name=\"OwnerName\">");
            EndContext();
            BeginContext(1327, 9, false);
#line 43 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
                                     Write(ownerName);

#line default
#line hidden
            EndContext();
            BeginContext(1336, 51, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1387, "\"", 1435, 1);
#line 45 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
WriteAttributeValue("", 1394, Url.Action("Update" ,new { id=item.Id }), 1394, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1436, 105, true);
            WriteLiteral(" class=\"btn btn-info btn-sm\"><span class=\"glyphicon glyphicon-pencil\"></span></a>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1541, "\"", 1589, 1);
#line 46 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
WriteAttributeValue("", 1548, Url.Action("Delete" ,new { id=item.Id }), 1548, 41, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1590, 126, true);
            WriteLiteral(" class=\"btn btn-danger btn-sm\"><span class=\"glyphicon glyphicon-trash\"></span></a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 49 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Estate\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1731, 42, true);
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASAN.Entities.Estate>> Html { get; private set; }
    }
}
#pragma warning restore 1591
