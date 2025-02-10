using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalMS.Views.Admin;

namespace HospitalMS.Views.Laboratorian
{
    public partial class Patients : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowPatient();
        }
        private void ShowPatient()
        {
            string Query = "Select * from PatientTbl";
            PatientGV.DataSource = Con.GetDatas(Query);
            PatientGV.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string PatName = PatNameTb.Value;
                string PatPhone = PatPhoneTb.Value;
                string PatGen = GenderCb.SelectedValue;
                string PatDOB = PatDOBTb.Value;
                string PatAdd = PatAddressTb.Value;
                string PatAllergies = PatAllergiesTb.Value;
                string User = Session["uid"] as string;


                string Query = "insert into PatientTbl values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')";
                Query = string.Format(Query, PatName, PatPhone,PatGen,PatDOB,PatAdd,PatAllergies, User);
                Con.SetData(Query);
                ShowPatient();
                ErrMsg.InnerText = "Patient Added Successfully";
                PatNameTb.Value = "";
                PatPhoneTb.Value = "";
                GenderCb.SelectedIndex=-1;
                PatDOBTb.Value = "";
                PatAddressTb.Value = "";
                PatAllergiesTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }

        }
        int key = 0;

        protected void PatientGV_SelectedIndexChanged(object sender, EventArgs e)
        {

            PatNameTb.Value = PatientGV.SelectedRow.Cells[2].Text;
            PatPhoneTb.Value = PatientGV.SelectedRow.Cells[3].Text;
            if (PatientGV.SelectedRow.Cells[4].Text == "Male")
            {
                GenderCb.SelectedIndex = 0;
            }
            else
            {
                GenderCb.SelectedIndex = 1;

            }
            PatDOBTb.Value = PatientGV.SelectedRow.Cells[5].Text;
            PatAddressTb.Value = PatientGV.SelectedRow.Cells[6].Text;
            PatAllergiesTb.Value = PatientGV.SelectedRow.Cells[7].Text;


            if (PatNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PatientGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {

                string PatName = PatNameTb.Value;
                string PatPhone = PatPhoneTb.Value;
                string PatGen = GenderCb.SelectedValue;
                string PatDOB = PatDOBTb.Value;
                string PatAdd = PatAddressTb.Value;
                string PatAllergies = PatAllergiesTb.Value;
                string Query = "Update PatientTbl set  PatName = '{0}', PatPhone = '{1}', PatGen =  '{2}', PatDOB = '{3}', PatAdd = '{4}' , PatAllergies = '{5}'  where PatId = '{6}' ";
                Query = string.Format(Query, PatName, PatPhone, PatGen, PatDOB, PatAdd, PatAllergies, PatientGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowPatient();
                ErrMsg.InnerText = "Patient Updated Successfully";
                PatNameTb.Value = "";
                PatPhoneTb.Value = "";
                GenderCb.SelectedIndex = -1;
                PatDOBTb.Value = "";
                PatAddressTb.Value = "";
                PatAllergiesTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PatNameTb.Value == "")
                {
                    ErrMsg.InnerText = "Select a Patient!!";

                }
                else
                {
                    string Query = "delete from PatientTbl where PatId = {0}";
                    Query = string.Format(Query, PatientGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowPatient();
                    ErrMsg.InnerText = "Laboratorian Deleted Successfully";
                    key = 0;
                    PatNameTb.Value = "";
                    PatPhoneTb.Value = "";
                    GenderCb.SelectedIndex = -1;
                    PatDOBTb.Value = "";
                    PatAddressTb.Value = "";
                    PatAllergiesTb.Value = "";
                }


            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}