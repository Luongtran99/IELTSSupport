using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SupportingIELTSWriting.Data;
using SupportingIELTSWriting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Services
{
    public class WordServices : IWordServices
    {
        public readonly DictionaryDbContext context;
        public WordServices(DictionaryDbContext ct)
        {
            this.context = ct;
        }
        public void addWord(string word, string popularRating)
        {
            if(word == null || word == "")
            {
                var message = "";
            }
            else
            {
                // check word is existed
                if (!Exist(word))
                {
                    var _word = GetMeanWordAPI.ValueAsync(word, popularRating);
                
                    //context.Words.Add(_word);
                }

            }
        }

        public async Task AddWordAsync(Word word)
        {
            if (word == null )
            {
                var message = "";
            }
            else
            {
                context.Words.Add(word);
                await context.SaveChangesAsync();
            }
        }

        public int Count()
        {
            return this.context.Words.Count();
        }

        public void deleteWord(string word)
        {
            if(word == null || word == "")
            {
                context.Words.Remove(null);
            }
            else
            {
                var _word = GetWord(word);
                var x = context.Words.Remove(_word);

            }
        }

        public bool Exist(string word)
        {
            //var x = context.Words.FirstOrDefault(p => p.word == word);
            var x = (from ep in context.Words
                     //join e in context.Meanings on ep.wordId equals e.wordId
                     join q in context.Phonetics on ep.wordId equals q.wordId
                     //join t in context.Definitions on e.meaningId equals t.meaningId
                     where ep.word == word
                     select new Phonetic
                     {
                         audio =q.audio,
                         text = q.text
                     }).ToList();
            //var x = context.Words.Where(p => p.word == word);
            // var x = context.Words.
            //var result = context.Words.Where(p => p.word == word).Join(context.Meanings.Where(p => p.wordId));
            if (x.Count != 0)
            {
                return true;
            }
            else
            {
                // insert new word to 
                return false;
            }
        }

        public Word GetWord(string word)
        {
            if(word == null || word == "" || Exist(word) == false)
            {
                return null;
            }
            else
            {
                // get meaning
                Word ne = new Word
                {
                    word = word,
                    phonetics = (from ep in context.Words
                                     //join e in context.Meanings on ep.wordId equals e.wordId
                                 join q in context.Phonetics on ep.wordId equals q.wordId
                                 //join t in context.Definitions on e.meaningId equals t.meaningId
                                 where ep.word == word
                                 select new Phonetic
                                 {
                                     audio = q.audio,
                                     text = q.text,

                                 }).ToList(),
                    meanings = (from ep in context.Words
                                join e in context.Meanings on ep.wordId equals e.wordId
                                //join q in context.Phonetics on ep.wordId equals q.wordId
                                // join t in context.Definitions on e.meaningId equals t.meaningId
                                where ep.word == word
                                select new Meaning
                                {
                                    partOfSpeech = e.partOfSpeech,
                                    definitions = (from j in context.Meanings
                                                   join k in context.Definitions on j.meaningId equals k.meaningId
                                                   where j.wordId == ep.wordId
                                                   where k.meaningId == e.meaningId
                                                   select new Definition
                                                   {
                                                       definition = k.definition,
                                                       example = k.example,
                                                       synonyms = k.synonyms
                                                   }
                                                   ).ToList(),
                                }).ToList()
                };

                return ne;
            }
        }

        public bool isSaved()
        {
            throw new NotImplementedException();
        }

        public Word updateWord(Word word)
        {
            if(word == null)
            {
                return word;
            }
            else
            {
                var getword = context.Words.Where(p => p.word.ToLower() == word.word.ToLower()).FirstOrDefault();

                getword = word;

                context.Words.Update(getword);

                context.SaveChanges();

                return getword;
            }

        }
    }
}
