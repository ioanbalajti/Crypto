using System.IO;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            string buffer, s = "";
            TextReader inputText = new StreamReader(@"..\..\Input.txt");
            while ((buffer = inputText.ReadLine()) != null) s += buffer;
            StreamWriter outputText = new StreamWriter(@"..\..\Output.txt");

            Crypto c = new RotN(s, 3);
            Calculate(c);
            outputText.WriteLine("Caesar...");
            outputText.WriteLine();
            TextWrite(c, outputText);

            c = new RotN(s, 13);
            Calculate(c);
            outputText.WriteLine("Rot13...");
            outputText.WriteLine();
            TextWrite(c, outputText);

            c = new RotN(s, 7);
            Calculate(c);
            outputText.WriteLine("RotN...");
            outputText.WriteLine();
            TextWrite(c, outputText);

            c = new MonoSubstitution(s);
            Calculate(c);
            outputText.WriteLine("MonoAlfa Substitution...");
            outputText.WriteLine();
            TextWrite(c, outputText);

            c = new PoliSubstitution(s);
            Calculate(c);
            outputText.WriteLine("PoliAlfa Substitution...");
            outputText.WriteLine();
            TextWrite(c, outputText);

            outputText.Close();
        }

        static void Calculate(Crypto c)
        {
            c.Encrypt();
            c.Decrypt();
        }

        static void TextWrite(Crypto c, StreamWriter text)
        {
            text.WriteLine("Encrypted:");
            text.WriteLine(c.encryptedText);
            text.WriteLine();
            text.WriteLine("Decrypted:");
            text.WriteLine(c.decryptedText);
            text.WriteLine();
            text.WriteLine();
        }
    }
}
