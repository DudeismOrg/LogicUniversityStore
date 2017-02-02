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
    <form runat="server">


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
                        <%--<table class="table">
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
                            </tr>--%>

                        <%--   <asp:ListView ID="lvSearchResults" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <input value="<%# Eval("key.ReqID") %>" type="checkbox"></td>
                                        <td><%# Eval("key.ReqID") %>.</td>
                                        <td><%# Eval("key.ReqNumber") %></td>
                                        <td><%# Eval("key.Department.DepartmentName") %></td>
                                        <td>
                                            <div class="progress progress-xs progress-striped active">
                                                <div class="progress-bar progress-bar-success" style="width: <%# Eval("value") %>%"></div>
                                            </div>
                                        </td>
                                        <td>
                                            <%# Eval("key.ReqDate") %>
                                        </td>
                                        <td> 
                                            <a href="#" data-id="<%# Eval("key.ReqID") %>" class="btn btn-sm 
                                                <%# string.Format(Eval("value").Equals(100) ? "btn-danger" : "btn-primary") %>           
                                                set-item-values">View/Edit</a>
                                            <a href="#" class="btn btn-sm btn-warning">Send Note to Department</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>--%>

                        <asp:GridView ID="gvRequisitions" runat="server" CssClass="table" BackColor="#FF6666" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%--<input value="<%# Eval("key.ReqID") %>" type="checkbox"></td>--%>
                                        <asp:CheckBox ID="cbReq" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="key.ReqID" HeaderText="Request ID" />

                                <asp:BoundField DataField="key.ReqNumber" HeaderText="Request ID" />


                                <asp:BoundField DataField="key.Department.DepartmentName" HeaderText="Request ID" />

                                <asp:TemplateField HeaderText="Fullfillment Status">
                                    <ItemTemplate>
                                        <div class="progress progress-xs progress-striped active">
                                            <div class="progress-bar progress-bar-success" style="width: <%# Eval("value") %>%"></div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <%# Eval("key.ReqDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View/Edit">
                                    <ItemTemplate>
                                        <a href="#" data-id="<%# Eval("key.ReqID") %>" class="btn btn-sm 
                                                <%# string.Format(Eval("value").Equals(100) ? "btn-danger" : "btn-primary") %>           
                                                set-item-values">View/Edit</a>
                                        <%--<a href="#" class="btn btn-sm btn-warning">Send Note to Department</a>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                            <EditRowStyle BackColor="#FF6666" BorderStyle="None" />
                        </asp:GridView>

                        <%--                        </tbody>
                    </table>--%>
                    </div>
                    <div class="box-footer" style="margin-top: 20px">
                        <a class="btn btn-primary pull-right" style="margin-left: 5px" href="#">View Total Request Item</a>
                        <%--<a class="btn btn-success pull-right" data-toggle="modal" data-target="#retrievel-modal" style="margin-right: 5px" href="#">Generate Retrieval Form</a>--%>
                        <asp:Button ID="btnGenRetrival" runat="server" Text="Generate Retrival" OnClick="btnGenRetrival_Click" />
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>


        <%--<div class="modal fade" id="details-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Requested Items</h4>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="modal-body" id="main-modal-id">
                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success">Save</button>
                    <button type="button" class="btn btn-default">Close</button>
                </div>
            </div>
        </div>
    </div>--%>


        <%--<div class="modal fade" id="retrievel-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="retrievel-modalLabel">Generate Retrieval Form</h4>
                </div>
                <div class="modal-body">
                    <div class="col-md-12">
                        <div class="box">
                            <!-- /.box-header -->
                            <div class="box-body no-padding">
                                <table class="table table-condensed">
                                    <tbody>
                                        <tr>
                                            <th style="width: 10px">#</th>
                                            <th>Request Number</th>
                                            <th>Department</th>
                                            <th>Status</th>
                                            <th>Detail</th>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success"> Retrieval Form</button>
                    <button type="button" class="btn btn-default">Close</button>
                </div>
            </div>
        </div>
    </div>--%>
        <div id="divStudentFullRecord" style="min-height: 92px; max-height: none; height: 378px; width: 0px" title="Basic dialog">

        </div>

        <%--<div id="divPopup" style="min-height: 92px;max-height: none;height: 378px; width:0px" title="Basic dialog">
        
    </div>--%>

    </form>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".set-item-values").click(function () {
                var id = $(this).data("id");
                $("#divStudentFullRecord").html("Please wait content is Loading...");
                $("#divStudentFullRecord")
                    .load("/View/Store/Clerk/Modal/RequestFormAlterItems.aspx", { Id: id })
                    .dialog({
                        autoOpen: false,
                        show: "blind",
                        hide: "explode",
                        modal: true,
                        width: 673,
                        title: "Requested Items"
                    });
                $("#divStudentFullRecord").dialog("open");
                return false;
            });

        });




    </script>



</asp:Content>
