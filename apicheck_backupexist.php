<?php

$serialNumber = $_GET['serialNumber'];

if(file_exists ('Backups/'.$serialNumber))
{
    
    $found = "EXISTE";	

}
else
{
  $found = "NOT_EXISTE";	
}

echo $found;

?>
