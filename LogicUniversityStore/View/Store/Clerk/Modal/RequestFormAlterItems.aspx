<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestFormAlterItems.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.Modal.RequestFormAlterItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
                                        <td><%# Eval("ReqItemID") %>.</td>
                                        <td><%# Eval("ItemName") %></td>
                                        <td>
                                            <span class="badge bg-red"><%# Eval("NeededQuantity") %> Units</span>
                                        </td>
                                        <td><%# Eval("OnHandQuantity") %> Units</td>
                                        <td>
                                            <input type="text" data-id="<%# Eval("ReqItemID") %>" class="form-control" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>

                        </tbody>
                    </table>
                </div>
                <div class="box-body">
                    <a class="btn btn-success pull-right">Save</a>
                </div>
                <!-- /.box-body -->
            </div>
        </div>
</body>
</html>
