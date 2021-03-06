﻿using System;
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
        int noOfPage = 0;
        public EssayServices(DictionaryDbContext ct, IHistoryServices sv)
        {
            context = ct;
            services = sv;
            noOfPage = (int)context.Essays.Count() / 10 + 1;
        }

        public async Task<List<Essay>> getAllEssays(int essayPage)
        {
            int pageSize = 10;

            if(essayPage < 0  || essayPage > noOfPage)
            {
                return null;
            }

            List<Essay> x = new List<Essay>();


            x = await context.Essays.OrderBy(p => p.Id).ToListAsync();


            if (x == null)
            {
                return null;
            }

            return x;

        }

        public async Task<bool> CreateEssayAsync(Essay essay)
        {
            await context.Essays.AddAsync(essay);
            var created = await context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteEssayByIdAsync(string id)
        {

            // check 
            var history = new History { essayId = id };

            List<History> x = context.Histories.Where(p => p.essayId == id).ToList();

            foreach( var i in x)
            {
                context.Histories.Remove(i);
                context.SaveChanges();
            }

            // remove in history
            //context.Histories.RemoveRange(history);
            //context.SaveChanges();
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

        // user get their essays

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

        public async Task<bool> UserOwnEssayAsync(string essayId, string currentUser)
        {

            var essay = await context.Essays.AsNoTracking().SingleOrDefaultAsync(p => p.Id == essayId);

            if(essay == null)
            {
                return false;
            }

            if(essay.userId == null)
            {
                return true;
            }

            if(essay.userId != currentUser)
            {
                return false;
            }

            return true;    
        }
    }
}
