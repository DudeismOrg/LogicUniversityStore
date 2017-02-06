<%@ Page Title="" Language="C#" MasterPageFile="~/View/Store/Clerk/Clerk.master" AutoEventWireup="true" CodeBehind="ClrkMain.aspx.cs" Inherits="LogicUniversityStore.View.Store.Clerk.ClrkMain" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="clrkCssBlock" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="clrkMainHeader" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="clrkMainContentBlock" runat="server">
    <div class="row">
        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-aqua"><i class="ion ion-ios-gear-outline"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">REQUISITIONS</span>
                    <span class="info-box-number"><asp:Label runat="server" ID="lblReqsCount"></asp:Label></span>
                </div>
            </div>
        </div>
        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-red"><i class="fa fa-google-plus"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">DISBURSEMENTS</span>
                    <span class="info-box-number">5</span>
                </div>
            </div>
        </div>

        <div class="clearfix visible-sm-block"></div>

        <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-green"><i class="ion ion-ios-cart-outline"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">PURCHASE ORDERS</span>
                    <span class="info-box-number">06</span>
                </div>
            </div>
        </div>
        <%--<div class="col-md-3 col-sm-6 col-xs-12">
            <div class="info-box">
                <span class="info-box-icon bg-yellow"><i class="ion ion-ios-people-outline"></i></span>

                <div class="info-box-content">
                    <span class="info-box-text">NEXT STOCK-TAKE</span>
                    <span class="info-box-number">28<small>days</small></span>
                </div>
            </div>
        </div>--%>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="box">
                <div class="box-header with-border">
                    <h3 class="box-title">Y-o-Y Requisition Report</h3>

                    <div class="box-tools pull-right">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                        <div class="btn-group">
                            <button type="button" class="btn btn-box-tool dropdown-toggle" data-toggle="dropdown">
                                <i class="fa fa-wrench"></i>
                            </button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Action</a></li>
                                <li><a href="#">Another action</a></li>
                                <li><a href="#">Something else here</a></li>
                                <li class="divider"></li>
                                <li><a href="#">Separated link</a></li>
                            </ul>
                        </div>
                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-8">

                            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="PO_Supplier" ToolbarImagesFolderUrl="" ToolPanelView="None" ToolPanelWidth="200px" Width="350px" />
                            <CR:CrystalReportSource ID="PO_Supplier" runat="server">
                                <Report FileName="View\Store\Reports\PO_Supplier.rpt">
                                </Report>
                            </CR:CrystalReportSource>
                        </div>
                        <div class="col-md-4">
                            <p class="text-center">
                                <strong>Frequently Requested Items (Monthly)</strong>
                            </p>
                            <% foreach (var freq in freqCount) {%>
                            <div class="progress-group">
                                <span class="progress-text"><%= freq.Key.ItemDesc %></span>
                                <span class="progress-number"><b><%= Math.Floor(freq.Value) %>%</b>/box</span>

                                <div class="progress sm">
                                    <div class="progress-bar <%=  (freq.Value > 25 ? ( (freq.Value > 50 ? "progress-bar-green" : "progress-bar-yellow" )) : "progress-bar-red") %>'" style='width: <%= freq.Value %>%'></div>
                                </div>
                            </div>
                            <%} %>
                            <%--<div class="progress-group">
                                <span class="progress-text">Exercise Book - 100pg</span>
                                <span class="progress-number"><b>310</b>/each</span>

                                <div class="progress sm">
                                    <div class="progress-bar progress-bar-red" style="width: 70%"></div>
                                </div>
                            </div>
                            <div class="progress-group">
                                <span class="progress-text">Pen-Ballpoint Black</span>
                                <span class="progress-number"><b>480</b>/dozen</span>

                                <div class="progress sm">
                                    <div class="progress-bar progress-bar-green" style="width: 90%"></div>
                                </div>
                            </div>
                            <div class="progress-group">
                                <span class="progress-text">Envelopes (3"x6")- Brown</span>
                                <span class="progress-number"><b>1200</b>/each</span>

                                <div class="progress sm">
                                    <div class="progress-bar progress-bar-yellow" style="width: 80%"></div>
                                </div>
                            </div>--%>

                            <%--<asp:GridView ID="gvFrequent" runat="server" CssClass="table-condensed" AutoGenerateColumns="false" BorderStyle="None" RowStyle-BorderStyle="None">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="progress-group">
                                                <span class="progress-text">'<%# Eval("key.ItemName") %>'</span>
                                                <span class="progress-number"><b><%#String.Format("{0:f2}", Eval("value")) %> %</b> </span>

                                                <div class="progress sm">
                                                    <div class='progress-bar  <%#  ((double)Eval("value") > 25 ? ( ((double)Eval("value") > 50 ? "progress-bar-green" : "progress-bar-yellow" )) : "progress-bar-red") %>' style='width: <%#  Eval("value") %>%'</div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>--%>
                        </div>
                    </div>
                </div>
                <div class="box-footer">
                    <div class="row">
                        <div class="col-sm-3 col-xs-6">
                            <div class="description-block border-right">
                                <a href="../Reports/DisplayDeptUsagePeriod.aspx">
                                    <span class="description-text">REQUISITIONS OVER PERIOD</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-sm-3 col-xs-6">
                            <div class="description-block border-right">
                                <a href="../Reports/DisplayDeptUsage.aspx">
                                    <span class="description-text">DEPT USAGE COMPARISON</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-sm-3 col-xs-6">
                            <div class="description-block border-right">
                                <a href="../Reports/DisplaySupplierPOPeriod.aspx">
                                    <span class="description-text">SUPPLIER POs OVER PERIOD</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-sm-3 col-xs-6">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="clrkMainJs" runat="server">
</asp:Content>
