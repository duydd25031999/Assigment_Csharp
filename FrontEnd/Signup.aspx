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
                    <label for="name">Name</label>
                </p>
                <input id="name" name="name" placeholder="First and last name" required="" tabindex="1" type="text"/>
                <p class="contact">
                    <label for="email">Email</label>
                </p>
                <input id="email" name="email" placeholder="example@domain.com" required="" type="email"/>
                <p class="contact">
                    <label for="username">Create a username</label>
                </p>
                <input id="username" name="username" placeholder="username" required="" tabindex="2" type="text"/>
                <p class="contact">
                    <label for="password">Create a password</label>
                </p>
                <input id="password" name="password" required="" type="text"/>
                <p class="contact">
                    <label for="repassword">Confirm your password</label>
                </p>
                <input id="repassword" name="password" required="" type="text"/>
                
                <label for="birthday">Birthdate</label>
                <input type="date" name="bday" min="1930-01-01" max="2019-12-31"/>

                <label for="gender">Gender</label>
                <select class="select-style gender" name="gender">
                    <option value="select">i am..</option>
                    <option value="m">Male</option>
                    <option value="f">Female</option>
                    <option value="others">Other</option>
                </select><br/>
                <br/>
                <p class="contact">
                    <label for="phone">Mobile phone</label>
                </p>
                <input id="phone" name="phone" placeholder="phone number" required="" type="text"/>
                <br/>
                <button type="submit">Sign Up</button>
		</div>
	</div>
    </form>
</body>
</html>
