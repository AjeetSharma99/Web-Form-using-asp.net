using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;



namespace student1
{
    public partial class student2 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("data source=LAPTOP-VK16NQ9A; initial catalog=db79_28623; integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                show();
                showgender();
            showcourse();
            }
        }
        public void showgender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblgender", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblgender.DataValueField = "genderid";
            rblgender.DataTextField = "gendername";
            rblgender.DataSource = dt;
            rblgender.DataBind();

        }
        public void showcourse()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Tblcourse", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcourse.DataValueField = "courseid";
            ddlcourse.DataTextField = "coursename";
            ddlcourse.DataSource = dt;
            ddlcourse.DataBind();
            ddlcourse.Items.Insert(0, new ListItem("--select course--", "0"));

        }

        public void show()
            {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student2",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvstudent2.DataSource = dt;
            gvstudent2.DataBind();

        }
        public void clear()
        {
            txtname.Text = "";
            txtrollno.Text = "";
            txtsalary.Text = "";
            rblgender.ClearSelection();
            ddlcourse.SelectedValue = "0";
            btnsubmit.Text = "submit";
           
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if(btnsubmit.Text=="submit")
            { 
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into student2(name,rollno,salary,gender,course) values('"+txtname.Text+"','"+txtrollno.Text+"','"+txtsalary.Text+"','"+rblgender.SelectedValue+"','"+ddlcourse.SelectedValue+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            show();
                clear();

            }
            else if(btnsubmit.Text=="update")
            { 
                con.Open();
              SqlCommand cmd = new SqlCommand(" update student2 set name='"+txtname.Text+"',rollno='"+txtrollno.Text+"',salary='"+txtsalary.Text+"',gender='"+rblgender.SelectedValue+"',course='"+ddlcourse.SelectedValue+"' where  id='"+ViewState["ID"]+"' ",con);
                cmd.ExecuteNonQuery();
                con.Close();
              show();
              clear();
            }


        }
    protected void gvstudent2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from student2 where id='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                show();
            }
            else if(e.CommandName=="B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select* from student2 where id='" + e.CommandArgument + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtrollno.Text = dt.Rows[0]["rollno"].ToString();
                txtsalary.Text = dt.Rows[0]["salary"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                ddlcourse.SelectedValue = dt.Rows[0]["course"].ToString();
                btnsubmit.Text = "update";
                ViewState["ID"] = e.CommandArgument; 
            }

        }
    }
}