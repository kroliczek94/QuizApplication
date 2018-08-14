using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApplication
{
    public partial class Quiz : System.Web.UI.Page
    {

        private void MyEventHandlerFunction_QuizFailed(object sender, EventArgs e)
        {
            Wizard1.ActiveStepIndex = 3;
        }

        protected void StartQuizButton_Click(object sender, EventArgs e)
        {

            question.Start();
            Wizard1.ActiveStepIndex = 1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.question.QuizFailedEvent += new EventHandler(MyEventHandlerFunction_QuizFailed);
            this.question.FinalQuestionEvent += new EventHandler(MyEventHandlerFunction_FinalQuestion);
            this.question.AbortQuestion += new EventHandler(MyEventHandlerFunction_AbortQuestion);


        }

        private void MyEventHandlerFunction_AbortQuestion(object sender, EventArgs e)
        {
            Wizard1.ActiveStepIndex = 0;
        }

        private void MyEventHandlerFunction_FinalQuestion(object sender, EventArgs e)
        {
            ResultLabel.Text = question.Duration.ToString();
            Wizard1.ActiveStepIndex = 2;
        }

        protected void RestartButton_Click(object sender, EventArgs e)
        {

            Wizard1.ActiveStepIndex = 0;
        }
    }
}