<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="ApproveReject.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.WebForm2" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Approve/Reject Requests</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Request Form</li>
    </ol>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
    <form id="ApproveReject" runat="server">
     <div class="row">
     <div class="col-md-12">
     <div class="box">
     <div class="box-header">
     <div class="input-group input-group-sm pull-left" style="width: 150px;">
     <%--<input type="text" name="table_search" class="form-control pull-left" placeholder="Search"> --%>
     <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control pull-left"></asp:TextBox>
     <div class="input-group-btn">
     <%-- <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button> --%>
     <asp:Button ID="btnSearch" runat="server"   CssClass="btn btn-default fa fa-search"  />
     </div>
     </div>
     </div>
     <!-- /.box-header -->
                               
     <div>
     <asp:GridView ID="gvRequestedRequisition" runat="server" OnRowDataBound = "OnRowDataBound" AutoGenerateColumns="False"   OnSelectedIndexChanged="gvRequestedRequisition_SelectedIndexChanged" CellPadding="20" CellSpacing="5" ForeColor="#333333" GridLines="None" Height="100px" Width="661px"  >
     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
       <Columns>
       <asp:BoundField DataField="ReqID" HeaderText="RequisitionID" />
       <asp:BoundField DataField="ReqNumber" HeaderText="RequisitionNumber" />
       <asp:BoundField DataField="ReqDate" HeaderText="Requisition Date" />
       </Columns>
     <EditRowStyle BackColor="#999999" BorderStyle="None" />
     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
     <SelectedRowStyle BackColor="#999999" Font-Bold="True" ForeColor="#333333" />
     <SortedAscendingCellStyle BackColor="#E9E7E2" />
     <SortedAscendingHeaderStyle BackColor="#506C8C" />
     <SortedDescendingCellStyle BackColor="#FFFDF8" />
     <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
     </asp:GridView>                                                         
     <!-- /.box-body -->
     </div>
     </div>
     </div>
     <!-- /.content -->
</div>
</form>        
<!-- /.box-body -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="empMainJs" runat="server">
</asp:Content>
                
                                   
                                                                

                                            
        





            

                                            

                                        

                           

                       
        
    



