<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SwaggerDemo.aspx.cs" Inherits="Hydocs.SwaggerDemo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
#loadImg{position:absolute;z-index:999;}
#loadImg div{display:table-cell;width:950px;height:633px;text-align:center;vertical-align:middle;}
</style>
    <div id="iframe-container">
        <div id="loadImg" class="col-sm-12">
            <div><img src="Content/loading.gif" /></div>
        </div>
        <object data="swagger/ui/index" width="950" height="633" type="text/html" onload="document.getElementById('loadImg').style.opacity='0';">

</object>
      <iframe id= "frame" src="swagger/ui/index" onload="document.getElementById('loadImg').style.opacity='0';"> </iframe>
     </div> 

</asp:Content>

