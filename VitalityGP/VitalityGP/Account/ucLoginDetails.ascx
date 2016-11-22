<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucLoginDetails.ascx.vb" Inherits="ucLoginDetails" %>

<%@ Import Namespace="Alliance.Data" %>

<%@ Register assembly="DevExpress.Xpo.v16.1, Version=16.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Xpo" tagprefix="dx" %>

<link href="css/PasswordTable.css" rel="stylesheet" />

  <table class="t1" summary="This table displays the User Names and Password to access the current website. It also displays the Client that the user belongs to.">

       <asp:Repeater ID="Repeater1" runat="server" DataSourceID="" >
            <HeaderTemplate>
                    <thead>
                        <tr>
                            <th>Client</th>
                            <th>Business Unit</th>
                            <th>User Name</th>
                            <th>Password</th>
                        </tr>
                        </thead>
            </HeaderTemplate>
           <ItemTemplate>

              <tr>
              <th> 
                <asp:Label runat="server" ID="lblClient"
                 text='<%# Eval("FullName")%>' />
 <%--                text='<%# Eval("Client")%>' />--%>
               </th>
               <th> 
                <asp:Label runat="server" ID="lblBusinessUnit"
                 text='<%# Eval("BusinessUnit")%>' />
               </th>
              <th> 
                <asp:Label runat="server" ID="lblUserName"
                 text='<%# Eval("UserName")%>' />
               </th>
         

              <th> 
                <asp:Label runat="server" ID="lblPasswordDecrypted" 
                 text='<%# PasswordHelper.Decode(EntityType.Beneficiary, Eval("Password").ToString)%>' />
              </th>
              </tr>

          </ItemTemplate>
        <FooterTemplate>
            <tfoot>
                <tr><th colspan="3" >Alliance Surgical</th></tr>
            </tfoot>
        </FooterTemplate>

        </asp:Repeater>
</table>
