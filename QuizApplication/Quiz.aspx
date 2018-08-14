<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="QuizApplication.Quiz" %>

<%@ Register TagPrefix="uc" TagName="QuestionControl" Src="~/QuestionControl.ascx" %>
<%@ Register TagPrefix="uc2" TagName="EntryList" Src="~/EntryList.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-top: 50px">
        <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="false" Width="100%">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                    <div class="content">
                        <div class="panel panel-default">
                            <div class="panel-heading">Rozpocznij Quiz</div>
                            <div class="panel-body">
                                <asp:Button ID="StartQuizButton" runat="server" OnClick="StartQuizButton_Click" Text="Start" CssClass="btn btn-primary" /></div>
                        </div>

                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
                    <div class="content">
                        <uc:QuestionControl ID="question" runat="server"></uc:QuestionControl>
                        <asp:Button ID="Abort" runat="server" OnClick="Abort_Click" Text="Przerwij" />
                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3">
                    <div class="content">
                        <uc2:EntryList ID="Entries" runat="server" />
                    </div>
                </asp:WizardStep>

                <asp:WizardStep ID="WizardStep4" runat="server" Title="Step 3">
                    <div class="content">
                       <h3> <span class="label label-danger">Niestety, odpowiedź nieprawidłowa, spróbuj jeszcze raz</span></h3>
                        <asp:Button Id="RestartButton" runat="server" OnClick="RestartButton_Click" Text="Spróbuj ponownie"/>
                    </div>
                </asp:WizardStep>

            </WizardSteps>
    <startnavigationtemplate>
        </startnavigationtemplate>
    <stepnavigationtemplate>
        </stepnavigationtemplate>
    <finishnavigationtemplate>
        </finishnavigationtemplate>
    </asp:Wizard>
         </div>
  
</asp:Content>

