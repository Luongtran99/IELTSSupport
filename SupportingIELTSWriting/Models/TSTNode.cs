using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class TSTNode
    {
        private string nGramWord;

        private char splitChar;

        private bool isEndOfWord;

        private object value;

        private TSTNode leftNode, middleNode, rightNode;

        public TSTNode(char _splitChar)
        {
            splitChar = _splitChar;
            nGramWord = null;
            isEndOfWord = false;
            leftNode = null;
            middleNode = null;
            rightNode = null;
            value = null;
        }


        public TSTNode LeftNode
        {
            set
            {
                this.leftNode = value;
            }
            get
            {
                return this.leftNode;
            }
        }

        public TSTNode MiddleNode
        {
            set
            {
                this.middleNode = value;
            }
            get
            {
                return this.middleNode;
            }
        }

        public TSTNode RightNode
        {
            set
            {
                this.rightNode = value;
            }
            get
            {
                return this.rightNode;
            }
        }

        public char SplitChar
        {
            set
            {
                this.splitChar = value;
            }
            get
            {
                return this.splitChar;
            }
        }

        public bool IsEndOfWord
        {
            set
            {
                this.isEndOfWord = value;
            }
            get
            {
                return this.isEndOfWord;
            }
        }

        public string NGramWord
        {
            get
            {
                return this.nGramWord;
            }
            set
            {
                this.nGramWord = value;
            }
        }
    }
}
