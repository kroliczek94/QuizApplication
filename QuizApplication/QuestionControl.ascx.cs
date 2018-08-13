using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApplication
{
    public partial class QuestionControl : System.Web.UI.UserControl
    {
        List<Question> questions = new List<Question>();
        public QuestionControl()
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
        private bool? _answer = null;

        public int QuestionLimit { get; private set; } = 5;

        public int QuestionNo
        {
            get
            {
                var value = ViewState["questionNo"];
                return null != value ? (int)value : 0;
            }
            set
            {
                ViewState["questionNo"] = value;
            }
        }

        public string Body
        {
            set
            {
                content.Text = value;
            }
        }

        public bool Answer
        {
            set
            {
                _answer = value;
            }
        }

        public event EventHandler QuizFailedEvent;
        public event EventHandler FinalQuestionEvent;

        private void OnFail()
        {
            QuizFailedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void OnFinalQuestion()
        {
            FinalQuestionEvent?.Invoke(this, EventArgs.Empty);
        }

        private void OnUserNextQuestion()
        {   
            if (QuestionNo < QuestionLimit - 1)
            {
                QuestionNo++;
                Body = questions[QuestionNo].Body;
                Answer = questions[QuestionNo].Answer;
            }
            else
            {
                FinalQuestionEvent.Invoke(this, EventArgs.Empty);
            }
        }

        protected void YesButton_Click(object sender, EventArgs e)
        {
            if (_answer.HasValue)
            {
                if (!_answer.Value)
                {
                    OnFail();
                }
                else
                {
                    OnUserNextQuestion();
                }
            }
        }

        protected void NoButton_Click(object sender, EventArgs e)
        {
            if (_answer.HasValue)
            {
                if (_answer.Value)
                {
                    OnFail();
                }
                else
                {
                    OnUserNextQuestion();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["questionNo"] = 0;
            }
            else
            {
                Body = questions[QuestionNo].Body;
                Answer = questions[QuestionNo].Answer;
            }
        }



    }
}