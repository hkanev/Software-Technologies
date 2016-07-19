<!doctype html>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>SunTowns</title>
    </head>
    <body>

        <?php
        if(isset($_GET['towns-incomes'])) {
            $lines = array_filter(array_map('trim', explode("\n", $_GET['towns-incomes'])));
            $sums= sumIncomes($lines);
            ksort($sums);

            foreach($sums as $town => $sum){
                echo "$town -> $sum <br>";
            }
        }

            function sumIncomes(array $lines)
            {
                $sums = [];
                foreach ($lines as $line) {
                    $tokens = explode(':', $line);
                    $town = $tokens[0];
                    $income = $tokens[1];
                    if(isset($sums[$town])){
                        $sums[$town] += $income;
                    }
                    else {
                        $sums[$town] = $income;
                    }
                }
                return $sums;
            }
        ?>

        <form>
            <textarea name="towns-incomes" rows="10"></textarea>
            <br>
            <input type="submit"/>
        </form>
    </body>
</html>