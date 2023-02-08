<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DaySite.aspx.cs" Inherits="Default.DaySite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Day Site</h1>
        <asp:Button ID="Last24Hours" runat="server" Text="The Last 24 Hours" OnClick="Last24Hours_Click" />
        <asp:Button ID="MonthSite" runat="server" Text="Month Site" OnClick="MonthSite_Click" />
        <asp:Button ID="YearSite" runat="server" Text="Year Site" OnClick="YearSite_Click" />
        <br />
        <br />
        <div>
            <asp:DropDownList ID="Year" runat="server" AutoPostBack="true" OnSelectedIndexChanged="UpdateGridViewOnDropDownlList">
<%--            <asp:listitem text="Year" value=""></asp:listitem>--%>
  <%--          <asp:listitem text="2022" value="2022"></asp:listitem>
            <asp:listitem text="2023" value="2023"></asp:listitem>
            <asp:listitem text="2024" value="2024"></asp:listitem>
            <asp:listitem text="2025" value="2025"></asp:listitem>
            <asp:listitem text="2026" value="2026"></asp:listitem>
            <asp:listitem text="2027" value="2027"></asp:listitem>
            <asp:listitem text="2028" value="2028"></asp:listitem>
            <asp:listitem text="2029" value="2029"></asp:listitem>
            <asp:listitem text="2030" value="2030"></asp:listitem>--%>
        </asp:DropDownList>
        <asp:DropDownList ID="Month" runat="server" AutoPostBack="true" OnSelectedIndexChanged="UpdateGridViewOnDropDownlList">
<%--            <asp:listitem text="Month" value=""></asp:listitem>--%>
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
        <asp:DropDownList ID="Day" runat="server" AutoPostBack="true" OnSelectedIndexChanged="UpdateGridViewOnDropDownlList">
<%--            <asp:listitem text="Day" value=""></asp:listitem>--%>
  <asp:listitem text="1" value="1"></asp:listitem>
            <asp:listitem text="2" value="2"></asp:listitem>
            <asp:listitem text="3" value="3"></asp:listitem>
            <asp:listitem text="4" value="4"></asp:listitem>
            <asp:listitem text="5" value="5"></asp:listitem>
            <asp:listitem text="6" value="6"></asp:listitem>
            <asp:listitem text="7" value="7"></asp:listitem>
            <asp:listitem text="8" value="8"></asp:listitem>
            <asp:listitem text="9" value="9"></asp:listitem>
            <asp:listitem text="10" value="10"></asp:listitem>
            <asp:listitem text="11" value="11"></asp:listitem>
            <asp:listitem text="12" value="12"></asp:listitem>
            <asp:listitem text="13" value="13"></asp:listitem>
            <asp:listitem text="14" value="14"></asp:listitem>
            <asp:listitem text="15" value="15"></asp:listitem>
            <asp:listitem text="16" value="16"></asp:listitem>
            <asp:listitem text="17" value="17"></asp:listitem>
            <asp:listitem text="18" value="18"></asp:listitem>
            <asp:listitem text="19" value="19"></asp:listitem>
            <asp:listitem text="20" value="20"></asp:listitem>
            <asp:listitem text="21" value="21"></asp:listitem>
            <asp:listitem text="22" value="22"></asp:listitem>
            <asp:listitem text="23" value="23"></asp:listitem>
            <asp:listitem text="24" value="24"></asp:listitem>
            <asp:listitem text="25" value="25"></asp:listitem>
            <asp:listitem text="26" value="26"></asp:listitem>
            <asp:listitem text="27" value="27"></asp:listitem>
            <asp:listitem text="28" value="28"></asp:listitem>
            <asp:listitem text="29" value="29"></asp:listitem>
            <asp:listitem text="30" value="30"></asp:listitem>
            <asp:listitem text="31" value="31"></asp:listitem>
        </asp:DropDownList>
        <%--<asp:Button ID="Search1" runat="server" Text="Search" OnClick="Search" />--%>
        <asp:Label ID="ErrorMessage" Visible="false" runat="server" Text="The selected date is not registered!"></asp:Label>
        <br/>
        <br/>
            <asp:Button ID="Left" runat="server" Text="<" OnClick="Left_Click" />
            <asp:Button ID="Right" runat="server" Text=">" OnClick="Right_Click" />
        <br/>
        <br/>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="False" Width="1195px" style="margin-right: 27px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
                <asp:ImageField DataImageUrlField="Sky" HeaderText="Sky" ItemStyle-Width="50px" ControlStyle-Width="100" ControlStyle-Height="100">
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
        <asp:chart id="ChartTemp" runat="server" 
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
									<%--<asp:series Name="Series2" ChartType="FastLine" ShadowColor="Black" BorderColor="180, 26, 59, 105" Color="224, 64, 10">
                                    </asp:series>--%>
								
								<chartareas>
									<asp:chartarea  Name="ChartArea1" BorderColor="#38505d" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="white" ShadowColor="Transparent" BackGradientStyle="TopBottom">
										<%--<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>--%>
										<%--<axisy linecolor="#38505d" IsLabelAutoFit="False">
											<labelstyle font="Helvetica Neue, 8.25pt, style=Bold" ForeColor="#38505d" />
											<majorgrid linecolor="#38505d" />
										</axisy>
										<axisx linecolor="#38505d" IsLabelAutoFit="False">
											<labelstyle font="Helvetica Neue, 8.25pt, style=Bold" ForeColor="#38505d" />
											<majorgrid linecolor="#38505d" />
										</axisx>--%>
									</asp:chartarea>
								</chartareas>
							</asp:chart>
    </form>
</body>
</html>
