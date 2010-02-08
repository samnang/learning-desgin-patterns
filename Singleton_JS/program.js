/*
Singleton Pattern:

Ensure a class has only one instance and provide a global point of access to it.
*/

//================== Really, Really basic Singleton =================
var MySingleton = {
	attribute1: true,
	attribute2: 10,
	
	method1: function() {
	},
	method2: function(arg) {
	}
};

//================== Another example Singleton =======================
ApplicationSettings = (function() {
	//Private member 
	var appName = "Singleton in Practice";
	
	return { //Public member
		applicationName: function() {
			return appName;
		}		
	};
})();

console.log(ApplicationSettings.applicationName()); //Run example


//========== Another example Singleton in lazy instantiation ==========
ApplicationResources = (function() {
	var expensiveInstance;
	
	function constructor() {
		//Private members.
		var privateAttribute = false;
		
		function privateMethod() {
			console.log("private method");
		}
		
		return { //Public members.
			publicAttribute: 10,
			
			publicMethod: function() {
				privateMethod(); //Calling private method
				console.log("public method");
			}
		};
	}
	
	return {
		getInstance: function() {
			if(!expensiveInstance) {
				expensiveInstance = constructor();
			}
			
			return expensiveInstance;
		}
	};
})();

ApplicationResources.getInstance().publicMethod(); //Run example