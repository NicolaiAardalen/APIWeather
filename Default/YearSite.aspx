﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YearSite.aspx.cs" Inherits="Default.YearSite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <h1>Year Site</h1>
        <asp:Button ID="Last24Hours" runat="server" Text="The Last 24 Hours" OnClick="Last24Hours_Click" />
        <asp:Button ID="DaySite" runat="server" Text="Day Site" OnClick="DaySite_Click" />
         <asp:Button ID="MonthSite" runat="server" Text="Month Site" OnClick="MonthSite_Click" />
        <br />
        <br />
        <div>
            <asp:DropDownList ID="Year" runat="server" AutoPostBack="true" OnSelectedIndexChanged="UpdateGridViewOnDropDownlList">
        </asp:DropDownList>
        <asp:Label ID="ErrorMessage" Visible="false" runat="server" Text="The selected Year is not registered!"></asp:Label>
        <br/>
        <br/>
            <asp:Button ID="Left" runat="server" Text="<" OnClick="Left_Click"/>
            <asp:Button ID="Right" runat="server" Text=">" OnClick="Right_Click"/>
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
                <asp:BoundField ItemStyle-Width="100px" DataField="MaxTemperature" HeaderText="MaxTemp" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="MaxTempDay" HeaderText="MaxTempDay" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="MaxTempHour" HeaderText="MaxTempHour" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="MinTemperature" HeaderText="MinTemp" >
<ItemStyle Width="100px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" DataField="MinTempDay" HeaderText="MinTempDay" >
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
            <asp:Label ID="Label6" runat="server" Text="Month:"></asp:Label>
            <asp:Label ID="MaxTempMonth" runat="server" Text="MaxTempMonth:"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Day:"></asp:Label>
            <asp:Label ID="MaxTempDay" runat="server" Text="MaxTempDay:"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="Hour:"></asp:Label>
            <asp:Label ID="MaxTempHour" runat="server" Text="MaxTempHour:"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Min Temperature: "></asp:Label>
            <asp:Label ID="LabelMinTemp" runat="server" Text="LabelMinTemp"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text="Month:"></asp:Label>
            <asp:Label ID="MinTempMonth" runat="server" Text="MinTempMonth:"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="Day:"></asp:Label>
            <asp:Label ID="MinTempDay" runat="server" Text="MinTempDay:"></asp:Label>
            <asp:Label ID="Label8" runat="server" Text="Hour:"></asp:Label>
            <asp:Label ID="MinTempHour" runat="server" Text="MinTempHour:"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Avg Temperature: "></asp:Label>
            <asp:Label ID="LabelAvgTemp" runat="server" Text="LabelAvgTemp"></asp:Label>
        </div>
    </form>
</body>
</html>
