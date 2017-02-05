<%@ Page Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="CreateRetreivalForm.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.Modal.RetrievalForm" %>

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
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
    <h1>Create Retriveal Form</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li a="#">Purchase Order</li>
        <li class="active">Create Retriveal Form</li>
    </ol>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="box box-success">
                <div class="box-header">
                </div>
                <div class="box-body">

                    <table class="table">
                        <tbody>
                            <tr>
                                <th style="width: 10px">#</th>
                                <th>Item Name</th>
                                <th>Requested Quantity</th>
                                <th>Approved Quantity</th>
                                <th>Click to Expand</th>
                            </tr>
                            <%--</tbody>
                        <tbody>--%>
                            <% int i = 1; foreach (var req in requistionDic)
                                { %>

                            <tr data-toggle="collapse" data-target="#departments-<%= i%>" class="accordion-toggle">
                                <td><%= i %></td>
                                <td><%= req.Key.SupplierItem.Item.ItemName %></td>
                                <td><%= req.Value.Pair.Needed%></td>
                                <td><%= req.Value.Pair.Approved %></td>
                                <td>
                                    <a class="btn btn-default" data-toggle="collapse" data-target="#departments-<%= i%>" href="javascript:void(0);"><i class="fa fa-briefcase" aria-hidden="true"></i></a>
                                </td>
                            </tr>
                            <tr class="hiddenRow">
                                <td colspan="5" class="hiddenRow" style="padding: 0px; text-align: center">
                                    <div class="accordian-body collapse" id="departments-<%= i%>">
                                        <div class="col-md-12" style="text-align: center">
                                            <table class="table pull-right" style="background-color: #d2d6de; border-radius: 7px; width: 50%">
                                                <thead>
                                                    <tr>
                                                        <th>Department Name</th>
                                                        <th>Needed Qnty</th>
                                                        <th>Approved Qnty</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <% foreach (var dic in req.Value.DictionaryMap)
                                                        {%>
                                                    <tr>
                                                        <td><%= dic.Key.DepartmentName %></td>
                                                        <td><%= dic.Value.Needed %></td>
                                                        <td><%= dic.Value.Approved %></td>
                                                    </tr>
                                                    <%} %>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                            <% i += 1;
                                } %>
                        </tbody>
                    </table>
                </div>
                <div class="box-footer">
                    <asp:Button ID="btnCancel" runat="server" Text="Back and Reselect" OnClick="btnCancel_Click" CssClass="btn btn-danger pull-right mrl-5" />
                    <asp:Button ID="btnGenerateR" runat="server" Text="Generate Retrieval" OnClick="btnGenerateR_Click"  CssClass="btn btn-success pull-right mrl-5" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
</asp:Content>
