<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblMiddleName" runat="server" Text="MiddleName :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtLstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblContactNo" runat="server" Text="Contact No :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblAddress" runat="server" Text="Address :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Rows="3"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblCity" runat="server" Text="City :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblNativePlace" runat="server" Text="Native Place :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtNativePlace" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblEmail" runat="server" Text="Email :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblReference" runat="server" Text="Reference :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtReference" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblBdate" runat="server" Text="Birth Date :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtBdate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblExDate" runat="server" Text="Ex Date :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtExDate" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblEducation" runat="server" Text="Education :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtEducation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblOccupation" runat="server" Text="Occupation :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblDesignation" runat="server" Text="Designation :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblCompanyName" runat="server" Text="Company Name :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:Label ID="lblWorkAddress" runat="server" Text="Work Address :" CssClass="control-label"></asp:Label>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtWorkAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">

        </div>
    </div>

</asp:Content>
