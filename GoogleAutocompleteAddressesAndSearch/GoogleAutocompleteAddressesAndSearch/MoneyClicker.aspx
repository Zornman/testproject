<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoneyClicker.aspx.cs" Inherits="GoogleAutocompleteAddressesAndSearch.MoneyClicker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12" style="text-align: center;">
                    <h1>Bitcoin Clicker</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4" style="text-align: right;">
                    <asp:Label ID="Label3" runat="server" Text="Total Coins: " Font-Size="Large"></asp:Label>
                    <asp:Label ID="lblTotalCoins" runat="server" Text="" Font-Size="Large"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="Save Data" Height="50px" OnClick="btnSave_Click" Width="150px" />
                </div>
                <div class="col-md-4" style="text-align: center;">
                    <asp:ImageButton ID="imgbtnCoin" runat="server" ImageUrl="~/Images/bitcoin.png" Height="250" Width="250" OnClick="imgbtnCoin_Click" />
                    <br />
                    <asp:Label ID="lblTotalCoinsEarned" runat="server" Text="" Font-Size="Large"></asp:Label>
                    <br />
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" Font-Size="Large" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label1" runat="server" Text="Coins per Click: " Font-Size="Large"></asp:Label>
                    <asp:Label ID="lblCoinsPerClick" runat="server" Text="" Font-Size="Large"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Coins per Hour: " Font-Size="Large"></asp:Label>
                    <asp:Label ID="lblCoinsPerHour" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color: #efcc40;">
                <asp:LinkButton ID="homeTabLink" runat="server" OnClick="homeTab_Click">
                    <div class="col-md-3" style="text-align: center;">
                        <asp:Label ID="Label4" runat="server" Text="Home" Font-Size="Large"></asp:Label>
                    </div>
                </asp:LinkButton>
                <asp:LinkButton ID="clickerTabLink" runat="server" OnClick="clickerTab_Click">
                    <div class="col-md-3" style="text-align: center;">
                        <asp:Label ID="Label5" runat="server" Text="Clicker" Font-Size="Large"></asp:Label>
                    </div>
                </asp:LinkButton>
                <asp:LinkButton ID="upgradesTabLink" runat="server" OnClick="upgradesTab_Click">
                    <div class="col-md-3" style="text-align: center;">
                        <asp:Label ID="Label6" runat="server" Text="Upgrades" Font-Size="Large"></asp:Label>
                    </div>
                </asp:LinkButton>
                <asp:LinkButton ID="extrasTabLink" runat="server" OnClick="extrasTab_Click">
                    <div class="col-md-3" style="text-align: center;">
                        <asp:Label ID="Label7" runat="server" Text="Extras" Font-Size="Large"></asp:Label>
                    </div>
                </asp:LinkButton>
            </div>
            <div class="row">
                <div id="homeTab" runat="server" class="col-md-12">
                    <h1>Home Tab Test</h1>
                </div>
                <div id="clickerTab" runat="server" class="col-md-12">
                    <asp:GridView ID="dgClickerList" runat="server" AutoGenerateColumns="false" Width="1129px" OnRowCommand="PurchaseClickerIncrease_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Name" />
                            <asp:BoundField DataField="cost" HeaderText="Cost" />
                            <asp:BoundField DataField="clickIncrease" HeaderText="Increase By" />
                            <asp:BoundField DataField="bought" HeaderText="Owned" />
                            <asp:ButtonField buttontype="Button" CommandName="SelectClicker" HeaderText="Purchase" Text="Purchase" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="upgradesTab" runat="server" class="col-md-12">
                    <asp:GridView ID="dgPropertyList" runat="server" AutoGenerateColumns="false" Width="1129px" OnRowCommand="PurchaseClickerIncrease_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Name" />
                            <asp:BoundField DataField="cost" HeaderText="Cost" />
                            <asp:BoundField DataField="hourlyIncrease" HeaderText="Hourly Increase" />
                            <asp:BoundField DataField="bought" HeaderText="Owned" />
                            <asp:ButtonField ButtonType="Button" CommandName="SelectProperty" HeaderText="Purchase" Text="Purchase" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="extrasTab" runat="server" class="col-md-12">
                    <h1>Extras Tab Test</h1>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
