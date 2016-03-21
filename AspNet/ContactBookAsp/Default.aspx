<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
   
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-info pull-right" OnClick="btnEdit_Click" Visible="false" />
                    </div>
                    <div class="col-md-6"></div>
                </div>
                <br />
                <asp:HiddenField ID="hfSrNo" runat="server" />

                <asp:Panel ID="pnl" runat="server">
                    <div class="col-md-6">
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblFirstName" runat="server" Text="First Name :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblMiddleName" runat="server" Text="MiddleName :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtLstName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblContactNo" runat="server" Text="Contact No :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblAddress" runat="server" Text="Address :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Rows="3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblCity" runat="server" Text="City :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblNativePlace" runat="server" Text="Native Place :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtNativePlace" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblEmail" runat="server" Text="Email :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblReference" runat="server" Text="Reference :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtReference" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblBdate" runat="server" Text="Birth Date :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtBdate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblExDate" runat="server" Text="Ex Date :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtExDate" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblEducation" runat="server" Text="Education :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtEducation" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblOccupation" runat="server" Text="Occupation :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtOccupation" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblDesignation" runat="server" Text="Designation :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblCompanyName" runat="server" Text="Company Name :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblWorkAddress" runat="server" Text="Work Address :" CssClass="control-label"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtWorkAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="pull-right">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </asp:Panel>

                <br />
                <div class="col-md-6">

                    <asp:GridView ID="gv" CssClass="table table-striped" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="SrNo" Text='<% #Bind("SrNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                            <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnSelect" runat="server" Text="Select" CssClass="btn btn-primary" OnClick="btnSelect_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-sm btn-primary" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


