<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SubtitleTranslator._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <p>
  <asp:FileUpload ID="FileUpload1" runat="server" />  
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />

    </p>
    
    <p>
        <asp:Label ID="Label1" runat="server" ></asp:Label>
    </p>
</asp:Content>
