<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="HodMain.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Dashboard<small>Version 2.0</small></h1>
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
                    <span class="info-box-icon bg-green"><i class="fa fa-star-half-full"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Approve/Reject</span>
                        <span class="info-box-number">10</span>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="fa fa-users"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Manage Roles</span>
                        
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-red"><i class="fa fa-thumbs-o-down"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text">Cancel/Update Requisition</span>
                        <span class="info-box-number">10</span>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-yellow"><i class="fa fa-calendar"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text" style="margin-top: 20%;">Request History</span>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="fa fa-battery-empty"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text" style="margin-top: 20%;">Track Outstanding</span>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-yellow"><i class="fa fa-bar-chart"></i></span>
                    <div class="info-box-content">
                        <span class="info-box-text" style="margin-top: 20%;">Generate Report</span>
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
