#define DEBUG


using System;
/*
	by 'using' System, anything we reference that is not found 
	such as Console, when using Console.WriteLine, searches System,
	and other namespaces that we are 'using' to match.
*/
using System.Diagnostics;
//This is required for 'Conditional[]' attribute

//Interface Example
public interface DisplaysData{

	string getDataString();
}

public class Point : DisplaysData{

	public int x;
	public int y;

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

		Point pointA = new Point(5, 10);
		Point pointB = new Point(1, 2);
		Point pointC = pointA + pointB;

		/*
			This call will raise an error at compiletime
			//Console.WriteLine(pointC.getString());
		*/

		Console.WriteLine(pointC.getDataString());
	}
}
