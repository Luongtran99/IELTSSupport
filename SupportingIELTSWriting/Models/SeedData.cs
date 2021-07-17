using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Models
{
    public class SeedData
    {

        public const char[] defaultCharacters = (char[])null;

        public static async void EnsurePopulatedAsync(IApplicationBuilder app)
        {
            DictionaryDbContext context = app.ApplicationServices.GetRequiredService<DictionaryDbContext>();
            context.Database.Migrate();
            
            string path = "E:/Lớp học/Project I/SourceCode/SymSpell-master/SymSpell-master/SymSpell/frequency_dictionary_en_82_765_2.txt";
            string lineVal = null;

            List<Word> bufWord = new List<Word>();
            using (StreamReader reader = new StreamReader(path))
            {

                if (reader == null)
                {
                    throw new Exception("Your dictionary file is missed");
                }

                while ((lineVal = reader.ReadLine()) != null)
                {
                    string[] lineParts = lineVal.Split(defaultCharacters);
                    //if(lineParts == null)
                    //{
                    //    continue;
                    //}
                    //else
                    //{
                        context.Words.Add(await GetMeanWordAPI.ValueAsync(lineParts[0], lineParts[1]));

                        await context.SaveChangesAsync();

                    lineVal = null;
                    //}
                   
                }
            }
        }    
    }
}
