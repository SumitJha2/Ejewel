<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCertificateMaster.aspx.cs" Inherits="EJewel.AdminView.Master.Certificate.ListCertificateMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript"> 
    var qs_name = '';
    var view =querystring('view');
    if (view.length > 0) {
        qs_name = view[0];
        if (qs_name != '') {
            $(function () {
                $('#lnkCreateNew').attr('href', '/Master/Certificate/ManageCertificateMaster.aspx?view=' + qs_name + '');
            });
        }
    }
    else {
    //redirect to mail page
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span12">                    
                        <div class="head clearfix">
                            <div class="isw-grid"></div>
                            <h1 id="headingText">Stone List</h1>
                            <ul class="buttons">
                                <li><a href="#" class="isw-download"></a></li>                                                        
                                <li>
                                    <a href="#" class="isw-settings"></a>
                                    <ul class="dd-list">
                                        <li><a href="javascript:void(0)" id="lnkCreateNew"><span class="isw-plus"></span>Add New</a></li>
                                        <li><a href="#"><span class="isw-refresh"></span>Refresh</a></li>
                                    </ul>
                                </li>
                            </ul>                        
                        </div>
                        <div class="block-fluid">
                        <table id="tableCertificateMaster"></table>
                        </div>
                        </div>
<script type="text/javascript" src="/asset/Script/Master/Certificate/CertificateMasterListScript.js"></script>
<script type="text/javascript">
    /*
    Partha Ranjan
    @ 28-12-12
    */
    //load grid on demand
    loadCertificateMaster(qs_name);
</script>
</asp:Content>
