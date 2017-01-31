<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.PurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="clrkCssBlock" runat="server">
    <style type="text/css">
        tbody {
            display: table-row-group;
            vertical-align: middle;
            border-color: inherit;
            border-top-color: inherit;
            border-right-color: inherit;
            border-bottom-color: inherit;
            border-left-color: inherit;
        }

        table {
            border-spacing: 0;
            border-collapse: collapse;
        }

        tr {
            display: table-row;
            vertical-align: inherit;
            border-color: inherit;
        }
        .align-center{
            text-align:center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
    <h1>Purchase Order</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Purchase Order</li>
    </ol>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
    <form id="purchaseOrder" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header">
                        <h4>Add Another Item</h4>
                    </div>
                    <div class="box-body">
                        <div class="col-md-12">
                            <div class="col-md-6">
                                <label>Category</label>
                                <asp:DropDownList ID="DdlCategories" runat="server" AutoPostBack="true" CssClass="form-control select2"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>Item</label>
                                <asp:DropDownList ID="DdlItems" runat="server" CssClass="form-control select2"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer" style="height: 50px">
                        <asp:Button ID="btnAddPurchaseOrderItem" runat="server" Text="Add Item" CssClass="pull-right btn btn-success" OnClick="btnAddPurchaseOrderItem_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">

                <div class="box">
                    <div class="box-header">

                        <div class="input-group input-group-sm pull-left" style="width: 150px;">
                        </div>
                    </div>


                    <div class="box-body">


                        <asp:GridView ID="gvReqItems" onrowdatabound="gvItems_RowCreated"  runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" DataKeyNames="ItemId" AllowPaging="true" OnRowDeleting="DeleteRow" PageSize="10">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRow"  CssClass="item-checkbox" runat="server" Checked="false"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ItemID" HeaderText="#" ReadOnly="true" />
                                <asp:BoundField DataField="ItemCode" HeaderText="Item Number" ReadOnly="true" />
                                <asp:BoundField DataField="Category" HeaderText="Category" ReadOnly="true" />
                                <asp:BoundField DataField="ItemName" HeaderText="Description" ReadOnly="true" />
                                <asp:TemplateField HeaderText="Reorder Quantity">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtReorder" runat="server" Text='<%# Bind("ReorderQuantity") %>' CssClass="form-control" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlSupplier" CssClass="form-control suplier-drp" runat="server"  DataValueField="SupplierId" DataTextField="SupplierName"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete?">
                                    <ItemTemplate>
                                        <span onclick="return confirm('Are you sure to delete?')">
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" ForeColor="Red" CommandName="Delete">
                                                <i class="fa fa-times"></i>
                                            </asp:LinkButton>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>



                        <%--<table class="table">
                            <tbody>
                                <tr>
                                    <th style="width: 10px">
                                        <input type="checkbox"></th>
                                    <th style="width: 10px">#</th>
                                    <th>Item Number</th>
                                    <th>Category</th>
                                    <th>Item</th>
                                    <th>Reorder Quantity</th>
                                    <th>Unit</th>
                                    <th>Supplier & contact</th>
                                    <th>Remove</th>
                                </tr>

                                <% foreach (var item in ItemsToPurchase)
                                    { %>
                                <tr>
                                    <td>
                                        <input value="<%= item.ItemID%>" type="checkbox"></td>
                                    <td><%= item.ItemID %>.</td>
                                    <td><%= item.ItemCode %></td>
                                    <td><%= item.Category %></td>
                                    <td><%= item.ItemDesc %></td>
                                    <td>
                                        <input class="form-control" type="text" value="<%= item.ReorderQuantity %>"></td>
                                    <td>Pax</td>
                                    <td>
                                        <select class="form-control">
                                            <%  foreach (var suplier in getAllSupplierItems(item))
                                                { %>
                                            <option value="<%= suplier.SupplierID%>"><%= getSupplierNameNumber(suplier.SupplierID)%></option>
                                            <%} %>
                                        </select>
                                    </td>
                                    <td>
                                        <a href="javascript:void(0);" class="remove-item" data-id="<%= item.ItemID%>"><i class="fa fa-times"></i></a>
                                        <a href="PurchaseOrder.aspx?id=<%= item.ItemID%>"><i class="fa fa-times">a</i></a>
                                    </td>
                                </tr>
                                <% } %>
                            </tbody>
                        </table>--%>
                    </div>



                    <div class="box-footer">
                        <a href="#" class="btn btn-danger pull-right" style="margin-left: 5px">Cancel</a>
                        <a href="#" id="purchaseorde-modal-show" class="btn btn-success pull-right" style="margin-right: 5px">Generate PO</a>
                        <asp:Button ID="confirm" OnClick="ConfirmItems_Click" CssClass="btn-success" runat="server" Text="Confirm Items" />
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="po-modal" tabindex="-1" role="dialog">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content" style="width:130%">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="retrievel-modalLabel">Purchase Order #PO123</h4>
                            </div>
                            <div class="modal-body">
                                <div class="col-md-12">
                                    <div class="box">
                                        <div class="box-body">
                                            <h4>Confirm to generate Purchase order for selected items and send mail to the respective Suppliers</h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <%--<button type="button" class="btn btn-success">Confirm</button>--%>
                                <%--<asp:Button ID="confirm" OnClick="ConfirmItems_Click" CssClass="btn-success" runat="server" Text="Confirm Items" />--%>
                                <%--<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />--%>
                                <button type="button" class="btn btn-default">Close</button>
                            </div>
                        </div>
                    </div>
                </div>


    </form>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("table").addClass("table table-condensed");
            $(".remove-item").click(function () {
                var itemId = $(this).data("id");
            });

            $("#purchaseorde-modal-show").click(function () {
                var items = new Array();
                $('input[type="checkbox"]:checked').each(function () {
                    items.push($(this).attr("id"));
                });
                if (items.length === 0) {
                    swal("Please Select atleast one Item to create a purchase Order!!")
                } else {
                    $("#po-modal").modal("show");
                }
            });
        });
    </script>
</asp:Content>
