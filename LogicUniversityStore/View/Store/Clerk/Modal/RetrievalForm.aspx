<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrievalForm.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.Modal.RetrievalForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvRetrieval" runat="server"  AutoGenerateColumns="false">
            <Columns>

                                <asp:BoundField DataField="key.SupplierItem.Item.ItemName" HeaderText="Request ID" />


                                <asp:BoundField DataField="value.Pair.Needed" HeaderText="Needed Quantity" />
                                <asp:BoundField DataField="value.Pair.Approved" HeaderText="Approve Quantity" />


                               <%-- <asp:TemplateField HeaderText="Fullfillment Status">
                                    <ItemTemplate>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                --%>

                            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
