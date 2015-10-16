<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupMasterMain.aspx.cs"
    Inherits="NPU_ProfessionalNet.GroupMasterMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <b>Your Groups:</b>
        <asp:DataGrid runat="server" ID="dgGroup" AutoGenerateColumns="False" PageSize="20"
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
                <asp:TemplateColumn HeaderText="Group Name">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("~/GroupHomeMain.aspx?GroupID={0}&GroupName={1}",
HttpUtility.UrlEncode(Eval("GroupID").ToString()), HttpUtility.UrlEncode(Eval("GroupName").ToString()) ) %>'
                            Text='<%# Eval("GroupName") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <SelectedItemStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        </asp:DataGrid>
        <asp:Button ID="btnDelete" runat="server" Text="Leave Group" OnClick="btnDelete_Click"
            Visible="false" />
        <asp:Button ID="Button1" runat="server" Text="<< Back" />
    </div>
    </form>
</body>
</html>
