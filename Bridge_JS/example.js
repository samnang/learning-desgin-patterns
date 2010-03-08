/* 
 Bridge Pattern:
    - Decouple an abstraction from its implementation so that the two can vary independently.
 */

//The 'Abstraction' class
Shape = function(drawing) {
	
	//Implementor
	this._drawing = drawing;
}

// The 'RefinedAbstraction' class
Rectangle = function(drawing, x1, y1, x2, y2) {
	Shape.call(this, drawing);
	var _x1 = x1;
	var _y1 = y1;
	var _x2 = x2;
	var _y2 = y2;
	
	this.draw = function() {
		console.log('Drawing rectangle');
		this._drawing.drawLine( _x1, _y1, _x2, _y1);
		this._drawing.drawLine( _x2, _y1, _x2, _y2);
		this._drawing.drawLine( _x2, _y2, _x1, _y2);
		this._drawing.drawLine( _x1, _y2, _x1, _y1);
	};
};

// The 'RefinedAbstraction' class
Circle = function(drawing, x, y, r) {
	Shape.call(this, drawing);
	var _x = x;
	var _y = y;
	var _r = r;
	
	this.draw = function() {
		console.log('Drawing circle');
		this._drawing.drawCircle(_x, _y, _r);
	}
}

//The 'ConcretImplementor' class
SVG = function() {
	this.drawLine = function (x, y){
		console.log('Calling SVG drawLine function');
	};
	
	this.drawCircle = function(x, y, r) {
		console.log('Calling SVG drawCircle function');
	};
};

//The 'ConcretImplementor' class
VML = function() {
	this.drawLine = function (x1, y1, x2, y2){
		console.log('Calling VML drawLine function');
	};
	
	this.drawCircle = function(x, y, r) {
		console.log('Calling VML drawCircle function');
	};
};


//Running example
rectangle = new Rectangle(new SVG(), 10, 10, 110, 200);
rectangle.draw();

circle = new Circle(new VML(), 10, 10, 50);
circle.draw();

