using System;

namespace Crypto
{
    internal class MonoSubstitution : Crypto
    {
        internal Random r = new Random();

        internal MonoSubstitution(string text)
        {
            GenerateKey(text);
            wrongKey = key;
        }

        protected override void GenerateKey(string text)
        {
            initialText = text;
            key.n = 1;
            key.values = new char[1][];
            key.values[0] = new char[26];
            char a = 'a';

            int[] v = new int[26];
            for (int i = 0; i < 26; i++)
                v[i] = i;

            for (int i = 25; i >= 0; i--)
            {
                int index = r.Next(i);
                int temp = v[i];
                v[i] = v[index];
                v[index] = temp;
            }

            for(int i=0; i<26; i++)
                key.values[0][i] = (char)(a + v[i]);
        }
    }
}