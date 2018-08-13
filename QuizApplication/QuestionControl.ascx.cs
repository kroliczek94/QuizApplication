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
        public QuestionControl()
        {

        }
        private bool? _answer = null;
        private bool _fail = false;
        public string QuestionBody
        {
            set
            {
                content.Text = value;
            }
        }

        public bool QuestionAnswer
        {
            set
            {
                _answer = value;
            }
        }

        public bool Failed
        {
            get
            {
                return _fail;
            }
            set
            {
                _fail = value;
            }

        }

        public event EventHandler StatusUpdated;

        private void OnUserControlButtonClick()
        {
            if (StatusUpdated != null)
            {
                StatusUpdated(this, EventArgs.Empty);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void YesButton_Click(object sender, EventArgs e)
        {
            if (_answer.HasValue)
            {
                if (_answer.Value)
                {
                    _fail = true;
                    OnUserControlButtonClick();
                }
            }
        }

        protected void NoButton_Click(object sender, EventArgs e)
        {
            if (_answer.HasValue)
            {
                if (!_answer.Value)
                {
                    _fail = true;
                    if (this.StatusUpdated != null)
                        this.StatusUpdated(this, new EventArgs());
                }
            }
        }
    }
}