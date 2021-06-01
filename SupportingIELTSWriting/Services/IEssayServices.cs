using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportingIELTSWriting.Models.Entities;

namespace SupportingIELTSWriting.Services
{
    public interface IEssayServices
    {
        Task<List<Essay>> getAllEssays(int essayPage);
        Task<List<Essay>> GetEssaysAsync(string userId);
        Task<bool> CreateEssayAsync(Essay essay);
        Task<Essay> GetEssayByIdAsync(string postid);
        Task<bool> DeleteEssayByIdAsync(string id);
        Task<bool> UserOwnEssayAsync(string id, string v);
        Task<bool> EditEssayAsync(Essay essay);
        Task<List<History>> GetHistoriesByEssayIdAsync(string essayId);
    }
}
