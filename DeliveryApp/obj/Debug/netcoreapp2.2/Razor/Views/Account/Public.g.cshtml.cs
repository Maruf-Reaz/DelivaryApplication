#pragma checksum "D:\DeliveryApp\DeliveryApp\Views\Account\Public.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2dc83277165ba12d97c18a0dc01f609644680e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Public), @"mvc.1.0.view", @"/Views/Account/Public.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Public.cshtml", typeof(AspNetCore.Views_Account_Public))]
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
#line 1 "D:\DeliveryApp\DeliveryApp\Views\_ViewImports.cshtml"
using DeliveryApp;

#line default
#line hidden
#line 2 "D:\DeliveryApp\DeliveryApp\Views\_ViewImports.cshtml"
using DeliveryApp.Models;

#line default
#line hidden
#line 1 "D:\DeliveryApp\DeliveryApp\Views\Account\Public.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2dc83277165ba12d97c18a0dc01f609644680e1", @"/Views/Account/Public.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8c17bd6bc47298a47a1f0d59f587625e92904df", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Public : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/fonts/fontawesome-pro/css/pro.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/vendor/jquery-confirm/jquery-confirm.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-lg btn-floating btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(224, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 6 "D:\DeliveryApp\DeliveryApp\Views\Account\Public.cshtml"
  
    ViewData["Title"] = "Home";
    Layout = "~/Views/Shared/_SecurityPartial.cshtml";

#line default
#line hidden
            BeginContext(324, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e2dc83277165ba12d97c18a0dc01f609644680e17396", async() => {
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
            EndContext();
            BeginContext(403, 217, true);
            WriteLiteral("\r\n<!-- Bootstrap core CSS -->\r\n<link href=\"vendor/bootstrap/css/bootstrap.min.css\" rel=\"stylesheet\">\r\n<!-- Custom fonts for this template -->\r\n<link href=\"vendor/fontawesome-free/css/all.min.css\" rel=\"stylesheet\">\r\n\r\n");
            EndContext();
            BeginContext(620, 115, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e2dc83277165ba12d97c18a0dc01f609644680e18884", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
#line 16 "D:\DeliveryApp\DeliveryApp\Views\Account\Public.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(735, 700, true);
            WriteLiteral(@"
<link href=""vendor/simple-line-icons/css/simple-line-icons.css"" rel=""stylesheet"" type=""text/css"">
<link href=""https://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic"" rel=""stylesheet"" type=""text/css"">
<!-- Custom styles for this template -->
<link href=""css/landing-page.min.css"" rel=""stylesheet"">
<style>
    .validation-summary-errors ul {
        list-style: none;
        padding-left: 0;
    }

    .visibility {
        right: 50px;
        top: 30%;
    }
</style>


<!-- Navigation -->
<nav class=""navbar navbar-light bg-light static-top"">
    <div class=""container"">
        <a class=""navbar-brand"" href=""#"">Parcel Management System</a>
");
            EndContext();
#line 38 "D:\DeliveryApp\DeliveryApp\Views\Account\Public.cshtml"
         if (!SignInManager.IsSignedIn(User) || User == null)
        {

#line default
#line hidden
            BeginContext(1509, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1521, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2dc83277165ba12d97c18a0dc01f609644680e111998", async() => {
                BeginContext(1592, 7, true);
                WriteLiteral("Sign In");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1603, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 41 "D:\DeliveryApp\DeliveryApp\Views\Account\Public.cshtml"
        }
        else
        {


#line default
#line hidden
            BeginContext(1643, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1655, 81, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2dc83277165ba12d97c18a0dc01f609644680e113910", async() => {
                BeginContext(1723, 9, true);
                WriteLiteral("Home Page");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1736, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 46 "D:\DeliveryApp\DeliveryApp\Views\Account\Public.cshtml"
        }

#line default
#line hidden
            BeginContext(1749, 6414, true);
            WriteLiteral(@"
    </div>
</nav>
<!-- Masthead -->
<header class=""masthead text-white text-center"">
    <div class=""overlay""></div>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xl-9 mx-auto"">
                <h1 class=""mb-5 text-light"">Track Your Parcel Here</h1>
            </div>
            <div class=""col-md-10 col-lg-8 col-xl-7 mx-auto"">
                <div class=""form-row"">
                    <div class=""col-12 col-md-9 mb-2 mb-md-0"">

                        <input id=""trackIng"" class=""form-control form-control-lg"" placeholder=""Enter Tracking Number ..."" autocomplete=""off"">
                    </div>
                    <div class=""col-12 col-md-3"">
                        <button type=""button"" class=""form-control form-control-lg btn btn-block btn-primary"" id=""trackingButton""> Track </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</header>
<!-- Icons Grid -->
<section class=""features-icons bg-lig");
            WriteLiteral(@"ht text-center"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-4"">
                <div class=""features-icons-item mx-auto mb-5 mb-lg-0 mb-lg-3"">
                    <div class=""features-icons-icon d-flex"">
                        <i class=""icon-screen-desktop m-auto text-primary""></i>
                    </div>
                    <h3>Fully Responsive</h3>
                    <p class=""lead mb-0"">This theme will look great on any device, no matter the size!</p>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""features-icons-item mx-auto mb-5 mb-lg-0 mb-lg-3"">
                    <div class=""features-icons-icon d-flex"">
                        <i class=""icon-layers m-auto text-primary""></i>
                    </div>
                    <h3>Bootstrap 4 Ready</h3>
                    <p class=""lead mb-0"">Featuring the latest build of the new Bootstrap 4 framework!</p>
                </div>
      ");
            WriteLiteral(@"      </div>
            <div class=""col-lg-4"">
                <div class=""features-icons-item mx-auto mb-0 mb-lg-3"">
                    <div class=""features-icons-icon d-flex"">
                        <i class=""icon-check m-auto text-primary""></i>
                    </div>
                    <h3>Easy to Use</h3>
                    <p class=""lead mb-0"">Ready to use with your own content, or customize the source files!</p>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Image Showcases -->
<section class=""showcase"">
    <div class=""container-fluid p-0"">
        <div class=""row no-gutters"">
            <div class=""col-lg-6 order-lg-2 text-white showcase-img"" style=""background-image: url('img/bg-showcase-1.jpg');""></div>
            <div class=""col-lg-6 order-lg-1 my-auto showcase-text"">
                <h2 class=""text-white"">Fully Responsive Design</h2>
                <p class=""lead mb-0 text-white "">When you use a theme created by Start Bootstrap, y");
            WriteLiteral(@"ou know that the theme will look great on any device, whether it's a phone, tablet, or desktop the page will behave responsively!</p>
            </div>
        </div>
        <div class=""row no-gutters"">
            <div class=""col-lg-6 text-white showcase-img"" style=""background-image: url('img/bg-showcase-2.jpg');""></div>
            <div class=""col-lg-6 my-auto showcase-text"">
                <h2 class=""text-white"">Updated For Bootstrap 4</h2>
                <p class=""lead mb-0 text-white "">Newly improved, and full of great utility classes, Bootstrap 4 is leading the way in mobile responsive web development! All of the themes on Start Bootstrap are now using Bootstrap 4!</p>
            </div>
        </div>
        <div class=""row no-gutters"">
            <div class=""col-lg-6 order-lg-2 text-white showcase-img"" style=""background-image: url('img/bg-showcase-3.jpg');""></div>
            <div class=""col-lg-6 order-lg-1 my-auto showcase-text"">
                <h2 class=""text-white"">Easy to Use &");
            WriteLiteral(@"amp; Customize</h2>
                <p class=""lead mb-0 text-white "">Landing Page is just HTML and CSS with a splash of SCSS for users who demand some deeper customization options. Out of the box, just add your content and images, and your new landing page will be ready to go!</p>
            </div>
        </div>
    </div>
</section>
<!-- Testimonials -->
<section class=""testimonials text-center bg-light"">
    <div class=""container"">
        <h2 class=""mb-5"">What people are saying...</h2>
        <div class=""row"">
            <div class=""col-lg-4"">
                <div class=""testimonial-item mx-auto mb-5 mb-lg-0"">
                    <img class=""img-fluid rounded-circle mb-3"" src=""img/testimonials-1.jpg"" alt="""">
                    <h5>Margaret E.</h5>
                    <p class=""font-weight-light mb-0"">""This is fantastic! Thanks so much guys!""</p>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""testimonial-item mx-auto mb-5 mb-l");
            WriteLiteral(@"g-0"">
                    <img class=""img-fluid rounded-circle mb-3"" src=""img/testimonials-2.jpg"" alt="""">
                    <h5>Fred S.</h5>
                    <p class=""font-weight-light mb-0"">""Bootstrap is amazing. I've been using it to create lots of super nice landing pages.""</p>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""testimonial-item mx-auto mb-5 mb-lg-0"">
                    <img class=""img-fluid rounded-circle mb-3"" src=""img/testimonials-3.jpg"" alt="""">
                    <h5>Sarah W.</h5>
                    <p class=""font-weight-light mb-0"">""Thanks so much for making these free resources available to us!""</p>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Call to Action -->
<section class=""call-to-action text-white text-center"">
    <div class=""overlay""></div>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xl-9 mx-auto"">
                <h2");
            WriteLiteral(@" class=""mb-4  text-light"">Ready to get started? Sign up now!</h2>
            </div>
            <div class=""col-md-10 col-lg-8 col-xl-7 mx-auto"">

                <div class=""form-row"">
                    <div class=""col-12 col-md-12"">

                        ");
            EndContext();
            BeginContext(8163, 115, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2dc83277165ba12d97c18a0dc01f609644680e122573", async() => {
                BeginContext(8267, 7, true);
                WriteLiteral("Sign Up");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(8278, 1310, true);
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Footer -->
<footer class=""footer bg-light"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6 h-100 text-center text-lg-left my-auto"">

                <p class=""text-muted small mb-4 mb-lg-0"">&copy; Your Website 2020. All Rights Reserved.</p>
            </div>
            <div class=""col-lg-6 h-100 text-center text-lg-right my-auto"">
                <ul class=""list-inline mb-0"">
                    <li class=""list-inline-item mr-3"">
                        <a href=""#"">
                            <i class=""fab fa-facebook fa-2x fa-fw""></i>
                        </a>
                    </li>
                    <li class=""list-inline-item mr-3"">
                        <a href=""#"">
                            <i class=""fab fa-twitter-square fa-2x fa-fw""></i>
                        </a>
                    </li>
                    ");
            WriteLiteral(@"<li class=""list-inline-item"">
                        <a href=""#"">
                            <i class=""fab fa-instagram fa-2x fa-fw""></i>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</footer>


");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(9606, 213, true);
                WriteLiteral("\r\n\r\n    <script>\r\n        $(document).ready(function () {\r\n\r\n            $(\"#trackingButton\").on(\'click\', function (event) {\r\n                var trackingNumber = $(\'#trackIng\').val();\r\n                var url = \'");
                EndContext();
                BeginContext(9820, 52, false);
#line 220 "D:\DeliveryApp\DeliveryApp\Views\Account\Public.cshtml"
                      Write(Url.Action("GetPackageByTrackingNumber", "Packages"));

#line default
#line hidden
                EndContext();
                BeginContext(9872, 5043, true);
                WriteLiteral(@"';


                $.ajax({
                    type: ""POST"",
                    dataType: 'json',
                    url: url,
                    data: {
                        trackingNumber: trackingNumber,
                    },
                    cache: false,
                    success: function (result) {
                        console.log(result);
                        if (result == false) {
                           
                        $.confirm({
                            title: 'Package Info !',
                            theme: 'modern',
                            animation: 'zoom',
                            closeAnimation: 'zoom',
                            backgroundDismiss: true,
                            backgroundDismissAnimation: 'shake',
                            closeIcon: true,
                            content: '' +
                                '<form action="""" class=""formName"">' +
                                '<div class=""form");
                WriteLiteral(@"-group"">' +
                                '<label class=""text-danger"">Package Not Found </br> Please Check Your Tracking Number .</label>' +
                                //'<input type=""text"" id =""totalAmountPayable"" placeholder=""Total Amount"" disabled value="""" class=""name form-control mb-2"" required />' +
                                //'<input type=""text"" id =""totalAmountPaid"" placeholder=""Pay"" class=""name form-control mb-2"" value="""" required />' +

                                '</div>' +
                                '</form>',
                            buttons: {
                                formSubmit: {
                                    text: 'Ok',
                                    btnClass: 'btn-blue',
                                    action: function () {

                                        // submit
                                    }
                                }
                            },
                            backgroundDismiss: true,
 ");
                WriteLiteral(@"                       });
                    }
                    else {
                        var status = """";
                        var label = """";
                        if (result.status == 3) {
                            status = ""Picked Up By Parcel Company"";
                             label = ""warning"";
                        }
                        else if (result.status==4) {
                            status = ""Enlisted By Parcel Company"";
                            label = ""warning"";
                        }
                         else if (result.status==5) {
                            status = ""Shipped By Parcel Company"";
                            label = ""warning"";
                        }
                           else if (result.status==6) {
                            status = ""Delivared By Parcel Company"";
                            label = ""success"";
                        }
                     

                        $.confirm({
         ");
                WriteLiteral(@"                   title: 'Package Info !',
                            theme: 'modern',
                            animation: 'zoom',
                            closeAnimation: 'zoom',
                            backgroundDismiss: true,
                            backgroundDismissAnimation: 'shake',
                            closeIcon: true,
                            content: '' +
                                '<form action="""" class=""formName"">' +
                                '<div class=""form-group"">' +

                                '<label class=""text-dark text-wrap"">Merchant Name : ' + result.merchant+ '</label> </br>' +

                                '<label class=""text-dark"">Package Catagory : ' + result.packageCatagory +'</label></br>' +
                                '<label class=""text-dark"">Location : ' + result.locationFrom + ' - ' + result.locationTo + ' </label></br>' +
                                '<label class=""text-dark"">Weight : ' + result.weight + ' KG' +");
                WriteLiteral(@" '</label></br>' +
                                '<label class=""text-dark"">Total : ' + result.price + ' BDT' + '</label></br>' +
                                '<label class="" btn btn-' + label+'"">Status : ' + status + '</label></br>' +


                                '</div>' +
                                '</form>',
                            buttons: {
                                formSubmit: {
                                    text: 'Ok',
                                    btnClass: 'btn-blue',
                                    action: function () {

                                        // submit
                                    }
                                }
                            },
                            backgroundDismiss: true,
                        });


                    }
                    }
                });
            });
        });
    </script>
");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<DeliveryApp.Models.Common.Authentication.ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<DeliveryApp.Models.Common.Authentication.ApplicationUser> SignInManager { get; private set; }
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