<!doctype html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>All Caps WOrds</title>
    </head>
    <body>

        <?php
            if(isset($_GET['text'])){
                $text =$_GET['text'];
                preg_match_all('/\w+/',$text, $words);
                $words= $words[0];
                $upperWords = array_filter($words, 'isUpperCaseWords');
                echo implode(', ', $upperWords);
            }

            function isUpperCaseWords($word)
            {
                return strtoupper($word) == $word;
            }
        ?>

        <form>
            <textarea name="text" rows="20"></textarea>
            <br>
            <input type="submit" />
        </form>

    </body>
</html>