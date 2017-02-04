<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="ViewRetrieval.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.WebForm1" %>

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

        .ml-5{
            margin-left:5px;
        }
        
        .mr-5{
            margin-right:5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
    <h1>Retrival Number</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Retrievals View</li>
    </ol>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="box box-success">
                <div class="box-header">
                    <h4>Total Measure to collect</h4>
                </div>
                <div class="box-body">
                    <asp:GridView ID="gvRetrieval" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="key.SupplierItem.Item.ItemName" HeaderText="Request ID" />
                            <asp:BoundField DataField="value.Pair.Needed" HeaderText="Needed Quantity" />
                            <asp:BoundField DataField="value.Pair.Approved" HeaderText="Approve Quantity" />
                            <asp:TemplateField HeaderText="Collected Quantity"  HeaderStyle-CssClass="pull-right">
                                <ItemTemplate>
                                    <asp:TextBox ID="approvedQuantity" Visible="false" ReadOnly="true" runat="server" Text='<%# Bind("value.Pair.Approved") %>' CssClass="form-control pull-right" />
                                    <asp:TextBox ID="txtRetrevedQuantity" runat="server" Text='<%# Bind("value.Pair.Approved") %>' CssClass="form-control pull-right" />
                                    <asp:TextBox ID="txtItemId" ReadOnly="true" Visible="false"  runat="server" Text='<%# Bind("key.SupplierItem.ItemID") %>' CssClass="form-control pull-right" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="box-footer">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger pull-right ml-5" />
                    <asp:Button ID="btnCollected" runat="server" Text="Collected And Ready for Shipment" OnClick="btnCollected_Click" CssClass="btn btn-success pull-right mr-5" />
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">

            <div class="box">
                <div class="box-header">
                    <h5>Related Requests and Departments</h5>
                </div>
                <div class="box-body">
                    <asp:GridView ID="gvRequisition" runat="server" AutoGenerateColumns="false"  CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ReqNumber" HeaderText="Department name" />
                            <asp:BoundField DataField="DepartmentName" HeaderText="Needed" />
                            <asp:TemplateField HeaderText="Action" ControlStyle-CssClass="pull-right">
                                <ItemTemplate>
                                    <a href="#" class="btn btn-default" data-id='<%# Eval("ReqID")%>'>Items</a>
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
