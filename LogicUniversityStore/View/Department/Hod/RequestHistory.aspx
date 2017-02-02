<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="RequestHistory.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.WebForm4" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Request History</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Request History</li>
    </ol>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
    <form id="requestHistory" runat="server">
    <div class="row">

                        <div class="col-xs-12">

                            <div class="box">                               
                                <div>

                                    
                                        <asp:GridView ID="gvRequestHistory" runat="server" AutoGenerateColumns="False"   OnSelectedIndexChanged="gvRequestHistory_SelectedIndexChanged" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" Height="100px" Width="813px"  >
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                              <asp:BoundField DataField="ReqID" HeaderText="RequisitionID" ItemStyle-Height="50px" />
                                              <asp:BoundField DataField="ReqNumber" HeaderText="RequisitionNumber" />
                                              <asp:BoundField DataField="ReqDate" HeaderText="Requisition Date" DataFormatString="{0:D}" />
                                              <asp:BoundField DataField="Status" HeaderText="Requisition Status" />
                                              <asp:BoundField DataField="Remark" HeaderText="Remark" />
                                              <asp:CommandField HeaderText="View" ButtonType="Button" ShowSelectButton="true" SelectText="View" ControlStyle-CssClass="btn btn-sm btn-primary"  />
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
