var express = require('express');
var app     = express();
var ip 		= '10.0.0.10';
var port    = process.env.PORT || 8080;
var fs 	    = require('fs');


app.get('/', function(req, res) {
	fs.readFile('client.html', function (err, data) {
		res.writeHead(200, {'Content-Type': 'text/html', 'Content-Length':data.length});
		res.write(data);
		res.end();
	});
});

app.listen(port);
console.log('Server on http://' + ip + ':' + port);

var rpio = require('rpio');

app.get('/blink', function(req, res) { 
    blinkLed(7);
});

function blinkLed(port) {
	console.log('Led Blink');
	rpio.open(port, rpio.OUTPUT, rpio.LOW);
	rpio.write(port, rpio.HIGH);
	rpio.sleep(1);
	rpio.write(port, rpio.LOW);
	rpio.msleep(500);
}
