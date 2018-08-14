<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimerASP.ascx.cs" Inherits="QuizApplication.TimerASP" %>
    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1>
            <asp:Label CssClass="label label-default" ID="time" runat="server">0</asp:Label>
            </h1>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>