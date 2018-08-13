<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionControl.ascx.cs" Inherits="QuizApplication.QuestionControl" %>
<fieldset>
    <asp:UpdatePanel ID="updPnl" runat="server" UpdateMode="Conditional" RenderMode="Block">
        <ContentTemplate>
            <asp:Label ID="content" runat="server"></asp:Label>
            <asp:Button ID="YesButton" runat="server" OnClick="YesButton_Click" Text="TAK" />
            <asp:Button ID="NoButton" runat="server" OnClick="NoButton_Click" Text="NIE" />
        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>
