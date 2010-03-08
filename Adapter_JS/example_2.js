/*
Adapter Pattern:

Convert the interface of a class into another interface clients expect.
Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.
*/

//Third party
Calculator = function() {
	this.sum = function(a, b) {
		console.log('sum = ' + (a + b).toString());
	};
};

//Adapter
CalculatorWrapper = function() {
	var _adaptee = new Calculator();
	
	this.sum = function(a, b) {
		_adaptee.sum(a, b);
	};
};

//Running example
var calculator = new CalculatorWrapper();
calculator.sum(1, 2);