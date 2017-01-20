<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="ApproveReject.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.WebForm2" %>
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
                                <asp:GridView ID="gvRequestedRequisition" runat="server" AutoGenerateSelectButton="True"></asp:GridView>
                                        

                                <!-- /.box-body -->

                            </div>

                        </div>

                    </div>

               

                <!-- /.content -->



                
                                   
                                                                

                                            </div>

                                            <!-- /.box-body -->

                                        

                           

                       
        
    </form>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="empMainJs" runat="server">
</asp:Content>


