using SupportingIELTSWriting.Infrastructure.TernarySearchTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public interface ITernarySearchTreeRepository
    {
        TSTNode TSTRoot { get; }

        bool AddWord(string wrd);

        bool DeleteWord(string wrd);

        bool Search(string word);
        string getPopularity(string word);

        List<Word> SpWordList(string word);

        Tree Tree { get; }
    }
}
