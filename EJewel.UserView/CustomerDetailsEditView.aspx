<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDetailsEditView.aspx.cs" Inherits="EJewel.UserView.CustomerDetailsEditView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




<div class="container push-below-header">
			<div class="row">
				<div class="span12">
					<h2 class="section-heading noBottom">Register Account</h2>
				</div>
			</div>

			<div class="row">
				<div class="span3 side-options phone-span-diff">
					<h3 class="subheading">Settings</h3>
					<ul class="side-nav">
						<li><a href="#">Account Center</a></li>
						<li><a href="#">Help</a></li>
						
					</ul>
				</div>
				<div class="span9">
					<div class="row push30">
						<div class="span9">
							<p class="primary long phone-full-width">
								Welcome to Fascinating Diamonds! Please set your account and provide the information
								needed for us to make your experience unique. Enjoy your shopping!
							</p>
						</div>
					</div>
					<div class="row">
						<div class="span3 push20 phone-block">
							<span class="secondary">Personal Details</span>
						</div>
					</div>
					<div class="row hidden-phone">
						<div class="span3">
							<p>First Name: <span class="highlight">*</span></p>
						</div>
						<div class="span3">
							<p>Middle Name: <span class="highlight">*</span></p>
						</div>
						<div class="span3">
							<p>Last Name: <span class="highlight">*</span></p>
						</div>
					</div>
					<div class="row">
						<div class="span3">
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
							<%--<input type="text" placeholder="First Name">--%>
						</div>
						<div class="span3">
                         <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
							<%--<input type="text" placeholder="Last Name">--%>
						</div>
						<div class="span3">
                         <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
							<%--<input type="text" placeholder="Telephone">--%>
						</div>
					</div>
                    	<div class="row">
						<div class="span3">
                       <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please Enter FirstName" Display="Dynamic" ValidationGroup="validateRegister" SetFocusOnError="true"></asp:RequiredFieldValidator>
							<%--<input type="text" placeholder="First Name">--%>
						</div>
						<div class="span3">
                        
						</div>
						<div class="span3">
                         <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please Enter LastName" Display="Dynamic" ValidationGroup="validateRegister" SetFocusOnError="true"></asp:RequiredFieldValidator>
							<%--<input type="text" placeholder="Telephone">--%>
						</div>
					</div>


					

					<div class="row push30">
						<div class="span6">
							<div class="row">
								<div class="span6 phone-block">
									<span class="secondary">Address</span>
								</div>
							</div>
							

                            <div class="row hidden-phone">
								<div class="span3">
									<p>Country:</p>
								</div>
								<div class="span3">
									<p><asp:Label ID="lblStateName" runat="server"></asp:Label>: <span class="highlight">*</span></p>
								</div>
							</div>
							<div class="row">
								<div class="span3">
                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" Width="100%" Height="45px" BackColor="#d6d8d7" ForeColor="White" Font-Bold="true"
                                        onselectedindexchanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
									
								</div>
								<div class="span3">
									<asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" Width="100%" Height="45px" BackColor="#d6d8d7" ForeColor="White" Font-Bold="true"
                                        onselectedindexchanged="ddlState_SelectedIndexChanged"></asp:DropDownList>

                                        <asp:TextBox ID="txtStateName" runat="server"></asp:TextBox>
								</div>
							</div>
                            	<div class="row">
								<div class="span3">
                               <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry" ErrorMessage="Please Select Country" Display="Dynamic" ValidationGroup="validateRegister" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
									
								</div>
								<div class="span3">
									  <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState" ErrorMessage="Please Select State" Display="Dynamic" ValidationGroup="validateRegister" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
								</div>
							</div>
							<div class="row hidden-phone">
								<div class="span3">
									<p>City:</p>
								</div>
								<div class="span3">
									<p><asp:Label ID="PostalCodeDisplayName" runat="server"></asp:Label>: <span class="highlight">*</span></p>
								</div>
							</div>
							<div class="row">
								<div class="span3">
								<asp:DropDownList ID="ddlCity" runat="server" Width="100%" Height="45px" BackColor="#d6d8d7" ForeColor="White" Font-Bold="true"></asp:DropDownList>
                                 <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
								</div>
								<div class="span3">
									<asp:DropDownList ID="ddlZipCode" runat="server" Width="100%" Height="45px" BackColor="#d6d8d7" ForeColor="White" Font-Bold="true"></asp:DropDownList>
								</div>
							</div>
                            <div class="row">
								<div class="span3">
                               <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" ErrorMessage="Please Select City" Display="Dynamic" ValidationGroup="validateRegister" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
									
								</div>
								<div class="span3">
								<%--	  <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="ddlZipCode" ErrorMessage="Please Select ZipCode" Display="Dynamic" ValidationGroup="validateRegister" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>--%>

								</div>
							</div>


							<div class="row hidden-phone">
								<div class="span6">
									<p>Address 1: <span class="highlight">*</span></p>
								</div>
							</div>
							<div class="row">
								<div class="span6">
									 <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
								</div>
							</div>
                            <div class="row">
								<div class="span6">
									  <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Enter Address" Display="Dynamic" ValidationGroup="validateRegister" SetFocusOnError="true"></asp:RequiredFieldValidator>
								</div>
							</div>

                            <div class="row hidden-phone">
						<%--<div class="span3">
							<p>E-mail: <span class="highlight">*</span></p>
						</div>--%>
						<div class="span3">
							<p>Phone Number: <span class="highlight">*</span></p>
						</div>
						<div class="span3">
							<p>Fax Numbrer:</p>
						</div>
					</div>
					<div class="row">
						<%--<div class="span3">
						 <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
						</div>--%>
						<div class="span3">
						 <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
						</div>
						<div class="span3">
					          <asp:TextBox ID="txtFaxNumber" runat="server"></asp:TextBox>
						</div>
					</div>

                    <div class="row">
						<%--<div class="span3">
						 <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
						</div>--%>
						<div class="span3">
						 <asp:RequiredFieldValidator ID="rfvPhoneNo" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Please Enter PhoneNumber" Display="Dynamic" ValidationGroup="validateRegister" SetFocusOnError="true"></asp:RequiredFieldValidator>
						</div>
						<div class="span3">
					        
						</div>
					</div>
							
						</div>







						
					</div>
<%-- 100    1
					<div class="row">
						<div class="span9">
							<div class="row push30 hidden-phone">
								<div class="span9">
									<p class="secondary">Password</p>
								</div>
							</div>
							<div class="row hidden-phone">
								<div class="span3">
									<p>Password: <span class="highlight">*</span></p>
								</div>
								<div class="span6">
									<p>Confirm Password: <span class="highlight">*</span></p>
								</div>
							</div>
							<div class="row">
								<div class="span3">
									<input type="text" placeholder="Password">
								</div>
								<div class="span3">
									<input type="text" placeholder="Confirm Password">
								</div>
							</div>
						</div>
					</div>--%>
					<div class="row push30">
						<div class="span9 phone-block">
                        <asp:CheckBox ID="chkboxDefaultAddress" runat="server" Text="Default" /><br />
                     <%--    <asp:CheckBox ID="chkboxagreed" runat="server" Text="I have read and agree to the Privacy Policy"  />--%>
							<%--<input type="checkboxagreed" id="agreed">

							<label for="agreed">I have read and agree to the Privacy Policy</label>--%>
						</div>
					</div>
					<div class="row push20">
						<div class="span9">
                        <asp:Button ID="btnRegister" runat="server" Text="register"  ValidationGroup="validateRegister"
                                class="simple-submit secondary" onclick="btnRegister_Click" />
                                <asp:Label ID="lblmessage" runat="server"></asp:Label>
							<%--<input type="submit" class="simple-submit secondary" value="register">--%>
						</div>
					</div>
				</div>
			</div>

		</div><!-- end container -->



       
        <asp:HiddenField ID="hfcustomerID" runat="server" />
     
</asp:Content>
