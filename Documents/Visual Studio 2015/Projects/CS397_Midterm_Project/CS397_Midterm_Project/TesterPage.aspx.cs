using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace CS397_Midterm_Project
{
    public partial class TesterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employeeToken"].ToString() == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void LogoffButton_Click(object sender, EventArgs e)
        {
            Session["employeeToken"] = null;
            Response.Redirect("Default.aspx");
        }

        protected void ReportButton_Click(object sender, EventArgs e)
        {
            string enteredBy = Session["employeeToken"].ToString().Remove(4, 6);
            string subject = SubjectTextBox.Text;
            string priority = PriorityDropDownList.SelectedValue.ToString();
            string description = DescriptionTextBox.Text;
            OleDbConnection bugsConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["EmployeeCS"].ConnectionString);
            string quary = "INSERT INTO Bugs (EnteredBy, Subject, Priority, Description) VALUES ('" + enteredBy + "', '" + subject + "', '" + priority + "', '" + description + "')";
            //Using INSERT INTO on the table adds new bug entries, but starts them at BugID=2
            OleDbCommand command = new OleDbCommand(quary, bugsConnection);
            bugsConnection.Open();
            command.ExecuteNonQuery();
            bugsConnection.Close();
            UpdateGridIvew();
        }

        protected void UpdateGridIvew()
        {
            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["EmployeeCS"].ConnectionString);
            string quary = "Select * from Bugs";
            OleDbCommand command = new OleDbCommand(quary, connection);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds, "Bugs");
            BugGridView.DataSource = ds.Tables["Bugs"];
            BugGridView.DataBind();
        }

        protected void BugGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void BugGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }
    }
}