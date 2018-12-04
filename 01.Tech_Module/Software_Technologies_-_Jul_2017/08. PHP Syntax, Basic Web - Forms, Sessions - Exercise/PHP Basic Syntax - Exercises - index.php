<!--01. Multiply a Number by 2-->
<!DOCTYPE html>
<?php
$num = "";
if(isset($_GET['num'])){
    $num = intval($_GET['num']);
    $num *= 2;
}
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" /><br/>
    <?php echo $num;?>
</form>
</body>
</html>
<!--02. Multiply Two Numbers-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num1" />
    M: <input type="text" name="num2" />
    <input type="submit" />
</form><br/>
<?php
$result = "";
if (isset($_GET['num1']) && isset($_GET['num2'])){
    $num1 = intval($_GET['num1']);
    $num2 = ($_GET['num2']);
    $result = $num1 * $num2;
    echo $result;
}
?>
</body>
</html>
<!--03. Multiply / Divide Numbers-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num1" />
    M: <input type="text" name="num2" />
    <input type="submit" />
</form><br/>
<?php
if (isset($_GET['num1']) && isset($_GET['num2'])){
    $result = "";
    $num1 = intval($_GET['num1']);
    $num2 = intval($_GET['num2']);
    if ($num2 >= $num1){
        $result = $num1 * $num2;
    } else {
        $result = $num1 / $num2;
    }
    echo $result;
}
?>
</body>
</html>
<!--04. Product of 3 Numbers-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    X: <input type="text" name="num1" />
    Y: <input type="text" name="num2" />
    Z: <input type="text" name="num3" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])){
    $num1 = intval($_GET['num1']);
    $num2 = intval($_GET['num2']);
    $num3 = intval($_GET['num3']);
    $nums = [$num1, $num2, $num3];
    $positiveNums = 0;
    $negativeNums = 0;
    $isZero = false;
    $result = "";
    foreach ($nums as $num) {
        if ($num > 0){
            $positiveNums++;
        } else if ($num < 0) {
            $negativeNums++;
        } else if ($num == 0) {
            $isZero = true;
            break;
        }
    }
    if ($isZero == true || $negativeNums % 2 == 0) {
        $result = "Positive";
    } else {
        $result = "Negative";
    }
    echo $result;
}
?>
</body>
</html>
<!--05. Numbers from 1 to N-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    for ($i = 1; $i <= $num; $i++){
        if ($i != $num) {
            echo "$i ";
        } else {
            echo $i;
        }
    }
}
?>
</body>
</html>
<!--06. Numbers from N to 1-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])){
    $num = intval($_GET['num']);
    for ($i = $num; $i >= 1; $i--){
        if ($i != 1) {
            echo "$i ";
        } else {
            echo $i;
        }
    }
}
?>
</body>
</html>
<!--07. Even Numbers from 1 to N-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num']))
{
    $num = intval($_GET['num']);
    for ($cycle = 2; $cycle <= $num; $cycle+=2)
    {
        echo $cycle . " ";
    }
}
?>
</body>
</html>
<!--08. Odd Numbers from N to 1-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    $validNumbers = [];
    for ($i = $num; $i >= 1; $i--) {
        if ($i % 2 != 0) {
            $validNumbers[] = $i;
        }
    }
    echo implode(", ", $validNumbers);
}
?>
</body>
</html>
<!--09. N Factorial-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    $result = 1;
    for ($i = 1; $i <= $num; $i++) {
        $result *= $i;
    }
    echo $result;
}
?>
</body>
</html>
<!--10. Not Divisor Numbers-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    $validNums = [];
    for ($i = $num; $i >= 1; $i--) {
        if ($num % $i != 0) {
            $validNums[] = $i;
        }
    }
    echo implode(", ", $validNums);
}
?>
</body>
</html>
<!--11. Fibonacci Sequence-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    $fibonacciNumbers = [1, 1];
    $num1 = 1;
    $num2 = 1;
    for ($i = 2; $i < $num; $i++) {
        $fibonacciNumbers[] = $num1 + $num2;
        $num1 = $fibonacciNumbers[$i - 1];
        $num2 = $fibonacciNumbers[$i];
    }
    echo implode(" ", $fibonacciNumbers);
}
?>
</body>
</html>
<!--12. Tribonacci Sequence-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    $tribonacciNumbers = [1, 1, 2];
    $firstNum = 1;
    $secNum = 1;
    $thirdNum = 2;
    for ($i = 3; $i < $num; $i++) {
        $tribonacciNumbers[$i] = $firstNum + $secNum + $thirdNum;
        $thirdNum = $tribonacciNumbers[$i];
        $secNum = $tribonacciNumbers[$i - 1];
        $firstNum = $tribonacciNumbers[$i - 2];
    }
    echo implode(" ", $tribonacciNumbers);
}
?>
</body>
</html>
<!--13. Prime Numbers from N to 1-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    $primeNumbers = [2, 3];
    for ($i = 2; $i <= $num; $i++) {
        $isPrime = true;
        for ($j = 2; $j <= sqrt($num); $j++) {
            if ($i % $j == 0) {
                $isPrime = false;
                break;
            }
        }
        if ($isPrime) {
            $primeNumbers[] = $i;
        }
    }
    $primeNumbers = array_reverse($primeNumbers);
    echo implode(" ", $primeNumbers);
}
?>
</body>
</html>
<!--14. HTML Buttons-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    for ($i = 1; $i <= $num; $i++): ?>
        <button> <?=$i?> </button>
    <?php endfor;
}
?>
</body>
</html>
<!--15. Sub-Lists-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num1" />
    M: <input type="text" name="num2" />
    <input type="submit" />
</form>
<ul>
    <?php
    if (isset($_GET['num1']) && isset($_GET['num2'])) {
        $num1 = intval($_GET['num1']);
        $num2 = intval($_GET['num2']);
        for ($i = 1; $i <= $num1; $i++) {
            echo "<li>List $i<ul>";
            for ($j = 1; $j <= $num2; $j++) {
                echo "<li>Element $i.$j</li>";
            }
            echo "</ul></li>";
        }
    }
    echo "</ul>";
    ?>
</body>
</html>
<!--16. Draw an S with Buttons-->
<?php
for ($i = 0; $i < 4 ; $i++) {
    for ($j = 0; $j < 5; $j++) {
        if ($i == 0 || $j == 0) {
            echo "<button style='background-color:blue'>1</button>";
        } else {
            echo "<button>0</button>";
        }
    }
    echo "<br/>";
}
for ($i = 0; $i < 5; $i++) {
    echo "<button style='background-color:blue'>1</button>";
}
echo "<br/>";
for ($i = 1; $i <= 4; $i++) {
    for ($j = 0; $j < 5; $j++) {
        if ($j == 4 || $i == 4) {
            echo "<button style='background-color:blue'>1</button>";
        }
        else {
            echo "<button>0</button>";
        }
    }
    echo "<br/>";
}
?>
<!--17. RGB Table-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        table * {
            border: 1px solid black;
            width: 50px;
            height: 50px;
        }
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
    <?php
    $color = 51;
    for ($i = 0; $i <= 5; $i++) {
        echo "<tr>";
        echo "<td style='background-color: rgb($color, 0, 0)'></td>";
        echo "<td style='background-color: rgb(0, $color, 0)'></td>";
        echo "<td style='background-color: rgb(0, 0, $color)'></td>";
        echo "</tr>";
        $color += 51;
    }
    ?>
</table>
</body>
</html>
<!--18. Fifty Shades of Grey-->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
<?php
$color = 0;
for ($i = 0; $i < 5; $i++) {
    $innerColor = $color;
    for ($j = 0; $j < 10; $j++) {
        echo "<div style='background-color: rgb($innerColor, $innerColor, $innerColor);'></div>";
        $innerColor += 5;
    }
    $color += 51;
    echo "<br/>";
}
?>
</body>
</html>