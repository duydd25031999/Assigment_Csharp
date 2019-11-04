<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dictionary.aspx.cs" Inherits="FrontEnd.Dictionary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dynamic Dictionary</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            font-family: sans-serif;
        }

        #container {
            width: 80%;
            margin: auto;
        }

        h1 {
            margin-left: 20px;
            margin-bottom: 0;
        }

        span {
            color: blue;
        }

        #head-description {
            margin-top: 5px;
            margin-left: 35px;
        }

        #searchForm {
            margin: 50px auto;
            position: relative;
        }

        input[type=text] {
            width: 100%;
            height: 50px;
            font-size: 30px;
            box-sizing: border-box;
            padding: 0 250px 0 30px;
            border: 1px solid gray;
            border-radius: 1em 1em 1em 1em;
        }

        input[type=text]:focus {
            outline: none;
        }

        #selection {
            border-left: 1px solid gray;
            position: absolute;
            right: 30px;
            top: 10px;
            box-sizing: border-box;
            padding-left: 10px;
            height: 30px;
        }

        #selection > select {
            border: none;
            font-size: 18px;
            color: gray;
            position: relative;
            top: -6px;
        }

        #selection > select:focus, button:focus {
            outline: none;
        }

        #selection > button {
            background-color: white;
            border: none;
            font-size: 30px;
            color: gray;
            cursor: pointer;
        }

        #kindOfDictionary {
            color: red;
        }

        #volumnUp {
            position: absolute;
            top: 250px;
            right: 180px;
            color: gray;
        }


    </style>
</head>
<body>
    <div id="container">
        <h1><span>DYNAMIC</span> DICTIONARY</h1>
        <h3 id="head-description">Search in own dictionary</h3>

        <form id="searchForm" runat="server">
            <input type="text" name="keyWord" id="keyword" runat="server" placeholder="Tìm kiếm từ khóa..."/>
            <div id="selection">
                <select>
                    <option>Anh - Việt</option>
                    <option>Việt - Anh</option>
                </select>
                <%--<asp:Button ID="btSearch" class="searchButton" runat="server" OnClick="Search" Text="Search" />--%>
                <button class="searchButton" onserverclick="Search" runat="server"><i class="fa fa-search"></i></button>
            </div>
        </form>

        <div>
            <h3 id="kindOfDictionary">Từ điển Anh - Việt</h3>
            <span id="volumnUp"><i class="fa fa-volume-up"></i></span>
            <hr />
            <table>
                <tr>
                    <td style="color: gray;">[ɪkˈspɪə.ri.əns]</td>
                </tr>
                <tr>
                    <td style="color: blue;">* danh từ</td>
                </tr>
                <tr>
                    <td style="color: blue;">&emsp;kinh nghiệm</td>
                </tr>
                <tr>
                    <td style="color: blue;">&emsp;&emsp;- to lack experience</td>
                </tr>
                <tr>
                    <td style="color: gray;">&emsp;&emsp;thiếu kinh nghiệm</td>
                </tr>
                <tr>
                    <td style="color: blue;">&emsp;&emsp;- to learn by experience</td>
                </tr>
                <tr>
                    <td style="color: gray;">&emsp;&emsp;học hỏi qua kinh nghiệm</td>
                </tr>
                <tr>
                    <td style="color: blue;">&emsp;&emsp;- to have much experience of teaching</td>
                </tr>
                <tr>
                    <td style="color: gray;">&emsp;&emsp;có nhiều kinh nghiệm trong việc dạy học</td>
                </tr>
                <tr>
                    <td style="color: blue;">&emsp;&emsp;- to know something from experience</td>
                </tr>
                <tr>
                    <td style="color: gray;">&emsp;&emsp;do kinh nghiệm mà biết được điều gì</td>
                </tr>
            </table>
        </div>
        <div id="demo" runat="server"></div>
    </div>
</body>
</html>
