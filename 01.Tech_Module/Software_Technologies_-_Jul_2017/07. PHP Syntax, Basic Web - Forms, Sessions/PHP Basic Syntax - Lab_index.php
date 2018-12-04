<!--01. Hello PHP-->

<?php
echo "Hello PHP";
?>

<!--02. Numbers 1 to 20-->
<ul>
    <?php for ($i = 1; $i <= 20; $i++): ?>
        <?php $color = $i % 2 == 0 ? "green" : "blue"; ?>
        <li> <span style="color:<?=$color;?>"><?=$i;?></span></li>
    <?php endfor; ?>
</ul>

<!--03. Color Palette-->
<head><style>div{
            display: inline-block;
            width: 150px;
            padding: 2px;
            margin: 5px;
        }
    </style></head>
<body>
<?php
for ($red = 0; $red <= 255; $red += 51)
    for ($green = 0; $green <= 255; $green += 51)
        for ($blue = 0; $blue <= 255; $blue += 51) {
            $color = "rgb($red, $green, $blue)";
            echo "<div style='background:$color'> $color</div>\n";
        }
?>
</body>

<!--04. Hello, Person-->
<?php
if (isset($_GET['person'])){
    $person=htmlspecialchars($_GET['person']);
    echo "Hello $person";
} else { ?>
    <form>
        Name: <input type="text" name="person"/>
        <input type="submit">
    </form>
<?php }
?>

<!--05. Dump a HTTP GET Request-->
<form>
    <div>Name:</div>
    <input type="text" name="personName"/>
    <div>Age:</div>
    <input type="text" name="personAge"/>
    <div>Town:</div>
    <select name="townId">
        <option value="10">Sofia</option>
        <option value="20">Plovdiv</option>
        <option value="30">Varna</option>
    </select>
    <div><input type="submit"/></div>
</form>
<?php var_dump($_GET);
?>
//06. Sum Two Numbers
<?php
if (isset($_GET['num1']) && isset($_GET['num2'])) {
    $num1 = intval($_GET['num1']);
    $num2 = intval($_GET['num2']);
    $sum = $num1 + $num2;
    echo "$num1 + $num2 = $sum";
} ?>
<form>
    <div>First Number:</div>
    <input type="number" name="num1"/>
    <div>Second Number:</div>
    <input type="number" name="num2"/>
    <div><input type="submit"/></div>
</form>

<!--07. Celsius - Fahrenheit-->
<?php
$message = "";
if (isset($_GET['cel'])){
    $cel = floatval($_GET['cel']);
    $fah = celToFah($cel);
    $message = "$cel &deg;C = $fah &deg;F";
} else if (isset($_GET['fah'])){
    $fah = floatval($_GET['fah']);
    $cel = fahToCel($fah);
    $message = "$fah &deg;F = $cel &deg;C";
};
function fahToCel(float $fahrenheit) : float
{
    return ($fahrenheit - 32) / 1.8;
}
function celToFah(float $celsius) : float
{
    return $celsius * 1.8 + 32;
}
?>

<form>
    Celsius: <input type="number" name="cel"/>
    <input type="submit" value="Convert">
    <?php if (isset($_GET['cel'])){
        echo $message;
    }?>
</form>
<form>
    Fahrenheit: <input type="number" name="fah"/>
    <input type="submit" value="Convert">
    <?php if (isset($_GET['fah'])){
        echo $message;
    }?>
</form>


<!--08. Sort Lines-->
<?php
$sortedLines = "";
if(isset($_GET['lines'])){
    $lines = explode("\n", $_GET['lines']);
    $lines = array_map('trim', $lines);
    sort($lines, SORT_STRING);
    $sortedLines = implode("\n", $lines);
}
?>

<form>
    <textarea name="lines" rows="10"><?= $sortedLines?></textarea><br/>
    <input type="submit" value="Sort"/>
</form>

<!--09. Capital-Case Words-->
<?php
if(isset($_GET['text'])) {
    $text = $_GET['text'];
    preg_match_all('/\w+/', $text, $words);
    $words = $words[0];
    $upperwords = array_filter($words, function($word){
        return strtoupper($word) == $word;
    });
    echo implode(', ', $upperwords);
};
?>
<form>
    <textarea name="text" rows="10"></textarea><br/>
    <input type="submit">
</form>
