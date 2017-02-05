<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="DisbursementsMain.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.DisbursementsMain" %>

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

        .hide {
            display: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
    <h1>Disbursements</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Disbursements</li>
    </ol>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">
                    <h4>Select Departments</h4>
                </div>
                <div class="box-body">
                    <asp:DropDownList ID="DdlDepartment" runat="server" OnSelectedIndexChanged="DdlDepartment_Change" AutoPostBack="true" CssClass="form-control select2 drpDpt"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="col-md-12">
            <div class="box" id="disbDet">
                <div class="box-header">
                    <h4>Disbursements</h4>
                </div>
                <div class="box-body">
                    <div class="col-md-12">






                        <% foreach (var s in requisition)
                            {
                        %>


                        <div class="col-md-12">
                            <div class="box box-default box-solid collapsed-box">
                                <div class="box-header with-border">
                                    <table style="margin: 0px;">
                                        <thead>
                                            <tr>
                                                <th>Disbursement Number: <%= s.Disbursement.DisbursementNumber %></th>
                                                <th>Number of Items: <%= s.NumberOfItems %></th>
                                                <th>Disbursement Generated On: <%= s.Disbursement.DisbursementDate %></th>
                                            </tr>
                                        </thead>
                                    </table>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-plus"></i>
                                        </button>
                                    </div>
                                </div>
                                <div class="box-body" style="display: none;">


                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <th style="width: 10px">#</th>
                                                <th>Item Number</th>
                                                <th>Category</th>
                                                <th>Item</th>
                                                <th>Needed Quantity</th>
                                                <th>Allocated Quantity</th>
                                                <th>Collected Quantity</th>
                                                <th>Delivered Quantity</th>
                                            </tr>

                                            <% foreach (var reqItm in s.RequisitionItems)
                                                { %>
                                            <tr>
                                                <td><%= reqItm.ReqItemID %></td>
                                                <td><%= reqItm.SupplierItem.Item.ItemCode %>.</td>
                                                <td><%= reqItm.SupplierItem.Item.Category %></td>
                                                <td><%= reqItm.SupplierItem.Item.ItemDesc %></td>
                                                <td><%= reqItm.NeededQuantity %></td>
                                                <td><%= reqItm.ApprovedQuantity %></td>
                                                <td><%= reqItm.RetirevedQuantity %></td>
                                                <td>
                                                    <input type="text" class="form-control delivered-qty" name="delivered-<%= reqItm.ReqItemID %>" value="<%= reqItm.RetirevedQuantity %>" />
                                                </td>
                                            </tr>

                                            <% } %>
                                        </tbody>
                                    </table>
                                    <a class="btn btn-success col-md-12 delivered" data-reqid='<%= s.ReqID %>' style="text-align: center; margin-top: 10px">Items Delivered</a>
                                </div>
                            </div>
                        </div>

                        <%} %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("table").addClass("table table-condensed");

            $(".delivered").click(function () {
                var dataId = $(this).data("reqid");
                $.ajax({
                    type: "POST",
                    url: "DisbursementsMain.aspx/GetSetSessionValue",
                    data: '{ ReqIdSess: "' + dataId + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        alert(response.d);
                        $("form").submit();
                    },
                    failure: function (response) {
                        alert("Error in calling Ajax:" + response.d);
                    }

                });

            });

            $(".delivered-qty").click(function () {
                var id = $(this).data();
            });

        });

    </script>
</asp:Content>


