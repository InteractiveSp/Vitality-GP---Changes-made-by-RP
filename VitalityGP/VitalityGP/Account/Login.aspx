<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Account_Login"  UnobtrusiveValidationMode="None" %>
<%@ Register TagPrefix="uc" TagName="ucLoginDetails" Src="~/Account/ucLoginDetails.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head runat="server">
    <title></title>
<%--    <link href="css/materialize.css" rel="stylesheet" />
    <link href="css/global.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />--%>
        <style type="text/css"> 
        .centered
{
    margin: 0 auto;
    float: none !important;
    display: table;
}

  .Absolute-Center {
  position: absolute;
        top: 50%;
        left: 50%;
        margin-right: -50%;
        transform: translate(-50%, -50%) 

}
 </style>
</head>
<body>
    <form id="form1" runat="server" class="Absolute-Center" >
  <asp:login id="Login1" style="width: 100%;" runat="server">
    <layouttemplate>          
      <div class="main-header">
            <div class="overlay"></div>
            <div class="wrapper">
             <%--   <div class="wrapper" style="left: 0px; top: 0px">
                    <a href="/corporate-healthcare/" class="brand-logo">
                        <img src="Images/Alliance-Surgical-Corporate-Health.png" />
                    </a>
                    <h1><span class="animated fadeInDown center-align">My Healthcare Portal</span></h1>
                </div> --%>
  <%--              <div class="page-footer light-blue" style="width:20%; margin-right: 40%; margin-left:40%; padding:20px">--%>
                <div class="accountHeader">
                    <h2>Log In</h2>
                </div>

               <%-- <div class="animated fadeIn center-align">User Name:</div>--%>
                <dx:ASPxLabel ID="lblUserName" runat="server" AssociatedControlID="tbUserName" Text="User Name:" />
             <%--   <div class="center-align">
                    <asp:textbox class="centered" id="UserName" runat="server" placeholder="User Number" Width="200px"></asp:textbox>
                    <asp:requiredfieldvalidator id="UserNameRequired" runat="server" validationgroup="Login1" tooltip="User Name is required." errormessage="User Name is required." controltovalidate="UserName">*</asp:requiredfieldvalidator>
                </div>--%>
                <div class="form-field">
                    <dx:ASPxTextBox id="UserName" runat="server" Width="200px">
                        <ValidationSettings ValidationGroup="LoginUserValidationGroup">
                            <RequiredField ErrorText="User Name is required." IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </div>
                <p></p>
<%--                <div class="animated fadeIn center-align">Password:</div>--%>
                <dx:ASPxLabel ID="lblPassword" runat="server" AssociatedControlID="tbPassword" Text="Password:" />
             <%--   <div class="center-align">
                    <asp:textbox class="field" id="Password" runat="server" textmode="Password" placeholder="Password" Width="200px"></asp:textbox>
                    <asp:requiredfieldvalidator id="PasswordRequired" runat="server" validationgroup="Login1" tooltip="Password is required." errormessage="Password is required." controltovalidate="Password">*</asp:requiredfieldvalidator>
                </div>--%>
                <div class="form-field">
                    <dx:ASPxTextBox ID="Password" runat="server" Password="true" Width="200px">
                        <ValidationSettings ValidationGroup="LoginUserValidationGroup">
                            <RequiredField ErrorText="Password is required." IsRequired="true" />
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </div>
                <br>
                <div class="center-align">
                  <%--  <asp:button class="waves-effect waves-light green lighten-1 btn-small btn-center modal-trigger animated fadeIn" id="LoginButton" runat="server" validationgroup="Login1" text="Log In" commandname="Login" OnClick="LoginButton_Click"></asp:button> --%>   
                    <dx:ASPxButton ID="LoginButton" runat="server" Text="Log In" ValidationGroup="LoginUserValidationGroup"
                            OnClick="LoginButton_Click">
                        </dx:ASPxButton>
                    <div class="center-align">
                        <asp:literal id="FailureText" runat="server" enableviewstate="False"></asp:literal>
                    </div>
                </div>
            <div>
        </div>
    </layouttemplate>
</asp:login>
          <div class="center-align" style="width: 25%;height:initial; margin-right: auto; margin-left:auto; padding:initial" >
           <uc:uclogindetails ID="LoginDetails1" runat="server" style="width: initial;height:initial; margin-right: initial; margin-left:initial; padding:initial" Visible="false" />     
      </div>
    </form>
</body>
</html>
