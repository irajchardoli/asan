#pragma checksum "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Owner\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "692487d08f6a310f3eb8a3d3975a994580fe1a13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Owner_Index), @"mvc.1.0.view", @"/Views/Owner/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Owner/Index.cshtml", typeof(AspNetCore.Views_Owner_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"692487d08f6a310f3eb8a3d3975a994580fe1a13", @"/Views/Owner/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d57861c63318ec9ea719bbab42e954ff8138fde", @"/Views/_ViewImports.cshtml")]
    public class Views_Owner_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASAN.Entities.Owner>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 388, true);
            WriteLiteral(@"
<div class=""table-responsive"">
    <table class=""table table-bordered table-hover"">
        <thead>
            <tr class=""column-sortable"" data-enterkey-function=""fnGetBrands"">                
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Tel</th>
            </tr>
        </thead>
        <tbody>

");
            EndContext();
#line 15 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Owner\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(486, 61, true);
            WriteLiteral("                <tr>\r\n                    <td data-name=\"Id\">");
            EndContext();
            BeginContext(548, 7, false);
#line 18 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Owner\Index.cshtml"
                                  Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(555, 53, true);
            WriteLiteral("</td>\r\n                    <td data-name=\"FirstName\">");
            EndContext();
            BeginContext(609, 14, false);
#line 19 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Owner\Index.cshtml"
                                         Write(item.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(623, 52, true);
            WriteLiteral("</td>\r\n                    <td data-name=\"LastName\">");
            EndContext();
            BeginContext(676, 13, false);
#line 20 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Owner\Index.cshtml"
                                        Write(item.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(689, 55, true);
            WriteLiteral("</td>\r\n                    <td data-name=\"PhoneNumber\">");
            EndContext();
            BeginContext(745, 16, false);
#line 21 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Owner\Index.cshtml"
                                           Write(item.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(761, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 23 "C:\Partition\TempProjects\AsanShahr\ASAN\src\ASAN.WebUI\Views\Owner\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(806, 40, true);
            WriteLiteral("\r\n        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASAN.Entities.Owner>> Html { get; private set; }
    }
}
#pragma warning restore 1591
