<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthSite.aspx.cs" Inherits="Default.MonthSite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Month Site</h1>
        <asp:Button ID="Last24Hours" runat="server" Text="The Last 24 Hours" OnClick="Last24Hours_Click" />
        <asp:Button ID="DaySite" runat="server" Text="Day Site" OnClick="DaySite_Click" />
        <asp:Button ID="YearSite" runat="server" Text="Year Site" OnClick="YearSite_Click" />
        <br />
        <br />
        <div>
            <asp:DropDownList ID="Year" runat="server" AutoPostBack="true" OnSelectedIndexChanged="UpdateGridViewOnDropDownlList">
            <asp:listitem text="2022" value="2022"></asp:listitem>
            <asp:listitem text="2023" value="2023"></asp:listitem>
            <asp:listitem text="2024" value="2024"></asp:listitem>
            <asp:listitem text="2025" value="2025"></asp:listitem>
            <asp:listitem text="2026" value="2026"></asp:listitem>
            <asp:listitem text="2027" value="2027"></asp:listitem>
            <asp:listitem text="2028" value="2028"></asp:listitem>
            <asp:listitem text="2029" value="2029"></asp:listitem>
            <asp:listitem text="2030" value="2030"></asp:listitem>
        </asp:DropDownList>
        <asp:DropDownList ID="Month" runat="server" AutoPostBack="true" OnSelectedIndexChanged="UpdateGridViewOnDropDownlList">
            <asp:listitem text="January" value="1"></asp:listitem>
            <asp:listitem text="Febuary" value="2"></asp:listitem>
            <asp:listitem text="March" value="3"></asp:listitem>
            <asp:listitem text="April" value="4"></asp:listitem>
            <asp:listitem text="May" value="5"></asp:listitem>
            <asp:listitem text="June" value="6"></asp:listitem>
            <asp:listitem text="July" value="7"></asp:listitem>
            <asp:listitem text="August" value="8"></asp:listitem>
            <asp:listitem text="Septemper" value="9"></asp:listitem>
            <asp:listitem text="October" value="10"></asp:listitem>
            <asp:listitem text="November" value="11"></asp:listitem>
            <asp:listitem text="December" value="12"></asp:listitem>
        </asp:DropDownList>
        <asp:Label ID="ErrorMessage" Visible="false" runat="server" Text="The selected Month is not registered!"></asp:Label>
        <br/>
        <br/>
            <asp:Button ID="Left" runat="server" Text="<" OnClick="Left_Click" />
            <asp:Button ID="Right" runat="server" Text=">" OnClick="Right_Click" />
        <br/>
        <br/>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="False" Width="1448px" style="margin-right: 27px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
                <asp:BoundField ItemStyle-Width="100px" DataField="MaxTemperature" HeaderText="MaxTemp" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="MaxTempHour" HeaderText="MaxTempHour" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="MinTemperature" HeaderText="MinTemp" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="MinTempHour" HeaderText="MinTempHour" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="AvgTemperature" HeaderText="AvgTemp" >
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
            <asp:Label ID="Label2" runat="server" Text="Max Temperature: "></asp:Label>
            <asp:Label ID="LabelMaxTemp" runat="server" Text="LabelMaxTemp"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Day:"></asp:Label>
            <asp:Label ID="MaxTempDay" runat="server" Text="MaxTempDay:"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="Hour:"></asp:Label>
            <asp:Label ID="MaxTempHour" runat="server" Text="MaxTempHour:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Min Temperature: "></asp:Label>
            <asp:Label ID="LabelMinTemp" runat="server" Text="LabelMinTemp"></asp:Label>
            <asp:Label ID="Label6" runat="server" Text="Day:"></asp:Label>
            <asp:Label ID="MinTempDay" runat="server" Text="MinTempDay:"></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="Hour:"></asp:Label>
            <asp:Label ID="MinTempHour" runat="server" Text="MinTempHour:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Avg Temperature: "></asp:Label>
            <asp:Label ID="LabelAvgTemp" runat="server" Text="LabelAvgTemp"></asp:Label>
        </div>
    </form>
</body>
</html>