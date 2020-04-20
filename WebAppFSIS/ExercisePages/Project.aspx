<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Project</h1>
    <div class="offset-2">
        <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
        </asp:DataList>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter a Partial Employee Name "></asp:Label>&nbsp;&nbsp
        <asp:TextBox ID="PartialEmployeeNameV2" runat="server"></asp:TextBox>
        <asp:Button ID="SearchEmployeesPartial" runat="server" Text="Search Employee"
            OnClick="SearchEmployeesPartial_Click" />
        <br />
        <br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
        <asp:GridView ID="EmployeeGridViewV2" runat="server"

            AutoGenerateColumns="False"
            CssClass="table table-striped" GridLines="Horizontal"
            BorderStyle="None" AllowPaging="True"
            OnPageIndexChanging="List02_PageIndexChanging" PageSize="5"
            OnSelectedIndexChanged="List02_SelectedIndexChanged">

            <Columns>
                <asp:CommandField SelectText="View" ShowSelectButton="True" 
                    ButtonType="Button" CausesValidation="false">
                </asp:CommandField>
                <asp:TemplateField HeaderText="ID" Visible="True">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="EmployeeID" runat="server" 
                            Text='<%# Eval("EmployeeID") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Employee">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="FullName" runat="server" 
                            Text='<%# Eval("FullName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateHired">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="QuantityPerUnit" runat="server" 
                            Text='<%# Eval("DateHired") == null ? "each" : Eval("DateHired") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ReleaseDate">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                     <ItemTemplate>
                        <asp:Label ID="ReleaseDate" runat="server" 
                            Text='<%# Eval("ReleaseDate") == null ? "each" : Eval("ReleaseDate") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
            <EmptyDataTemplate>
                no data to display
            </EmptyDataTemplate>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="3" />
        </asp:GridView>
    </div>
</asp:Content>
