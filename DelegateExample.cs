using System;

delegate object FunctionPointer();

public class DelegateExample{

	//Initialised to the tricksy function
	private static FunctionPointer functionInPlay = new FunctionPointer(wrongFunction);
	private static object trueObject = "This is the correct object!";
	private static object falseObject = "This is the not the right object!";

	//Functions to return objects
	private static object wrongFunction(){

		return falseObject;
	}
	private static object rightFunction(){

		return trueObject;
	}

	//Function to switch functions to the right function if the password is right!
	public static void switchFunctions(string password){

		//If the password is correct
		if(password == "joejoe"){

			//functionInPlay will point to a new function
			functionInPlay = new FunctionPointer(rightFunction);
		}
	}

	//Main
	public static void Main(string[] args){

		object myObject = functionInPlay();

		Console.WriteLine(myObject);

		switchFunctions("joejoe");

		myObject = functionInPlay();

		Console.WriteLine(myObject);
	}
}
