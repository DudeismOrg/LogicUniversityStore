<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="ApproveRejectRequisitionItems.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Requisition Details</h1>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
   

        <div class="col-md-12">

                                    <div class="col-md-6">

                                        <div class="pull-left" style="text-align: left">

                                            <h5><u>Request form Number</u>: #Numb</h5>

                                            <h5><u>Created Date</u>: dd-mm-yyyy</h5>

                                            <h5><u>Remark by Employee</u>: Some Remark</h5>

                                        </div>

                                    </div>

                                    <div class="col-md-6">

                                        <div class="pull-right" style="text-align: right">

                                            <h5><u>Department</u>: Dept </h5><small>Dept code</small>

                                            <h5><u>Created By</u>: Name</h5>

                                        </div>

                                    </div>

                                </div>

                                <div class="col-md-12" style="height:10px"></div>

                                <form id="requisitionDetails" runat="server">
                                    

                                    <div class="col-md-12" style="height:10px"></div>

                                    <div class="col-md-12">

                                        <div class="box">

                                            <div class="box-header">

                                                <h3 class="box-title">Requested Items</h3>

                                            </div>

                                            <!-- /.box-header -->

                                            <div class="box-body no-padding">

                                                <asp:GridView ID="gvRequisitionDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="953px">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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

                                    </div>
                                    <div class="modal-footer">

                                <%--<button type="button" class="btn btn-success">Approve</button>--%>

                                <%--<button type="button" class="btn btn-danger">Reject</button>--%>

                                <%--<button type="button" class="btn btn-default">Close</button>--%>
                                        <asp:Button ID="btnApprove" CssClass="btn btn-success" runat="server" Text="Approve" OnClick="btnApprove_Click" />
                                        <asp:Button ID="btnReject" CssClass="btn btn-danger" runat="server" Text="Reject" OnClick="btnReject_Click" />
                                        <asp:Button ID="btnClose" CssClass="btn btn-default" runat="server" Text="Back" OnClick="btnClose_Click" />

                            </div>

        </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="empMainJs" runat="server">
</asp:Content>
