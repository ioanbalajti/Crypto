namespace Crypto
{
    internal class RotN: Crypto
    {
        internal int n;

        internal RotN(string text, int value)
        {
            n = value;
            GenerateKey(text);
            wrongKey = key;
        }

        protected override void GenerateKey(string text)
        {
            initialText = text;
            key.n = 1;
            key.values = new char[1][];
            key.values[0] = new char[26];

            for (char i = 'a'; i <= 'z'; i++)
            {
                if (i + n <= 'z')
                    key.values[0][i-97] = (char)(i + n);
                else
                    key.values[0][i - 97] = (char)(i - 26 + n);
            }
        }
    }
}