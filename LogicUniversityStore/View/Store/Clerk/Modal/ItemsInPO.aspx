<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemsInPO.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.Modal.ItemsInPO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form runat="server" method="post">--%>
        <div class="col-md-12" id="adijada">
            <div class="box">
                <div class="box-body no-padding">


                    <table  class="table table-condensed">
                        <tbody>
                            <tr>
                                <th style="width: 10px">#</th>
                                <th>Catagory</th>
                                <th>Item</th>
                                <th>Reorder Quantity</th>
                            </tr>

                            <asp:ListView ID="lvItemsInPO" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("itemId") %>.</td>
                                        <td><%# Eval("catagory") %>.</td>
                                        <td><%# Eval("itemName") %></td>
                                        <td>
                                            <span class="badge bg-red"><%# Eval("reorderQuantity") %> Units</span>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>
<%--    </form>--%>
</body>
</html>
