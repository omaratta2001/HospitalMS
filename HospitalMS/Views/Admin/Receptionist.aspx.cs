using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HospitalMS.Views.Admin
{
    public partial class Receptionist : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowReceptionist();
        }

        //Add This Overriden Method
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }

        private void ShowReceptionist()
        {
            string Query = "Select * from ReceptionistTbl";
            ReceptionistGV.DataSource = Con.GetDatas(Query);
            ReceptionistGV.DataBind();
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RName = RecNameTb.Value;
                string REmail = RecEmailTb.Value;
                string RAdd = RecAddressTb.Value;
                string RPhone = RecPhoneTb.Value;
                string Password = PasswordTb.Value;
                string Query = "insert into ReceptionistTbl values('{0}','{1}','{2}','{3}','{4}')";
                Query = string.Format(Query, RName, REmail, RAdd, RPhone, Password);
                Con.SetData(Query);
                ShowReceptionist();
                ErrMsg.InnerText = "Receptionist Added Successfully";
                RecNameTb.Value = "";
                RecEmailTb.Value = "";
                RecAddressTb.Value = "";
                RecPhoneTb.Value = "";
                PasswordTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
        int key = 0;

        protected void ReceptionistGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecNameTb.Value = ReceptionistGV.SelectedRow.Cells[2].Text;
            RecEmailTb.Value = ReceptionistGV.SelectedRow.Cells[3].Text;
            RecAddressTb.Value = ReceptionistGV.SelectedRow.Cells[4].Text;
            RecPhoneTb.Value = ReceptionistGV.SelectedRow.Cells[5].Text;
            PasswordTb.Value = ReceptionistGV.SelectedRow.Cells[6].Text;
           if(RecNameTb.Value =="")
            {
                key = 0;
            }
           else
            {
                key = Convert.ToInt32(ReceptionistGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            string RName = RecNameTb.Value;
            string REmail = RecEmailTb.Value;
            string RAdd = RecAddressTb.Value;
            string RPhone = RecPhoneTb.Value;
            string Password = PasswordTb.Value;

            try
            {
                string Query = "Update ReceptionistTbl set  RecName = '{0}', RecEmail = '{1}', RecAdd =  '{2}', RecPhone = '{3}', RecPassword = '{4}' where RecId = '{5}' ";
                Query = string.Format(Query, RName, REmail, RAdd, RPhone, Password, ReceptionistGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowReceptionist();
                ErrMsg.InnerText = "Receptionist Updated Successfully";
                RecNameTb.Value = "";
                RecEmailTb.Value = "";
                RecAddressTb.Value = "";
                RecPhoneTb.Value = "";
                PasswordTb.Value = "";

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
                if(RecNameTb.Value== "")
                {
                    ErrMsg.InnerText = "Select a Receptionist!!";

                }
                else
                {
                    string Query = "delete from ReceptionistTbl where RecId = {0}";
                    Query = string.Format(Query, ReceptionistGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowReceptionist();
                    ErrMsg.InnerText = "Receptionist Deleted Successfully";
                    key = 0;
                    RecNameTb.Value = "";
                    RecEmailTb.Value = "";
                    RecAddressTb.Value = "";
                    RecPhoneTb.Value = "";
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