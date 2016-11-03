<?php
	require('sponsorship.php');
	
	if (!empty($_POST))
	{
		$my_sponsorship = new Sponsorship();
		
		if (!empty($_POST['add']) && !empty($_POST['sponsorship']))
		{
			echo $my_sponsorship->addSponsoship($_POST['sponsorship']);
		}
		else if (!empty($_POST['list']))
		{
			echo $my_sponsorship->listSponsoships();
		}
		else
			echo 0;
	}
	else
		echo -1;
?>
