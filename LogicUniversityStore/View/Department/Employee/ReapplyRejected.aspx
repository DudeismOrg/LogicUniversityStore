﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Employee/Employee.master" AutoEventWireup="true" CodeBehind="ReapplyRejected.aspx.cs" Inherits="LogicUniversityStore.View.Department.Employee.WebForm3" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Request History</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Reapply Requests</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
    <form id="rejectedRequests" runat="server">
    <div class="row">

                        <div class="col-xs-12">

                            <div class="box">

                                <div class="box-header">



                                    <div class="input-group input-group-sm pull-left" style="width: 150px;">

                                        <input type="text" name="table_search" class="form-control pull-left" placeholder="Search">



                                        <div class="input-group-btn">

                                            <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>

                                        </div>

                                    </div>                                    

                                </div>

                                <!-- /.box-header -->

                                <div>

                                    
                                        <asp:GridView ID="gvRejectedRequests" runat="server"   OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged="gvRejectedRequisition_SelectedIndexChanged" AutoGenerateColumns="False"  CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" Height="100px" Width="961px" OnRowDeleting="gvRejectedRequests_RowDeleting"  >
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                              <asp:BoundField DataField="ReqID" HeaderText="RequisitionID" />
                                              <asp:BoundField DataField="ReqNumber" HeaderText="RequisitionNumber" />
                                              <asp:BoundField DataField="ReqDate" HeaderText="Requisition Date" DataFormatString="{0:D}" />                                             
                                              <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                              <asp:CommandField HeaderText="Delete" ButtonType="Button" ShowDeleteButton="true" ControlStyle-CssClass="btn btn-sm btn-danger"  />                                                                                                              
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        </asp:GridView>
                                    

                                </div>

                                <!-- /.box-body -->

                            </div>

                            <!-- /.box -->

                        </div>

                    </div>
        </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="empMainJs" runat="server">
</asp:Content>