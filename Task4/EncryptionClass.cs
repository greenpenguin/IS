using System.Collections.Generic;
using System.Text;

namespace Task4
{
    public class EncryptionClass
    {
        public List<int> Encryption(string messageForEncryption, char[,] matrixOfKeys)
        {
            List<int> codeOfMessage = new List<int>();
            
            for (int i = 0; i < messageForEncryption.Length; i++)
            {
                for (int j = 0; j < matrixOfKeys.GetLength(0); j++)
                {
                    for (int k = 0; k < matrixOfKeys.GetLength(1); k++)
                    {
                        if (matrixOfKeys[j, k] == messageForEncryption[i])
                        {
                            codeOfMessage.Add(j);
                            codeOfMessage.Add(k);
                            break;
                        }
                    }
                }
            }
            
            return codeOfMessage;
        }

        public StringBuilder Decryption(List<int> messageForDecryption, char[,] matrixOfKeys)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < messageForDecryption.Count - 2; i += 2)
            {
                result.Append(matrixOfKeys[messageForDecryption[i], messageForDecryption[i + 1]]);
            }
            return result;
        }

    }
}