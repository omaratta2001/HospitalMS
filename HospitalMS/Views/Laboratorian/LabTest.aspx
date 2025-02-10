<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Laboratorian/LaboratorianMaster.Master" AutoEventWireup="true" CodeBehind="LabTest.aspx.cs" Inherits="HospitalMS.Views.Laboratorian.LabTest" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
        <div class="container-fluid">
            <div class="row" style="height:50px">

            </div>
        <div class="row">
            <div class="col-md-4">
                <h2>Laboratory Test Details</h2>
                <form>
  <div class="mb-3">
    <label for="exampleInputEmail1" class="form-label">Lab TestName</label>
    <input type="text" class="form-control" id="LabNameTb" runat="server" required ="required"/>
  </div>
    <div class="mb-3">
  <label for="TestCostTb" class="form-label">Test Cost</label>
  <input type="text" class="form-control" id="TestCostTb" runat="server" required ="required"/>
   </div>
    <div class="row" style="height:150px"></div>

    <label runat="server" id="ErrMsg" class="text-danger"></label>
                    <br />

                    <asp:Button ID="EditBtn" runat="server" Text="  Edit  " class="btn btn-warning" OnClick="EditBtn_Click" />
                    <asp:Button ID="AddBtn" runat="server" Text="  Save  " class="btn btn-primary" OnClick="AddBtn_Click" />
                    <asp:Button ID="DeleteBtn" runat="server" Text="  Delete  " class="btn btn-danger" OnClick="DeleteBtn_Click" />
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
                        <h1>Laboratory Test Details</h1>
                        <asp:GridView ID="LabTestGV" CssClass="table table-hover" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="LabTestGV_SelectedIndexChanged"></asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
