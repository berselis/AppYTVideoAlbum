<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutMain.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppYTVideoAlbum.Default" %>

<asp:Content ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <div class="col-md-12">
            <h3 class="text-center"><strong>YTVideos album</strong></h3>
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <h4><strong>Añadir nuevo video</strong></h4>
            <div class="input-group input-group-lg">
                <asp:TextBox runat="server" ID="UrlText" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" ID="BtnAddUrl" Text="Añadir" CssClass="btn btn-primary btn-lg" Font-Bold="True" OnClick="BtnAddUrl_Click" />
            </div>
             <asp:Label ID="LabelMsj" runat="server" CssClass="msj-error" Visible="False"></asp:Label>

        </div>
    </div>

    <asp:Panel runat="server" ID="PanelVideoList" CssClass="panel-video-list">

        <div class="card-video">
            <asp:HyperLink runat="server" CssClass="btn-close btn-delete-video" aria-label="Close"></asp:HyperLink>
            <asp:HyperLink runat="server" CssClass="bnt-view-detail">
                <asp:Image CssClass="img-fluid" runat="server" ImageUrl="https://logos-world.net/wp-content/uploads/2020/04/Huawei-Logo.png"/>
            </asp:HyperLink>
        </div>

         <div class="card-video">
            <asp:HyperLink runat="server" CssClass="btn-close btn-delete-video" aria-label="Close"></asp:HyperLink>
            <asp:HyperLink runat="server" CssClass="bnt-view-detail">
                <asp:Image CssClass="img-fluid" runat="server" ImageUrl="https://logos-world.net/wp-content/uploads/2020/12/Lays-Logo.png"/>
            </asp:HyperLink>
        </div>


    </asp:Panel>
    
   

    

</asp:Content>


