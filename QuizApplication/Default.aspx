<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuizApplication._Default" %>
<%@ Register TagPrefix="uc2" TagName="TimerASP" Src="~/TimerASP.ascx" %>
<%@ Register TagPrefix="uc" TagName="QuestionControl" Src="~/QuestionControl.ascx" %>

<script runat="server">



</script>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="false">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1">
                <div class="content">
                    <asp:Button ID="StartQuizButton" runat="server" OnClick="StartQuizButton_Click" Text="Start" />
                </div>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2">
                <div class="content">
                    <uc2:TimerASP ID="timerASP" runat="server"/>
                    <uc:QuestionControl ID="question" runat="server"></uc:QuestionControl>
                    <asp:Button ID="Abort" runat="server" OnClick="Abort_Click" Text="Przerwij" />
                </div>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3">
                <div class="content">Szczęśliwe zakończenie</div>
            </asp:WizardStep>

            <asp:WizardStep ID="WizardStep4" runat="server" Title="Step 3">
                <div class="content">Pechowe zakończenie</div>
            </asp:WizardStep>

        </WizardSteps>
        <StartNavigationTemplate>
        </StartNavigationTemplate>
        <StepNavigationTemplate>
        </StepNavigationTemplate>
        <FinishNavigationTemplate>
        </FinishNavigationTemplate>
    </asp:Wizard>
   


</asp:Content>
