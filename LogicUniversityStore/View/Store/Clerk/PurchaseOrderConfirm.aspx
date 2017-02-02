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


        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header">
                        <div class="input-group input-group-sm pull-left" style="width: 150px;">
                        </div>
                    </div>
                    <div class="box-body">
                        <asp:GridView ID="gvPurchaseOrders" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" DataKeyNames="suplierId" AllowPaging="true" PageSize="10">
                            <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:TextBox Visible="false" ID="idVal" runat="server" Text='<%#Bind("suplierId") %>'></asp:TextBox>
                                  </ItemTemplate>
                              </asp:TemplateField>
                                <asp:BoundField DataField="suplierId" HeaderText="#" ReadOnly="true" />
                                <asp:BoundField DataField="suplierName" HeaderText="Supplier" ReadOnly="true" />
                                <asp:BoundField DataField="supplierContact" HeaderText="Supplier Staff" ReadOnly="true" />
                                <asp:BoundField DataField="supplierPhone" HeaderText="Phone" ReadOnly="true" />
                                <%--<asp:BoundField DataField="supplierAddress" HeaderText="Address" ReadOnly="true" />--%>
                                <asp:BoundField DataField="registration" HeaderText="Registraion Number" ReadOnly="true" />
                                <asp:TemplateField HeaderText="Expected Delivery Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtReorder" runat="server" Text='<%# Bind("expectedDeliveryDate") %>' CssClass="form-control"  ReadOnly="true"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="supRemark" CssClass="form-control suplier-drp" runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Items">
                                    <ItemTemplate>
                                        <a class="btn btn-success viewItems" href="#" data-id="<%# Eval("suplierId")%>">Items</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="box-footer">
                        <a href="#" class="btn btn-danger pull-right" style="margin-left: 5px">Cancel</a>
                        <asp:Button ID="cnfrmPo" class="btn btn-success pull-right" OnClick="POnfirmPo_Click" runat="server" Text="Confirm and Generate PO" />
                    </div>
                </div>
            </div>
        </div>
        <div id="divItemsInPO" style="min-height: 92px; max-height: none; height: 378px; width: 0px" title="Basic dialog">
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
