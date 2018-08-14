using QuizApplication.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApplication
{
    public partial class EntryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridviewData();
        }

        protected void BindGridviewData()
        {
            var newQueryResult = QuestionDAO.GetHistoryEntries(10).Select(t => new
            {
                Data = t.Ended.ToShortDateString(),
                Wynik = t.Score,
                Czas = t.Time,
                Użytkownik = t.UserId
            });

            GridView1.DataSource = newQueryResult;
            GridView1.DataBind();
        }
    }
}