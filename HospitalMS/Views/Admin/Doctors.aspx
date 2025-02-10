<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="HospitalMS.Views.Admin.Doctors" enableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <h2>Doctors Detail</h2>
                <form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Doctor Name</label>
    <input type="text" class="form-control" id="DocNameTb" runat="server" required ="required" >
  </div>

    <div class="mb-3">
  <label for="DocPhoneTb" class="form-label">Phone Number</label>
  <input type="text" class="form-control" id="DocPhoneTb" runat="server" required ="required">
   </div>
    <div class="mb-3">
  <label for="DocExpTb" class="form-label">Experience</label>
  <input type="text" class="form-control" id="DocExpTb" runat="server" required ="required">
    </div>
    <div class="mb-3">
    <label for="DocSpecTb" class="form-label">Specialisation</label>
    <input type="text" class="form-control" id="DocSpecTb" runat="server" required ="required">
  </div>
  <div class="mb-3">
    <label for="PasswordTb" class="form-label">Password</label>
    <input type="password" class="form-control" id="PasswordTb" runat="server" required ="required">
  </div>
    <div class="mb-3">
    <label for="GenderTb" class="form-label">Gender</label>
    <asp:DropDownList ID="GenderCb" runat="server" class="form-control">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>
  </div>
    <div class="mb-3">
  <label for="AddressTb" class="form-label">Address</label>
  <input type="text" class="form-control" id="AddressTb" runat="server" required ="required">
</div>
   <div class="mb-3">
  <label for="DOBTb" class="form-label" >Date of Birth</label>
  <input type="date" class="form-control" id="DOBTb"  runat="server" >
</div>
<div class="mb-3">
  <label for="EmailTb" class="form-label text-primary">Email address</label>
  <input type="email" class="form-control" id="EmailTb" aria-describedby="emailHelp" runat="server">
</div>
    <label runat="server" id="ErrMsg" class="text-danger"> </label> <br />

  <asp:Button ID="EditBtn" runat="server" Text="Edit"  class="btn btn-warning" OnClick="EditBtn_Click" />
  <asp:Button ID="AddBtn" runat="server" Text="Save" class="btn btn-primary" OnClick="AddBtn_Click" />
  <asp:Button ID="DeleteBtn" runat="server" Text="Delete" class="btn btn-danger" OnClick="DeleteBtn_Click" />
</form>
            </div>
            <div class ="col-md-8">
                <div class="row">
                    <div class="col">
                        <img src="../../Assets/Images/Doctor.jpg" height="200px" width="100%" class="rounded-3"/>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <h1>Doctors Details</h1>
                        <asp:GridView ID="DoctorsGV" CssClass="table table-hover" runat="server" OnSelectedIndexChanged="DoctorsGV_SelectedIndexChanged" AutoGenerateSelectButton="True"></asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
