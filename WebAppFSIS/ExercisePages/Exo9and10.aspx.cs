using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FSISSystem.BLL;
using FSISSystem.ENTITIES;

namespace WebAppFSIS.ExercisePages
{
    public partial class Exo9and10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel1.Text = "";
            if (!Page.IsPostBack)
            {
                BindList();
            }
        }
        protected void BindList()
        {
            try
            {
                PlayerController sysmgr = new PlayerController();
                List<Player> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                List01.DataSource = info;
                List01.DataTextField = nameof(Player.FullName);
                List01.DataValueField = nameof(Player.PlayerID);
                List01.DataBind();
                List01.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                MessageLabel1.Text = ex.Message;
            }
        }
        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (List01.SelectedIndex == 0)
            {
                MessageLabel1.Text = "Select a player";
            }
            else
            {
                try
                {
                    string PlayerID = List01.SelectedValue;
                    Response.Redirect("CRUDPage.aspx?page=4&pid=" + PlayerID + "&add=" + "no");
                }
                catch (Exception ex)
                {
                    MessageLabel1.Text = ex.Message;
                }
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                string PlayerID = List01.SelectedValue;
                Response.Redirect("CRUDPage.aspx?page=4&pid=" + PlayerID + "&add=" + "yes");
            }
            catch (Exception ex)
            {
                MessageLabel1.Text = ex.Message;
            }
        }
    }

}