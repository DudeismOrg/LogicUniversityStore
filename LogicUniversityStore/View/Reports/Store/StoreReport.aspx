<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="StoreReport.aspx.cs" Inherits="LogicUniversityStore.View.Reports.Store.StoreReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="clrkCssBlock" runat="server">
    <style type="text/css">
        .hide {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">

    <form id="form1" runat="server">
        <div class="panel panel-primary">
            <div class="panel-body">
                <a href="#" id="show-rpt-one" class="btn btn-success">Report One</a>
                <a href="#" class="btn btn-success">Report Two</a>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-body">
                <div id="first-report" class="">
                    <CR:CrystalReportViewer ID="testReport" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="Test_Report" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
                    <CR:CrystalReportSource ID="Test_Report" runat="server">
                        <report filename="TEST.rpt">
                        </report>
                    </CR:CrystalReportSource>
                </div>
            </div>
        </div>
    </form>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
    <script type="text/javascript">
        $("#show-rpt-one").click(function () {
            alert("asdsad");
            $("#first-report").removeClass("hide");
            $("#second-report").addClass("hide");
        });
    </script>
</asp:Content>
