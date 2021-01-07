using SupportingIELTSWriting.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public interface IHistoryServices
    {
        Task<bool> Create(History history);
        Task<bool> Delete(string historyId);
        Task<List<History>> GetHistoriesByEssayIdAsync(string essayId);
    }
}
