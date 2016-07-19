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

    $result = $mysqli->query('SELECT * FROM posts ORDER BY date');

    if(!$result){
        die ('Cannont read `posts` from MySQL');
    }

    echo "<table style='background: #777;'>\n";
    echo "<tr><th>Title</th><th>Content</th><th>Date</th></tr>\n";
    while ($row = $result->fetch_assoc()) {
      $title = htmlspecialchars($row['title']);
      $body = htmlspecialchars($row['content']);
      $date = (new DateTime($row['date']))->format('d.m.Y');
      echo "<tr style='background: #999;'><td>$title</td><td>$body</td><td>$date</td></tr>\n";
    }
    echo "</table>\n";
?>