<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="ProcessRequest.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.ProcessRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="clrkCssBlock" runat="server">
    <style type="text/css">
        tbody {
            display: table-row-group;
            vertical-align: middle;
            border-color: inherit;
            border-top-color: inherit;
            border-right-color: inherit;
            border-bottom-color: inherit;
            border-left-color: inherit;
        }

        table {
            border-spacing: 0;
            border-collapse: collapse;
        }

        tr {
            display: table-row;
            vertical-align: inherit;
            border-color: inherit;
        }

        .align-center {
            text-align: center;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
    <h1>Process Requests</h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
        <li class="active">Process Requests</li>
    </ol>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
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
                    </div>
                </div>
                <div class="box-body">
                    <asp:GridView ID="gvRequisitions" runat="server"  ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" Width="100%" AllowPaging="true" >
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbReq" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:TextBox Visible="false" ID="reqIdHiden" runat="server" Text='<%#Bind("key.ReqID") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                                    <a href="#" data-id="<%# Eval("key.ReqID") %>" class="btn btn-sm <%# string.Format(Eval("value").Equals(100) ? "btn-danger" : "btn-primary") %> set-item-values">View/Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#FF6666" BorderStyle="None" />
                    </asp:GridView>
                </div>
                <div class="box-footer" style="margin-top: 20px">
                    <a class="btn btn-primary pull-right" style="margin-left: 10px" href="ProcessRequest.aspx">Reset All Manual Changes</a>
                    <asp:Button ID="btnGenRetrival" CssClass="btn btn-success pull-right" runat="server" Text="Proceed to Generate Retrival"  OnClick="btnGenRetrival_Click" />
                </div>
            </div>
        </div>
    </div>
    <div id="divStudentFullRecord" style="min-height: 92px; max-height: none; height: 378px; width: 0px" title="Basic dialog">
    </div>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("table").addClass("table table-condensed");
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
