<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyPage.aspx.cs" Inherits="FrontEnd.MyPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Page</title>

	<link rel="stylesheet" href="css/style_mypage.css"/>
</head>
<body>
    <div class="header">
            <div class="header-left">
                <h1><span>DYNAMIC</span> DICTIONARY</h1>
                <h3 id="head-description">Search in own dictionary</h3>
            </div>
            <div class="header-right">
                <button runat="server" id="btnUserChange" onserverclick="ChangeUser"></button>
                <a runat="server" id="lblUsername"></a>
                <a runat="server" id="lblDictionary" href="Dictionary.aspx">Dictionary</a>
            </div>
        </div>
    <hr />
    <form id="form1" runat="server">
        <div id="page_content" runat="server"></div>
    </form>
</body>
</html>
