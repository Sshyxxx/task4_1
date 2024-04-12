namespace task4_1;

class Program
{
    static void Main(string[] args)
    {
        OneDArray<string> one = new OneDArray<string>();
        one.Add("one");
        OneDArray<int> two = new OneDArray<int>();
        two.Add(2);
        OneDArray<int> two2 = new OneDArray<int>();
        two2.Add(2);
        OneDArray<double> three = new OneDArray<double>();
        three.Add(3.3);
        OneDArray<bool> four = new OneDArray<bool>();
        four.Add(true);


        Console.WriteLine("Hello, World!");
    }
}
