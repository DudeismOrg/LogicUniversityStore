<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Employee/Employee.master" AutoEventWireup="true" CodeBehind="CancelUpdatePendingApproval.aspx.cs" Inherits="LogicUniversityStore.View.Department.Employee.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Cancel/Update Pending Approval Requests</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Cancel/Update Pending Requests</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
<form id="pendingRequests" runat="server">
    <div class="row">

                        <div class="col-xs-12">

                            <div class="box">                                                              
                                <div>

                                    
                                        <asp:GridView ID="gvPendingRequests" runat="server"  OnSelectedIndexChanged="gvPendingRequests_SelectedIndexChanged" AutoGenerateColumns="False"  CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" Height="100px" Width="961px" OnRowDeleting="gvPendingRequests_RowDeleting"  >
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                              <asp:BoundField DataField="ReqID" HeaderText="RequisitionID" />
                                              <asp:BoundField DataField="ReqNumber" HeaderText="RequisitionNumber" />
                                              <asp:BoundField DataField="ReqDate" HeaderText="Requisition Date" DataFormatString="{0:D}" />                                             
                                              <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                              <asp:CommandField HeaderText="View" ButtonType="Button" ShowSelectButton="true" SelectText="View" ControlStyle-CssClass="btn btn-sm btn-primary"  />
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
