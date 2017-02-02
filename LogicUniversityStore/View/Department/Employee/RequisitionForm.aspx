<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Employee/Employee.master" AutoEventWireup="true" CodeBehind="RequisitionForm.aspx.cs" Inherits="LogicUniversityStore.View.Department.Employee.RequisitionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
    <h1>Request Form</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Request Form</li>
    </ol>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
   
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Requisition Form Number: DDS/111/99</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                        <div class="box-body">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <div class="pull-left">
                                        <h3>Department: CS Department</h3>
                                        <span>Department Code: CSD</span>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="pull-right">
                                        <h3>Employee Name: Name</h3>
                                        <span>Employee Number: 123</span><br>
                                        <span>Employee Email: email@email.com</span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="height: 20px"></div>
                            <div class="col-md-12">
                                <div class="panel panel-primary">
                                    <div class="panel-body">
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <label>Select Category</label>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="DdlCategories" runat="server" AutoPostBack="true" CssClass="form-control select2"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="height: 10px"></div>
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <label>Select Item</label>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="DdlItems" runat="server" CssClass="form-control select2" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-12" style="height: 10px"></div>
                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <label>Quantity</label>
                                            </div>
                                            <div class="col-md-8">
                                                <div class="input-group">
                                                   <%-- <input class="form-control" type="text" placeholder="Enter Quntity">--%>
                                                    <asp:TextBox ID="tbAmount" runat="server" CssClass="form-control" ></asp:TextBox>
                                                    <span class="input-group-addon"> 
                                                        <span >Unit: </span>
                                                        <asp:Label ID="lblUnit" runat="server" Text=" "></asp:Label>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-footer" style="height: 50px">
                                    <%--    <a class="pull-right btn btn-success">Add Item</a>--%>
                                        <asp:Button ID="btnAddItem"  runat="server" Text="Add Item" CssClass="pull-right btn btn-success" OnClick="btnAddItem_Click"/>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12" style="height: 20px"></div>
                            <div class="col-md-12">
                                <div class="box">
                                    <div class="box-header">
                                        <h3 class="box-title">Selected Items</h3>
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body no-padding">
                                        <%--<table class="table table-condensed">
                                            <tbody>
                                                <tr>
                                                    <th style="width: 10px">#</th>
                                                    <th>Item Code</th>
                                                    <th>Category</th>
                                                    <th>Item</th>
                                                    <th>Qty</th>
                                                    <th style="width: 40px">Remove</th>
                                                </tr>
                                                <tr>
                                                    <td>1.</td>
                                                    <td>C001</td>
                                                    <td>Clip</td>
                                                    <td>Clip Double2</td>
                                                    <td>
                                                        <span class="badge bg-red">5 Units</span>
                                                    </td>
                                                    <td>
                                                        <a href="#">
                                                            <i class="fa fa-close" aria-hidden="true"></i>
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>2.</td>
                                                    <td>E001</td>
                                                    <td>Envelop</td>
                                                    <td>Envelop Item</td>
                                                    <td>
                                                        <span class="badge bg-red">2 Units</span>
                                                    </td>
                                                    <td>
                                                        <a href="#"><i class="fa fa-close" aria-hidden="true"></i></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>3.</td>
                                                    <td>P001</td>
                                                    <td>Pen</td>
                                                    <td>Pen Item</td>
                                                    <td>
                                                        <span class="badge bg-red">1 Units</span>
                                                    </td>
                                                    <td>
                                                        <a href="#"><i class="fa fa-close" aria-hidden="true"></i></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>4.</td>
                                                    <td>C001</td>
                                                    <td>Clip</td>
                                                    <td>Clip Double1</td>
                                                    <td>
                                                        <span class="badge bg-red">5 Units</span>
                                                    </td>
                                                    <td>
                                                        <a href="#"><i class="fa fa-close" aria-hidden="true"></i></a>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>--%>
                                     
                                        <asp:GridView ID="gvReqItems" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="576px" OnRowCommand="GridView1_RowCommand">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <Columns>
                                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                                <asp:BoundField DataField="SupplierItem" HeaderText="Description" />
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="tbQuantity" runat="server" Text='<%# Eval("Quantity") %>'> </asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField >
                                                    <ItemTemplate>
                                                        <asp:Button runat="server" ID="btnModify" Text="Modify" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%-- <asp:BoundField DataField="Quantity" HeaderText="Quantity" />   --%>
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
                            </div>
                            <div class="col-md-12" style="height: 20px"></div>
                            <div class="col-md-12">
                                <label>Remarks</label>
                                <div class="box-body pad">
                                    <textarea class="textarea" placeholder="Place some text here" style="width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;"></textarea>
                                </div>
                            </div>


                        </div>
                        <!-- /.box-body -->

                        <div class="box-footer">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="pull-right btn btn-danger" OnClick="btnCancel_Click" />
                            <%--<button type="submit" class="pull-right btn btn-danger" style="margin-left: 5px">Cancel</button>--%>
                           <%-- <button type="submit" class="pull-right btn btn-primary" style="margin-right: 5px">Put Request</button>--%>
                            <asp:Button ID="btnSubmit" runat="server" Text="Place Request" CssClass="pull-right btn btn-primary" OnClick="btnSubmit_Click" />
                        </div>

                </div>
            </div>
        </div>

</asp:Content>
