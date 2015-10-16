<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="NPU_ProfessionalNet.SignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h2>Sign Up</h2>
    <asp:Panel id="panel1" runat="server">
    <table>
        <tr>
        <td> 
            <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtfname" runat="server"></asp:TextBox><br />
        </td>
        </tr>

        <tr>
        <td> 
           <asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtlname" runat="server"></asp:TextBox><br />
        </td>
        </tr>

        <tr>
        <td> 
           <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtemail" runat="server"></asp:TextBox><br />
        </td>
        </tr>

        <tr>
        <td> 
            <asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox><br />
        </td>
        </tr>

        <tr>
            <td>
             
            </td>
            <td>
                <asp:Button ID="btnjoin" runat="server" Text="Join" onclick="Button4_Click" />
            </td>
        </tr>
     </table>
     </asp:Panel>

   <asp:Panel id="panel2" runat="server" Visible="false">
    <table>
        <tr>
        <td> 
            <asp:Label ID="Label5" runat="server" Text="Country:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="drpcountry" runat="server">
                <asp:ListItem>Australia</asp:ListItem>
                <asp:ListItem>Canada</asp:ListItem>
                <asp:ListItem>India</asp:ListItem>
                <asp:ListItem>Mexico</asp:ListItem>
                <asp:ListItem>USA</asp:ListItem>
            </asp:DropDownList>
            <br />
        </td>
        </tr>

        <tr>
        <td> 
           <asp:Label ID="Label6" runat="server" Text="Zip Code:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtzipcode" runat="server"></asp:TextBox>
            <br />
        </td>
        </tr>

        <tr>
        <td> 
           <asp:Label ID="Label7" runat="server" Text="I am currently:"></asp:Label>
        </td>
        <td>
            <asp:RadioButton ID="rdbemployed" runat="server" GroupName="status" 
                Text="Employed" oncheckedchanged="rdbemployed_CheckedChanged" AutoPostBack="true" />
            <asp:RadioButton ID="rdbjobseeker" runat="server" GroupName="status" 
                Text="Job Seeker" AutoPostBack="true" 
                oncheckedchanged="rdbjobseeker_CheckedChanged" />
            <asp:RadioButton ID="rdbstudent" runat="server" GroupName="status" 
                Text="Student" AutoPostBack="true" 
                oncheckedchanged="rdbstudent_CheckedChanged" />
            <br />
        </td>
        </tr>
         </table>
     </asp:Panel>

     <asp:Panel id="pnlemployed" runat="server" Visible="false">
    <table>
        <tr>
        <td> 
            <asp:Label ID="Label8" runat="server" Text="Job Title:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtjobtitle" runat="server"></asp:TextBox><br />
        </td>
        </tr>
     </table>
   </asp:Panel>
   <asp:Panel id="pnljobseeker" runat="server" Visible="false">
    <table>
        <tr>
        <td> 
            <asp:Label ID="Label9" runat="server" Text="Most recent Job Title:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtrecentjob" runat="server"></asp:TextBox><br />
        </td>
        </tr>

         <tr>
        <td> 
            <asp:Label ID="Label10" runat="server" Text="Most recent Company:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtrecentcompany" runat="server"></asp:TextBox><br />
        </td>
        </tr>

         <tr>
        <td> 
            <asp:Label ID="Label11" runat="server" Text="Time Period:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="drpjobstart" runat="server">
            </asp:DropDownList>
            &nbsp;To&nbsp;
            <asp:DropDownList ID="drpjobend" runat="server">
            </asp:DropDownList>
        </td>
        </tr>
        </table>
   </asp:Panel>
       <asp:Panel id="pnlstudent" runat="server" Visible="false">
    <table>
         <tr>
        <td> 
            <asp:Label ID="Label12" runat="server" Text="School/University:"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtschool" runat="server"></asp:TextBox><br />
        </td>
        </tr>

         <tr>
        <td> 
            <asp:Label ID="Label13" runat="server" Text="Dates attended:"></asp:Label>
        </td>
        <td>
             <asp:DropDownList ID="drpschoolstart" runat="server">
            </asp:DropDownList>
            &nbsp;To&nbsp;
            <asp:DropDownList ID="drpschoolend" runat="server">
            </asp:DropDownList>
        </td>
        </tr>
        </table>
    </asp:Panel>
    <table>
        <tr>
            <td>
             
            </td>
            <td>
                <asp:Button ID="btncreateprofile" runat="server" Text="Create My Profile" Visible="false"/>
            </td>
        </tr>
     </table>
   </div>
    </form>
</body>
</html>
