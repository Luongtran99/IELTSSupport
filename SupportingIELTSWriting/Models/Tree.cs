using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class Tree
    {
        private int countNodes;

        private int usedMemory;

        private int maxDeep;

        private int countWords;

        public int CountNodes
        {
            get
            {
                return countNodes;
            }
            set
            {
                this.countNodes = value;
            }
        }

        public int MaxDeep
        {
            get
            {
                return maxDeep;
            }
            set
            {
                this.maxDeep = value;
            }
        }

        public int CountWords
        {
            get
            {
                return countWords;
            }
            set
            {

                this.countWords = value;
            }
        }

        public int UsedMemory
        {
            get
            {
                return this.usedMemory;
            }
            set
            {
                this.usedMemory = value;
            }
        }
        public bool CheckValue()
        {
            // check countword


            // 
            return false;
        }
    }
}
