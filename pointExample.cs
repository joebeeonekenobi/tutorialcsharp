#define DEBUG
//Preprocessor symbol which cannot take a value, and does not conflict with any in-program variables names.


using System;
/*
	by 'using' System, anything we reference that is not found 
	such as Console, when using Console.WriteLine, searches System,
	and other namespaces that we are 'using' to match.
*/
using System.Diagnostics;
//This is required for 'Conditional[]' attribute
using System.Collections;
//For a Stack

//Interface Example
public interface DisplaysData{

	string getDataString();
}

//Attribute Example

//This tag restricts how the attribute can be used, I have allowed all components.
//I have also redundantly set the AllowMultiple field to false (default false), so that it can only be applied to each method at max once.
[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class OverloadTag : System.Attribute{

	/*
		An attribute is essentially just an object like any other, that implements
		the System.attribute interface.
	*/

	public string operatorName;
	public int overloadNumber;

	public OverloadTag(string name, int number){

		this.operatorName = name;
		this.overloadNumber = number;
	}
}

[OverloadTag("plus", 0)]
public class Point : DisplaysData{

	public int x;
	public int y;
	public bool warningRaised = false;
	private string hiddenName; //Cannot be accessed directly

	//A way to access the hidden name
	public string name{
		get{
			//This method ensures that hiddenName cannot be accessed and returned. It is write only, unless another exposed method returns it somehow!

			Console.WriteLine("Sorry, name is hidden.");
			return null;
		}
		set{
			//This method CANNOT set a value to itsself (name) or an infinite loop will occur.

			Console.WriteLine("WARNING, NAME OF POINT IS BEING OVERWRITTEN to : "+value);
			hiddenName = value;
			//value is essentially reserved in a set accessor, and it will raise an error to declare it.
			//It inherently contains the value that is passed to it from the setting of the variable.
		}
	}

	public Point(int x, int y){

		this.x = x;
		this.y = y;
		logCreation();
	}

	//Operator Overloading Example
	public static Point operator+(Point a, Point b){

		Point point = new Point(a.x + b.x, a.y + b.y);
		return point;
	}

//!Currently broken
	public static object[] getTags(){

		//Get the attribute info for Point
		System.Reflection.MemberInfo info = typeof(Point);

		//Create a store for the attributes
		Stack tags = new Stack();

		//There may be many attributes for Point
		foreach(var attribute in info.GetCustomAttributes(true)){

			//Push them into the store
			tags.Push(attribute);
		}

		//Return an array and not a stack
		return tags.ToArray();
	}

	//This function will only be called when DEBUG is defined;
	[Conditional("DEBUG")]
	public void logCreation(){

		Console.WriteLine("New Point Created: ("+ this.x +", "+ this.y +")");
	}

	//Obeys Interface
	public string getDataString(){

		return this.x + ", " + this.y;
	}

	[Obsolete("Do not use this function at all", true)]
	public string getString(){

		Console.WriteLine("This function is deprecated.");
		return "";
	}

	public static void Main(string[] args){

		/*
			Preprocessor Code
		*/
		#if(DEBUG)
			Console.WriteLine("Debugging is enabled.");
		#endif
		#if(TRACE)
			Console.WriteLine("Tracing is enabled.");
		#endif

		Point pointA = new Point(5, 10);
		Point pointB = new Point(1, 2);
		Point pointC = pointA + pointB;
		pointC.name = "joejoe"; //This will hit the set accessor, rather than directly set the value.

		Console.WriteLine(pointC.name);

		//Can now get the attribute tags in program
		object[] tags = Point.getTags();
		//The first tag is the OverloadTag.
		Console.WriteLine(tags[0]);

		/*
			This call will raise an error at compiletime as the method is marked as obsolete
			//Console.WriteLine(pointC.getString());
		*/

		Console.WriteLine(pointC.getDataString());
	}
}
