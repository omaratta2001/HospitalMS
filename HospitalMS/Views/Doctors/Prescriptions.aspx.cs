using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalMS.Views.Laboratorian;

namespace HospitalMS.Views.Doctors
{
    public partial class Prescriptions : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowPrescription();
            GetTreatment();
            GetPatient();
        }
        private void ShowPrescription()
        {
            string Query = "Select * from PrescriptionTbl";
            PrescriptionGV.DataSource = Con.GetDatas(Query);
            PrescriptionGV.DataBind();
        }

        private void GetPatient()
        {
            string Query = "select * from PatientTbl";
            PatientCb.DataTextField = Con.GetDatas(Query).Columns["PatName"].ToString();
            PatientCb.DataValueField = Con.GetDatas(Query).Columns["PatId"].ToString();
            PatientCb.DataSource = Con.GetDatas(Query);
            PatientCb.DataBind();
        }

        private void GetTreatment()
        {
            string Query = "select * from LabTestTbl";
            LabTestCb.DataTextField = Con.GetDatas(Query).Columns["TestName"].ToString();
            LabTestCb.DataValueField = Con.GetDatas(Query).Columns["TestId"].ToString();
            LabTestCb.DataSource  = Con.GetDatas(Query);
            LabTestCb.DataBind();
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Doctor = Session["uid"] as string;
                string Patinet = PatientCb.SelectedValue.ToString();
                string Medicine = MedicinesTb.Value;
                string Test = LabTestCb.SelectedValue.ToString();
                string Cost = CostTb.Value;


                string Query = "insert into PrescriptionTbl values('{0}',{1},'{2}',{3},{4})";
                Query = string.Format(Query, Doctor,Patinet ,Medicine, Test, Cost);
                Con.SetData(Query);
                ShowPrescription();
                GetTreatment();
                GetPatient();
                ErrMsg.InnerText = "Prescription Added Successfully";
                MedicinesTb.Value = "";
                CostTb.Value = "";
                PatientCb.SelectedIndex = -1;
                LabTestCb.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.InnerText = ex.Message;
            }
        }
    }
}