<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="DeliveryOrder.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.DeliveryOrder" %>

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
    <h1>Delivery Order</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Delivery Order</li>
    </ol>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                    <h4>Fetch Purchase Orders</h4>
                </div>
                <div class="box-body">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <label>Find By Batch Number</label>
                            <asp:DropDownList ID="DdlBatchNumber" runat="server" OnSelectedIndexChanged="DdlBatchNumber_Change" AutoPostBack="true" CssClass="form-control select2"></asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <label>Find By Supplier</label>
                            <asp:DropDownList ID="DdlSupplier" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlSupplier_Change" CssClass="form-control select2"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12">
            <div class="box box-success">
                <div class="box-body">
                    <asp:GridView ID="gvPoByBatchNumb" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" DataKeyNames="PurchaseOrderID" AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:BoundField DataField="PurchaseOrderID" HeaderText="#" ReadOnly="true" />
                            <asp:BoundField DataField="PuchaseOrderNo" HeaderText="Purchase-order Number" ReadOnly="true" />
                            <asp:BoundField DataField="OrderDate" HeaderText="Ordered Date" ReadOnly="true" />
                            <asp:BoundField DataField="SupplierDetails" HeaderText="Supplier Name" ReadOnly="true" />
                            <asp:BoundField DataField="PORemark" HeaderText="Remarks" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Items">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" CssClass="btn btn-success" runat="server" navigateurl='<%# String.Format("DeliveryOrderConfirm.aspx?poid={0}", Eval("PurchaseOrderID")) %>' OnClick="btnDoConfirm_Click">
                                         <i class="fa fa-2x fa-truck" aria-hidden="true"></i>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvPoBySupplier" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" DataKeyNames="PurchaseOrderID" AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:BoundField DataField="PurchaseOrderID" HeaderText="#" ReadOnly="true" />
                            <asp:BoundField DataField="PuchaseOrderNo" HeaderText="Purchase-order Number" ReadOnly="true" />
                            <asp:BoundField DataField="OrderDate" HeaderText="Ordered Date" ReadOnly="true" />
                            <asp:BoundField DataField="SupplierDetails" HeaderText="Supplier Name" ReadOnly="true" />
                            <asp:BoundField DataField="PORemark" HeaderText="Remarks" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Items">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" CssClass="btn btn-success" runat="server" navigateurl='<%# String.Format("DeliveryOrderConfirm.aspx?poid={0}", Eval("PurchaseOrderID")) %>' OnClick="btnDoConfirm_Click">
                                         <i class="fa fa-2x fa-truck" aria-hidden="true"></i>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("table").addClass("table table-condensed");
        });
    </script>
</asp:Content>
