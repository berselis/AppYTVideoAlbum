<%@ Page Title="" Language="C#" MasterPageFile="~/LayoutMain.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppYTVideoAlbum.Default" %>

<asp:Content ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" CssClass="content-place-holder">

    <!-- Modal | Dialogo para remover video -->
    <button hidden id="BtnShowModalDelete" type="button" data-bs-toggle="modal" data-bs-target="#ModalDelete"></button>
    <div class="modal fade" id="ModalDelete" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title fs-5"><strong>¿Seguro quieres eliminar este video?</strong></h3>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-primary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:TextBox ID="IdVideoDelete" runat="server" ClientIDMode="Static" CssClass="hidden-element"></asp:TextBox>
                    <asp:Button ID="BtnConfirmDelete" runat="server" Text="Eliminar" CssClass="btn btn-primary" OnClick="BtnConfirmRemove_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal | para mostrar detalles del video-->
    <button hidden id="BtnShowModalDetail" type="button" data-bs-toggle="modal" data-bs-target="#ModalDetails"></button>
    <div class="modal fade" id="ModalDetails" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered modal-lg modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="thumbnail-video-play">
                                <asp:Button ID="BtnVideoPlay" runat="server" Text="Play" CssClass="btn-video-play" ClientIDMode="Static" OnClick="BtnVideoPlay_Click"/>
                                <img id="BtnImgPlay" src="/" class="img-video-paly" />
                                 <asp:TextBox ID="IdVideoPlay" runat="server" ClientIDMode="Static" CssClass="hidden-element"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <h5><strong id="TittleDetail">Titulo</strong></h5>
                            <p id="DescriptDetail">Descripción</p>
                        </div>
                    </div>
                </div>

                <div class="modal-footer"></div>
            </div>
        </div>
    </div>


    <!--Titulo de la app -->
    <div class="row">
        <div class="col-md-12">
            <h3 class="text-center"><strong>YTVideos album</strong></h3>
            <hr />
        </div>
    </div>

    <!--Input de la url -->
    <div class="row">
        <div class="col-md-12">
            <h4><strong>Añadir nuevo video</strong></h4>
            <div class="input-group input-group-lg">
                <asp:TextBox runat="server" ID="UrlText" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" ID="BtnAddUrl" Text="Añadir" CssClass="btn btn-primary btn-lg" Font-Bold="True" OnClick="BtnAddUrl_Click" ClientIDMode="Static" />
            </div>
            <asp:Label ID="LabelMsj" runat="server" CssClass="msj-error" Visible="False"></asp:Label>

        </div>
    </div>

    <!--Panel listado de videos -->
    <asp:Panel runat="server" ID="PanelVideoList" CssClass="panel-video-list"></asp:Panel>

    <!--Script para el modal de manera dinámica -->
    <script type="text/javascript">
        const deleteButtons = document.querySelectorAll('.btn-delete-video');
        deleteButtons.forEach(btn => {
            btn.addEventListener('click', (e) => {
                const IdVideo = e.target.id.split('_')[1];
                const input = document.getElementById('IdVideoDelete');
                input.value = IdVideo;
                const btnShowModal = document.getElementById('BtnShowModalDelete');
                btnShowModal.click();
            });
        });


        const details = document.querySelectorAll('.view-detail');
        details.forEach(detail => {
            detail.addEventListener('click', (e) => {

                const IdVideo = e.target.id.split('_')[1];
                const label = document.getElementById(`MainContent_${IdVideo}_Label`);

                const video = JSON.parse(label.innerText);

                BtnImgPlay.src = video.UrlImg;
                TittleDetail.innerText = video.Tittle;
                DescriptDetail.innerText = video.Descript; IdVideoPlay
                const input = document.getElementById('IdVideoPlay');
                input.value = IdVideo;


                const btndModal = document.getElementById('BtnShowModalDetail');
                btndModal.click();
            });
        });


    </script>



</asp:Content>


