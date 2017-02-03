<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="DeliveryOrderConfirm.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.DeliveryOrderConfirm" %>

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

        .align-center {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
    <h1>Purchase Order</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li a="#">Delivery Order</li>
        <li class="active">Delivery Order Validate</li>
    </ol>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <h4><b>Purchase Order Number:</b> <%= currentPurchaseOrder.PuchaseOrderNo %></h4>
                            <h4><b>Supplier Name:</b> <%= currentPurchaseOrder.SupplierDetails %></h4>
                        </div>
                        <div class="col-md-6">
                            <h4><b>Ordered Date:</b> <%= currentPurchaseOrder.OrderDate %></h4>
                            <h4><b>Batch Number:</b> <%= currentPurchaseOrder.POBatch.BatchNumber %></h4>
                        </div>
                    </div>
                </div>
                <div class="box-body">
                    <asp:GridView ID="gvPurchaseOrderItems" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" DataKeyNames="PurchaeOrderItemID" AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox Visible="false" ID="idVal" runat="server" Text='<%#Bind("PurchaeOrderItemID") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PurchaeOrderItemID" HeaderText="#" ReadOnly="true" />
                            <asp:BoundField DataField="ItemCode" HeaderText="Item Number" ReadOnly="true" />
                            <asp:BoundField DataField="ItemCategory" HeaderText="Category" ReadOnly="true" />
                            <asp:BoundField DataField="ItemName" HeaderText="Description" ReadOnly="true" />
                            <asp:BoundField DataField="RequestedQuantity" HeaderText="Ordered Quantity" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Received Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQntyReceived" runat="server" Text='<%# Bind("RequestedQuantity") %>' CssClass="form-control" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="box-footer">
                    <div class="col-md-12">
                        <div class="col-md-8">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <label>Enter the DO Number:</label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtDoNumber" runat="server" CssClass="pull-left form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <a href="#" class="btn btn-danger pull-right" style="margin-left: 10px">Cancel</a>
                            <asp:Button ID="btnSaveDo" CssClass="btn btn-success pull-right" runat="server" OnClick="btnSaveDo_click" Text="Save Delivery Order" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("table").addClass("table table-condensed");
            $(".remove-item").click(function () {
                var itemId = $(this).data("id");
            });
        });

        $(".viewItems").click(function () {
            var id = $(this).data("id");
            $("#divItemsInPO").html("Please wait content is Loading...");
            $("#divItemsInPO")
                .load("/View/Store/Clerk/Modal/ItemsInPO.aspx", { Id: id })
                .dialog({
                    autoOpen: false,
                    show: "blind",
                    hide: "explode",
                    modal: true,
                    width: 673,
                    title: "Requested Items"
                });
            $("#divItemsInPO").dialog("open");
            return false;
        });
    </script>
</asp:Content>
