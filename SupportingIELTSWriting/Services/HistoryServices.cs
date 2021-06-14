using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Models.Entities;

namespace SupportingIELTSWriting.Services
{
    public class HistoryServices : IHistoryServices
    {
        private DictionaryDbContext dbContext;
        public HistoryServices(DictionaryDbContext ct)
        {
            dbContext = ct;
        }
        public async Task<List<History>> GetHistoriesByEssayIdAsync(string essayId)
        {
            var histories = await dbContext.Histories.Where(p => p.essayId == essayId).ToListAsync();

            if(histories == null)
            {
                return null;
            }

            return histories;
        }

        public async Task<bool> Create(History history)
        {
            try
            {
                await dbContext.Histories.AddAsync(history);

                var x = await dbContext.SaveChangesAsync();

                return x > 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(string historyId)
        {
            var history = await dbContext.Histories.FirstOrDefaultAsync(p => p.id == historyId);

            if(history == null)
            {
                return false;
            }

            dbContext.Histories.Remove(history);

            var x = await dbContext.SaveChangesAsync();

            return x > 0;
        }
    }
}
