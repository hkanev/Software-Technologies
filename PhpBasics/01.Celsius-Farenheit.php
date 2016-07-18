<!DOCTYPE html>
<html>
    <head>
        <title>Conventor</title>
    </head>

        <body>

        <?php
            function celToFar(float $celsius): float
            {
                return $celsius * 1.8 + 32;
            }

            function fahToCel(float $fah): float
            {
                return ($fah - 32) / 1.8;
            }

            if(isset($_GET['cel'])) {
                $cel=floatval($_GET['cel']);
                $fah=celToFar($cel);
                $fahMsg="$cel &deg;C = $fah &deg;F";
            }

            if(isset($_GET['fah'])) {
                $fah=floatval($_GET['fah']);
                $cel=fahToCel($fah);
                $celMsg="$fah &deg;F = $cel &deg;C";
            }
        ?>

        <form>
            Celsius:
            <input type="number" name="cel" />
            <input type="submit" value="Convert" />
        </form>

        <?php if(isset($fahMsg)) echo $fahMsg ?>
        <form>

            <input type="number" name="fah" />
            <input type="submit" value="Convert" />
        </form>

         <?php if(isset($celMsg)) echo $celMsg ?>

    </body>
</html>