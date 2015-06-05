<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="p04_Edit.aspx.vb" Inherits="AppWeb1._4.p04_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #Ig {
            width: 100%;
            height: 100%;
        }

            #Ig ul {
                margin: 0;
                padding: 0;
                text-align: center;
                list-style: none;
            }

                #Ig ul li {
                    display:inline;
                    width: 100px;
                    height: 100px;
                    border: solid 1px #999;
                    margin: 5px 0 5px 0;
                    background-color: #fff;
                    position: relative;
                }

                    #Ig ul li img {
                        width: 100px;
                        height: 100px;
                        margin: 5px 0 5px 0;
                    }

                    #Ig ul li div {
                        position: absolute;
                        left: 0;
                        top: 0;
                    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Ig">
            <ul>
         <asp:Literal ID="L" runat="server"></asp:Literal>
                </ul>
        </div>

        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="上傳" />
    </form>
</body>
</html>
