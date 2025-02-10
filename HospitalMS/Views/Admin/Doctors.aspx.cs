using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HospitalMS.Views.Admin
{
    public partial class Doctors : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowDoctor();

        }
        private void ShowDoctor()
        {
            string Query = "Select * from DoctorTbl";
            DoctorsGV.DataSource = Con.GetDatas(Query);
            DoctorsGV.DataBind();
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {

            try
            {

                string DocName = DocNameTb.Value;
                string DocPhone = DocPhoneTb.Value;
                string DocExp = DocExpTb.Value;
                string DocSpec = DocSpecTb.Value;
                string DocGen = GenderCb.SelectedValue;
                string DocAdd = AddressTb.Value;
                string DocDOB = DOBTb.Value;
                string DocEmail = EmailTb.Value;

                string DocPass = PasswordTb.Value;
                string Query = "Update DoctorTbl set  DocName = '{0}', DocPhone = '{1}', DocExp =  '{2}', DocSpec = '{3}', DocGen = '{4}' , DocAdd = '{5}' , DocDOB = '{6}' , DocPass = '{7}' , DocEmail = '{8}'  where DocId = '{9}' ";
                Query = string.Format(Query, DocName, DocPhone, DocExp, DocSpec, DocGen, DocAdd, DocDOB, DocPass,DocEmail, DoctorsGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowDoctor();
                ErrMsg.InnerText = "Doctor Updated Successfully";
                DocNameTb.Value = "";
                DocPhoneTb.Value = "";
                DocExpTb.Value = "";
                DocSpecTb.Value = "";
                GenderCb.SelectedIndex = -1;
                AddressTb.Value = "";
                DOBTb.Value = "";
                PasswordTb.Value = "";
                EmailTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
        int key = 0;

        protected void DoctorsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocNameTb.Value = DoctorsGV.SelectedRow.Cells[2].Text;
            DocPhoneTb.Value = DoctorsGV.SelectedRow.Cells[3].Text;
            DocExpTb.Value = DoctorsGV.SelectedRow.Cells[4].Text;
            DocSpecTb.Value = DoctorsGV.SelectedRow.Cells[5].Text;
            if(DoctorsGV.SelectedRow.Cells[6].Text == "Male")
            {
                GenderCb.SelectedIndex = 0;
            }
            else
            {
                GenderCb.SelectedIndex = 1;

            }
            AddressTb.Value = DoctorsGV.SelectedRow.Cells[7].Text;
            DOBTb.Value = DoctorsGV.SelectedRow.Cells[8].Text;
            PasswordTb.Value = DoctorsGV.SelectedRow.Cells[9].Text;
            EmailTb.Value = DoctorsGV.SelectedRow.Cells[10].Text;
            if (DocNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DoctorsGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string DocName = DocNameTb.Value;
                string DocPhone = DocPhoneTb.Value;
                string DocExp = DocExpTb.Value;
                string DocSpec = DocSpecTb.Value;
                string DocGen = GenderCb.SelectedValue.ToString();
                string DocAdd = AddressTb.Value;
                string DocDOB = DOBTb.Value;
                string DocPass = PasswordTb.Value;
                string DocEmail = EmailTb.Value;



                string Query = "insert into DoctorTbl values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}' ,'{8}')";
                Query = string.Format(Query, DocName, DocPhone, DocExp, DocSpec, DocGen, DocAdd, DocDOB, DocPass,DocEmail);
                Con.SetData(Query);
                ShowDoctor();
                ErrMsg.InnerText = "Doctor Added Successfully";
                DocNameTb.Value = "";
                DocPhoneTb.Value = "";
                DocExpTb.Value = "";
                DocSpecTb.Value = "";
                GenderCb.SelectedIndex = -1;
                AddressTb.Value = "";
                DOBTb.Value = "";
                PasswordTb.Value = "";
                EmailTb.Value = "";

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
                if (DocNameTb.Value == "")
                {
                    ErrMsg.InnerText = "Select a Doctor!!";

                }
                else
                {
                    string Query = "delete from DoctorTbl where DocId = {0}";
                    Query = string.Format(Query, DoctorsGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowDoctor();
                    ErrMsg.InnerText = "Receptionist Deleted Successfully";
                    key = 0;
                    DocNameTb.Value = "";
                    DocPhoneTb.Value = "";
                    DocExpTb.Value = "";
                    DocSpecTb.Value = "";
                    GenderCb.SelectedIndex = -1;
                    AddressTb.Value = "";
                    DOBTb.Value = "";
                    PasswordTb.Value = "";
                }


            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}