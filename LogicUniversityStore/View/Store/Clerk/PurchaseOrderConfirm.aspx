<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="PurchaseOrderConfirm.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.PurchaseOrderConfirm" %>
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
        <li a="#">Purchase Order</li>
        <li class="active">Purchase Order Confirm</li>
    </ol>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">


    <form id="purchaseOrder" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header">
                        <div class="input-group input-group-sm pull-left" style="width: 150px;">
                        </div>
                    </div>
                    <div class="box-body">
                        <asp:GridView ID="gvPurchaseOrders" onrowdatabound="gvItems_RowCreated"  runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" DataKeyNames="ItemId" AllowPaging="true" OnRowDeleting="DeleteRow" PageSize="10">
                            <Columns>
                                <asp:BoundField DataField="Supplier" HeaderText="#" ReadOnly="true" />
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
                    </div>
                    <div class="box-footer">
                        <a href="#" class="btn btn-danger pull-right" style="margin-left: 5px">Cancel</a>
                        <a href="#" id="purchaseorde-modal-show" class="btn btn-success pull-right" style="margin-right: 5px">Generate PO</a>
                        <asp:Button ID="confirm" OnClick="ConfirmItems_Click" CssClass="btn-success" runat="server" Text="Confirm Items" />
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
        });
    </script>
</asp:Content>
