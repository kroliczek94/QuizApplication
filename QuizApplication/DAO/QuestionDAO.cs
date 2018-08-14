using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApplication.DAO
{
    public class QuestionDAO
    {
        private static Model1 dbModel1 = new Model1();
        public static List<Question> GetQuestions()
        {

            var query = from b in dbModel1.Questions
                        orderby b.ID
                        select b;

            return query.ToList();
        }

        public static IEnumerable<HistoryEntry> GetHistoryEntries(int n)
        {
            var query = from b in dbModel1.Entries
                        orderby b.Score, b.Time
                        select b;
            return query.AsEnumerable().Take(n);
           
        }

        public static IEnumerable<HistoryEntry> GetHistoryEntries()
        {
            return GetHistoryEntries(dbModel1.Entries.Count());
        }
    }
}
