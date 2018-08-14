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
            var value = ViewState["usedQuestions"];
           

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

        public int CurrentQuestionId
        {
            get
            {
                var value = ViewState["CurrentQuestionId"];
                return null != value ? (int)value : 0;
            }
            set
            {
                ViewState["CurrentQuestionId"] = value;
            }
        }


        public string Body
        {
            set
            {
                content.Text = value;
            }
        }

        public string UsedQuestionsStr
        {
            get
            {
                var value = ViewState["usedQuestions"];
                return null != value ? (string)value : string.Empty;
            }
            set
            {
                ViewState["usedQuestions"] = value;
            }
        } 

        public int Duration
        {
            get { return timerASP.Seconds; }
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
        public event EventHandler AbortQuestion;

        private void OnFail()
        {
            timerASP.Stop();
            QuizFailedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void OnAbortClick()
        {
            timerASP.Stop();
            AbortQuestion?.Invoke(this, EventArgs.Empty);
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
            UsedQuestionsStr += CurrentQuestionId.ToString() + ";";
           
            if (QuestionNo < QuestionLimit - 1)
            {
                CurrentQuestionId = GetNextQuestionId();
                FillBodyAndAnswer();
                QuestionNo++;
            }
            else
            {
                AfterFinalQuestion();
            }
        }

        private void FillBodyAndAnswer()
        {
            var curQuestion = questions.Where(x => x.ID == CurrentQuestionId).First();
            Body = curQuestion.Body;
            Answer = curQuestion.Answer;
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

        protected void Abort_Click(object sender, EventArgs e)
        {
            OnAbortClick();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["questionNo"] = 0;
            }
            if (CurrentQuestionId != 0)
                FillBodyAndAnswer();
        }

        public void Start()
        {
            timerASP.Start();
            QuestionNo = 0;
            UsedQuestionsStr = "";
            CurrentQuestionId = GetNextQuestionId();
            FillBodyAndAnswer();
        }

        private int GetNextQuestionId()
        {
            var UsedQuestions = UsedQuestionsStr.Split(new string[] { ";" }, StringSplitOptions.None).ToList();
            var TempQuestions = questions;
            TempQuestions.RemoveAll(x => UsedQuestions.Contains(x.ID.ToString()));
            return TempQuestions.OrderBy(a => Guid.NewGuid()).First().ID;
            
        }
    }
}