namespace CryptLab2;

public class BlockTest
{
    private static int rounds = 3;
    public void feist(char[] a, bool reverse)
    {
        for (int s = 0; s < a.Length; s += 2)
        {
            int round = reverse? rounds: 1;
            char l = a[s];
            char r = a[s + 1];
            for (int i = 0; i < rounds; i++)
            {
                if (i < rounds - 1) // если не последний раунд
                {
                    char t = l;
                    int aux = (r ^ f(l, round));
                    l = (char) aux;
                    r = t;
                }
                else // последний раунд
                {
                    r = (char) (r ^ f(l, round));
                }
                round += reverse? -1: 1;
            }
            a[s] = l;
            a[s + 1] = r;
        }

    }
    private int f(char b, int k)
    {
        return b + k;
    }

    private void print(char[] a)
    {
        foreach (char symbol in a)
        {
            Console.Write(symbol + " ");
        }
        Console.WriteLine();
    }
    
    public void test()
    {
        char[] a = new char[8];

        for (int j = 0; j < 8; j++)
        {
            a[j] = (char) (j + 40);
        }
        print(a);
        feist(a, false);
        print(a);
        feist(a, true);
        print(a);
    }
}