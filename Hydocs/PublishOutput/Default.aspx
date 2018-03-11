<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="imagediv">
 <div class="title">
        <h1>The Hydocs project</h1>
     <br style="clear: both;">
 
     <div class="lr">
   <h2 >This demo showcases documentation for a simple MVC 6 application (REST API) and some REACT features.</h2>

       </div>
        <p>Scroll for more!</p>
    </div>
     </div>
  
   
    <p>&nbsp;</p>
    <div class="row">
         <div class="col-md-3"><p>
 <span class="h4">Hydocs </span></p>
             <p> Demonstrates use of Microsoft ASP.NET Web API Help Page and the Swagger package for Visual Studio 2017 (Swashbuckle) for documentation generation. You will still need to write the XML comments in the code files, to substitute Microsoft's default texts.
       .</p>
          <p>Built with Entity Framework 6, using the two tables (&quot;Customers&quot; and &quot;Products&quot;) from the Adventure Works database, the samples are very basic and more enhancements are coming soon. Edit and Delete functions are disabled on purpose.</p>
         <p>
             </div>
         <div class="col-md-3"><p><span class="h4">Tip</span></p>
             <p>When playing with available features, hit &quot;Try MVC&quot;- button or the &quot;MVC 5&quot; menu item first, and not the List View demo on the Home page. This way you&nbsp; will be able to observe that it takes a little longer time to fetch the results into&nbsp; the MVC framework vs. Web Forms List Views,. The List Views use the Adworks Web API as Data Sources.</p>
        </div>
           <div class="col-md-3"><p><span class="h4">Note</span></p>
    <p>This is an ASP.NET 4.5, hybrid web application, where the MVC controllers are different from Web API controllers. An MVC controller uses the System.Web.MVC.Controller base class and a Web API controller uses the System.Web.Http.ApiController base class. In MVC 6 (.NET Core 1.0), there is only one Controller base class for both MVC and Web API controllers that is the Microsoft.AspNet.Mvc.Controller class.<br />
    I hope to convert the app,&nbsp; demonstrate and document this, too, very soon. For now, I am using a combination of both Controller types.<br />
   </p> <br /></div>
      <div class="col-md-3"><p><span class="h4">Credits</span></p>
           
     <p>1. <img alt="" src="Content/Pinch.gif" />
          (aka Tatiana K. Joergensen)</p>
             <br />
    <p> 2. <a class="btn btn-default"  href="https://blog.rsuter.com/best-practices-for-writing-xml-documentation-phrases-in-c/">Best practices for writing XNL comments</a>&nbsp;
</p>
</div>     
    </div>
 
     
 
     
   
</asp:Content>