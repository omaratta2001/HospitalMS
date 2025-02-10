using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalMS.Views.Admin;

namespace HospitalMS.Views.Laboratorian
{
    public partial class LabTest : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowLabTest();
        }
        private void ShowLabTest()
        {
            string Query = "Select * from LabTestTbl";
            LabTestGV.DataSource = Con.GetDatas(Query);
            LabTestGV.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TestName = LabNameTb.Value;
                string TestCost = TestCostTb.Value;
                string User = Session["uid"] as string;

                string Query = "insert into LabTestTbl values('{0}','{1}','{2}')";
                Query = string.Format(Query, TestName, TestCost, User);
                Con.SetData(Query);
                ShowLabTest();
                ErrMsg.InnerText = "Lab Test Added Successfully";
                LabNameTb.Value = "";
                TestCostTb.Value = "";
               

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }

        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {

                string TestName = LabNameTb.Value;
                string TestCost = TestCostTb.Value;
                string User = Session["uid"] as string;

                string Query = "Update LabTestTbl set  TestName = '{0}', TestCost = '{1}', AddBy =  '{2}'  where TestId = '{3}' ";
                Query = string.Format(Query, TestName,TestCost, User, LabTestGV.SelectedRow.Cells[1].Text);
                Con.SetData(Query);
                ShowLabTest();
                ErrMsg.InnerText = "Test Updated Successfully";
                LabNameTb.Value = "";
                TestCostTb.Value = "";
               
            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
        int key = 0;
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (LabNameTb.Value == "")
                {
                    ErrMsg.InnerText = "Select a Test!!";

                }
                else
                {
                    string Query = "delete from LabTestTbl where TestId = {0}";
                    Query = string.Format(Query, LabTestGV.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowLabTest();
                    ErrMsg.InnerText = "Test Deleted Successfully";
                    key = 0;
                    LabNameTb.Value = "";
                    TestCostTb.Value = "";
                    
                }


            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }

        protected void LabTestGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabNameTb.Value = LabTestGV.SelectedRow.Cells[2].Text;
            TestCostTb.Value = LabTestGV.SelectedRow.Cells[3].Text;
          

            if (LabNameTb.Value == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(LabTestGV.SelectedRow.Cells[1].Text);
            }
        }
    }
}