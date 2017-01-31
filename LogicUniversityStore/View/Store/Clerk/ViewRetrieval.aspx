<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="ViewRetrieval.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="clrkCssBlock" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvRetrieval" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>

                    <asp:BoundField DataField="key.SupplierItem.Item.ItemName" HeaderText="Request ID" />


                    <asp:BoundField DataField="value.Pair.Needed" HeaderText="Needed Quantity" />
                    <asp:BoundField DataField="value.Pair.Approved" HeaderText="Approve Quantity" />



                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:GridView ID="gvChild" runat="server" AutoGenerateColumns="false" CssClass="table">
                                <Columns>
                                    <asp:BoundField DataField="key" HeaderText="Department name" />
                                    <asp:BoundField DataField="value.Needed" HeaderText="Needed" />
                                    <asp:BoundField DataField="value.Approved" HeaderText="Approved" />

                                </Columns>

                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

        </div>
    </form>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
</asp:Content>
