<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Doctors/DoctorMaster.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="HospitalMS.Views.Doctors.Prescriptions" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
            <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <h2>Prescription Detail</h2>
                <br /><br /><br />
                <form>
<div class="mb-3">
  <label for="PatientCb" class="form-label">Patient</label>
    <asp:DropDownList class ="form-control" ID="PatientCb" runat="server">

    </asp:DropDownList>
</div>
  <div class="mb-3">
    <label for="MedicinesTb" class="form-label">Medicines</label>
    <input type="text" class="form-control" id="MedicinesTb" runat="server" required ="required"/>
  </div>
    <div class="mb-3">
  <label for="LabTestCb" class="form-label">LabTest</label>
<asp:DropDownList class ="form-control" ID="LabTestCb" runat="server">

</asp:DropDownList>   </div>
    <div class="mb-3">
    <label for="CostTb" class="form-label">Cost</label>
    <input type="text" class="form-control" id="CostTb" runat="server" required ="required"/>
  </div>
 
<div class="d-grid">
       <label runat="server" id="ErrMsg" class="text-danger"> </label> <br />
    <asp:Button ID="AddBtn" runat="server" Text="Save Presription" class="btn btn-warning btn-block" OnClick="AddBtn_Click" />
</div>
    
 
</form>
            </div>
            <div class ="col-md-8">
                <div class="row">
                    <div class="col">
                        <img src="../../Assets/Images/Lab.jpeg" height="200px" width="100%" class="rounded-3"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <h1>Prescriptions Details</h1>
                        <asp:GridView ID="PrescriptionGV" CssClass="table table-hover" runat="server" AutoGenerateSelectButton="True" ></asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
