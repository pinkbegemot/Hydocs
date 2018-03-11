<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WFdemo.aspx.cs" Inherits="Hydocs.WFdemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p ></p>
    <div class="container">
        
<h3>Hydocs: A WebForm calling REST API </h3>
        <p>NB! Editing is not implemented yet :(</p>
        <div class="row">
            <div class="table-scroll">
    <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1" OnItemEditing="ListView1_ItemEditing"  >
        <AlternatingItemTemplate>
            <tr style="background-color:#FFF8DC">
                <td>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="CustomerKeyLabel" runat="server" Text='<%# Eval("CustomerKey") %>' />
                </td>
                <td>
                    <asp:Label ID="GeographyKeyLabel" runat="server" Text='<%# Eval("GeographyKey") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerAlternateKeyLabel" runat="server" Text='<%# Eval("CustomerAlternateKey") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                </td>
                <td>
                    <asp:Label ID="MiddleNameLabel" runat="server" Text='<%# Eval("MiddleName") %>' />
                </td>
                <td>
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="NameStyleCheckBox" runat="server" Checked='<%# Eval("NameStyle") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="BirthDateLabel" runat="server" Text='<%# Eval("BirthDate") %>' />
                </td>
                <td>
                    <asp:Label ID="MaritalStatusLabel" runat="server" Text='<%# Eval("MaritalStatus") %>' />
                </td>
                <td>
                    <asp:Label ID="SuffixLabel" runat="server" Text='<%# Eval("Suffix") %>' />
                </td>
                <td>
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                </td>
                <td>
                    <asp:Label ID="EmailAddressLabel" runat="server" Text='<%# Eval("EmailAddress") %>' />
                </td>
                <td>
                    <asp:Label ID="YearlyIncomeLabel" runat="server" Text='<%# Eval("YearlyIncome") %>' />
                </td>
                <td>
                    <asp:Label ID="TotalChildrenLabel" runat="server" Text='<%# Eval("TotalChildren") %>' />
                </td>
                <td>
                    <asp:Label ID="NumberChildrenAtHomeLabel" runat="server" Text='<%# Eval("NumberChildrenAtHome") %>' />
                </td>
                <td>
                    <asp:Label ID="EnglishEducationLabel" runat="server" Text='<%# Eval("EnglishEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="SpanishEducationLabel" runat="server" Text='<%# Eval("SpanishEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="FrenchEducationLabel" runat="server" Text='<%# Eval("FrenchEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="EnglishOccupationLabel" runat="server" Text='<%# Eval("EnglishOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="SpanishOccupationLabel" runat="server" Text='<%# Eval("SpanishOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="FrenchOccupationLabel" runat="server" Text='<%# Eval("FrenchOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="HouseOwnerFlagLabel" runat="server" Text='<%# Eval("HouseOwnerFlag") %>' />
                </td>
                <td>
                    <asp:Label ID="NumberCarsOwnedLabel" runat="server" Text='<%# Eval("NumberCarsOwned") %>' />
                </td>
                <td>
                    <asp:Label ID="AddressLine1Label" runat="server" Text='<%# Eval("AddressLine1") %>' />
                </td>
                <td>
                    <asp:Label ID="AddressLine2Label" runat="server" Text='<%# Eval("AddressLine2") %>' />
                </td>
                <td>
                    <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                </td>
                <td>
                    <asp:Label ID="DateFirstPurchaseLabel" runat="server" Text='<%# Eval("DateFirstPurchase") %>' />
                </td>
                <td>
                    <asp:Label ID="CommuteDistanceLabel" runat="server" Text='<%# Eval("CommuteDistance") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
     
        <EditItemTemplate>
            <tr style="background-color:#008A8C; color: #FFFFFF;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:TextBox ID="CustomerKeyTextBox" runat="server" Text='<%# Bind("CustomerKey") %>' />
                </td>
                <td>
                    <asp:TextBox ID="GeographyKeyTextBox" runat="server" Text='<%# Bind("GeographyKey") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CustomerAlternateKeyTextBox" runat="server" Text='<%# Bind("CustomerAlternateKey") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="NameStyleCheckBox" runat="server" Checked='<%# Bind("NameStyle") %>' />
                </td>
                <td>
                    <asp:TextBox ID="BirthDateTextBox" runat="server" Text='<%# Bind("BirthDate") %>' />
                </td>
                <td>
                    <asp:TextBox ID="MaritalStatusTextBox" runat="server" Text='<%# Bind("MaritalStatus") %>' />
                </td>
                <td>
                    <asp:TextBox ID="SuffixTextBox" runat="server" Text='<%# Bind("Suffix") %>' />
                </td>
                <td>
                    <asp:TextBox ID="GenderTextBox" runat="server" Text='<%# Bind("Gender") %>' />
                </td>
                <td>
                    <asp:TextBox ID="EmailAddressTextBox" runat="server" Text='<%# Bind("EmailAddress") %>' />
                </td>
                <td>
                    <asp:TextBox ID="YearlyIncomeTextBox" runat="server" Text='<%# Bind("YearlyIncome") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TotalChildrenTextBox" runat="server" Text='<%# Bind("TotalChildren") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NumberChildrenAtHomeTextBox" runat="server" Text='<%# Bind("NumberChildrenAtHome") %>' />
                </td>
                <td>
                    <asp:TextBox ID="EnglishEducationTextBox" runat="server" Text='<%# Bind("EnglishEducation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="SpanishEducationTextBox" runat="server" Text='<%# Bind("SpanishEducation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="FrenchEducationTextBox" runat="server" Text='<%# Bind("FrenchEducation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="EnglishOccupationTextBox" runat="server" Text='<%# Bind("EnglishOccupation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="SpanishOccupationTextBox" runat="server" Text='<%# Bind("SpanishOccupation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="FrenchOccupationTextBox" runat="server" Text='<%# Bind("FrenchOccupation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="HouseOwnerFlagTextBox" runat="server" Text='<%# Bind("HouseOwnerFlag") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NumberCarsOwnedTextBox" runat="server" Text='<%# Bind("NumberCarsOwned") %>' />
                </td>
                <td>
                    <asp:TextBox ID="AddressLine1TextBox" runat="server" Text='<%# Bind("AddressLine1") %>' />
                </td>
                <td>
                    <asp:TextBox ID="AddressLine2TextBox" runat="server" Text='<%# Bind("AddressLine2") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DateFirstPurchaseTextBox" runat="server" Text='<%# Bind("DateFirstPurchase") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CommuteDistanceTextBox" runat="server" Text='<%# Bind("CommuteDistance") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="CustomerKeyTextBox" runat="server" Text='<%# Bind("CustomerKey") %>' />
                </td>
                <td>
                    <asp:TextBox ID="GeographyKeyTextBox" runat="server" Text='<%# Bind("GeographyKey") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CustomerAlternateKeyTextBox" runat="server" Text='<%# Bind("CustomerAlternateKey") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="MiddleNameTextBox" runat="server" Text='<%# Bind("MiddleName") %>' />
                </td>
                <td>
                    <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="NameStyleCheckBox" runat="server" Checked='<%# Bind("NameStyle") %>' />
                </td>
                <td>
                    <asp:TextBox ID="BirthDateTextBox" runat="server" Text='<%# Bind("BirthDate") %>' />
                </td>
                <td>
                    <asp:TextBox ID="MaritalStatusTextBox" runat="server" Text='<%# Bind("MaritalStatus") %>' />
                </td>
                <td>
                    <asp:TextBox ID="SuffixTextBox" runat="server" Text='<%# Bind("Suffix") %>' />
                </td>
                <td>
                    <asp:TextBox ID="GenderTextBox" runat="server" Text='<%# Bind("Gender") %>' />
                </td>
                <td>
                    <asp:TextBox ID="EmailAddressTextBox" runat="server" Text='<%# Bind("EmailAddress") %>' />
                </td>
                <td>
                    <asp:TextBox ID="YearlyIncomeTextBox" runat="server" Text='<%# Bind("YearlyIncome") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TotalChildrenTextBox" runat="server" Text='<%# Bind("TotalChildren") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NumberChildrenAtHomeTextBox" runat="server" Text='<%# Bind("NumberChildrenAtHome") %>' />
                </td>
                <td>
                    <asp:TextBox ID="EnglishEducationTextBox" runat="server" Text='<%# Bind("EnglishEducation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="SpanishEducationTextBox" runat="server" Text='<%# Bind("SpanishEducation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="FrenchEducationTextBox" runat="server" Text='<%# Bind("FrenchEducation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="EnglishOccupationTextBox" runat="server" Text='<%# Bind("EnglishOccupation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="SpanishOccupationTextBox" runat="server" Text='<%# Bind("SpanishOccupation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="FrenchOccupationTextBox" runat="server" Text='<%# Bind("FrenchOccupation") %>' />
                </td>
                <td>
                    <asp:TextBox ID="HouseOwnerFlagTextBox" runat="server" Text='<%# Bind("HouseOwnerFlag") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NumberCarsOwnedTextBox" runat="server" Text='<%# Bind("NumberCarsOwned") %>' />
                </td>
                <td>
                    <asp:TextBox ID="AddressLine1TextBox" runat="server" Text='<%# Bind("AddressLine1") %>' />
                </td>
                <td>
                    <asp:TextBox ID="AddressLine2TextBox" runat="server" Text='<%# Bind("AddressLine2") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DateFirstPurchaseTextBox" runat="server" Text='<%# Bind("DateFirstPurchase") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CommuteDistanceTextBox" runat="server" Text='<%# Bind("CommuteDistance") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color:#DCDCDC; color: #000000;">
                <td>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="CustomerKeyLabel" runat="server" Text='<%# Eval("CustomerKey") %>' />
                </td>
                <td>
                    <asp:Label ID="GeographyKeyLabel" runat="server" Text='<%# Eval("GeographyKey") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerAlternateKeyLabel" runat="server" Text='<%# Eval("CustomerAlternateKey") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                </td>
                <td>
                    <asp:Label ID="MiddleNameLabel" runat="server" Text='<%# Eval("MiddleName") %>' />
                </td>
                <td>
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="NameStyleCheckBox" runat="server" Checked='<%# Eval("NameStyle") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="BirthDateLabel" runat="server" Text='<%# Eval("BirthDate") %>' />
                </td>
                <td>
                    <asp:Label ID="MaritalStatusLabel" runat="server" Text='<%# Eval("MaritalStatus") %>' />
                </td>
                <td>
                    <asp:Label ID="SuffixLabel" runat="server" Text='<%# Eval("Suffix") %>' />
                </td>
                <td>
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                </td>
                <td>
                    <asp:Label ID="EmailAddressLabel" runat="server" Text='<%# Eval("EmailAddress") %>' />
                </td>
                <td>
                    <asp:Label ID="YearlyIncomeLabel" runat="server" Text='<%# Eval("YearlyIncome") %>' />
                </td>
                <td>
                    <asp:Label ID="TotalChildrenLabel" runat="server" Text='<%# Eval("TotalChildren") %>' />
                </td>
                <td>
                    <asp:Label ID="NumberChildrenAtHomeLabel" runat="server" Text='<%# Eval("NumberChildrenAtHome") %>' />
                </td>
                <td>
                    <asp:Label ID="EnglishEducationLabel" runat="server" Text='<%# Eval("EnglishEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="SpanishEducationLabel" runat="server" Text='<%# Eval("SpanishEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="FrenchEducationLabel" runat="server" Text='<%# Eval("FrenchEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="EnglishOccupationLabel" runat="server" Text='<%# Eval("EnglishOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="SpanishOccupationLabel" runat="server" Text='<%# Eval("SpanishOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="FrenchOccupationLabel" runat="server" Text='<%# Eval("FrenchOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="HouseOwnerFlagLabel" runat="server" Text='<%# Eval("HouseOwnerFlag") %>' />
                </td>
                <td>
                    <asp:Label ID="NumberCarsOwnedLabel" runat="server" Text='<%# Eval("NumberCarsOwned") %>' />
                </td>
                <td>
                    <asp:Label ID="AddressLine1Label" runat="server" Text='<%# Eval("AddressLine1") %>' />
                </td>
                <td>
                    <asp:Label ID="AddressLine2Label" runat="server" Text='<%# Eval("AddressLine2") %>' />
                </td>
                <td>
                    <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                </td>
                <td>
                    <asp:Label ID="DateFirstPurchaseLabel" runat="server" Text='<%# Eval("DateFirstPurchase") %>' />
                </td>
                <td>
                    <asp:Label ID="CommuteDistanceLabel" runat="server" Text='<%# Eval("CommuteDistance") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color:#DCDCDC; color: #000000;">
                                <th runat="server"></th>
                                <th runat="server">CustomerKey</th>
                                <th runat="server">GeographyKey</th>
                                <th runat="server">CustomerAlternateKey</th>
                                <th runat="server">Title</th>
                                <th runat="server">FirstName</th>
                                <th runat="server">MiddleName</th>
                                <th runat="server">LastName</th>
                                <th runat="server">NameStyle</th>
                                <th runat="server">BirthDate</th>
                                <th runat="server">MaritalStatus</th>
                                <th runat="server">Suffix</th>
                                <th runat="server">Gender</th>
                                <th runat="server">EmailAddress</th>
                                <th runat="server">YearlyIncome</th>
                                <th runat="server">TotalChildren</th>
                                <th runat="server">NumberChildrenAtHome</th>
                                <th runat="server">EnglishEducation</th>
                                <th runat="server">SpanishEducation</th>
                                <th runat="server">FrenchEducation</th>
                                <th runat="server">EnglishOccupation</th>
                                <th runat="server">SpanishOccupation</th>
                                <th runat="server">FrenchOccupation</th>
                                <th runat="server">HouseOwnerFlag</th>
                                <th runat="server">NumberCarsOwned</th>
                                <th runat="server">AddressLine1</th>
                                <th runat="server">AddressLine2</th>
                                <th runat="server">Phone</th>
                                <th runat="server">DateFirstPurchase</th>
                                <th runat="server">CommuteDistance</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                     </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color:#008A8C; font-weight: bold;color: #FFFFFF;">
                <td>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="CustomerKeyLabel" runat="server" Text='<%# Eval("CustomerKey") %>' />
                </td>
                <td>
                    <asp:Label ID="GeographyKeyLabel" runat="server" Text='<%# Eval("GeographyKey") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerAlternateKeyLabel" runat="server" Text='<%# Eval("CustomerAlternateKey") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                </td>
                <td>
                    <asp:Label ID="MiddleNameLabel" runat="server" Text='<%# Eval("MiddleName") %>' />
                </td>
                <td>
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="NameStyleCheckBox" runat="server" Checked='<%# Eval("NameStyle") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="BirthDateLabel" runat="server" Text='<%# Eval("BirthDate") %>' />
                </td>
                <td>
                    <asp:Label ID="MaritalStatusLabel" runat="server" Text='<%# Eval("MaritalStatus") %>' />
                </td>
                <td>
                    <asp:Label ID="SuffixLabel" runat="server" Text='<%# Eval("Suffix") %>' />
                </td>
                <td>
                    <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                </td>
                <td>
                    <asp:Label ID="EmailAddressLabel" runat="server" Text='<%# Eval("EmailAddress") %>' />
                </td>
                <td>
                    <asp:Label ID="YearlyIncomeLabel" runat="server" Text='<%# Eval("YearlyIncome") %>' />
                </td>
                <td>
                    <asp:Label ID="TotalChildrenLabel" runat="server" Text='<%# Eval("TotalChildren") %>' />
                </td>
                <td>
                    <asp:Label ID="NumberChildrenAtHomeLabel" runat="server" Text='<%# Eval("NumberChildrenAtHome") %>' />
                </td>
                <td>
                    <asp:Label ID="EnglishEducationLabel" runat="server" Text='<%# Eval("EnglishEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="SpanishEducationLabel" runat="server" Text='<%# Eval("SpanishEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="FrenchEducationLabel" runat="server" Text='<%# Eval("FrenchEducation") %>' />
                </td>
                <td>
                    <asp:Label ID="EnglishOccupationLabel" runat="server" Text='<%# Eval("EnglishOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="SpanishOccupationLabel" runat="server" Text='<%# Eval("SpanishOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="FrenchOccupationLabel" runat="server" Text='<%# Eval("FrenchOccupation") %>' />
                </td>
                <td>
                    <asp:Label ID="HouseOwnerFlagLabel" runat="server" Text='<%# Eval("HouseOwnerFlag") %>' />
                </td>
                <td>
                    <asp:Label ID="NumberCarsOwnedLabel" runat="server" Text='<%# Eval("NumberCarsOwned") %>' />
                </td>
                <td>
                    <asp:Label ID="AddressLine1Label" runat="server" Text='<%# Eval("AddressLine1") %>' />
                </td>
                <td>
                    <asp:Label ID="AddressLine2Label" runat="server" Text='<%# Eval("AddressLine2") %>' />
                </td>
                <td>
                    <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                </td>
                <td>
                    <asp:Label ID="DateFirstPurchaseLabel" runat="server" Text='<%# Eval("DateFirstPurchase") %>' />
                </td>
                <td>
                    <asp:Label ID="CommuteDistanceLabel" runat="server" Text='<%# Eval("CommuteDistance") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
            </div>
              </div>
 
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCustomers" TypeName="Hydocs.Areas.AdWorks.Controllers.CustomersMVController" DataObjectTypeName="Hydocs.Areas.AdWorks.Models.DB.Customer" InsertMethod="Create" UpdateMethod="Edit" OnUpdating="ObjectDataSource1_Updating">
    </asp:ObjectDataSource>
  </div>
</asp:Content>
