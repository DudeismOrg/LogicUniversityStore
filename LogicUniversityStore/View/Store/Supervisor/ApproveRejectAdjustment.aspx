<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="ApproveRejectAdjustment.aspx.cs" Inherits="LogicUniversityStore.View.Store.Supervisor.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Approve/Reject Adjustments</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Approve/Reject Adjustments</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
     <form id="approveRejectAdjustment" runat="server">
    <div class="row">

                        <div class="col-xs-12">

                            <div class="box">                               
                                <div>                                    
                                        <asp:GridView ID="gvAdjustmentItemList" runat="server" AutoGenerateColumns="False" CellPadding="10" CellSpacing="5" ForeColor="#333333" GridLines="None" Height="93px" Width="977px"  >
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                              <asp:BoundField DataField="StockAdjustmentNumber" HeaderText="Stock Adjustment Number" ItemStyle-Height="50px"/>
                                              <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
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
