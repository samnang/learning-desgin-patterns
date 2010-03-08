/*
Adapter Pattern:

Convert the interface of a class into another interface clients expect.
Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
*/

//Existing component
LegacyLine = function() {
	this.drawLine = function(x1, y1, x2, y2) {
		console.log("line from (" + x1 + ',' + y1 + ") to (" + x2 + ',' 
          + y2 + ')');
	};
};

LegacyRectangle = function() {
	this.drawRectangle = function(x, y, w, h) {
		 console.log("rectangle at (" + x + ',' + y + ") with width " + w
          + " and height " + h);
	};
};

//Adapter
Line = function() {
	var _legacyLine = new LegacyLine();
	
	this.draw = function(x1, y1, x2, y2) {
		_legacyLine.drawLine(x1, y1, x2, y2);
	};
};

Rectangle = function() {
	var _legacyRectangle = new LegacyRectangle();
	
	this.draw = function(x1, y1, x2, y2) {
		_legacyRectangle.drawRectangle(Math.min(x1, x2), Math.min(y1, y2), Math.abs(x2 - x1), Math.abs(y2 - y1));
	};
};

//Running example
var shapes = [new Line(), new Rectangle()];
var x1 = 10, y1 = 20;
var x2 = 30, y2 = 60;

for (var i = 0; i < shapes.length; i++)
  shapes[i].draw(x1, y1, x2, y2);