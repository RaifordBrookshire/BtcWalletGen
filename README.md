## Bitcoin HD Wallet Generator
This is a C# .NET 7.0 console CLI tool that generates Bitcoin addresses and writes the results to the console. It uses the NBitcoin class library to create the Bitcoin keys and public addresses.

### Create keys in an Offline Environment
When generating crypto wallets, it is important to do so in an offline environment to ensure maximum security. This is because an online environment is more susceptible to hacking and other forms of cyber attacks. Additionally, it is important to securely store the 12-word mnemonic in a safe and secure place, such as a password manager like KeePass. KeePass is completely offline with encryption, which provides an added layer of security for your mnemonic.

> *IMPORTANT: The private keys and specifically the 12 word phrase should be kept private  and not shared with anyone, as it gives access to the funds associated with the wallet.*
### Using the Command Line Tool
To use the command, you will need to install the NBitcoin class library via Nuget. The command to install is:

```
Install-Package NBitcoin    
or   
dotnet add package NBitcoin
```

Once the library is installed, you can run the command by typing the following into the console:
```
BtcKeyGenerator
```
Running this command will generate the Bitcoin address and display the output to the console.

### Program Output
The output of the program will dump the following data:

   * BIP39 Mnemonic: 
     * This is a 12-word seed phrase that is used to generate the private key. It should be kept in a safe and secure place and is the only thing you need to restore your wallet at anytime.


   * BIP39 Seed: 
     * This is a 128-bit seed that is used to generate the private key.
 

   * BIP32 Root Key: 
     * This is the master private key that is used to generate the other private keys.
 
 
   * BIP32 Derivation Path: 
     * This is the path that is used to generate the other private keys.
 

   * BIP32 ExtPubKey: 
     * This is the extended public key that is used to generate the public addresses.
   
The program will also display a list of derived public addresses in the format:

##### [derivation path], [public address], [public key], [private key]

### Example Output

```text
Derivation Path ->  Public Address  ->  Public Key  ->  Private Key

m/44'/0'/0'/0/0	1EFJ6V2faD7UVfjuVH8Q1dHLxvwuVuW3hF	0309a8630c60d8b51fddbc392a0e4ad3de07c6928a434d4eb38e73b21ee1389057 L5hziKTFhoPKykpUHYji1gQMkKwmd1ZqwLv5nswtFEuEw2Xqbxva
m/44'/0'/0'/0/1	18D44FdmxzHd24si4gE6Xf2H4m8w2PnUcY	03ad9ae83c24f8d7e4ec4b127151c097068923051dd8643d93ef9a926dc1fb38a7 KzxNiTMUSMnQC5ZMo1BYtKU9Xi3Nc68vB36bMotMfoDcwVyj7uE7
m/44'/0'/0'/0/2	1AL5GXiKw6pcHaZHuq2FeWWkvzQoyep3i1	023bf016efae1b7671216a0d1fa7d6f2ce7ab77ded26ab1489411a6dc7938d9634 L1KvAXxvph3FmNVgDPVQNhVYuq5ap1htFmkUD2tAFnw41xVQagyA
```


Since the 12-word phrase is all you need to restore your wallet you must keep that secure and encrypted. You can save the public address and use these addresses to receieve Bitcoin. It is good practice to use a new public address for each transaction to ensure privacy.