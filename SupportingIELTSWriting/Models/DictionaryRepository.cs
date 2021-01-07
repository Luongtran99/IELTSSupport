using SupportingIELTSWriting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private DictionaryDbContext context;
        public DictionaryRepository(DictionaryDbContext ct)
        {
            this.context = ct;
        }
        public void addWord(string word, string popularity)
        {
            throw new NotImplementedException();
        }

        public int count()
        {
            throw new NotImplementedException();
        }

        public void deleteWord(string word)
        {
            throw new NotImplementedException();
        }

        public Word GetWord(string word)
        {
            throw new NotImplementedException();
        }

        public bool isSaved()
        {
            throw new NotImplementedException();
        }

        public Word updateWord(Word word)
        {
            throw new NotImplementedException();
        }
    }
}
