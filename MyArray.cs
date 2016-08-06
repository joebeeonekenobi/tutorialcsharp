using System;
namespace MyArrayTest{

	class MyArray{

		private object[] members;
		private int size = 0;
		public int length{
			get{
				return size;
			}
			set{
				//this will have to do more if we are changing the length of the array mid-execution...
				size = value;
			}
		}

		//Constructor
		public MyArray(int size){

			this.length = size;
			this.members = new object[size];
		}

		//Indexer accessor
		public object this[int index]{
			/*
				This example shows how you can define array access for custom object.
				Exciting?
			*/

			get{

				if( (index >= 0) && (index < this.length) ){
					return this.members[index];
				}

				return null;
			}
			set{

				if( (index >= 0) && (index < this.length) ){
					this.members[index] = value;
				}
			}
		}

		public void printArray(){

			for(var i=0; i<this.length; i++){

				Console.WriteLine("Entry["+i+"] : " + this.members[i]);
			}
		}

		//Main
		public static void Main(string[] args){

			MyArray myArray = new MyArray(2);

			myArray[0] = "Hello you!";
			myArray[1] = 1;

			Console.WriteLine(myArray);
			myArray.printArray();
		}

	}
}