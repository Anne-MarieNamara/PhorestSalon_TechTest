using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhorestSalon_TechTest.ObjectRepository
{
    public class PageObjects
    {
        // Landing Screen
        public static string landingScreenTitleXpath = "//p[text()='Demo US']";
        public static string buyAGiftCardTextXpath = "//span[text()='Buy a Gift Card']";
        public static string giftCardValueTitleXpath = "//span[text()='Gift Card Value']";
        public static string fiftyDollarChecboxId = "option50";
        public static string oneHDollarCheckboxId = "option100";
        public static string oneFiftyDollarCheckboxId = "option150";
        public static string otherDollarCheckboxId = "optionOther";
        public static string sendToMeLinkTextXpath = "//a[text()='Send to me']";
        public static string sendToSomeoneElseLinkText = "//a[text()='Send to someone else']";
        public static string purchaserEmailAddressInputXpath = "//input[@data-target='email.purchaserEmailInput']";
        public static string recipientEmailAddressInputXpath = "//input[@data-target='email.recipientEmailInput']";
        public static string firstNameInputXpath = "//input[@data-target='name.purchaserFirstNameInput']";
        public static string lastNameInputXpath = "//input[@data-target='name.purchaserLastNameInput']";
        public static string landingPageTotalCostXpath = "(//span[@data-target='checkout.price'])[1]";
        public static string checkoutButtonXpath = "(//button[@data-target='checkout.checkoutButton'])[1]";
        public static string messageForRecipient = "//textarea[@data-target='email.recipientMessageInput']";
        public static string otherAmountInputXpath = "//input[@data-target='amount.otherInput']";
        public static string minAmtValidationMsgXpath = "//p[@data-target='amount.otherSectionError']";
        public static string expectedMinAmtValMsgXpath = "The minimum spend is $25 and the maximum spend is $1000.";

        // Summary Screen
        public static string summaryTitleXpath = "//h2[text()='Summary']";
        public static string editLinkXpath = "//button[text()='Edit']";
        public static string confirmPaymentAmountId = "confirm-payment-amount";
        public static string valueOfGiftCardId = "confirm-voucher-value";
        public static string sendReceiptToEmailId = "confirm-purchaser-email";
        public static string sendGiftCardToEmailId = "confirm-recipient-email";
        public static string confirmDetailsButtonXpath = "//button[@data-action='confirm#confirmAction']";
        public static string submitButtonId = "submitButton";

        // Payment screen
        public static string expiryDateErrorMsgXpath = "//p[text()='The expiration date must be in the future']";
        public static string cardHolderNameId = "card-name";       
        public static string cardHolderNameXpath = "//input[@id='card-name']";
        public static string zipCodeId = "card-zip";
        public static string cardNumberId = "card-number";
        public static string cardExpiryId = "card-expiry";
        public static string securityCodeId = "card-security";
        public static string purchaseEmailErrorXpath = "//div[@data-target='email.purchaserEmailError']";
        public static string recipientEmailErrorXpath = "//div[@data-target='email.recipientEmailError']";
        public static string payment_iframeName = "__privateStripeMetricsController2900";        
        public static string payment_iFrameXpath = "//div[@id='bancard-payment-form']//iframe";

        // Confirmation screen
        public static string paymentAcceptedTextXpath = "//div[@data-controller='success']//p[text()='Payment accepted, thank you!']";
        public static string confirmationDollarTotalXpath = "//p[@class='mb-8 text-3xl font-bold']";
        public static string giftcardCodeXpath = "//p[@class='text-xl font-bold mb-8']";
        public static string doneButtonXpath = "//button[@data-action='application#doneAction']";
       
    }
}
