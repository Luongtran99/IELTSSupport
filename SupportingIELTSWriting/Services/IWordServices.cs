using SupportingIELTSWriting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public interface IWordServices : IServices
    {
        Word GetWord(string word); 
        void addWord(string word, string popularRating);
        Task AddWordAsync(Word word);
        void deleteWord(string word);
        Word updateWord(Word word);
        bool Exist(string word);
        int Count();
        bool isSaved();
    }
}
