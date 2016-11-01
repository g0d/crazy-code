<?php
	if !empty($_POST)
	{
		$test = json_decode($_POST['sponsorship']);
		
		if empty($test)
			echo 0;
		else
			echo 1;
	}
	else
		echo -1;
?>
