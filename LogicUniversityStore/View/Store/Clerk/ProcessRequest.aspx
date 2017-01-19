<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="ProcessRequest.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.ProcessRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="clrkCssBlock" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
    <h1>Process Requests</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Process Requests</li>
    </ol>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header">

                    <div class="input-group input-group-sm pull-left" style="width: 150px;">
                        <input type="text" name="table_search" class="form-control pull-left" placeholder="Search">

                        <div class="input-group-btn">
                            <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                        </div>
                    </div>


                    <div class="box-tools">
                        <ul class="pagination pagination-sm no-margin pull-right">
                            <li><a href="#">«</a></li>
                            <li><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">»</a></li>
                        </ul>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class="box-body no-padding">
                    <table class="table">
                        <tbody>
                            <tr>
                                <th style="width: 10px">
                                    <input type="checkbox"></th>
                                <th style="width: 10px">#</th>
                                <th>Request Number</th>
                                <th>Department</th>
                                <th>Fulfilment Status</th>
                                <th>Date</th>
                                <th style="width: 250px; text-align: right">Action</th>
                            </tr>

                            <asp:ListView ID="lvSearchResults" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <input type="checkbox"></td>
                                        <td>1.</td>
                                        <td>#DD/343/F01</td>
                                        <td><%# Eval("CategoryCode") %></td>
                                        <td>
                                            <div class="progress progress-xs progress-striped active">
                                                <div class="progress-bar progress-bar-success" style="width: 90%"></div>
                                            </div>
                                        </td>
                                        <td>01-02-2017
                                        </td>
                                        <td>
                                            <a href="#" data-toggle="modal" data-target="#details-modal" class="btn btn-sm btn-primary">View/Edit</a>
                                            <a href="#" class="btn btn-sm btn-warning">Send Note to Department</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>

                        </tbody>
                    </table>
                </div>
                <div class="box-footer" style="margin-top: 20px">
                    <a class="btn btn-primary pull-right" style="margin-left: 5px" href="#">View Total Request Item</a>
                    <a class="btn btn-success pull-right" data-toggle="modal" data-target="#retrievel-modal" style="margin-right: 5px" href="#">Generate Retrieval Form</a>
                </div>
                <!-- /.box-body -->
            </div>
        </div>
    </div>






    <form runat="server" id="form1">
        <%--<asp:ListView ID="lvSearchResults" runat="server">
            <ItemTemplate>
                <span class="price">$<%# Eval("CategoryCode") %></span><br />
            </ItemTemplate>
        </asp:ListView>--%>
    </form>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
</asp:Content>
