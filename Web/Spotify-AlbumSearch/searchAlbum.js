function loadArtist(query) {
	document.getElementById("demo").innerHTML = " ";
	query = document.getElementById("album").value;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (xhttp.readyState == 4 && xhttp.status == 200) {
			var data = xhttp.responseText;
			var jsonArray = JSON.parse(data);
			loadAlbum(jsonArray.artists.items[0].id);
		}
	};
  var input = "https://api.spotify.com/v1/search?q=" + query + "&type=artist";
  xhttp.open("GET", input, true);
  xhttp.send();
}

function loadAlbum(query) {
	document.getElementById("demo").innerHTML += "<br>Albuns: <br> ";
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (xhttp.readyState == 4 && xhttp.status == 200) {

			var data = xhttp.responseText;
			var jsonArray = JSON.parse(data);
			var sizeof = 0;
			for (i in jsonArray.items) {
				sizeof++;
			}
			if (sizeof == 50) {
				i = 50;
			}
			for (sizeof; sizeof != 0; sizeof--)
			{
				var output = "<img src="+jsonArray.items[sizeof-1].images[0].url+" height='200' />";
				document.getElementById("demo").innerHTML += output;
			}
			
			if (i == 50) {
				loadAlbum2(query);
			}
		}
	};
  var input = "https://api.spotify.com/v1/artists/" + query + "/albums?limit=50&album_type=album,single,compilation,appears_on";
  xhttp.open("GET", input, true);
  xhttp.send();
}

function loadAlbum2(query) {
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (xhttp.readyState == 4 && xhttp.status == 200) {

			var data = xhttp.responseText;
			var jsonArray = JSON.parse(data);
			var sizeof = 0;
			for (i in jsonArray.items) {
				sizeof++;
			}
			if (sizeof == 50) {
				i = 50;
			}
			for (sizeof; sizeof != 0; sizeof--)
			{
				var output = "<img src="+jsonArray.items[sizeof-1].images[0].url+" height='200' />";
				document.getElementById("demo").innerHTML += output;
			}
			if (i == 50) {
				loadAlbum3(query);
			}
		}
	};
  var input = "https://api.spotify.com/v1/artists/" + query + "/albums?offset=50&limit=50&album_type=album,single,compilation,appears_on";
  xhttp.open("GET", input, true);
  xhttp.send();
}

function loadAlbum2(query) {
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
		if (xhttp.readyState == 4 && xhttp.status == 200) {

			var data = xhttp.responseText;
			var jsonArray = JSON.parse(data);
			var sizeof = 0;
			for (i in jsonArray.items) {
				sizeof++;
			}
			for (sizeof; sizeof != 0; sizeof--)
			{
				var output = "<img src="+jsonArray.items[sizeof-1].images[0].url+" height='200' />";
				document.getElementById("demo").innerHTML += output;
			}
		}
	};
  var input = "https://api.spotify.com/v1/artists/" + query + "/albums?offset=100&limit=50&album_type=album,single,compilation,appears_on";
  xhttp.open("GET", input, true);
  xhttp.send();
}
