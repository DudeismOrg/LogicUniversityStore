<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Employee/Employee.master" AutoEventWireup="true" CodeBehind="RequisitionForm.aspx.cs" Inherits="LogicUniversityStore.View.Department.Employee.RequisitionForm" %>

<asp:Content ID="Content4" ContentPlaceHolderID="empCssBlk" runat="server">
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
    <h1>Request Form</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Request Form</li>
    </ol>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Requisition Form Number:<asp:Label ID="lblReqNum" runat="server"></asp:Label></h3>
                </div>
                <div class="box-body">
                    <div class="col-md-12">
                        <%--<div class="col-md-6">
                            <div class="pull-left">
                                <h3>Department: CS Department</h3>
                                <span>Department Code: CSD</span>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="pull-right">
                                <h3>Employee Name: Name</h3>
                                <span>Employee Number: 123</span><br>
                                <span>Employee Email: email@email.com</span>
                            </div>
                        </div>--%>
                    </div>
                    <div class="col-md-12" style="height: 20px"></div>
                    <div class="col-md-12">
                        <div class="panel panel-primary">
                            <div class="panel-body">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <label>Select Category</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="DdlCategories" runat="server" AutoPostBack="true" CssClass="form-control select2" OnSelectedIndexChanged="DdlCategories_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Category must be selected" Display="Dynamic" Text="*" ControlToValidate="DdlCategories" ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12" style="height: 10px"></div>
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <label>Select Item</label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="DdlItems" runat="server" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="DdlItems_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Item must be selected" Display="Dynamic" Text="*" ControlToValidate="DdlItems" ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-12" style="height: 10px"></div>
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <label>Quantity</label>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="input-group">
                                            <asp:TextBox ID="tbAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Quantity must be entered" Display="Dynamic" Text="*" ControlToValidate="tbAmount" ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Quantity must be a integer" Text="*" Display="Dynamic" ControlToValidate="tbAmount" Type="Integer" ForeColor="Red" Operator="DataTypeCheck" ValidationGroup="vg"></asp:CompareValidator>
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Quantity must be greater than 0" Text="*" Display="Dynamic" ControlToValidate="tbAmount" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0" ValidationGroup="vg"></asp:CompareValidator>
                                            <span class="input-group-addon">
                                                <span>Unit: </span>
                                                <asp:Label ID="lblUnit" runat="server" Text=" "></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="panel-footer" style="height: 50px">
                                <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="pull-right btn btn-success" OnClick="btnAddItem_Click" ValidationGroup="vg" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="height: 20px"></div>
                    <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" ShowSummary="true" DisplayMode="BulletList" ShowMessageBox="True" ValidationGroup="vg" />
                    <div class="col-md-12">
                        <div class="box">
                            <div class="box-header">
                                <h3 class="box-title">Selected Items</h3>
                            </div>
                            <div class="box-body">
                                <asp:GridView ID="gvReqItems" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" AllowPaging="true" OnRowCommand="gvReqItems_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Category" HeaderText="Category" />
                                        <asp:BoundField DataField="SupplierItem" HeaderText="Description" />
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbQuantity" runat="server" Text='<%# Eval("Quantity") %>'> </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Quantity must be entered" Display="Dynamic" Text="*" ControlToValidate="tbQuantity" ForeColor="Red" ValidationGroup="vg1"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Quantity must be a integer" Text="*" Display="Dynamic" ControlToValidate="tbQuantity" Type="Integer" ForeColor="Red" ValidationGroup="vg1" Operator="DataTypeCheck"></asp:CompareValidator>
                                                <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Quantity must be greater than 0" Text="*" Display="Dynamic" ControlToValidate="tbQuantity" ForeColor="Red" ValidationGroup="vg1" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="btnModify" Text="Remove" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="height: 20px"></div>
                    <div class="col-md-12">
                        <label>Remarks</label>
                        <div class="box-body pad">
                            <asp:TextBox ID="tbRemarks" runat="server" CssClass="textarea" placeholder="Place some text here" Style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="pull-right btn btn-danger ml-5" OnClick="btnCancel_Click" />
                    <asp:Button ID="btnSubmit" runat="server" Text="Place Request" CssClass="pull-right btn btn-primary mr-5" OnClick="btnSubmit_Click" ValidationGroup="vg1" />
                </div>
                <asp:ValidationSummary ID="ValidationSummary2" ForeColor="Red" runat="server" ShowSummary="true" DisplayMode="BulletList" ShowMessageBox="True" ValidationGroup="vg1" />
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
