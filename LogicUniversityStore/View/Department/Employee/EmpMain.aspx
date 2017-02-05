<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Employee/Employee.master" AutoEventWireup="true" CodeBehind="EmpMain.aspx.cs" Inherits="LogicUniversityStore.View.Department.Employee.EmpMain" %>

<asp:Content ID="Content2" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Dashboard</h1>
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
                        <asp:HyperLink ID="lnkRequisitions" runat="server" NavigateUrl="~/View/Department/Employee/RequisitionForm.aspx">
                        <span class="info-box-text" style="margin-top: 20%;">Requisition Form</span></asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-aqua"><i class="fa fa-spinner"></i></span>
                    <div class="info-box-content">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Department/Employee/CancelUpdatePendingApproval.aspx">
                        <span class="info-box-text">Pending Approval</span>
                        </asp:HyperLink>
                        <span class="info-box-number">
                            <asp:Label ID="lblPendingApproval" runat="server"></asp:Label>
                        </span>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-red"><i class="fa fa-thumbs-o-down"></i></span>
                    <div class="info-box-content">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/View/Department/Employee/ReapplyRejected.aspx">
                        <span class="info-box-text">Rejected Requests</span>
                        </asp:HyperLink>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-6 col-xs-12">
                <div class="info-box">
                    <span class="info-box-icon bg-yellow"><i class="fa fa-calendar"></i></span>
                    <div class="info-box-content">
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/View/Department/Employee/RequestHistory.aspx">
                        <span class="info-box-text" style="margin-top: 20%;">Request History</span>
                        </asp:HyperLink>
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
