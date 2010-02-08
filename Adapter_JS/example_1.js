/*
Convert the interface of a class into another interface clients expect.
Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
*/

//Existing component
LegacyLine = function() {
	this.drawLine = function(x1, y1, x2, y2, fill) {
		console.log("Draw Line");
	};
};

LineAdapter = function() {
	var _legacyLine = new LegacyLine();
	this.draw = function(x1, y2, x2, y2) {
		_legacyLine.drawLine(x1, y2, x2, y2, "black");
	};
};

//Client
var line = new LineAdapter();
line.draw();