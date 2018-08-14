using QuizApplication.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApplication
{
    public partial class QuestionControl : System.Web.UI.UserControl
    {
        List<Question> questions = new List<Question>();
        public QuestionControl()
        {
            questions= QuestionDAO.GetQuestions();
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
            timerASP.Stop();
            QuizFailedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void AfterFinalQuestion()
        {
            timerASP.Stop();
            using (var db = new Model1())
            {
                var histEntry = new HistoryEntry()
                {
                    UserId = Environment.UserName,
                    Score = 5,
                    Time = timerASP.Seconds,
                    Ended= DateTime.Now
                };
                db.Entries.Add(histEntry);
                db.SaveChanges();
            }
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
                AfterFinalQuestion();
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
            Body = questions[QuestionNo].Body;
            Answer = questions[QuestionNo].Answer;
        }

        public void Start()
        {
            timerASP.Start();
            Body = questions[QuestionNo].Body;
            Answer = questions[QuestionNo].Answer;
        }

    }
}