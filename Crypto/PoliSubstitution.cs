using System;

namespace Crypto
{
    internal class PoliSubstitution : Crypto
    {
        internal Random r = new Random();

        internal PoliSubstitution(string text)
        {
            GenerateKey(text);
            wrongKey = key;
        }

        protected override void GenerateKey(string text)
        {
            initialText = text;
            key.n = r.Next(2, 5);
            key.values = new char[key.n][];
            char a = 'a';

            int[] v = new int[26];
            for (int i = 0; i < 26; i++)
                v[i] = i;

            for (int i = 0; i < key.n; i++)
            {
                key.values[i] = new char[26];
                for (int j = 25; j >= 0; j--)
                {
                    int index = r.Next(j);
                    int temp = v[j];
                    v[j] = v[index];
                    v[index] = temp;
                }

                for (int j = 0; j < 26; j++)
                    key.values[i][j] = (char)(a + v[j]);
            }
        }
    }
}