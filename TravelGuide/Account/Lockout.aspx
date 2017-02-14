<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lockout.aspx.cs" Inherits="TravelGuide.Account.Lockout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup>
        <h1 class="text-center">Locked out.</h1>
        <h4 class="text-danger text-center">You have entered incorrect credentials 5 times. The login service is locked for five minutes!</h4>
    </hgroup>
</asp:Content>
