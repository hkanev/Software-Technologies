<?php

    $hostname = 'localhost';
    $username = 'root';
    $password = '';
    $dbname = 'blog';

    $mysqli = new mysqli($hostname, $username, $password, $dbname);

    if($mysqli->connect_errno){
        die("Error! Failed to connect to MySQL.");
    }

    $mysqli->set_charset("utf8");

    $query = $mysqli->prepare("INSERT INTO users (username, password, fullname) VALUES (?, ?, ?)");

    $username= "Greta";
    $password= md5("IchLibeWrustschen");
    $fullname= "Greta Berghoffen";

    $query->bind_param("sss", $username, $password, $fullname);
    $query->execute();

    if($query->affected_rows == 1){
            echo"User successfully created.";
        } else {
        die("Inserting user failed");
    }

?>