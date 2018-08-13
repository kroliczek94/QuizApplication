using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApplication
{
    public partial class _Default : Page
    {
        List<Question> questions = new List<Question>();
        private DateTime started, ended;
        public _Default()
        {
           
            using (var db = new Model1())
            {
                // Display all Blogs from the database 
                var query = from b in db.Questions
                            orderby b.ID
                            select b;
                questions = query.ToList();
              
            }
        }

        private void MyEventHandlerFunction_StatusUpdated(object sender, EventArgs e)
        {
            if (question.Failed)
            {
                question.QuestionBody = "No i cześć";
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int secondsBetween = (DateTime.Now - started).Seconds;
            time.Text = secondsBetween.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            this.question.StatusUpdated += new EventHandler(MyEventHandlerFunction_StatusUpdated);
            
            if (!IsPostBack)
            {
                Session["question_id"] = 0;
                started = DateTime.Now;
            }
            else
            {
             
                var str = Session["question_id"].ToString();
                var questionNo = Convert.ToInt32(str);
                questionNo++;
                Session["question_id"] = questionNo;
                question.QuestionBody = questions[questionNo].Body;
                question.QuestionAnswer = questions[questionNo].Answer;

                
            }
           
            
         



        }

      

    }
}