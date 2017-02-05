<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="RequestHistoryDetails.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.WebForm5" %>

<asp:Content ID="Content4" ContentPlaceHolderID="empMainCss" runat="server">
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

        .ml-5 {
            margin-left: 5px;
        }

        .mr-5 {
            margin-right: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Requisition Details</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
    <div class="col-md-12">
        <div class="box">
            <div class="box-header">
                <h3 class="box-title">Requested Items</h3>
            </div>
            <div class="box-body">
                <asp:GridView ID="gvRequisitionDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" AllowPaging="true">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <HeaderStyle Width="20" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ItemName" HeaderText="Item Name" ItemStyle-Height="50px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="NeededQuantity" HeaderText="Quantity">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="UOM" HeaderText="Unit Of Measure">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="box-footer">
                <asp:Button ID="btnClose" CssClass="btn btn-danger pull-right" runat="server" Text="Close" OnClick="btnClose_Click" />
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="empMainJs" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("table").addClass("table table-condensed");
        });
    </script>
</asp:Content>

