using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add a reference so we can use EF for our database
using comp2084_lesson8.Models;

namespace comp2084_lesson8
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the GetDepartments function to populate the grid
            GetDepartments();
        }

        protected void GetDepartments() 
        {
            //use Entity Framework to connect and get the list of Departments
            using (DefaultConnection db = new DefaultConnection())
            {
                var deps = from d in db.Departments
                           select d;

                //bind the deps query result to our grid
                grdDepartments.DataSource = deps.ToList();
                grdDepartments.DataBind();
            }
        }

        protected void grdDepartments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page index and repopulate the grid
            grdDepartments.PageIndex = e.NewPageIndex;
            GetDepartments();
        }
    }
}