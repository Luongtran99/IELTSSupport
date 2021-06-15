using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Infrastructure.SymSpell;
using System.Collections;
using SupportingIELTSWriting.Infrastructure.JsonResult;
using System.Threading;
using SupportingIELTSWriting.Services;

namespace SupportingIELTSWriting.Infrastructure.TernarySearchTree
{
    // Ternary Search Tree data structure will be created once time when the program is under way
    public class TernarySearchTree : ITernarySearchTreeRepository
    {
        public TSTNode treeRoot;

        private readonly Tree tree;

        private Dictionary<string, string> ngramDictionary;

        const char[] defaultCharacters = (char[])null;

        // auto load dictionary when create 
        public TernarySearchTree()
        {
            treeRoot = new TSTNode('t');
            ngramDictionary = new Dictionary<string, string>();
            tree = new Tree();
            LoadDictionary(); // create 
        }
        public TSTNode TreeRoot
        {
            get
            {
                return treeRoot;
            }
            set
            {
                this.treeRoot = value;
            }
        }
        public Dictionary<string, string> NGramDictionary
        {
            get
            {
                return ngramDictionary;
            }
            set
            {
                this.ngramDictionary = value;
            }
        }
        /// <summary>
        /// Load dictionary to Ternary Search Tree
        /// </summary>
        public bool LoadDictionary()
        {
            string path = "E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_dictionary_en_82_765.txt";
            string lineVal = null;

            using (StreamReader reader = new StreamReader(path))
            {

                if (reader == null)
                {
                    throw new Exception("Your dictionary file is missed");
                }

                while ((lineVal = reader.ReadLine()) != null)
                {
                    string[] lineParts = lineVal.Split(defaultCharacters);

                    AddNode(treeRoot, lineParts[0], lineParts[1], 0, null);

                }
            }

            return true;
        }

        /// <summary>
        /// Load Ngram dictionary to data structure
        /// </summary>
        /// <returns></returns>
        //public bool LoadNGramDictionary()
        //{
        //    string path = "E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_bigramdictionary_en_243_342.txt";
        //    // Separate number and string 


        //    return true;
        //}

        /// <summary>
        ///   // Add Node when create Tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="currentWord"></param>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static TSTNode AddNode(TSTNode root, string currentWord, string popularRate, int pos, object value)
        {

            if (root == null)
            {
                root = new TSTNode(currentWord[0]);
                root.SplitChar = currentWord[pos];
            }

            if (currentWord[pos] < root.SplitChar)
            {
                //root.nodePosition = NodePosition.Left;
                root.LeftNode = AddNode(root.LeftNode, currentWord, popularRate, pos, value);
                //root.leftNode.parentNode = root;
            }
            else if (currentWord[pos] == root.SplitChar)
            {
                if (pos < currentWord.Length - 1)
                {
                    //root.nodePosition = NodePosition.Middle;
                    root.MiddleNode = AddNode(root.MiddleNode, currentWord, popularRate, ++pos, value);
                    //root.middleNode.parentNode = root;
                }
                else
                {
                    root.IsEndOfWord = true;
                    root.NGramWord = popularRate;
                }
            }

            else
            {
                //root.nodePosition = NodePosition.Right;
                root.RightNode = AddNode(root.RightNode, currentWord, popularRate, pos, value);
                //root.rightNode.parentNode = root;
            }

            return root;
        }


        /// <summary>
        /// Search Word in tree
        /// </summary>
        /// <param name="word">Needed Word</param>
        /// <returns></returns>
        public bool SearchWord(string word)
        {
            if (word == null || word == "")
            {
                throw new ArgumentException("Word is incorrect formart string");
            }

            int pos = 0;

            TSTNode _root = treeRoot;

            while (_root != null)
            {
                if (word[pos] < _root.SplitChar)
                {
                    _root = _root.LeftNode;
                }
                else if (word[pos] > _root.SplitChar)
                {
                    _root = _root.RightNode;
                }
                else
                {
                    if (++pos == word.Length)
                    {
                        return _root.IsEndOfWord;
                    }
                    _root = _root.MiddleNode;
                }
            }

            return false;
        }

        public bool AddWord(string wrd)
        {
            string message = "";

            if (wrd == "")
            {
                message = "Input can not be null";
                return false;

            }

            // call Add word
            AddNode(treeRoot, wrd, "", 0, null);

            return false;
        }

        public bool DeleteWord(string wrd)
        {
            // check word 
            if (Search(wrd) == true)
            {
                if (wrd == null || wrd == "")
                {
                    throw new ArgumentNullException("Can not be null!");
                }
                TSTNode root = treeRoot;

                int pos = 0;

                while (root != null)
                {
                    if (wrd[pos] < root.SplitChar)
                    {
                        root = root.LeftNode;
                    }
                    else if (wrd[pos] > root.SplitChar)
                    {
                        root = root.RightNode;
                    }
                    else
                    {
                        if (++pos == wrd.Length)
                        {
                            root.IsEndOfWord = false;
                            return true;
                        }
                        root = root.MiddleNode;
                    }
                }
            }
            else
            {
                return false;
            }
            //
            return false;
        }

        public bool Search(string word)
        {
            if (word == null || word == "")
            {
                return false;
            }

            int pos = 0;

            TSTNode _root = treeRoot;

            while (_root != null)
            {
                if (word[pos] < _root.SplitChar)
                {
                    _root = _root.LeftNode;
                }

                else if (word[pos] > _root.SplitChar)
                {
                    _root = _root.RightNode;
                }
                else
                {
                    if (++pos == word.Length)
                    {
                        return _root.IsEndOfWord;
                    }
                    _root = _root.MiddleNode;
                }
            }
            return false;
        }

        public string convertStackToString(Stack cList)
        {
            string convertListToStr = null;

            foreach (var ch in cList)
            {
                convertListToStr = ch + convertListToStr;
            }

            return convertListToStr;
        }

        public Stack spChar = new Stack();
        public string search = "";
        public List<Word> spList;
        public List<Word> SpWordList(string wSearch)
        {
            if(wSearch == "" || wSearch == null)
            {
                return null;
            }
            search = wSearch.Trim();

            spList = new List<Word>();
            // get sp word list
            spWord(treeRoot);

            if (spList.Count > 10)
            {
                // sort List
                spList.Sort(delegate (Word x, Word y)
                {
                    var lenx = x.popularCount.Length;
                    var leny = y.popularCount.Length;
                    if (lenx > leny)
                        y.popularCount = y.popularCount.PadLeft(lenx, '0');
                    else if (lenx < leny)
                        x.popularCount = x.popularCount.PadLeft(leny, '0');

                    for (int i = 0; i < lenx; i++)
                    {
                        if (x.popularCount[i] < y.popularCount[i]) return 1;
                        if (x.popularCount[i] > y.popularCount[i]) return -1;
                    }

                    return 0;
                });

                List<Word> bufList = new List<Word>();
                for (int i = 0; i < 10; i++)
                {
                    bufList.Add(spList[i]);
                }
                return bufList;
            }
            else
            {
                return spList;
            }
        }


        // get 
        public TSTNode spWord(TSTNode cNode)
        {
            // step1:
            spChar.Push(cNode.SplitChar);

            // step2:
            if (cNode.IsEndOfWord)
            {
                string addedWord = convertStackToString(spChar);

                int distance = Leveinshein.DamerauLevenshtein(addedWord, search);

                if (distance < 2)
                {
                    spList.Add(new Word
                    {
                        word = addedWord,
                        popularCount = cNode.NGramWord
                    });
                    //spList.Add(GetMeanWordAPI.Value(addedWord, cNode.NGramWord));
                }

            }


            if (cNode.MiddleNode != null)
            {
                spWord(cNode.MiddleNode);
            }
            if (cNode.LeftNode != null && cNode.RightNode != null)
            {
                char bufChar = (char)spChar.Pop();
                spWord(cNode.LeftNode);
                spWord(cNode.RightNode);
                spChar.Push(bufChar);
            }
            else
            {
                if (cNode.LeftNode == null && cNode.RightNode != null)
                {
                    char bufChar = (char)spChar.Pop();
                    spWord(cNode.RightNode);
                    spChar.Push(bufChar);
                }

                if (cNode.RightNode == null && cNode.LeftNode != null)
                {
                    char bufChar = (char)spChar.Pop();
                    spWord(cNode.LeftNode);
                    spChar.Push(bufChar);
                }
            }

            spChar.Pop();
            return null;
        }

        public string getPopularity(string word)
        {
            if (word == null || word == "")
            {
                throw new ArgumentException();
            }

            int pos = 0;

            TSTNode _root = treeRoot;

            string bufP = "";

            while (_root != null)
            {
                if (word[pos] < _root.SplitChar)
                {
                    _root = _root.LeftNode;
                }

                else if (word[pos] > _root.SplitChar)
                {
                    _root = _root.RightNode;
                }
                else
                {
                    if (++pos == word.Length)
                    {
                        bufP = _root.NGramWord;
                        break;
                    }
                    _root = _root.MiddleNode;
                }
            }

            return bufP;

        }

        public TSTNode TSTRoot => treeRoot;

        Tree ITernarySearchTreeRepository.Tree => tree;
    }
}
