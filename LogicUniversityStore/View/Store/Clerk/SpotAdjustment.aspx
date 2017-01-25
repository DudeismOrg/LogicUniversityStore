<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="SpotAdjustment.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.SpotAdjustment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="clrkCssBlock" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">

    <form id="requestForm" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Adjustment#:
                            <asp:Label ID="lblAdjId" runat="server"></asp:Label></h3>
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
                                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </div>
                                    <div class="col-md-12" style="height: 10px"></div>
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <label>Select Category</label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="DdlCategories" runat="server" AutoPostBack="true" CssClass="form-control select2" OnSelectedIndexChanged="DdlCategories_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="height: 10px"></div>
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <label>Select Item</label>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="DdlItems" runat="server" CssClass="form-control select2"></asp:DropDownList>
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
                                                <asp:TextBox ID="tbAmount" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <asp:Label ID="lblUnits" runat="server"></asp:Label></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12" style="height: 10px"></div>
                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <label>Remarks</label>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="input-group" style="width: ">
                                                <%-- <input class="form-control" type="text" placeholder="Enter Quntity">--%>
                                                <asp:TextBox ID="tbRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-footer" style="height: 50px">
                                    <%--    <a class="pull-right btn btn-success">Add Item</a>--%>
                                    <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="pull-right btn btn-success" OnClick="btnAddItem_Click" />
                                    <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" CssClass="pull-right btn btn-success" OnClick="btnCancelEdit_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12" style="height: 20px"></div>
                        <div class="col-md-12">
                            <div class="box">
                                <div class="box-header">
                                    <h3 class="box-title">Adjusted Items</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body no-padding">

                                    <asp:GridView ID="gvReqItems" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                        AutoGenerateColumns="false" Width="100%" OnRowEditing="EditRow"
                                        DataKeyNames="ItemId" OnRowDeleting="DeleteRow" AllowPaging="true"
                                        PageSize="3">

                                        <Columns>
                                            <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="true" />
                                            <asp:BoundField DataField="ItemName" HeaderText="Description" ReadOnly="true" />
                                            <asp:BoundField DataField="Quantity" HeaderText="Count" ReadOnly="true" />
                                            <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit" ReadOnly="true" />
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" ReadOnly="true" />
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete?">

                                                <ItemTemplate>

                                                    <span onclick="return confirm('Are you sure to delete?')">

                                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" ForeColor="Red" CommandName="Delete" />

                                                    </span>

                                                </ItemTemplate>

                                            </asp:TemplateField>
                                        </Columns>
                                        <AlternatingRowStyle BackColor="White" />

                                        <EditRowStyle BackColor="#efefef" />

                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />

                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />

                                        <RowStyle BackColor="#EFF3FB" />

                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />

                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />

                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />

                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />

                                    </asp:GridView>



                                </div>
                                <!-- /.box-body -->
                            </div>
                        </div>
                        <div class="col-md-12" style="height: 20px"></div>
                    </div>
                    <!-- /.box-body -->

                    <div class="box-footer">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="pull-right btn btn-danger" />
                        <%--<button type="submit" class="pull-right btn btn-danger" style="margin-left: 5px">Cancel</button>--%>
                        <%-- <button type="submit" class="pull-right btn btn-primary" style="margin-right: 5px">Put Request</button>--%>
                        <asp:Button ID="btnSubmit" runat="server" Text="Create Adjustment" CssClass="pull-right btn btn-primary" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>

    </form>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
</asp:Content>
