//using System.Collections.Generic;
//using System.Data.Entity;

//namespace QuizApplication
//{
//    public class QuestionsInitializer : DropCreateDatabaseIfModelChanges<Model1>
//    {
//        protected override void Seed(Model1 context)
//        {
//            IList<Question> defaultStandards = new List<Question>();

//            defaultStandards.Add(new Question() { Body = "Czy 2+2 = 4", Answer = true});
//            defaultStandards.Add(new Question() { Body = "Czy 2+5 = 6", Answer= false });
//            defaultStandards.Add(new Question() { Body = "Czy 2+3 = 3", Answer= false });

//            context.Questions.AddRange(defaultStandards);

//            base.Seed(context);
//        }
//    }
//}