<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="ApproveReject.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.WebForm2" EnableEventValidation="false" %>

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

    <section class="content-header">
        <h1>Approve/Reject Requests</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li class="active">Approve/Reject Requests</li>
        </ol>
    </section>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div>
                    <asp:GridView ID="gvRequestedRequisition" runat="server" OnSelectedIndexChanged="gvRequestedRequisition_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" AllowPaging="true">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ReqID" HeaderText="RequisitionID" ItemStyle-Height="50px" />
                            <asp:BoundField DataField="ReqNumber" HeaderText="RequisitionNumber" />
                            <asp:BoundField DataField="ReqDate" HeaderText="Requisition Date" DataFormatString="{0:D}" />
                            <asp:CommandField HeaderText="View" ButtonType="Button" ShowSelectButton="true" SelectText="View" ControlStyle-CssClass="btn btn-sm btn-primary" />
                        </Columns>
                    </asp:GridView>
                </div>
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

























