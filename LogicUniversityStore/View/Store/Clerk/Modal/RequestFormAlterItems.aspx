<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestFormAlterItems.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.Modal.RequestFormAlterItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server" action="./Modal/RequestFormAlterItems.aspx">
        <div class="col-md-12" id="adijada">
            <div class="box">   
                <div class="box-body no-padding">
                    <table class="table table-condensed">
                        <tbody>
                            <tr>
                                <th style="width: 10px">#</th>
                                <th>Item</th>
                                <th>Qty Requested</th>
                                <th>In Stock</th>
                                <th>Approved Qty</th>
                            </tr>


                            <asp:ListView ID="lvItemsInReq" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("key.ReqItemID") %>.</td>
                                        <td><%# Eval("key.SupplierItem.Item.ItemName") %></td>
                                        <td>
                                            <span class="badge bg-red"><%# Eval("key.NeededQuantity") %> Units</span>
                                        </td>
                                        <td><%# Eval("value") %> Units</td>
                                        <td>
                                            <input type="text" data-id="<%# Eval("key.ReqItemID") %>" value="<%# Eval("key.ApprovedQuantity") %>" class="form-control" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>

                        </tbody>
                    </table>
                </div>
                <div class="box-body">
                   

                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSave_Click" />
                   
                      </div>
                <!-- /.box-body -->
            </div>
        </div>
        </form>
</body>
</html>
