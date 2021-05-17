using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using Rest;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;



namespace DemoTernarySearchTree
{
    class Program
    {
        public static int MAX_LEAF_NODES = 3;

        const char[] defaultSeparatorChars = (char[])null;
        //public static StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_dictionary_en_82_765.txt");


        public enum NodePosition{
            Left, Middle, Right, Parent
            }
        public class TSTNode
        {
            public char splitChar;
            public bool isEndOfWord;
            public TSTNode leftNode, middleNode, rightNode;
            public TSTNode(char _splitChar)
            {
                splitChar = _splitChar;
                isEndOfWord = false;
                leftNode = null;
                middleNode = null;
                rightNode = null;
            }

            public TSTNode()
            {
                
            }
        }
        // Trie Node
        public class Node
        {
            public char Value { get; set; }
            public List<Node> Children { get; set; }
            public Node Parent { get; set; }
            public int Depth { get; set; }

            public Node(char value, int depth, Node parent)
            {
                Value = value;
                Children = new List<Node>();
                Depth = depth;
                Parent = parent;
            }

            public bool IsLeaf()
            {
                return Children.Count == 0;
            }

            public Node FindChildNode(char c)
            {
                foreach (var child in Children)
                    if (child.Value == c)
                        return child;

                return null;
            }

            public void DeleteChildNode(char c)
            {
                for (var i = 0; i < Children.Count; i++)
                    if (Children[i].Value == c)
                        Children.RemoveAt(i);
            }
        }

        // create Trie
        public class Trie
        {
            private readonly Node _root;

            public Trie()
            {
                _root = new Node('^', 0, null);
            }

            public Node Prefix(string s)
            {
                var currentNode = _root;
                var result = currentNode;

                foreach (var c in s)
                {
                    currentNode = currentNode.FindChildNode(c);
                    if (currentNode == null)
                        break;
                    result = currentNode;
                }

                return result;
            }

            public bool Search(string s)
            {
                var prefix = Prefix(s);
                return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
            }

            public void InsertRange(List<string> items)
            {
                for (int i = 0; i < items.Count; i++)
                    Insert(items[i]);
            }

            public void Insert(string s)
            {
                var commonPrefix = Prefix(s);
                var current = commonPrefix;

                for (var i = current.Depth; i < s.Length; i++)
                {
                    var newNode = new Node(s[i], current.Depth + 1, current);
                    current.Children.Add(newNode);
                    current = newNode;
                }

                current.Children.Add(new Node('$', current.Depth + 1, current));
            }

            public void Delete(string s)
            {
                if (Search(s))
                {
                    var node = Prefix(s).FindChildNode('$');

                    while (node.IsLeaf())
                    {
                        var parent = node.Parent;
                        parent.DeleteChildNode(node.Value);
                        node = parent;
                    }
                }
            }

        }
        public static void CreateTrie(Trie root)
        {
            //StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_dictionary_en_82_765.txt");
            StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/dictionary_en_350_000.txt");

            Stopwatch stopWatch = new Stopwatch();

            string line = null;

            int count = 0;
            stopWatch.Start();
            while ((line = readDictionary.ReadLine()) != null)
            {
                string[] lineParts = line.Split(defaultSeparatorChars);
                //databaseNgram.Add(lineParts[0], long.Parse(lineParts[1]));
                root.Insert(lineParts[0]);
                count++;
            }

            stopWatch.Stop();

            Console.WriteLine("So luong tu da them vao CTDL TRie {0}", count);

            Console.WriteLine("Thời gian thêm {0} vào CTDL Trie là {1}", count, stopWatch.Elapsed.TotalMilliseconds + "ms");
        }
        // preProcessing 
        public static void CreateTST(TSTNode root)
        {
            StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_dictionary_en_82_765.txt");

            //StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_dictionary_en_82_765.txt");
            //StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell.Benchmark/test_data/frequency_dictionary_en_500_000.txt");

            Stopwatch stopWatch = new Stopwatch();

            string line = null;

            int count = 0;
            stopWatch.Start();
            while ((line = readDictionary.ReadLine()) != null)
            {
                string[] lineParts = line.Split(defaultSeparatorChars);
                //databaseNgram.Add(lineParts[0], long.Parse(lineParts[1]));
                AddNode(root, lineParts[0], 0, null); // add the first Array child to root, the second Array Child value is the popular rate 
                count++;
            }

            stopWatch.Stop();

            Console.WriteLine("So luong tu da them vao CTDL TST {0}", count);

            Console.WriteLine("Thời gian thêm {0} vào CTDL TST là {1}",count,  stopWatch.Elapsed.TotalMilliseconds+ "ms");
        }

        public static void AddBigGramDictionary(TSTNode root)
        {
            StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_bigramdictionary_en_243_342.txt");
            string line = null;
            while ((line = readDictionary.ReadLine()) != null)
            {
                string[] lineParts = line.Split(defaultSeparatorChars);
                AddNode(root, lineParts[0], 0, null);
                Console.Write(lineParts[0]);
                AddNode(root, lineParts[1], 0, null);
                Console.Write(lineParts[1]);
                Console.WriteLine("\n");
            }

        }

        public static Dictionary<string, long> databaseNgram = new Dictionary<string, long>(); 
        public static void CreateDictionaryDatabaseNgram()
        {
            // read text
            StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell.Benchmark/test_data/frequency_dictionary_en_500_000.txt");
            string line = null;
            while ((line = readDictionary.ReadLine())  != null){
                string[] lineParts = line.Split(defaultSeparatorChars);
                databaseNgram.Add(lineParts[0], long.Parse(lineParts[1])); // save part line to dictionary
            }



        }

        // process result
        public static long resultAfterProcessing(string param)
        {
            return databaseNgram.FirstOrDefault(p => p.Key == param).Value;
        }

        public static void ProcessWordList(List<string> param)
        {
            Dictionary<string, long> k = new Dictionary<string, long>();
            foreach( var str in param)
            {
                k.Add(str, resultAfterProcessing(str));
            }
            var items = from pair in k
                        orderby pair.Value descending
                        select pair;
            List<long> aList = new List<long>();
            aList = k.Select(p => p.Value).ToList();
            
            // improve list word
            // calculate avarage of list
            foreach(var p in items)
            {
                //if(p.Value > avarage && items.Count() < 10)
                //{
                    Console.WriteLine("{0}, {1}", p.Key, p.Value);
                //}
                
            }

        }
        private static TSTNode AddNode(TSTNode root,  string currentWord, int pos, object value)
        {

            if (root == null)
            {
                root = new TSTNode(currentWord[0]);
                root.splitChar = currentWord[pos];
            }

            if (currentWord[pos] < root.splitChar)
            {
                //root.nodePosition = NodePosition.Left;
                root.leftNode = AddNode(root.leftNode, currentWord, pos, value);
                //root.leftNode.parentNode = root;
            }
            else if (currentWord[pos] == root.splitChar)
            {
                if (pos < currentWord.Length - 1)
                {
                    //root.nodePosition = NodePosition.Middle;
                    root.middleNode = AddNode(root.middleNode, currentWord, ++pos, value);
                    //root.middleNode.parentNode = root;
                }
                else
                {
                    root.isEndOfWord = true;
                }
            }

            else
            {
                //root.nodePosition = NodePosition.Right;
                root.rightNode = AddNode(root.rightNode, currentWord, pos, value);
                //root.rightNode.parentNode = root;
            }
            
            return root;
        }

        // Search to check word spell 
        public static bool Search(TSTNode root, string word)
        {
            if (word == null || word == "")
            {
                throw new ArgumentException();
            }

            int pos = 0;

            TSTNode _root = root;
            
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            while (_root != null)
            {
                if (word[pos] < _root.splitChar)
                {
                    _root = _root.leftNode;

                }

                else if (word[pos] > _root.splitChar)
                {
                    _root = _root.rightNode;
                }
                else
                {
                    if (++pos == word.Length) {
                        stopwatch.Stop();
                        Console.WriteLine("Thoi gian tim kiem {0} ms", stopwatch.Elapsed.TotalMilliseconds );
                        return _root.isEndOfWord; }
                    _root = _root.middleNode;
                }
            }
            stopwatch.Stop();
            Console.WriteLine("Thoi gian tim kiem {0} ms", stopwatch.Elapsed.TotalMilliseconds);

            return false;
        }

        // delete TST node => isEndOfWord = false
        public static void delete(TSTNode root, string word)
        {
            // check word is correct

            // change end of word property to false 

        }

        // SymSpell = fuzzy search ( demarau leveinshein ) + trie
        public int SymSpell(string word)
        {



            return 0;
        }

        public static int Levenshtein(string firstStr, string secondStr)
        {
            //if(firstStr == secondStr)
            //{
            //    return 0;
            //}
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            int length1 = firstStr.Length;

            int length2 = secondStr.Length;

            if(firstStr == null)
            {
                return secondStr.Length;
            }
            if(secondStr == null)
            {
                return firstStr.Length;
            }

            int[,] distance = new int[length1 + 1, length2 + 1];

            for (int i = 0; i <= length1; i++) distance[i, 0] = i;

            for (int i = 0; i <= length2; i++) distance[0, i] = i;

            for(int i = 1; i <= length1; i++)
            {
                for(int j = 1; j <= length2; j++)
                {
                    int cost = (firstStr[i - 1] == secondStr[j - 1]) ? 0 : 1;

                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j -1] + 1), distance[i -1, j-1] + cost);
                    //Console.Write(distance[i, j]);
                }
                //Console.WriteLine("\n");
            }

            //stopwatch.Stop();

            //Console.WriteLine("{0} ", stopwatch.ElapsedMilliseconds, "ms");

            return distance[length1, length2];
        }

        public static int Damerau_Levenshtein_OSA(string s, string t)
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
                    //Console.Write(ArrayD[i, j]);
                }
                //Console.WriteLine("\n");
            }

            return ArrayD[s.Length, t.Length];

        }

        public static string StackCharToString(Stack stack)
        {
            string strFromCharList = null;
            foreach (var str in stack)
            {
                strFromCharList = str + strFromCharList;
            }
            return strFromCharList;
        }

        public static int Damerau_Levenshtein(Stack buffList, string word)
        {
            return Damerau_Levenshtein_OSA(word, StackCharToString(buffList));
        }

        public static Stack spChar = new Stack();
        public static string search;
        public static List<string> approximateWordList = new List<string>();

        public static List<string> searchWord(TSTNode cNode)
        {
            TSTNode currentNode = cNode;
            string searchWord = "";
            Stack spStack = new Stack();
            while(currentNode != null)
            {

            }


            return null;

        }

        public static TSTNode traverseTST(TSTNode currentNode)
        {

            // step 1 : add char to charList

            spChar.Push(currentNode.splitChar);

            // step2 : calculate damerauOSA distance if currentNode is the end of word

            if(currentNode.isEndOfWord)
            {
                string addedWord = StackCharToString(spChar);
                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();
                int countDis = Damerau_Levenshtein_OSA(addedWord, search);

                if (search.Length > 5)
                {
                    if (countDis < 3)
                    {
                        // calculate percent to same
                        //Console.WriteLine("{0} and {1} is {2}",addedWord, search, 1.0 - ((double)countDis / (double)Math.Max(addedWord.Length, search.Length)));
                        approximateWordList.Add(addedWord);
                        //stopwatch.Stop();
                        //Console.WriteLine("Calculate {0} and {1} is {2} ms", addedWord, search, stopwatch.Elapsed.TotalMilliseconds);
                    }
                }
                else
                {
                    if (countDis < 2)
                    {
                        //Console.WriteLine(countDis);
                        //Console.WriteLine("{0} and {1} is {2}", addedWord, search, 1.0 - ((double)countDis / (double)Math.Max(addedWord.Length, search.Length)));
                        approximateWordList.Add(addedWord);
                        //stopwatch.Stop();
                        //Console.WriteLine("Calculate {0} and {1} is {2} ms", addedWord, search, stopwatch.Elapsed.TotalMilliseconds);
                    }
                }
                //stopwatch.Stop();
                //if (countDis < 2)
                //{
                //    //Console.Write(countDis);
                //    approximateWordList.Add(addedWord);
                //}
            }

            

            if (currentNode.middleNode != null)
            {
                traverseTST(currentNode.middleNode);
            }

            if (currentNode.rightNode != null && currentNode.leftNode != null)
            {
                char buffChar = (char)spChar.Pop();
                traverseTST(currentNode.leftNode);
                traverseTST(currentNode.rightNode);
                spChar.Push(buffChar);
            }
            else
            {
                if (currentNode.rightNode != null && currentNode.leftNode == null)
                {
                    char buffChar = (char)spChar.Pop();
                    traverseTST(currentNode.rightNode);
                    spChar.Push(buffChar);
                }

                if (currentNode.leftNode != null && currentNode.rightNode == null)
                {
                    char buffChar = (char)spChar.Pop();
                    traverseTST(currentNode.leftNode);
                    spChar.Push(buffChar);
                }
            }
            

            //approximateWordList.Add(spChar.ToString());
            spChar.Pop();
            return null;
        }


        // TST + Leveinshtein
        public static void LookUp(TSTNode root, string word, int currentRow)
        {
            // properties
            TSTNode currentNode = root;
            int _len = word.Length;
            int _currentRow = currentRow + 1;
            search = word;

            List<char> charList = new List<char>();
            List<int> firstIndexList = new List<int>();
            List<int> secondIndexList = new List<int>();
            List<List<int>> MatixIndexList = new List<List<int>>();
            List<string> supportWord = new List<string>();

            for(int i = 0; i <= _len; i++)
            {
                firstIndexList.Add(i);
            }


            MatixIndexList.Add(firstIndexList);

            // process
            while (currentNode != null)
            {
                charList.Add(currentNode.splitChar);
                /*
                 * - Add char to charList
                 * - Calculate distance root.splitChar and 
                 * - Check isEndOfWord
                 * - if middle != null then root = root.middle 
                 * - Trarverse from left to right arrayChar.length - 1, 
                 * 
                 */


                // calculate Levenshtein distance
                int count = 0;
                // check countDistance
                if(count < 2)
                {
                    if(count == 0)
                    {
                        supportWord.Clear();
                        supportWord.Add(charList.ToString());
                        break;
                    }
                    else
                    {
                        supportWord.Add(charList.ToString());
                        continue;
                    }

                }
                
                break;
            }
        }

        // two conditions to check : isEndOfWord and count <= 2
        // Text + Leveishtein 
        public static List<string> SupportWord(string word)
        {
            long memSize = GC.GetTotalMemory(true);
            Stopwatch stopwatch = new Stopwatch();

            List<string> supportWordList = new List<string>();
            List<string> wordList = new List<string>();
            StreamReader readDictionary = new StreamReader("E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_dictionary_en_82_765.txt");
            int countDis = 0;
            string line = "";
            stopwatch.Start();
            
            while ((line = readDictionary.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                string[] lineParts = line.Split(defaultSeparatorChars);
                //Console.WriteLine(lineParts[0]);
                wordList.Add(lineParts[0]);
                
            }
            stopwatch.Stop();
            Console.WriteLine("thoi gian luu toan bo tu vung vao RAM la {0} ms", stopwatch.Elapsed.TotalMilliseconds);
            long memDelta = GC.GetTotalMemory(true) - memSize;
            Console.WriteLine("dung luong bo nho su dung cho luu vao RAM la {0}", (memDelta / 1024.0 / 1024.0).ToString("N1") + "MB ");

            Console.WriteLine(wordList.Contains("fol"));
            stopwatch.Start();
            foreach (var eachWrd in wordList.ToList())
            {

                countDis = Damerau_Levenshtein_OSA(eachWrd, word);

                //if(countDis < 2)
                //{
                //    supportWordList.Add(eachWrd);
                //}            
                if (word.Length > 5)
                {
                    if (countDis < 3)
                    {
                        // calculate percent to same
                        //Console.WriteLine("{0} and {1} is {2}",addedWord, search, 1.0 - ((double)countDis / (double)Math.Max(addedWord.Length, search.Length)));
                        supportWordList.Add(eachWrd);
                        //stopwatch.Stop();
                        //Console.WriteLine("Calculate {0} and {1} is {2} ms", addedWord, search, stopwatch.Elapsed.TotalMilliseconds);
                    }
                }
                else
                {
                    if (countDis < 2)
                    {
                        //Console.WriteLine(countDis);
                        //Console.WriteLine("{0} and {1} is {2}", addedWord, search, 1.0 - ((double)countDis / (double)Math.Max(addedWord.Length, search.Length)));
                        supportWordList.Add(eachWrd);
                        //stopwatch.Stop();
                        //Console.WriteLine("Calculate {0} and {1} is {2} ms", addedWord, search, stopwatch.Elapsed.TotalMilliseconds);
                    }
                }
            }

            stopwatch.Stop();

            Console.WriteLine("thoi gian tim tu gan dung bang cach dung Hash la {0} ms", stopwatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("{0} words", supportWordList.Count);

            foreach(string eachWrd in supportWordList)
            {
                Console.WriteLine(eachWrd);
            }


            // search word
            stopwatch.Start();
            foreach (string eachWrd in wordList)
            {
                if(eachWrd == "halh")
                {
                    break;
                }
            }
            stopwatch.Stop();

            Console.WriteLine("thoi gian tim tu su dung Hash la {0} ms", stopwatch.Elapsed.TotalMilliseconds);

            return supportWordList;
        }

        /*private static string filePythonExePath = Properties.Settings.Default.FilePythonExePath;
        private static string folderImagePath = Properties.Settings.Default.FolderImagePath;
        private static string filePythonNamePath = Properties.Settings.Default.FilePythonNamePath;
        private static string filePythonParameterName = Properties.Settings.Default.FilePythonParameterName;*/


        //public static async Task RunAsync()
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("https://books.google.com/ngrams/json?content=Churchill&year_start=2000&year_end=2019&corpus=26&smoothing=2");
        //    client.DefaultRequestHeaders.Accept.Clear();

        //    client.DefaultRequestHeaders.Accept.Add(
        //        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //    HttpResponseMessage response = await client.GetAsync("https://books.google.com/ngrams/json?content=Churchill&year_start=2000&year_end=2019&corpus=26&smoothing=2").Result;
        //    Console.WriteLine(response.Content.ReadAsStringAsync());

        //}

        // 
        public static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //char cRoot = 't';
            //TSTNode root = new TSTNode(cRoot);

            //AddNode(root, "tham", 0, null);
            //AddNode(root, "thì", 0, null);
            //AddNode(root, "a", 0, null); // problem is can not create leftNode and rightNode
            //AddNode(root, "an", 0, null);
            //AddNode(root, "am", 0, null);
            //AddNode(root, "hiểu", 0, null);
            //AddNode(root, "ói", 0, null);

            //char[] splitChar =
            //{
            //    'a','á','ạ','à','ã','ả',
            //    'â','ầ','ấ','ẫ','ậ','ẩ'
            //};

            //foreach(var c in splitChar)
            //{
            //    Console.WriteLine((int)c);
            //}
            //Program.AddBigGramDictionary(root);

            /*long memSize = GC.GetTotalMemory(true);

            long memDelta = GC.GetTotalMemory(true) - memSize;
            Console.WriteLine("dung luong bo nho su dung cho TST la {0}", (memDelta / 1024.0 / 1024.0).ToString("N1") + "MB ");

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();


            Trie trieNode = new Trie();
            memSize = GC.GetTotalMemory(true);
            Program.CreateTrie(trieNode);
            memDelta = GC.GetTotalMemory(true) - memSize;
            Console.WriteLine("dung luong bo nho su dung cho Trie la {0}", (memDelta / 1024.0 / 1024.0).ToString("N1") + "MB ");

            SupportWord("spentaclar");
            memDelta = GC.GetTotalMemory(true) - memSize;
            Console.WriteLine("dung luong bo nho su dung cho luu vao RAM la {0}", (memDelta / 1024.0 / 1024.0).ToString("N1") + "MB ");




            memSize = GC.GetTotalMemory(true);
            Program.CreateTST(root);
            stopwatch.Stop();
            //stopwatch = null;
            search = "spectacular";
            ////Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            traverseTST(root);
            stopwatch.Stop();
            Console.WriteLine("Thoi gian de tim tu gan giong voi tu \" {0} \" bang cach ket hop TST va DL la {1} ms", search, stopwatch.Elapsed.TotalMilliseconds);

            memDelta = GC.GetTotalMemory(true) - memSize;
            Console.WriteLine("dung luong bo nho su dung cho TST la {0}", (memDelta / 1024.0 / 1024.0).ToString("N1") + "MB ");
            SupportWord("spectacular");

            //Search(root, "halh");


            Console.WriteLine("Danh sach tu ");
            ////CreateDictionaryDatabaseNgram();
            //ProcessWordList(approximateWordList);
            foreach (string word in approximateWordList)
            {
            Console.Write("\"{0}\" + {1},", word, resultAfterProcessing(word));
            }
            

            string data = "https://lex-audio.useremarkable.com/mp3/hello_us_1_rr.mp3";

            Regex regex = new Regex(@"\/", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            MatchCollection collection = regex.Matches(data);

            string[] le = data.Split('/');
            //int len = data.Split('/').Length;
            Console.WriteLine(le[le.Length - 1]);
            Console.WriteLine($"{Directory.GetCurrentDirectory()}{@"\wwwroot\images"}");
            WebClient client = new WebClient();
            string imgpath = @"E:\download\hello_us_1_rr.mp3";
            //byte[] data = client.DownloadData("https://fbcdn-sphotos-h-a.akamaihd.net/hphotos-ak-xpf1/v/t34.0-12/10555140_10201501435212873_1318258071_n.jpg?oh=97ebc03895b7acee9aebbde7d6b002bf&oe=53C9ABB0&__gda__=1405685729_110e04e71d9");
            client.DownloadFile(data, $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\"}{le[le.Length - 1]}");
*/
            //byte[] imageBytes = System.IO.File.ReadAllBytes(imgpath);
            //string base64str = Convert.ToBase64String(imageBytes);
            //Console.WriteLine(base64str);


            /*var bytes = Convert.FromBase64String(base64str);
            //using (var imageFile = new FileStream(@"E:\Video\coco.jpg", FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
            /*
            string remoteUri = "http://www.contoso.com/library/homepage/images/";
            string fileName = "ms-banner.gif", myStringWebResource = null;
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, fileName);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);*/
            //Console.WriteLine(Damerau_Levenshtein_OSA("cat", "what"));
            //RunAsync();





            //Predicate<LocalDataStoreSlot> predicate = new Predicate<>();

            //StreamReader reader = new StreamReader("E:/Lớp học/Project I/SourceCode/Dictionary.txt");
            //string line = null;

            //int count = 0;
            //while((line = reader.ReadLine()) != null)
            //{
            //    Console.WriteLine(line);
            //    if(count++ == 50)
            //    {
            //        break;
            //    }
            //}


            // Read Dictionary Text and save to root


            // Program.SupportWord("thew");

            //Program.LookUp(root, "time", 0);

            //Console.Write($"Nhập vào từ bạn muốn tìm kiếm: ");
            //string needWrd = Console.ReadLine();
            //if(Search(root, needWrd))
            //{
            //    Console.WriteLine($"Có tồn tại");
            //}
            //else
            //{
            //    Console.WriteLine($"Không tồn tại");
            //}

            //string f1 = "tham";
            //string s2 = "the";

            //int count = s2.Length - f1.Length + 1;
            //Console.WriteLine(Levenshtein(s2, f1));
            ////Console.WriteLine(Distance_OSA(s2, f1));
            //Console.WriteLine(Damerau_Levenshtein_OSA(s2, f1));


            // setup grammar checker 











            Console.ReadLine();
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
        public class Phonetic
        {
            private string text;
            public string Text
            {
                get
                {
                    return text;
                }
                set { text = value; }
            }
            private string audio;
            public string Audio
            {
                get { return audio; }
                set { audio = value; }
            }
        }
        public class Definitions
        {
            //private string definition;
            public string definition
            {
                get;
                set;
            }
            public string example
            {
                get;
                set;
            }
            public IList<string> synonyms
            {
                get;
                set;
            }
        }
        public class Meaning
        {
            public string partOfSpeech
            {
                get;
                set;
            }
            public IList<Definitions> definitions
            {
                get;
                set;
            }
        }
        public class Word
        {
            public string word
            {
                get;
                set;
            }
            public IList<Phonetic> phonetics
            {
                get;
                set;
            }
            public IList<Meaning> meanings
            {
                get;
                set;
            }
        }
        private static async Task RunAsync()
        {
            //var x = await GetWordAsync();
            //string url = "https://api.dictionaryapi.dev/api/v2/entries/en/hello";
            //HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //string jsonVar = "";
            //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //{
            //    StreamReader reader = new StreamReader(response.GetResponseStream());
            //    jsonVar = reader.ReadToEnd();
            //}

            //List<Word> l = JsonConvert.DeserializeObject<List<Word>>(jsonVar);
            //Word s = new Word();
            //foreach(var x in l)
            //{
            //    s.word = x.word;
            //    s.meanings = x.meanings;
            //    s.phonetics = x.phonetics;
            //}
            //Console.WriteLine(s.meanings.Count);
            HttpClient client = new HttpClient();
            var resp = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://api.dictionaryapi.dev/api/v2/entries/en/microsoft"));

            HttpResponseMessage response = resp;
            
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                Word wrd = new Word();
                wrd.word = "microsoft";
                Console.WriteLine(wrd.word);
            }
            else
            {
            HttpContent content = response.Content;
            var json = content.ReadAsStringAsync().Result;

            List<Word> list = JsonConvert.DeserializeObject<List<Word>>(json);

            Console.WriteLine(list[0]);
            }

        }
    }
}
