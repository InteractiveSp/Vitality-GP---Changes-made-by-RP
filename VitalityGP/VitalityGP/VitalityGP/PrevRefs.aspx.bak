<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="PrevRefs.aspx.vb" Inherits="VitalityGP.PrevRefs" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Xpo.v15.2, Version=15.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Xpo" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="XpoDataSource1" EnableTheming="True" KeyFieldName="Oid" Theme="Moderno">
        <Columns>

            <dx:GridViewDataTextColumn FieldName="Oid" ReadOnly="True" Visible="False" VisibleIndex="2" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
<dx:GridViewDataTextColumn FieldName="userID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="3"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="4" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Firstname" VisibleIndex="5" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Lastname" VisibleIndex="6" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DOB" VisibleIndex="7" ShowInCustomizationForm="True">
            </dx:GridViewDataDateColumn>
<dx:GridViewDataTextColumn FieldName="Gender" ShowInCustomizationForm="True" Visible="False" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Address1" VisibleIndex="9" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Address2" VisibleIndex="10" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Address3" VisibleIndex="11" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Address4" VisibleIndex="12" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Postcode" VisibleIndex="13" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Telephone" VisibleIndex="14" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LeaveMessage" VisibleIndex="15" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ConsentThirdParty" VisibleIndex="16" Visible="False" ShowInCustomizationForm="True" >
             </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PolicyNumber" VisibleIndex="17" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AuthNumber" VisibleIndex="18" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PresentingCondition" VisibleIndex="19" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Symptoms" VisibleIndex="20" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Excess" VisibleIndex="21" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="OutpatientLimit" VisibleIndex="22" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="HospitalList" VisibleIndex="23" Visible="False" ShowInCustomizationForm="True">
            </dx:GridViewDataTextColumn>
         
               <dx:GridViewDataTextColumn FieldName="GPSelect" ShowInCustomizationForm="True" Visible="False" VisibleIndex="24">
               </dx:GridViewDataTextColumn>
               <dx:GridViewDataTextColumn FieldName="SelfPaying" ShowInCustomizationForm="True" Visible="False" VisibleIndex="25">
               </dx:GridViewDataTextColumn>
               <dx:GridViewDataDateColumn FieldName="Callback" ShowInCustomizationForm="True" Visible="False" VisibleIndex="26">
               </dx:GridViewDataDateColumn>
               <dx:GridViewDataDateColumn Caption="Posted to Alliance" FieldName="last_crm_post" ShowInCustomizationForm="True" VisibleIndex="27">
               </dx:GridViewDataDateColumn>
               <dx:GridViewDataTextColumn FieldName="AsRef" ShowInCustomizationForm="True" VisibleIndex="28">
               </dx:GridViewDataTextColumn>
               <dx:GridViewDataTextColumn FieldName="GPID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="29">
               </dx:GridViewDataTextColumn>
               <dx:GridViewDataHyperLinkColumn Caption="#" FieldName="Oid" FixedStyle="Left" ShowInCustomizationForm="True" VisibleIndex="1" Width="30px">
                   <PropertiesHyperLinkEdit NavigateUrlFormatString="~/EditForm.aspx?id={0}" Text="view">
                   </PropertiesHyperLinkEdit>
                   <Settings AllowAutoFilter="False" />
               </dx:GridViewDataHyperLinkColumn>
         
        </Columns>
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
    <dx:XpoDataSource ID="XpoDataSource1" runat="server" DefaultSorting="" TypeName="VitalityGP.vitop" Criteria="">
    </dx:XpoDataSource>
   
</asp:Content>
