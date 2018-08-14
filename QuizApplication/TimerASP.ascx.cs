using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApplication
{
    public partial class TimerASP : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int Seconds
        {
            get
            {
                var value = ViewState["seconds"];
                return null != value ? (int)value : -1;
            }
            set
            {
                ViewState["seconds"] = value;
                time.Text = "0";
            }
        }
        public bool Started
        {
            get
            {
                var value = ViewState["started"];
                return null != value ? (bool)value : false;
            }
            set
            {
                ViewState["started"] = value;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (Started)
            {
                Seconds++;
                time.Text = Seconds.ToString();
            }
        }

        public void Start()
        {
            Started = true;
            Seconds = 0;
        }

        public void Stop()
        {
            Started = false;
        }


    }
}