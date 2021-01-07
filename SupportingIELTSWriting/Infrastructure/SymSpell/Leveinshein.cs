using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Infrastructure.SymSpell
{
    public static class Leveinshein
    {
        private static string _firstStr;
        private static string _secondStr;

        public static string FirstStr
        {
            get { return _firstStr; }
        }
        public static string SecondStr
        {
            get { return _secondStr; }
        }
        public static int Leveinshtein(string firstStr, string secondStr)
        {
            int len1 = firstStr.Length;
            int len2 = secondStr.Length;
            var arrayDb = new int[len1 + 1, len2 + 1];

            for (int i = 0; i <= len1; i++)
                arrayDb[i, 0] = i;
            for (int i = 0; i <= len2; i++)
                arrayDb[0, i] = i;

            for(int i = 1; i <= len1; i++)
            {
                for(int j = 1; j <= len2; j++)
                {
                    int cost = firstStr[i] == secondStr[j] ? 0 : 1;
                    arrayDb[i, j] = Math.Min(Math.Min(arrayDb[i - 1, j], arrayDb[i, j - 1]), arrayDb[i - 1, j - 1] + cost);
                }
            }

            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cList"></param>
        /// <param name="cWord"></param>
        /// <returns></returns>

        public static int DamerauLevenshtein(string s, string t)
        {
            int len1 = s.Length;
            int len2 = t.Length;
            var ArrayD = new int[len1 + 1, len2 + 1];
            for (int i = 0; i <= len1; i++) ArrayD[i, 0] = i;
            for (int i = 0; i <= len2; i++) ArrayD[0, i] = i;
            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    int cost = s[i - 1] == t[j - 1] ? 0 : 1;
                    ArrayD[i, j] = Math.Min(Math.Min(ArrayD[i - 1, j] + 1, ArrayD[i, j - 1] + 1), ArrayD[i - 1, j - 1] + cost);

                    if (i > 1 && j > 1 && s[i - 1] == t[j - 2] && s[i - 2] == t[j - 1])
                    {
                        ArrayD[i, j] = Math.Min(ArrayD[i, j], ArrayD[i - 2, j - 2] + cost);

                    }
                }
            }

            return ArrayD[s.Length, t.Length];
        }

    }
}
