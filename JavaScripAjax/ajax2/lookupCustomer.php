<?php

$q=$_GET["phone"];

if ($q=="(111)222-3333")
{
	$tmp="This is you last orders: @ " . 	
		"1. Cheese Pizza, Taco salad, Coca Cola diet @ " .
		"2. CBBQ Chicken Pizza, Mushrooms, Orange Juce @ " . 
		"3. Ham & Pepperoni Pizza by the Slice, wine @ " . 
		"|Hello Andrey! Your telephone number is " . $q . "@" . 
		"Your address is 4271, 39 Avenue, Fargo, ND 5708";  
}
else if ($q=="(333)444-5555")
{
	$tmp="This is you last orders: @ " . 	
		"1. Swiss Mushroom Burger, Fanta @ " .
		"2. Bacoon Cheeseburger, Corn, Sprite @ " . 
		"3. Ham & Pepperoni Pizza by the Slice, beer @ " . 
		"|Hello Anders! Your telephone number is " . $q . "@" . 
		"Your address is 1781, 13 Avenue, Fargo, ND 5708";

}
else
{
	$tmp="Come to pick up today's special! " . 	
		"|Phone " . $q; 

}

echo("$tmp");

?>