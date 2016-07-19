<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Homework</title>
</head>
<body>
    <form>
        <div>Title</div>
        <input type="text" name="title">
        <div>Content</div>
        <textarea name="content"></textarea>
        <div><input type="submit" value="Post"></div>
    </form>

    <?php
        if(isset($_GET['title'])){
            $hostname = 'localhost';
            $username = 'root';
            $password = '';
            $dbname = 'blog';

            $mysqli = new mysqli($hostname, $username, $password, $dbname);

            if($mysqli->connect_errno){
                die("Error! Failed to connect to MySQL.");
            }

            $mysqli->set_charset("utf8");

            $stmt = $mysqli->prepare(
                "INSERT INTO posts(title, content) VALUES (?, ?)");
            $stmt->bind_param("ss",
                $_GET['title'], $_GET['content']);
            $stmt->execute();
            if ($stmt->affected_rows == 1)
                echo "Post created.";
            else die("Insert post failed.");
    }
    ?>

</body>
</html>