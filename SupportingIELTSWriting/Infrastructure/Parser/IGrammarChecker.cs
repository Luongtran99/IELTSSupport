using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Infrastructure.Parser
{
    public interface IGrammarChecker
    {
        Task<List<EssayErrors>> CheckSentenceAsync(string sentence);
        

    }
}
