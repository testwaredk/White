﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TestStack.White.Core.Security
{
    public class Cryptography
    {
        /// <summary>
        /// Returns a MD5 hash as a string
        /// http://dotnet-snippets.com/snippet/generate-md5-hash/644
        /// </summary>
        /// <param name="TextToHash">String to be hashed.</param>
        /// <returns>Hash as int.</returns>
        public static int GetMD5Hash(String TextToHash)
        {
            //Check wether data was passed
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return 0;
            }

            //Calculate MD5 hash. This requires that the string is splitted into a byte[].
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(TextToHash);
            byte[] result = md5.ComputeHash(textToHash);

            //Convert result back to string.
            return System.BitConverter.ToInt32(result, 0);
        }

        public static int GetMD5Hash(int[] integersToHash)
        {
            string textToHash = String.Concat(integersToHash);
            return GetMD5Hash(textToHash);
        }

    }
}
