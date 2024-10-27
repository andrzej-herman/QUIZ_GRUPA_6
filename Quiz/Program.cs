using Quiz;

var backend = new Backend();
var frontend = new Frontend();



var numbers = new List<string>();
numbers.Add("Ala");
numbers.Add("Basia");
numbers.Add("Ala");
numbers.Add("Tomek");

var name = numbers[3];
Console.WriteLine(name);

int howMuch = numbers.Count;
Console.WriteLine(howMuch);




Console.ReadLine();