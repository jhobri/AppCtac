using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Transversal.Extension
{
    public static class ConclusionDescriptivaRandom
    {
        public static string Get()
        {
            Random rnd = new Random();
            //Dictionary of strings
            string[] words = { "SIAGIE MINEDU PERU", "SIAGIE INICIAL MINEDU", "SIAGIE PRIMARIA MINEDU", "SIAGIE SECUNDARIA MINEDU", "SIAGIE MINEDU PERU EBR", "SIAGIE MINEDU AuToGeNeRaDo" };
            //Random number from - to
            int randomNumber = rnd.Next(20000, 30000);
            //Create combination of word + number
            string randomString = $"{words[rnd.Next(0, words.Length)]} {randomNumber}";

            return randomString;

        }
    }
}
