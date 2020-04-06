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
    public partial class exercise06 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                BlindList();
            }
        }
            protected void BlindList()
            {
                try
                {
                    TeamController sysmgr = new TeamController();
                    List<Team> info = null;
                info = sysmgr.List();/*Teams_FindByID(int.Parse(List01.SelectedValue));*/
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                List01.DataSource = info;
                List01.DataTextField = nameof(Team.TeamName);
                List01.DataValueField = nameof(Team.TeamID);
                List01.DataBind();
                List01.Items.Insert(0,"select...");

                }
            catch(Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
            }
        protected void Fetch_Click(object sender, EventArgs e)
        {
            if(List01.SelectedIndex == 0)
            {
                MessageLabel.Text = "select team";
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    List<Player> info = null;
                    info = sysmgr.Players_FindByID(int.Parse(List01.SelectedValue));
                    info.Sort((x, y) => x.PlayerID.CompareTo(y.PlayerID));
                    List02.DataSource = info;
                    List02.DataBind();
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }
        protected void List02_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            List02.PageIndex = e.NewPageIndex;
            Fetch_Click(sender, new EventArgs());
        }


    }
}