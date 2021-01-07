using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public interface IDictionaryRepository
    {
        Word GetWord(string word);
        void addWord(string word, string popularity);
        void deleteWord(string word);
        Word updateWord(Word word);
        int count();
        bool isSaved();
    }
}
