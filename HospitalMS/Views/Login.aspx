<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HospitalMS.Views.Login" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Libs/Bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../CSS/Login.css" />
    <style>
body {
    background-image: url(../Assets/Images/hospital.jpg);
    background-size: cover;
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    margin: 0;
}

.login-container {
    background-color: rgba(255, 255, 255, 0.9);
    padding: 20px;
    border-radius: 10px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    width: 400px;
}

h1 {
    color: #007bff;
    margin-bottom: 20px;
}

button {
    width: 100%;
    padding: 10px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    margin-top: 10px;
}

button:hover {
    background-color: #0056b3;
}

.form-label {
    color: blue;
}

.T {
    color: blue;
    
}
    </style>
</head>
<body >
   <div class="container-fluid">
       <div class="row" style="height:120px">

       </div>
       <div class="row">
           <div class="col-md-4">
           </div>
           <div class="col-md-5 bg-light shadow-lg opacity-75 rounded-3">
               <h1 class="T pl-2 text-center">Heaven Care Clinic</h1>
                   <form id="form1" runat="server">
  <div class="mb-3">
    <label for="EmailTb" class="form-label text-primary">Email address</label>
    <input type="email" class="form-control" id="EmailTb" aria-describedby="emailHelp" runat="server">
  </div>
  <div class="mb-3">
    <label for="PasswordTb" class="form-label text-primary">Password</label>
    <input type="password" class="form-control" id="PasswordTb" runat="server">
  </div>
  <div class="mb-3 form-check">
    <asp:DropDownList ID="RoleCb" runat="server" class="form-control">
    <asp:ListItem>--Select Role--</asp:ListItem>
    <asp:ListItem>Admin</asp:ListItem>
    <asp:ListItem>Doctor</asp:ListItem>
    <asp:ListItem>Receptionist</asp:ListItem>
    <asp:ListItem>Laboratorian</asp:ListItem>
</asp:DropDownList>
  </div>
   <div class="d-grid">
       <label runat="server" id="ErrMsg" class="text-danger"> </label> <br />
       <asp:Button ID="Login" runat="server" Text="Login" class="btn btn-primary btn-block" OnClick="Login_Click" />
   </div>
</form>

           </div>
           <div class="col-md-3">
           </div>
       </div>
   </div>
   
</body>
</html>
