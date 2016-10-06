var rpio = require('rpio');
rpio.spiBegin();

process.stdout.write('\x1b[36m');

process.on('SIGTERM', function () {
    process.exit(0);
});

process.on('SIGINT', function () {
    process.exit(0);
});

process.on('exit', function () {
    rpio.spiEnd();
    process.exit(0);
});

var http = require('http');

var server = http.createServer(function(request, response){
    var channel = 0;

    var txBuffer = new Buffer([0x01, (8 + channel << 4), 0x01]);
    var rxBuffer = new Buffer(txBuffer.byteLength);

    rpio.spiTransfer(txBuffer, rxBuffer, txBuffer.length);

    var junk = rxBuffer[0],
        MSB = rxBuffer[1],
        LSB = rxBuffer[2];

    var value = ((MSB & 3) << 8) + LSB;

    response.writeHead(200, {'Content-Type': 'text/html'});
    
    response.write(value.toString());
    response.end();
});

server.listen(8001);
