using System;

//Operator Overloading Example
public class Point{

	public int x;
	public int y;

	public Point(int x, int y){
		this.x = x;
		this.y = y;
	}

	public static Point operator+(Point a, Point b){

		Point point = new Point(a.x + b.x, a.y + b.y);
		return point;
	}

	public string getDataString(){

		return this.x + ", " + this.y;
	}

	public static void Main(string[] args){

		Point pointA = new Point(5, 10);
		Point pointB = new Point(1, 2);
		Point pointC = pointA + pointB;

		Console.WriteLine(pointC.getDataString());
	}
}