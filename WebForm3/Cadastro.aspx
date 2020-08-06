<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="WebForm3.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfIdPessoa" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>

                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtNome" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Idade"></asp:Label>

                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtIdade" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Cidade"></asp:Label>

                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtCidade" runat="server"></asp:TextBox>

                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="E-mail"></asp:Label>

                </td>
                <td colspan="2">
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
                    

                </td>
                <td colspan="2">
                    <asp:Button ID="ButtonSalvar" runat="server" Text="Salvar" OnClick="ButtonSalvar_Click" />
                    <asp:Button ID="ButtonExcluir" runat="server" Text="Excluir" OnClick="ButtonExcluir_Click" />
                    <asp:Button ID="ButtonLimpar" runat="server" Text="Limpar" OnClick="ButtonLimpar_Click" />

                </td>
            </tr>
              <tr>
                <td>
                    

                </td>
                <td colspan="2">
                    <asp:Label ID="LabelSucessoMensagem" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
            </tr>
              <tr>
                <td>
                    

                </td>
                <td colspan="2">
                    <asp:Label ID="LabelErroMensagem" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
            <br />
            <asp:GridView ID="gvCadastro" runat="server" AutoGenerateColumns="false" >
               <Columns>
                   <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Idade" HeaderText="Idade" />
                    <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
                     <asp:BoundField DataField="Email" HeaderText="Email" />
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:LinkButton ID="LinkView" runat="server" CommandArgument='<%# Eval("IdPessoa") %>' OnClick="lnk_OnClick" >View</asp:LinkButton>
                   </ItemTemplate>
               </asp:TemplateField>
               </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
