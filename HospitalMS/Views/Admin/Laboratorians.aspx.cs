using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalMS.Views.Admin
{
    public partial class Laboratorian : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowLab();

        }
        private void ShowLab()
        {
            string Query = "Select * from LaboratorianTbl";
            LaboratorianGV.DataSource = Con.GetDatas(Query);
            LaboratorianGV.DataBind();
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string LabName = LabNameTb.Value;
                string LabEmail = LabbEmailTb.Value;
                string LapPass = LabPasswordTb.Value;
                string LabPhone = LabPhoneTb.Value;
                string LabAddress = LabAddressTb.Value;
                string LabGen = LabGenderCb.SelectedItem.Value;
                string Query = "insert into LaboratorianTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                Query = string.Format(Query, LabName, LabEmail, LapPass, LabPhone, LabAddress,LabGen);
                Con.SetData(Query);
                ShowLab();
                ErrMsg.InnerText = "Laboratorian Added Successfully";
                LabNameTb.Value = "";
                LabbEmailTb.Value = "";
                LabPasswordTb.Value = "";
                LabPhoneTb.Value = "";
                LabAddressTb.Value = "";
                LabGenderCb.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
        int key= 0;
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LabNameTb.Value == "")
                {
                    ErrMsg.InnerText = "Select a Laboratorian!!";

                }
                else
                {
                    string Query = "delete from LaboratorianTbl where LabId = {0}";
                    Query = string.Format(Query, LaboratorianGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowLab();
                    ErrMsg.InnerText = "Laboratorian Deleted Successfully";
                    key = 0;
                    LabNameTb.Value = "";
                    LabbEmailTb.Value = "";
                    LabPasswordTb.Value = "";
                    LabPhoneTb.Value = "";
                    LabAddressTb.Value = "";
                    LabGenderCb.SelectedIndex = -1;
                }


            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void LaboratorianGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabNameTb.Value = LaboratorianGV.SelectedRow.Cells[2].Text;
            LabbEmailTb.Value = LaboratorianGV.SelectedRow.Cells[3].Text;
            LabPasswordTb.Value = LaboratorianGV.SelectedRow.Cells[4].Text;
            LabPhoneTb.Value = LaboratorianGV.SelectedRow.Cells[5].Text;
            LabAddressTb.Value = LaboratorianGV.SelectedRow.Cells[6].Text;
    
            if (LaboratorianGV.SelectedRow.Cells[7].Text == "Male")
            {
                LabGenderCb.SelectedIndex = 0;
            }
            else
            {
                LabGenderCb.SelectedIndex = 1;

            }
   
            if (LabNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(LaboratorianGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {

            try
            {

                string LabName = LabNameTb.Value;
                string LabEmail = LabbEmailTb.Value;
                string LapPass = LabPasswordTb.Value;
                string LabPhone = LabPhoneTb.Value;
                string LabAddress = LabAddressTb.Value;
                string LabGen = LabGenderCb.SelectedItem.Value;
                string Query = "Update LaboratorianTbl set  LabName = '{0}', LabEmail = '{1}', LapPass =  '{2}', LabPhone = '{3}', LabAddress = '{4}' , LabGen = '{5}'  where LabId = '{6}' ";
                Query = string.Format(Query, LabName,LabEmail,LapPass,LabPhone,LabAddress,LabGen, LaboratorianGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowLab();
                ErrMsg.InnerText = "Doctor Updated Successfully";
                LabNameTb.Value = "";
                LabbEmailTb.Value = "";
                LabPasswordTb.Value = "";
                LabPhoneTb.Value = "";
                LabAddressTb.Value = "";
                LabGenderCb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}