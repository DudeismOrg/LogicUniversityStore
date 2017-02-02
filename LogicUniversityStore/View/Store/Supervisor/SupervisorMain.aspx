<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="SupervisorMain.aspx.cs" Inherits="LogicUniversityStore.View.Store.Supervisor.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Dashboard<small>Version 2.0</small></h1>
    <a href="SupervisorMain.aspx">SupervisorMain.aspx</a>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">Dashboard</li>
    </ol>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="empMainContentBlock" runat="server">
    <div class="row" style="margin-top: 10%;">

        <div class="col-md-12">

            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-green"><i class="ion ion-ios-cart-outline"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text" style="margin-top: 20%;">Approve/Reject Adjustment</span>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="fa fa-spinner"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Generate Reports</span>
                        <span class="info-box-number">20</span>
                    </div>
                </div>
            </div>           

        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="empMainJs" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

        });
    </script>
</asp:Content>

