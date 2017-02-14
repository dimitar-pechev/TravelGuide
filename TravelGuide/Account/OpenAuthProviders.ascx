<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="TravelGuide.Account.OpenAuthProviders" %>

<div id="socialLoginList">
    <div class="separator">
        <p>or</p>
    </div>
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default btn-login btn-facebook" name="provider" value="<%#: Item %>"
                    title="Log in using your <%#: Item %> account.">
                    <img src="../Images/fb-art.png" alt="fb-icon" class="fb-icon pull-left" />    Connect with <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>There are no external authentication services configured. See <a href="http://go.microsoft.com/fwlink/?LinkId=252803">this article</a> for details on setting up this ASP.NET application to support logging in via external services.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>
