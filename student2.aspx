<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="student2.aspx.cs" Inherits="student1.student2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
    <tr>
        <td>Name:</td>
        <td><asp:TextBox ID="txtname" runat="server" ></asp:TextBox></td>
    </tr>
     <tr>
        <td>rollno:</td>
        <td><asp:TextBox ID="txtrollno" runat="server" ></asp:TextBox></td>
    </tr>
    <tr>
        <td>salary:</td>
        <td><asp:TextBox ID="txtsalary" runat="server" ></asp:TextBox></td>
    </tr>
    <tr>
        <td>Gender:</td>
        <td>
            <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3" >
               
             </asp:RadioButtonList></td>
        
    </tr>
    <tr> 
         <td>course</td>
        <td><asp:DropDownList ID="ddlcourse" runat="server">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnsubmit" runat="server" Text="submit" OnClick="btnsubmit_Click" /></td>
    </tr>

     <tr>
        <td></td>
        <td><asp:GridView ID="gvstudent2" runat="server" OnRowCommand="gvstudent2_RowCommand" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="student2 id">
                    <ItemTemplate>
                        <%#Eval(" id") %>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText=" student2 name">
                    <ItemTemplate>
                        <%#Eval("name") %>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText="student2 rollno">
                    <ItemTemplate>
                        <%#Eval("rollno") %>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText="student2 salary">
                    <ItemTemplate>
                        <%#Eval("salary") %>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText="student2 gender">
                    <ItemTemplate>
                        <%#Eval("gender").ToString()=="1"?"male": Eval("gender").ToString() == "2"?"female":"other"%>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField HeaderText="student2 course">
                    <ItemTemplate>
                        <%#Eval("course").ToString() =="1"?"MCA":Eval("course").ToString() =="2"? "BCA":Eval("course").ToString() =="3"? "BBA":Eval("course").ToString() =="4"? "MBBS":"other" %>
                    </ItemTemplate>

                </asp:TemplateField>

                 <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button ID="btndelete" runat="server" Text="delete" CommandName="A" CommandArgument='<%#Eval("id") %>' />
                    </ItemTemplate>
                      </asp:TemplateField>

                     <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("id") %>' />
                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>
            </asp:GridView></td>
    </tr>
</table>
 </asp:Content>