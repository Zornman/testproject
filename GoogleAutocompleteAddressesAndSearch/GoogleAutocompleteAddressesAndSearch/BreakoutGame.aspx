<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BreakoutGame.aspx.cs" Inherits="GoogleAutocompleteAddressesAndSearch.SnakeGame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Breakout Game!</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <canvas id="breakoutCanvas" width="1500" height="1000" style="background: #eee; display: block; margin: 0 auto;"></canvas>
            </div>
        </div>
    </div>
    </form>

<script>
    var canvas = document.getElementById("breakoutCanvas");
    var ctx = canvas.getContext("2d");
    var score = 0;
    var lives = 3;

    // Variables for the ball
    var startingX = canvas.width/2;
    var startingY = canvas.height-30;
    var movingX = 4;
    var movingY = -4;
    var ballRadius = 20;

    // Variables & Events for the paddle
    var paddleHeight = 10;
    var paddleWidth = 100;
    var paddleX = (canvas.width - paddleWidth) / 2;
    var paddleY = 10;
    var rightPressed = false;
    var leftPressed = false;
    document.addEventListener("keydown", keyDownHandler, false);
    document.addEventListener("keyup", keyUpHandler, false);
    document.addEventListener("mousemove", mouseMoveHandler, false);

    // Variables for the bricks
    var brickRowCount = 5;
    var brickColumnCount = 10;
    var brickWidth = 125;
    var brickHeight = 20;
    var brickPadding = 20;
    var brickOffsetTop = 30;
    var brickOffsetLeft = 30;
    var bricks = [];

    for (var c = 0; c < brickColumnCount; c++)
    {
        bricks[c] = [];
        for (var r = 0; r < brickRowCount; r++)
            bricks[c][r] = { x: 0, y:  0, status: 1 };
    }

    function keyDownHandler(e) {
        if (e.keyCode == 39) {
            rightPressed = true;
        }
        else if (e.keyCode == 37) {
            leftPressed = true;
        }
    }

    function keyUpHandler(e) {
        if (e.keyCode == 39) {
            rightPressed = false;
        }
        else if (e.keyCode == 37) {
            leftPressed = false;
        }
    }

    function mouseMoveHandler(e) {
        var relativeX = e.clientX - canvas.offsetLeft;
        if (relativeX > 0 && relativeX < canvas.width) {
            paddleX = relativeX - paddleWidth / 2;
        }
    }

    function drawScore() {
        ctx.font = "16px Arial";
        ctx.fillStyle = "#0095DD";
        ctx.fillText("Score: " + score, 8, 20);
    }

    function drawBall() {
        ctx.beginPath();
        ctx.arc(startingX, startingY, ballRadius, 0, Math.PI * 2);
        ctx.fillStyle = "#0095DD";
        ctx.fill();
        ctx.closePath();
    }

    function drawPaddle() {
        ctx.beginPath();
        ctx.rect(paddleX, canvas.height - paddleHeight, paddleWidth, paddleHeight);
        ctx.fillStyle = "#0095DD";
        ctx.fill();
        ctx.closePath();
    }

    function drawBricks() {
        for (var c = 0; c < brickColumnCount; c++)
        {
            for (var r = 0; r < brickRowCount; r++)
            {
                if (bricks[c][r].status == 1)
                {
                    var brickX = (c * (brickWidth + brickPadding)) + brickOffsetLeft;
                    var brickY = (r * (brickHeight + brickPadding)) + brickOffsetTop;
                    bricks[c][r].x = brickX;
                    bricks[c][r].y = brickY;
                    ctx.beginPath();
                    ctx.rect(brickX, brickY, brickWidth, brickHeight);
                    ctx.fillStyle = "#0095DD";
                    ctx.fill();
                    ctx.closePath();
                }
            }
        }
    }

    function collisionDetection() {
        for (var c = 0; c < brickColumnCount; c++)
        {
            for (var r = 0; r < brickRowCount; r++)
            {
                var b = bricks[c][r];
                if (b.status == 1)
                {
                    if (startingX > b.x && startingX < b.x + brickWidth && startingY > b.y && startingY < b.y + brickHeight) {
                        movingY = -movingY;
                        b.status = 0;
                        score++;
                        if (score == brickColumnCount * brickRowCount)
                        {
                            alert("CONGRATULATIONS, YOU WIN... Nothing.");
                            document.location.reload();
                        }
                    }
                }
            }
        }
    }

    function drawLives() {
        ctx.font = "16px Arial";
        ctx.fillStyle = "#0095DD";
        ctx.fillText("Lives: " + lives, canvas.width - 65, 20);
    }

    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        drawBricks();
        drawBall();
        drawPaddle();
        drawScore();
        drawLives();
        collisionDetection();

        if (startingX + movingX > canvas.width-ballRadius || startingX + movingX < ballRadius)
            movingX = -movingX;

        if (startingY + movingY < ballRadius) {
            movingY = -movingY;
        } else if (startingY + movingY > canvas.height - ballRadius) {
            if (startingX > paddleX && startingX < paddleX + paddleWidth)
                movingY = -movingY;
            else
            {
                lives--;
                if (lives == 0) {
                    alert("GAME OVER");
                    document.location.reload();
                }
                else {
                    x = canvas.width / 2;
                    y = canvas.height - 30;
                    dx = 2;
                    dy = -2;
                    paddleX = (canvas.width - paddleWidth) / 2;
                }
            }
        }

        if (rightPressed && paddleX < canvas.width - paddleWidth) {
            paddleX += 7;
        }
        else if (leftPressed && paddleX > 0) {
            paddleX -= 7;
        }

        startingX += movingX;
        startingY += movingY;

        requestAnimationFrame(draw);
    }
    
    draw();
</script>

</body>
</html>
