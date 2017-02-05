<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="RetrievalForm.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.RetrievalForm" %>

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
    <h1>Retrievals</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Retrievals</li>
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
                    <asp:GridView ID="gvRetrievList" runat="server" AutoGenerateColumns="false" OnRowCommand="gvRetrievList_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="RetrievalID" AllowPaging="false">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="RetrievalNumber" HeaderText="Retrieval Number" />
                            <asp:BoundField DataField="RetrievalDate" HeaderText="Generated Date" />
                            <asp:TemplateField HeaderText="Collect Items" HeaderStyle-CssClass="pull-right">
                                <ItemTemplate>
                                    <span style="text-align:center">
                                        <asp:Button ID="btnView" runat="server" 
                                            CommandName='View'
                                            CommandArgument='<%# Eval("RetrievalID") %>' 
                                            Text='Collect'
                                            CssClass='btn btn-primary pull-right' />
                                    </span>
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
