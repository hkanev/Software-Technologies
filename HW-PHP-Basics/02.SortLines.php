<!DOCTYPE html>
<html>
    <head>
        <title>Conventor</title>
    </head>
    <body>
        <?php
        if(isset($_GET['lines'])) {
            $towns = $_GET['lines'];
            $towns = explode("\n", $towns);
            $towns = array_map('trim', $towns);
            sort($towns, SORT_STRING);
        }?>

        <form>
            <div><textarea name="towns" rows="10"><?php if (isset($towns)) echo implode("\n", $towns) ?></textarea></div>
            <div><input type="submit" value="Sort"</div>
        </form>

    </body>
</html>