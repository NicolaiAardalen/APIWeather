<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Year / Month / Day"></asp:Label>
        <div>
            <asp:TextBox ID="TextBoxS" runat="server" Width="65px"></asp:TextBox>
            <asp:TextBox ID="TextBoxS1" runat="server" Width="65"></asp:TextBox>
            <asp:TextBox ID="TextBoxS2" runat="server" Width="65px"></asp:TextBox>
        <asp:Button ID="Search1" runat="server" Text="Search" OnClick="Search" />
        <br/>
        <br/>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="False" Width="1488px" style="margin-right: 27px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField ItemStyle-Width="100px" DataField="Year" HeaderText="Year" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="Month" HeaderText="Month" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="Day" HeaderText="Day" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="Hour" HeaderText="Hour" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="Temperature" HeaderText="Temperature" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="Precipitation" HeaderText="Precipitation" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="Humidity" HeaderText="Humidity" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="WindDirection" HeaderText="Wind direction" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="WindSpeed" HeaderText="Wind speed" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="WindSpeedOfGust" HeaderText="Wind speed of gust" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
            </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <br />
            <asp:Label ID="LabelMaxTemp" runat="server" Text="LabelMaxTemp"></asp:Label>
            <asp:Label ID="LabelMinTemp" runat="server" Text="LabelMinTemp"></asp:Label>
            <asp:Label ID="LabelAvgTemp" runat="server" Text="LabelAvgTemp"></asp:Label>
        </div>
    </form>
</body>
</html>
