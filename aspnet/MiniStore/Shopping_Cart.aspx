<%@ Page Title="" Language="C#" MasterPageFile="~/StoreFront.Master" AutoEventWireup="true" CodeBehind="Shopping_Cart.aspx.cs" Inherits="MiniStore.Shopping_Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="content" class="page-content">
            <div class="page-header">
                <a href="#" class="deploy-sidebar"></a>
                <p class="bread-crumb">iApp微店-購物車(未完)</p> 
            </div>
            <div class="content-header">
            </div>

            <div class="content">
                <div class="decoration"></div>
                <div class="container no-bottom">
                    <div class="section-title">
                        <h4>購物車</h4>
                        <em>a few words about this section</em>
                        <strong>
                            <img src="images/misc/icons/mail.png" width="20" alt="img"></strong>
                    </div>
                </div>
                <div class="decoration"></div>
                <div class="container no-bottom">
                    <p>
                    </p>
                </div>
                <div class="decoration"></div>



                <div class="one-half-responsive">
                    <h4>Send us an email!</h4>
                    <p>Use the form to send us a message, it's AJAX and PHP powered and it's easy to use!</p>
                    <div class="container no-bottom">
                        <div class="contact-form no-bottom">
                            <div class="formSuccessMessageWrap" id="formSuccessMessageWrap">
                                <div class="big-notification green-notification">
                                    <h3 class="uppercase">Message Sent </h3>
                                    <a href="#" class="close-big-notification">x</a>
                                    <p>Your message has been successfuly sent. Please allow up to 48 hours for a reply! Thank you!</p>
                                </div>
                            </div>

                            <fieldset>
                                <div class="formValidationError" id="contactNameFieldError">
                                    <div class="static-notification-red tap-dismiss-notification">
                                        <p class="center-text uppercase">Name is required!</p>
                                    </div>
                                </div>
                                <div class="formValidationError" id="contactEmailFieldError">
                                    <div class="static-notification-red tap-dismiss-notification">
                                        <p class="center-text uppercase">Mail address required!</p>
                                    </div>
                                </div>
                                <div class="formValidationError" id="contactEmailFieldError2">
                                    <div class="static-notification-red tap-dismiss-notification">
                                        <p class="center-text uppercase">Mail address must be valid!</p>
                                    </div>
                                </div>
                                <div class="formValidationError" id="contactMessageTextareaError">
                                    <div class="static-notification-red tap-dismiss-notification">
                                        <p class="center-text uppercase">Message field is empty!</p>
                                    </div>
                                </div>
                                <div class="formFieldWrap">
                                    <label class="field-title contactNameField" for="contactNameField">Name:<span>(required)</span></label>
                                    <input type="text" name="contactNameField" value="" class="contactField requiredField" id="contactNameField" />
                                </div>
                                <div class="formFieldWrap">
                                    <label class="field-title contactEmailField" for="contactEmailField">Email: <span>(required)</span></label>
                                    <input type="text" name="contactEmailField" value="" class="contactField requiredField requiredEmailField" id="contactEmailField" />
                                </div>
                                <div class="formTextareaWrap">
                                    <label class="field-title contactMessageTextarea" for="contactMessageTextarea">Message: <span>(required)</span></label>
                                    <textarea name="contactMessageTextarea" class="contactTextarea requiredField" id="contactMessageTextarea"></textarea>
                                </div>
                                <div class="formSubmitButtonErrorsWrap">
                                    <input type="submit" class="buttonWrap button button-green contactSubmitButton" id="contactSubmitButton" value="SUBMIT" data-formid="contactForm" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <div class="decoration hide-if-responsive"></div>
                <div class="one-half-responsive last-column">
                    <div class="container no-bottom">
                        <h4>Contact Information</h4>
                        <p>
                            <strong>Postal Information</strong><br>
                            PO Box 16122 Collins Street West<br>
                            Victoria 8007 Australia
                   
                        </p>


                    </div>
                </div>

                <div class="decoration"></div>
                <div class="content-footer">
                    <p class="copyright-content">
                        iApp<br>
                        打造你自己的App
                    </p>
                    <a href="#" class="go-up-footer"></a>
                    <a href="#" class="facebook-footer"></a>
                    <div class="clear"></div>
                </div>
            </div>
        </div>
</asp:Content>
