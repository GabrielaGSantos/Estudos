var user = " "; // Put your last.fm user 
var apikey = " "; // Put your last.fm api key

var nome; // Used to store music name to reload only when needed.

function carregarMusica() { // Used to load the music info
var xhttp = new XMLHttpRequest(); 
xhttp.onreadystatechange = function() {
	if (xhttp.readyState == 4 && xhttp.status == 200) {
		var data = xhttp.responseText;
		var jsonArray = JSON.parse(data); //
		document.getElementById("cover").src = " ";
		document.getElementById("artist").innerHTML = jsonArray.recenttracks.track[0].artist['#text'].italics();
		document.getElementById("music").innerHTML = jsonArray.recenttracks.track[0].name.replace(/ *\-[^)]*/g, "").bold();
		document.getElementById("album").innerHTML = jsonArray.recenttracks.track[0].album["#text"].replace(/ *\([^)]*\) */g, "").replace(/ *\[[^)]*\] */g, "").replace(/ *\:[^)]*/g, "").replace(/ *\-[^)]*/g, "");
		document.getElementById("cover").src = (jsonArray.recenttracks.track[0].image[3]["#text"]).replace("/300x300/","/500x500/");
		nome = jsonArray.recenttracks.track[0].name;
	}
};
var input = "https://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user=" + user + "&api_key=" + apikey+ "&limit=1&format=json";
xhttp.open("GET", input, true);
xhttp.send();
}


function verificarNome() { // Used to check if the music name is the same. If changes, it reloads the cover.
var xhttp = new XMLHttpRequest();
xhttp.onreadystatechange = function() {
	if (xhttp.readyState == 4 && xhttp.status == 200) {
		var data = xhttp.responseText;
		var jsonArray = JSON.parse(data);
		document.getElementById("music").innerHTML = jsonArray.recenttracks.track[0].name.replace(/ *\-[^)]*/g, "").bold();
		document.getElementById("artist").innerHTML = jsonArray.recenttracks.track[0].artist['#text'].italics();
		document.getElementById("album").innerHTML = jsonArray.recenttracks.track[0].album["#text"].replace(/ *\([^)]*\) */g, "").replace(/ *\[[^)]*\] */g, "").replace(/ *\:[^)]*/g, "").replace(/ *\-[^)]*/g, "");
		if (jsonArray.recenttracks.track[0].name != nome) {
			document.getElementById("cover").src = "null";
			carregarMusica();
		}
	}
};
var input = "https://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user=" + user + "&api_key=" + apikey+ "&limit=1&format=json";
xhttp.open("GET", input, true);
xhttp.send();
}

setInterval(function() { // Calls verificaNome() each 1 second
	verificarNome();
}, 1000); 
