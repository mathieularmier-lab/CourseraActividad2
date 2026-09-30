namespace ApuntesClaseDyA;

public class ActCur2
{
    public string inpt;
    public string[] word;
    public int[] largo;

    public void DivINPT(string str)
    {
        word = str.Split(' ');
    }

    public void PrintWords()
    {
        foreach (string s in word)
        {
            Console.WriteLine(s);
        }
    }

    public void PrintCount()
    {
        foreach (string s in word)
        {
            Console.WriteLine(s.Length);
        }
    }
}