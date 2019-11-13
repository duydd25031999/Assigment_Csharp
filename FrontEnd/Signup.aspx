<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="FrontEnd.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Signup Form</title>
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
		    <div class="login-box">
			    <div class="box-header">
				    <h2>Signup form</h2>
			    </div>
                <p class="contact">
                    <label for="txtEmail">Email</label>
                </p>
                <input runat="server" id="txtEmail" name="email" placeholder="example@domain.com" required="" type="text"/>
                <p class="contact">
                    <label for="txtName">Create a username</label>
                </p>
                <input runat="server" id="txtName" name="username" placeholder="username" required="" tabindex="2" type="text"/>
                <p class="contact">
                    <label for="txtPassword">Create a password</label>
                </p>
                <input runat="server" id="txtPassword" name="password" required="" type="password"/>
                
                <p class="contact">
                    <label for="txtDob">Create a username</label>
                </p>
                <input runat="server" id="txtDob" name="dob" placeholder="dd/mm/yyyy" required="" tabindex="2" type="text"/>
                <br/>
                <p class="warning" runat="server" id="pWarning"></p>
                <button runat="server" id="btnSignup" onserverclick="SignupExcute">Sign Up</button>
		    </div>
	    </div>
    </form>
</body>
</html>
