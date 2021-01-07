using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Models.Entities;
using SupportingIELTSWriting.Models.ResponseModel;

namespace SupportingIELTSWriting.Services
{
    public class EssayServices : IEssayServices
    {
        private DictionaryDbContext context;
        private IHistoryServices services;
        public EssayServices(DictionaryDbContext ct, IHistoryServices sv)
        {
            context = ct;
            services = sv;
        }

        public async Task<bool> CreateEssayAsync(Essay essay)
        {
            await context.Essays.AddAsync(essay);
            var created = await context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteEssayByIdAsync(string id)
        {
            var essay = await GetEssayByIdAsync(id);

            if (essay == null)
            {
                return false;
            }

            context.Essays.Remove(essay);

            var deleted = await context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> EditEssayAsync(Essay essay)
        {

            context.Essays.Update(essay);
            var updated = await context.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<Essay> GetEssayByIdAsync(string postid)
        {
            var essay = await context.Essays.SingleOrDefaultAsync(p => p.Id == postid);

            if(essay == null)
            {
                return null;
            }

            return essay;
        }

        public async Task<List<Essay>> GetEssaysAsync(string userId)
        {
            var essayList = await context.Essays.Where(p => p.userId == userId || p.userId == null).ToListAsync();

            if(essayList == null)
            {
                return null;
            }


            return essayList;
        }

        public async Task<List<History>> GetHistoriesByEssayIdAsync(string essayId)
        {
            var x = await services.GetHistoriesByEssayIdAsync(essayId);

            if(x == null)
            {
                return null;
            }

            return x;
        }

        public async Task<bool> UserOwnEssayAsync(string essayId, string v)
        {
            var essay = await context.Essays.AsNoTracking().SingleOrDefaultAsync(p => p.Id == essayId);

            if(essay == null)
            {
                return false;
            }

            if(essay.userId != v)
            {
                return false;
            }

            return true;    
        }
    }
}
