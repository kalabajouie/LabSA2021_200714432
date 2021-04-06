<?php

//Step1
 $db = mysqli_connect('localhost','my_username','my_password','database_name')
 or die('Error connecting to MySQL server.');
?>

<html>
 <head>
 </head>
 <body>
 <h1>PHP connecting to MySQL</h1>

<?php
   
//Step2
$query = "SELECT * FROM table_name";
mysqli_query($db, $query) or die('Error querying database.');

//Step3
$result = mysqli_query($db, $query);

while ($row = mysqli_fetch_array($result)) {
 echo $row['FirstName'] . ' ' . $row['LastName'] . ': ' . $row['Email'] . ' ' . $row['City'] .'<br />';
}

//Step 4
mysqli_close($db);
?>

</body>
</html>