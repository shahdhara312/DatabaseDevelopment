<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupHomeMain.aspx.cs"
    Inherits="NPU_ProfessionalNet.GroupHomeMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="margin: auto;">
            <tr style="border-style: solid; border-width: thin;">
                <td>
                    <h2>
                        <asp:Label ID="lblgroupname" runat="server" Text=""></asp:Label>
                    </h2>
                </td>
                <td align="left">
                    <asp:Button ID="btnlike" runat="server" Text="Like" BorderStyle="Double" 
                        onclick="btnlike_Click" Visible="false"/>
                        <asp:Button ID="btnunlike" runat="server" Text="Unlike" BorderStyle="Double" onclick="btnlike_Click" Visible="false" />
                    <asp:Button ID="btnleave" runat="server" Text="Leave" BorderStyle="Double" 
                        onclick="btnleave_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    Start Discussion...
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtpost" runat="server" Height="48px" Width="284px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnpost" runat="server" Text="Post" BorderStyle="Double" 
                        onclick="btnpost_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid runat="server" ID="dgpost" AutoGenerateColumns="False" PageSize="20"
                        CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="DgHeader" BackColor="#006699" Font-Bold="True"
                            ForeColor="White" />
                        <ItemStyle ForeColor="#000066" />
                        <PagerStyle CssClass="DgHeader" Height="15px" BackColor="White" ForeColor="#000066"
                            HorizontalAlign="Left" Mode="NumericPages" />
                        <Columns>
                            <asp:TemplateColumn HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbRows" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Post">
                                <ItemTemplate>
                                    <asp:Label ID="lblpost" runat="server" Text='<%# Eval("post") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                             
                            <asp:TemplateColumn HeaderText="Posted on">
                                <ItemTemplate>
                                    <asp:Label ID="lblpostdate" runat="server" Text='<%# Eval("PostedOn") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Posted By">
                                <ItemTemplate>
                                    <asp:Label ID="lblpostedby" runat="server" Text='<%# Eval("PostUserMaster.FName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Comment">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server" Text="0"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
