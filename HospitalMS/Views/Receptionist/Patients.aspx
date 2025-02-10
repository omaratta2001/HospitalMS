<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Receptionist/ReceptionistMaster.Master" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="HospitalMS.Views.Laboratorian.Patients" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <h2>Patient Detail</h2>
                <form>
  <div class="mb-3">
    <label for="PatName" class="form-label">Name</label>
    <input type="text" class="form-control" id="PatNameTb" runat="server" required ="required"/>
  </div>
    <div class="mb-3">
  <label for="PatPhone" class="form-label">PHone</label>
  <input type="text" class="form-control" id="PatPhoneTb" runat="server" required ="required"/>
   </div>
    <div class="mb-3">
 <label for="GenderTb" class="form-label">Gender</label>
<asp:DropDownList ID="GenderCb" runat="server" class="form-control">
    <asp:ListItem>Male</asp:ListItem>
    <asp:ListItem>Female</asp:ListItem>
</asp:DropDownList>
    </div>
    <div class="mb-3">
    <label for="PatDOB" class="form-label">Date of Birth</label>
    <input type="date" class="form-control" id="PatDOBTb" runat="server" required ="required"/>
  </div>
  <div class="mb-3">
    <label for="PatAddressTb" class="form-label">Address</label>
    <input type="text" class="form-control" id="PatAddressTb" runat="server" required ="required"/>
  </div>
    <div class="mb-3">
    <label for="PatAllergies" class="form-label">Allergies</label>
    <input type="text" class="form-control" id="PatAllergiesTb" runat="server" required ="required"/>
  </div>
    
    <label runat="server" id="ErrMsg" class="text-danger"> </label> <br />

                    <asp:Button ID="EditBtn" runat="server" Text="Edit" class="btn btn-warning" OnClick="EditBtn_Click" />
                    <asp:Button ID="AddBtn" runat="server" Text="Save" class="btn btn-primary" OnClick="AddBtn_Click" />
                    <asp:Button ID="DeleteBtn" runat="server" Text="Delete" class="btn btn-danger" OnClick="DeleteBtn_Click" />
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
                        <h1>Patients Details</h1>
                        <asp:GridView ID="PatientGV" CssClass="table table-hover" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="PatientGV_SelectedIndexChanged"></asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
