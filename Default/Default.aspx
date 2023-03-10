<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>The Last 24 Hours</h1>
        <asp:Button ID="DaySite" runat="server" Text="Day Site" OnClick="DaySite_Click" />
        <asp:Button ID="MonthSite" runat="server" Text="Month Site" OnClick="MonthSite_Click" />
        <asp:Button ID="YearSite" runat="server" Text="Year Site" OnClick="YearSite_Click" />
        <br />
        <div>
        <br/>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="False" Width="1202px" style="margin-right: 27px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
                <asp:ImageField DataImageUrlField="Sky" HeaderText="Sky"  ItemStyle-Width="50px" ControlStyle-Width="100" ControlStyle-Height="100">
                    </asp:ImageField>
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
            <asp:Label ID="Label1" runat="server" Text="Hour: "></asp:Label>
            <asp:Label ID="MaxTempHour" runat="server" Text="MaxTempHour"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Min Temperature: "></asp:Label>
            <asp:Label ID="LabelMinTemp" runat="server" Text="LabelMinTemp"></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="Hour: "></asp:Label>
            <asp:Label ID="MinTempHour" runat="server" Text="MinTempHour"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Avg Temperature: "></asp:Label>
            <asp:Label ID="LabelAvgTemp" runat="server" Text="LabelAvgTemp"></asp:Label>
        </div>
        <%--<%--<%--<asp:chart id="ChartTemp" runat="server" 
            ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderWidth="2px" 
            BackGradientStyle="TopBottom" BackSecondaryColor="White" Palette="None" 
            BorderlineDashStyle="Solid" BorderColor="#38505D" Height="296px" Width="790px" 
            EnableViewState="True">
								<titles>
									<asp:title ShadowColor="white" Font="Helvetica Neue, 12pt, style=Bold" ShadowOffset="3" Text="Temperature" ForeColor="#38505d"></asp:title>
								</titles>
								<legends>
									<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Helvetica Neue, 8.25pt, style=Bold"></asp:legend>
								</legends>
								<borderskin skinstyle="None"></borderskin>
								<%--<series>
									    <asp:series Name="Series1"  BorderColor="#38505d" Color="Black" 
                                            ChartType="Line" YValuesPerPoint="24" >
                                        </asp:series>
                                    </asp:series>
								
								<chartareas>
									<asp:chartarea  Name="ChartArea1" BorderColor="#38505d" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="white" ShadowColor="Transparent" BackGradientStyle="TopBottom">
										<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
										<axisy linecolor="#38505d" IsLabelAutoFit="False">
											<labelstyle font="Helvetica Neue, 8.25pt, style=Bold" ForeColor="#38505d" />
											<majorgrid linecolor="#38505d" />
										</axisy>
										<axisx linecolor="#38505d" IsLabelAutoFit="False">
											<labelstyle font="Helvetica Neue, 8.25pt, style=Bold" ForeColor="#38505d" />
											<majorgrid linecolor="#38505d" />
										</axisx>
									</asp:chartarea>
								</chartareas>
							</asp:chart>--%>
        <asp:Chart ID="ChartTemp" runat="server" Width="700px" BorderWidth="2px" 
            BackGradientStyle="TopBottom" BackSecondaryColor="White" Palette="None" 
            BorderlineDashStyle="Solid" BorderColor="#38505D" EnableViewState="True">
            <titles>
									<asp:title ShadowColor="white" Font="Helvetica Neue, 12pt, style=Bold" ShadowOffset="3" Text="Temperature" ForeColor="#38505d"></asp:title>
								</titles>
								<legends>
									<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Helvetica Neue, 8.25pt, style=Bold"></asp:legend>
								</legends>
								<borderskin skinstyle="None"></borderskin>
                <Series>
                    <asp:Series Name="Temp"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
    </form>
</body>
</html>
