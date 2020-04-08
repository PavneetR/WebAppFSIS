using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FSISSystem.BLL;
using FSISSystem.ENTITIES;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace WebAppFSIS.ExercisePages
{
    public partial class CRUDPage : System.Web.UI.Page
    {
        static string pagenum = "";
        static string pid = "";
        static string add = "";
        List<string> errormsgs = new List<string>();
        private static List<Player> PlayerList = new List<Player>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                pagenum = Request.QueryString["page"];
                pid = Request.QueryString["pid"];
                add = Request.QueryString["add"];
                BindGuardianList();
                BindTeamList();
                if (string.IsNullOrEmpty(pid))
                {
                    Response.Redirect("~/Default.aspx");
                }
                
                else
                {
                    PlayerController sysmgr = new PlayerController();
                    Player info = null;
                    info = sysmgr.FindByID(int.Parse(pid)); //problem
                    if (info == null)
                    {
                        errormsgs.Add("Player is no longer on file.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        ID.Text = info.PlayerID.ToString();
                        ID.Text = info.GuardianID.ToString();
                        ID.Text = info.TeamID.ToString();

                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        
                       
                        //Age.Text =
                        //    info.Age.HasValue ? info.Age.Value.ToString() : "";
                        Age.Text =
                           info.Age.HasValue ? string.Format("{0}", info.Age.Value) : "";

                        Gender.Text = info.Gender;
                        //AlbertaHealthCareNumber.Text =
                        //    info.AlbertaHealthCareNumber.HasValue ? string.Format("{0}", info.AlbertaHealthCareNumber.Value) : "";
                        AlbertaHealthCareNumber.Text = info.AlbertaHealthCareNumber;
                        MedicalAlertDetails.Text = info.MedicalAlertDetails;
                       
                        if (info.TeamID.HasValue)
                        {
                            TeamList.SelectedValue = info.TeamID.ToString();
                        }
                        else
                        {
                            TeamList.SelectedIndex = 0;
                        }
                        if (info.GuardianID.HasValue)
                        {
                            GuardianList.SelectedValue = info.GuardianID.ToString();
                        }
                        else
                        {
                            GuardianList.SelectedIndex = 0;
                        }
                    }
                }
            }
        }
        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }
        protected void BindGuardianList()
        {
            try
            {
                GuardianController sysmgr = new GuardianController();
                List<Guardian> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.GFullName.CompareTo(y.GFullName));
                GuardianList.DataSource = info;
                GuardianList.DataTextField = nameof(Guardian.GFullName);
                GuardianList.DataValueField = nameof(Guardian.GFullName);
                GuardianList.DataBind();
                GuardianList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void BindTeamList()
        {
            try
            {
                TeamController sysmgr = new TeamController();
                List<Team> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void Validation(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                errormsgs.Add(" First Name is required");
            }
            if (string.IsNullOrEmpty(LastName.Text))
            {
                errormsgs.Add(" Last Name is required");
            }
            if (GuardianList.SelectedIndex == 0)
            {
                errormsgs.Add("Guardian is required");
            }
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Team is required");
            }
            //if (QuantityPerUnit.Text.Length > 20)
            //{
            //    errormsgs.Add("Quantity per Unit is limited to 20 characters");
            //}
            int age = 0;
            if (!string.IsNullOrEmpty(Age.Text))
            {
                if (int.TryParse(Age.Text, out age))
                {
                    if (age < 6 || age > 14)
                    {
                        errormsgs.Add("Age must be between 6 and 14");
                    }
                }
                else
                {
                    errormsgs.Add("Age must be a real number");
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            if (pagenum == "4")
            {
                Response.Redirect("Exo9and10.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            ID.Text = "";
            FirstName.Text = "";
            Gender.Text = "";
            Age.Text = "";
            LastName.Text = "";
            AlbertaHealthCareNumber.Text = "";
            MedicalAlertDetails.Text = "";
            
            GuardianList.ClearSelection();
            TeamList.ClearSelection();
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            Validation(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController sysmgr = new PlayerController();
                    Player item = new Player();
                    item.FirstName = FirstName.Text.Trim();
                    item.LastName = LastName.Text.Trim();
                    if (TeamList.SelectedIndex == 0)
                    {
                        item.TeamID = null;
                    }
                    else
                    {
                        item.TeamID = int.Parse(TeamList.SelectedValue);
                    }
                    
                    if (string.IsNullOrEmpty(Age.Text))
                    {
                        item.Age = null;
                    }
                    else
                    {
                        item.Age = int.Parse(Age.Text);
                    }
                    if (string.IsNullOrEmpty(AlbertaHealthCareNumber.Text))
                    {
                        item.AlbertaHealthCareNumber = null;
                    }
                    else
                    {
                        item.AlbertaHealthCareNumber = (AlbertaHealthCareNumber.Text);
                    }
                    item.Gender = Gender.Text.Trim();
                    item.MedicalAlertDetails = MedicalAlertDetails.Text.Trim();

                    int newID = sysmgr.Add(item);
                    ID.Text = newID.ToString();
                    errormsgs.Add("Player has been added");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(ID.Text))
            {
                errormsgs.Add("Search for a player to update");
            }
            else if (!int.TryParse(ID.Text, out id))
            {
                errormsgs.Add("Player id is invalid");
            }
            Validation(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {

            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(ID.Text))
            {
                errormsgs.Add("Search for a player to delete");
            }
            else if (!int.TryParse(ID.Text, out id))
            {
                errormsgs.Add("Player id is invalid");
            }
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CallFunction", "CallFunction();", true);
                    PlayerController sysmgr = new PlayerController();
                    int rowsaffected = sysmgr.Delete(id);
                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Player has been deleted");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        errormsgs.Add("Player was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }

                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

    }
    
}