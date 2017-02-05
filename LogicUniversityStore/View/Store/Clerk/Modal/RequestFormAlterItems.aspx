<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestFormAlterItems.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.Modal.RequestFormAlterItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .mrl-5 {
            margin-right: 5px;
            margin-left: 5px;
        }
    </style>
</head>
<body>
    <form runat="server" action="./Modal/RequestFormAlterItems.aspx">
        <div class="col-md-12" id="adijada">
            <div class="box">
                <div class="box-body" style="padding-top: 0px;">
                    <asp:GridView ID="gvAlter" runat="server" CssClass="table" ForeColor="#333333" AutoGenerateColumns="false" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="#" Visible="false">
                                <ItemTemplate>
                                    <%# Eval("key.ReqItemID") %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item">
                                <ItemTemplate>
                                    <%# Eval("key.SupplierItem.Item.ItemName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty Requested">
                                <ItemTemplate>
                                    <span class="badge bg-red"><%# Eval("key.NeededQuantity") %> Units</span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="In Stock">
                                <ItemTemplate>
                                    <%# Eval("value") %> Units
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approved Qty">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbAmount" CssClass="form-control" runat="server" Text='<%# Eval("key.ApprovedQuantity") %>'> </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="box-footer">
                    <asp:Button ID="btnCancell" runat="server" Text="Cancel" CssClass="btn btn-danger pull-right mrl-5" OnClick="btnCancell_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Update" CssClass="btn btn-success pull-right mrl-5" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
