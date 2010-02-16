/* 
 Builder Pattern:
    - Separate the construction of a complex object from its representation so 
      that the same construction process can create different representations.
    - Parse a complex representation, create one of several targets.
 */
 
// Director
CarShop = function(builder) {
	this._builder = builder;
	
	this.buildCar = function() {
		this._builder.makeColor();
		this._builder.makeWheels();
		this._builder.makeAirConditioning();
	};
};

// Builder
CarBuilder = function() {
	this._car = new Car();
	
	this.getCar = function() {
		return this._car;
	};
};

// Concret Builder
MediumBuilder = function() {
	CarBuilder.apply(this);
	
	this.makeColor = function() {
		this._car.color = "White";
	};
	
	this.makeWheels = function() {
		this._car.wheels = 4;
	};
	
	this.makeAirConditioning = function() {
		this._car.airConditioning = "Not Available";
	};
};

// Concret Builder
LuxuryBuilder = function() {
	CarBuilder.apply(this);
	
	this.makeColor = function() {
		this._car.color = "Black";
	};
	
	this.makeWheels = function() {
		this._car.wheels = 6;
	};
	
	this.makeAirConditioning = function() {
		this._car.airConditioning = "Available";
	};
};

// Product
Car = function() {
	this.color;
	this.wheels;
	this.airConditioning;
};


// Run Example
var mediumBuilder = new MediumBuilder();
var carShop = new CarShop(mediumBuilder);
carShop.buildCar();
console.log(mediumBuilder.getCar());

var luxuryBuilder = new LuxuryBuilder();
var carShop = new CarShop(luxuryBuilder);
carShop.buildCar();
console.log(luxuryBuilder.getCar());