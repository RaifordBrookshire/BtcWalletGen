using System;
using System.Drawing;
using System.Text;
using NBitcoin;
using NBitcoin.Crypto;

class Program
{
    static void Main(string[] args)
    {
        // Variable that can be changed via the command line
        string keyPath = "m/49'/0'/0'/0";
        WordCount wordCount = WordCount.Twelve;
        Network network = Network.Main;
        bool isHardened = true;
        var addressCount = 10;

        // Date / Time Generated
        WriteLine("");
        WriteLabel("Generated On: ");
        WriteLine($"{DateTime.Now.ToString()}", ConsoleColor.DarkGray);

        // Generate a 12 word passphrase
        var mnemonic = new Mnemonic(Wordlist.English, wordCount);
         WriteLabel("BIP39 Mnumonic: ");
       WriteLine($"{mnemonic}", ConsoleColor.Red);

        // Create the seed from the mnemonic
        var seed = mnemonic.DeriveSeed();
        var seedHex = HashBytesToHashString(seed);
        var seedHex2 = seed.ToString();
        WriteLabel("BIP39 Seed: ");
        WriteLine($"{seedHex}", ConsoleColor.DarkGray);

        // Create the root key from the seed
        var rootKey = new ExtKey(seedHex);
        var rootKeyHex = rootKey.ToString(network);
        WriteLabel("BIP32 RootKey: ");
        WriteLine($"{rootKeyHex}", ConsoleColor.DarkGray);

        // Define the derivation path
        var derivationPath = new KeyPath(keyPath);
        WriteLabel("BIP32 DerivationPath: ");
        WriteLine($"{derivationPath}", ConsoleColor.DarkGray);

        // Create the extended private key
        var extPrivKey = rootKey.Derive(derivationPath);
        WriteLabel("BIP32 ExtPrivKey: ");
        WriteLine($"{extPrivKey.ToString(network)}", ConsoleColor.DarkGray);

        // Create the extended public key
        var extPubKey = rootKey.Derive(derivationPath).Neuter();
        WriteLabel("BIP32 ExtPubKey: ");
        WriteLine($"{extPrivKey.ToString(network)}", ConsoleColor.DarkGray);

        WriteLabel("Hardened: ");
        WriteLine($"{isHardened}", ConsoleColor.DarkGray);

        WriteLine("");
        WriteLine("DERIVED ADDRESSES     Derivation Path ->  Public Address  ->  Public Key  ->  Private Key", ConsoleColor.Cyan);
        WriteLine("");

        for (int i = 0; i < addressCount; i++)
        {
            // Generate a Bitcoin private key
            var privKey = extPrivKey.Derive(i, isHardened).PrivateKey;
            // Generate a Bitcoin public key
            var pubKey = privKey.PubKey;
            // Generate a Bitcoin address
            var address = pubKey.GetAddress(ScriptPubKeyType.SegwitP2SH, network);

            // Print the results to the console
            Write($"m/{derivationPath}{i}, ");
            Write($"{address}, ", ConsoleColor.Green);
            Write($"{pubKey}, ");
            WriteLine($"{privKey.ToString(network)}", ConsoleColor.DarkRed);
        }

        WriteLine("");
        WriteLine("!!!! IMPORTANT  !!!!",  ConsoleColor.Yellow);
        WriteLine("");
        WriteLine("The RED text you should NEVER expose to anyone. Keep it PRIVATE!",  ConsoleColor.Yellow);
        WriteLine("The GREEN text can be saved and used for transactions. They are NOT private.",  ConsoleColor.Yellow);
        WriteLine("The GRAY text is PRIVATE, but not required to restore your wallet.",  ConsoleColor.Yellow);
        WriteLine("The WHITE text can be saved, but not required to restore your wallet. NOTE Private",  ConsoleColor.Yellow);
        WriteLine("");
    }

    #region Helper Methods
    public static byte[] StringToBytes(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        return bytes;
    }
    public static string BytesToString(byte[] bytes)
    {
        return BitConverter.ToString(bytes);
    }
    static public string HashBytesToHashString(byte[] bytes)
    {
        string hash = BytesToString(bytes);
        return hash.ToLower().Replace("-", "");
    }
    static void Write(string output, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.Write(output);
        Console.ResetColor();
    }
    static void WriteLine(string output, ConsoleColor color = ConsoleColor.DarkGray)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(output);
        Console.ResetColor();
    }
    static void WriteLabel(string output)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        //Console.Write($"\x1b[1m{output}\x1b[0m");
        Console.Write(output);
        Console.ResetColor();
    }
    # endregion
}