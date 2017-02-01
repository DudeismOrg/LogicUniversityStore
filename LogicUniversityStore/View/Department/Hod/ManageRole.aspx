<%@ Page Title="" Language="C#" MasterPageFile="~/View/Department/Hod/Hod.master" AutoEventWireup="true" CodeBehind="ManageRole.aspx.cs" Inherits="LogicUniversityStore.View.Department.Hod.ManageRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="empMainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="empMainContentBlock" runat="server">
    <form id="form1" runat="server">
        <table style="width: 100%;">
            <tr>
                <td colspan="2">
                    Manage Role:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="lstEmp" runat="server" SelectionMode="Single" AutoPostBack="true" DataTextField="FullName" DataValueField="UserID"
                        OnSelectedIndexChanged="lstEmp_SelectedIndexChanged"></asp:ListBox>
                </td>
                <td>
                    <asp:ListView runat="server" ID="lstRoles" DataKeyNames="RoleCode">
                        <LayoutTemplate>

                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>

                        </LayoutTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ckbRole" runat="server" AutoPostBack="true" Text='<%#Eval("RoleName") %>'
                                            OnCheckedChanged="ckbRole_CheckedChanged" />
                                    </td>
                                </tr>
                            </table>

                        </ItemTemplate>
                    </asp:ListView>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="align-content:center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="empMainJs" runat="server">
</asp:Content>
