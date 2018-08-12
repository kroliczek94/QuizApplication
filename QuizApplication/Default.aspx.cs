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
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new Model1())
            {
                // Display all Blogs from the database 
                var query = from b in db.Questions
                            orderby b.Body
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Body);
                }

                Console.WriteLine("Press any key to exit...");
                
            }
        }
    }
}