namespace Crypto
{
    internal abstract class Crypto
    {
        internal string initialText;
        internal string encryptedText;
        internal string decryptedText;

        static internal double[] occurance = new double[]
        {
            0.08167,
            0.01492,
            0.02782,
            0.04253,
            0.12702,
            0.02228,
            0.02015,
            0.06094,
            0.06966,
            0.00153,
            0.03872,
            0.04025,
            0.02406,
            0.06749,
            0.07507,
            0.01929,
            0.00095,
            0.05987,
            0.06327,
            0.09256,
            0.02758,
            0.00978,
            0.05370,
            0.00150,
            0.03978,
            0.00074
        };

        internal double[] occuranceDecypher = new double[26];

        protected struct Key
        {
            internal int n;
            internal char[][] values;
        }
        protected Key key;
        protected Key wrongKey;

        protected abstract void GenerateKey(string text);

        internal virtual void Encrypt()
        {
            string tf = "";
            string ti = initialText;
            int k = 0;
            for (int i = 0; i < ti.Length; i++)
            {
                if (!char.IsLetter(ti[i]))
                    tf += ti[i];
                else
                {
                    char a = 'a';
                    char aux = ti[i];
                    if (char.IsUpper(aux))
                    {
                        a = 'A';
                        tf += (char)(wrongKey.values[k][aux - a] - 32);
                    }
                    else
                        tf += wrongKey.values[k][aux - a];

                    k++;
                    if (k == wrongKey.n)
                        k = 0;
                }
            }
            encryptedText = tf;
        }

        internal virtual void Decrypt()
        {
            string tf = "";
            string ti = encryptedText;
            int k = 0;
            for (int i = 0; i < ti.Length; i++)
            {
                if (!char.IsLetter(ti[i]))
                    tf += ti[i];
                else
                {
                    char a = 'a';
                    char aux = ti[i];
                    if (char.IsUpper(aux))
                    {
                        a = 'A';
                        aux = (char)(aux + 32);
                    }

                    string temp = "";
                    foreach (char c in wrongKey.values[k])
                        temp += c;
                    tf += (char)(a + temp.IndexOf(aux));

                    k++;
                    if (k == wrongKey.n)
                        k = 0;
                }
            }
            decryptedText = tf;
        }
    }
}
