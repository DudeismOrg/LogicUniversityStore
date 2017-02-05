<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="ManageRole.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.ManageRole" %>

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

        .mrl-5 {
            margin-left: 5px;
            margin-right: 5px;
        }

        .height-style{
            height: 180px;
        }

        select{
            height: 180px !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <section class="content-header">
        <h1>Manage HOD Roles</h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
            <li class="active">Manage HOD Roles</li>
        </ol>
    </section>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                </div>
                <div class="box-body">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <label>Select an Employee</label>
                            <asp:ListBox ID="lstEmp" runat="server" SelectionMode="Single" AutoPostBack="true" DataTextField="FullName" DataValueField="UserID" OnSelectedIndexChanged="lstEmp_SelectedIndexChanged" CssClass="form-control col-md-12 height-style"></asp:ListBox>
                        </div>
                        <div class="col-md-6" style="text-align: right">
                            <label class="pull-tight">Available Rolles</label>
                            <div class="roles-table col-md-12" style="border: 1px solid; border-color: #d2d6de; padding: 7px">
                                <asp:ListView runat="server" ID="lstRoles" DataKeyNames="RoleCode">
                                    <LayoutTemplate>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <div class="col-md-12" style="text-align: right">
                                            <table class="pull-right">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            <asp:Label runat="server" Text='<%# Eval("RoleName") %>'></asp:Label>
                                                        </th>
                                                        <th>
                                                            <asp:CheckBox ID="ckbRole" runat="server" AutoPostBack="true" OnCheckedChanged="ckbRole_CheckedChanged" CssClass="pull-right" />
                                                        </th>
                                                    </tr>
                                                </thead>
                                            </table>

                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-danger pull-right mrl-5" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success pull-right mrl-5" />
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
