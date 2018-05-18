<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SnakeGame.aspx.cs" Inherits="GoogleAutocompleteAddressesAndSearch.SnakeGame1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Snake Game!</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <canvas id="snakeCanvas" width="1000" height="1000" style="background: #eee; display: block; margin: 0 auto;"></canvas>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btn" runat="server" Text="Start Game" />
                </div>
            </div>
        </div>
    </form>

<script>
    var canvas = document.getElementById("snakeCanvas");
    var btn = document.getElementById("btn");
    var ctx = canvas.getContext("2d");

</script>

</body>
</html>
