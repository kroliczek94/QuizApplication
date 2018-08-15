using QuizApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApplication.DAO
{
    public class QuestionDAO
    {
        private static ApplicationDbContext dbContext = new ApplicationDbContext();
        public static List<Question> GetQuestions()
        {

            var query = from b in dbContext.Questions
                        orderby b.ID
                        select b;

            return query.ToList();
        }

        public static IEnumerable<HistoryEntry> GetHistoryEntries(int n)
        {
            var query = from b in dbContext.Entries
                        orderby b.Score, b.Time
                        select b;
            return query.AsEnumerable().Take(n);

        }

        public static void SaveUserRecord(int time)
        {
            var histEntry = new HistoryEntry()
            {
                UserId = HttpContext.Current.User.Identity.Name,
                Time = time,
                Ended = DateTime.Now
            };

            dbContext.Entries.Add(histEntry);
            dbContext.SaveChanges();

        }

        public static IEnumerable<HistoryEntry> GetHistoryEntries()
        {
            return GetHistoryEntries(dbContext.Entries.Count());
        }
    }
}
