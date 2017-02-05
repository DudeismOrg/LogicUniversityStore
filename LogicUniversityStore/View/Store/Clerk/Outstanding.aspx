<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="Outstanding.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.Outstanding" %>

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
    <h1>Track Outstanding</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Outstanding</li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
    <div class="box box-success">
        <div class="box-header"></div>
        <div class="box-body">
            <asp:GridView ID="gvItems" runat="server"  ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" AllowPaging="true" PageSize="10">
                <Columns>
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                    <asp:BoundField DataField="ItemName" HeaderText="Item" />
                    <asp:BoundField DataField="OutstandingQty" HeaderText="Quantity" />
                </Columns>
            </asp:GridView>
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
