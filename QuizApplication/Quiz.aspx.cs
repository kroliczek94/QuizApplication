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
            timerASP.Start();
            Wizard1.ActiveStepIndex++;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.question.QuizFailedEvent += new EventHandler(MyEventHandlerFunction_QuizFailed);
            this.question.FinalQuestionEvent += new EventHandler(MyEventHandlerFunction_FinalQuestion);


        }

        private void MyEventHandlerFunction_FinalQuestion(object sender, EventArgs e)
        {
            timerASP.Stop();
            Wizard1.ActiveStepIndex = 2;
        }

        protected void Abort_Click(object sender, EventArgs e)
        {
            timerASP.Stop();
            Wizard1.ActiveStepIndex = 3;

        }
    }
}