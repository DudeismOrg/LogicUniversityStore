<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="RetrievalForm.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.RetrievalForm"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="clrkCssBlock" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
    <form runat="server">

   
    <asp:GridView ID="gvRetrievList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvRetrievList_RowCommand" CssClass="table">
        <Columns>
            <asp:BoundField DataField="RetrievalNumber" HeaderText="Retrieval Number" />
             <asp:BoundField DataField="RetrievalDate" HeaderText="Date" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server"
                        CommandName="View"
                        CommandArgument='<%# Eval("RetrievalID") %>' 
                        Text="View Retrieval Form"  CssClass="btn-primary"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
         </form>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
</asp:Content>
