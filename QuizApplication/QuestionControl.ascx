<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionControl.ascx.cs" Inherits="QuizApplication.QuestionControl" %>
<%@ Register TagPrefix="uc2" TagName="TimerASP" Src="~/TimerASP.ascx" %>

<fieldset>
    <div class="pull-right">
                         <uc2:TimerASP ID="timerASP" runat="server" />
                    </div>
    <asp:UpdatePanel ID="updPnl" runat="server" UpdateMode="Conditional" RenderMode="Block">
        <ContentTemplate>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3>
                        <asp:Label ID="content" runat="server"></asp:Label></h3>
                   
                </div>
                <div class="panel-body">
                    <div class="pull-left">
                        <asp:Button ID="YesButton" runat="server" OnClick="YesButton_Click" Text="TAK" CssClass="btn btn-success" />
                        <asp:Button ID="NoButton" runat="server" OnClick="NoButton_Click" Text="NIE" CssClass="btn btn-danger" />
                    </div>

                    <div class="pull-right">
                        <asp:Button ID="Abort" runat="server" OnClick="Abort_Click" Text="Przerwij" CssClass="btn btn-warning" /></div>


                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>
