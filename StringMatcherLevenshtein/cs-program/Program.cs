using System;

class Program
{
    // Método para calcular a distância de Levenshtein entre duas strings
    static int LevenshteinDistance(string s, string t)
    {
        int n = s.Length;
        int m = t.Length;
        int[,] d = new int[n + 1, m + 1];

        if (n == 0) return m;
        if (m == 0) return n;

        for (int i = 0; i <= n; d[i, 0] = i++) ;
        for (int j = 0; j <= m; d[0, j] = j++) ;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                d[i, j] = Math.Min(
                    Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                    d[i - 1, j - 1] + cost);
            }
        }

        return d[n, m];
    }

    // Método para encontrar e imprimir os pares mais próximos
    static void FindClosestPairs(string[] list1, string[] list2)
    {
        foreach (string s1 in list1)
        {
            int minDistance = int.MaxValue;
            string closest = "";

            foreach (string s2 in list2)
            {
                int distance = LevenshteinDistance(s1, s2);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = s2;
                }
            }

            Console.WriteLine($"f({s1}) = {closest}  d={minDistance}");
        }
    }

    static void Main(string[] args)
    {
        string[] list1 = { "gato", "cão", "pássaro", "passado", "passageiro", "pato", "são" };
        string[] list2 = { "rato", "cão", "passarinho" };

        FindClosestPairs(list1, list2);
    }
}
