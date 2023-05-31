using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PhorestSalon_TechTest.Helpers;
using PhorestSalon_TechTest.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static PhorestSalon_TechTest.Constants.TestContext;

namespace PhorestSalon_TechTest.StepDefinitions
{
    [Binding]
    public class SharedStepDefinitions
    {
        

        [Given(@"user logs onto giftcard screen")]
        public void GivenUserLogsOntoGiftcardScreen()
        {
            string Url = "https://gift-cards.phorest.com/salons/demous#";
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
        }

        [Given(@"user validates the ""(.*)"" screen")]
        public void GivenUserValidatesTheScreen(string screen)
        {
            switch (screen)
            {              
                case "giftcard":
                    // Validate Screen title
                    IWebElement paymentTitleXpath = driver.FindElement(By.XPath(PageObjects.landingScreenTitleXpath));
                    string actualLandingTitleStr = paymentTitleXpath.Text.Trim();
                    string expectedLandingTitleStr = "Demo US";
                    MiscHelperClass.ValidateMethod(actualLandingTitleStr, expectedLandingTitleStr);

                    // Validate Buy a gift card title text
                    IWebElement buyAGiftcardTitleXpath = driver.FindElement(By.XPath(PageObjects.buyAGiftCardTextXpath));
                    string actualBuyAGiftCardTitleStr = buyAGiftcardTitleXpath.Text.Trim();
                    string expectedBuyAGiftCardTitleStr = "Buy a Gift Card";
                    MiscHelperClass.ValidateMethod(actualBuyAGiftCardTitleStr, expectedBuyAGiftCardTitleStr);

                    // Validate the Gift card value text
                    IWebElement giftCardValueTextXpath = driver.FindElement(By.XPath(PageObjects.giftCardValueTitleXpath));
                    string actualGiftCardValueTextStr = giftCardValueTextXpath.Text.Trim();
                    string expectedGiftCardValueTextStr = "Gift Card Value";
                    MiscHelperClass.ValidateMethod(actualGiftCardValueTextStr, expectedGiftCardValueTextStr);
                    break;


                case "summary for yourself":
                    CheckSummaryTitle();
                    CheckGiftCardAndTotalCostMatches();
                    CheckPurchaserEmailMatches();
                    CheckRecipientEmailMatchesForYourself();
                    break;

                case "summary for someone else":
                    CheckSummaryTitle();
                    CheckGiftCardAndTotalCostMatches();
                    CheckPurchaserEmailMatches();
                    CheckRecipientEmailMatchesForSomeoneElse();
                    break;

                case "confirmation":
                    driver.SwitchTo().DefaultContent();
                    Thread.Sleep(1000);
                    MiscHelperClass.WaitForAjax(driver);
                    Thread.Sleep(6000);
                    // validate title
                    IWebElement paymentAcceptedTitleXpath = driver.FindElement(By.XPath(PageObjects.paymentAcceptedTextXpath));
                    string actualPaymentTitleStr = paymentAcceptedTitleXpath.Text.Trim();
                    string expectedPaymentTitleStr = "Payment accepted, thank you!";
                    MiscHelperClass.ValidateMethod(actualPaymentTitleStr, expectedPaymentTitleStr);

                    // validate total amount
                    IWebElement confirmationTotalXpath = driver.FindElement(By.XPath(PageObjects.confirmationDollarTotalXpath));
                    string actualConfirmationTotalStr = confirmationTotalXpath.Text.Trim();
                    string expectedCofirmationTotalStr = ApplicationContext.ApplicationContext.landingPageTotal + ".00";
                    MiscHelperClass.ValidateMethod(actualConfirmationTotalStr, expectedCofirmationTotalStr);
                    break;

                default:
                    Assert.Fail("Invalid screen chosen");
                    break;
            }
        }

        public static void CheckRecipientEmailMatchesForYourself()
        {
            // Check 'send gift card to recipient' matches (recipient email)
            bool isSendGiftCardToEmailDisplayed = driver.FindElements(By.Id(PageObjects.sendGiftCardToEmailId)).Count > 0;
            if (!isSendGiftCardToEmailDisplayed)
            {
                // Scroll to the bottom of the screen
                Actions actions1 = new Actions(driver);
                actions1.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();
            }
            IWebElement sendGiftCardToEmailXpath = driver.FindElement(By.Id(PageObjects.sendGiftCardToEmailId));
            string actualSendGiftCardToEmailStr = sendGiftCardToEmailXpath.Text.Trim();
            string expectedSendGiftCardToStr = ApplicationContext.ApplicationContext.purchaserEmailAddress;
            MiscHelperClass.ValidateMethod(actualSendGiftCardToEmailStr, expectedSendGiftCardToStr);

        }

        public static void CheckRecipientEmailMatchesForSomeoneElse()
        {
            // Check 'send gift card to recipient' matches (recipient email)
            bool isSendGiftCardToEmailDisplayed = driver.FindElements(By.Id(PageObjects.sendGiftCardToEmailId)).Count > 0;
            if (!isSendGiftCardToEmailDisplayed)
            {
                // Scroll to the bottom of the screen
                Actions actions2 = new Actions(driver);
                actions2.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();
            }
            IWebElement sendGiftCardToEmailXpath = driver.FindElement(By.Id(PageObjects.sendGiftCardToEmailId));
            string actualSendGiftCardToEmailStr = sendGiftCardToEmailXpath.Text.Trim();
            string expectedSendGiftCardToStr = ApplicationContext.ApplicationContext.recipientEmailAddress;
            MiscHelperClass.ValidateMethod(actualSendGiftCardToEmailStr, expectedSendGiftCardToStr);
        }

        public static void CheckPurchaserEmailMatches()
        {
            // check 'send receipt to email' matches (purchaser email)
            IWebElement sendReceiptToEmailXpath = driver.FindElement(By.Id(PageObjects.sendReceiptToEmailId));
            string actualSendReceiptToEmailStr = sendReceiptToEmailXpath.Text.Trim();
            string expectedEmailAddressStr = ApplicationContext.ApplicationContext.purchaserEmailAddress;
            MiscHelperClass.ValidateMethod(actualSendReceiptToEmailStr, expectedEmailAddressStr);
        }

        public static void CheckGiftCardAndTotalCostMatches()
        {
            // Check value of gift card and total amount chosen on previous screen matches
            IWebElement valueOfGiftCardId = driver.FindElement(By.Id(PageObjects.valueOfGiftCardId));
            string actualValueOfGiftCardStr = valueOfGiftCardId.Text.Trim();
            string expectedValueOfGiftCardStr = ApplicationContext.ApplicationContext.landingPageTotal + ".00";
            MiscHelperClass.ValidateMethod(actualValueOfGiftCardStr, expectedValueOfGiftCardStr);

            IWebElement TotalCostId = driver.FindElement(By.Id(PageObjects.valueOfGiftCardId));
            string actualTotalCostStr = TotalCostId.Text.Trim();
            string expectedTotalCostStr = ApplicationContext.ApplicationContext.landingPageTotal + ".00";
            MiscHelperClass.ValidateMethod(actualTotalCostStr, expectedTotalCostStr);
        }

        public static void CheckSummaryTitle()
        {
            MiscHelperClass.WaitForAjax(driver);
            Thread.Sleep(3000);
            // Check Summary title matches
            IWebElement summaryscreenTitleXpath = driver.FindElement(By.XPath(PageObjects.summaryTitleXpath));
            string actualSummaryScreenTitleStr = summaryscreenTitleXpath.Text.Trim();
            string expectedSummaryTitleStr = "Summary";
            MiscHelperClass.ValidateMethod(actualSummaryScreenTitleStr, expectedSummaryTitleStr);
        }


        [Given(@"user chooses ""(.*)"" amount")]
        public void GivenUserChoosesAmount(string amount)
        {
            switch (amount)
            {
                case "$50":
                    IWebElement fiftyDollarId = driver.FindElement(By.Id(PageObjects.fiftyDollarChecboxId));
                    fiftyDollarId.Click();
                    ApplicationContext.ApplicationContext.landingPageTotal = "$50";
                    Thread.Sleep(1000);
                    break;

                case "$100":
                    IWebElement oneHundredDollarId = driver.FindElement(By.Id(PageObjects.oneHDollarCheckboxId));
                    oneHundredDollarId.Click();
                    ApplicationContext.ApplicationContext.landingPageTotal = "$100";
                    Thread.Sleep(1000);
                    break;

                case "$150":
                    IWebElement oneFiftyDollarCheckboxId = driver.FindElement(By.Id(PageObjects.oneFiftyDollarCheckboxId));
                    oneFiftyDollarCheckboxId.Click();
                    ApplicationContext.ApplicationContext.landingPageTotal = "$150";
                    Thread.Sleep(1000);
                    break;

                case "other":
                    IWebElement otherDollarCheckboxId = driver.FindElement(By.Id(PageObjects.otherDollarCheckboxId));
                    otherDollarCheckboxId.Click();
                    Thread.Sleep(1000);

                    break;

                default:
                    Assert.Fail("Incorrect Amount");
                    break;
            }
        }

        [Given(@"user chooses ""(.*)"" as recipient")]
        public void GivenUserChoosesAsRecipient(string recipient)
        {
            switch (recipient)
            {
                case "send to me":
                    IWebElement sendToMeXpath = driver.FindElement(By.XPath(PageObjects.sendToMeLinkTextXpath));
                    sendToMeXpath.Click();
                    Thread.Sleep(1000);
                    break;

                case "send to someone else":
                    IWebElement sendToSomeoneElseLinkText = driver.FindElement(By.XPath(PageObjects.sendToSomeoneElseLinkText));
                    sendToSomeoneElseLinkText.Click();
                    Thread.Sleep(1000);
                    break;

                default:
                    Assert.Fail("Incorrect recipient");
                    break;
            }
        }

        [Given(@"user inputs purchaser email as ""(.*)""")]
        public void GivenUserInputsPurchaserEmailAs(string email)
        {
            // Scroll to the bottom of the screen
            Actions actions = new Actions(driver);
            actions.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();

            // input purchaser email
            IWebElement purchaserEmailAddressXpath = driver.FindElement(By.XPath(PageObjects.purchaserEmailAddressInputXpath));
            purchaserEmailAddressXpath.Click();
            purchaserEmailAddressXpath.Clear();
            purchaserEmailAddressXpath.SendKeys(email);
            ApplicationContext.ApplicationContext.purchaserEmailAddress = email;
            Thread.Sleep(1000);
        }

        [Given(@"user inputs first name as ""(.*)""")]
        public void GivenUserInputsFirstNameAs(string firstName)
        {
            IWebElement firstNameXpath = driver.FindElement(By.XPath(PageObjects.firstNameInputXpath));
            firstNameXpath.Click();
            firstNameXpath.Clear();
            firstNameXpath.SendKeys(firstName);
            ApplicationContext.ApplicationContext.firstName = firstName;
            Thread.Sleep(1000);
        }

        [Given(@"user inputs surname as ""(.*)""")]
        public void GivenUserInputsSurnameAs(string surname)
        {
            IWebElement surnameXpath = driver.FindElement(By.XPath(PageObjects.lastNameInputXpath));
            surnameXpath.Click();
            surnameXpath.Clear();
            surnameXpath.SendKeys(surname);
            ApplicationContext.ApplicationContext.surname = surname;
            Thread.Sleep(1000);
        }

        [Given(@"user validates ""(.*)"" amount as the total")]
        public void GivenUserValidatesAmountAsTheTotal(string amount)
        {
            IWebElement totalamountXpath = driver.FindElement(By.XPath(PageObjects.landingPageTotalCostXpath));
            string actualTotalAmountStr = totalamountXpath.Text.Trim();
            string expectedTotalAmountStr = amount + ".00";
            MiscHelperClass.ValidateMethod(actualTotalAmountStr, expectedTotalAmountStr);
        }

        [Given(@"user clicks the ""(.*)"" button")]
        public void GivenUserClicksTheButton(string button)
        {
            switch (button)
            {
                case "checkout":
                    IWebElement checkoutButtonXpath = driver.FindElement(By.XPath(PageObjects.checkoutButtonXpath));
                    checkoutButtonXpath.Click();
                    Thread.Sleep(2000);
                    break;

                case "confirm details":
                    Thread.Sleep(4000);                    

                    // Scroll to the bottom of the screen
                    Actions actions3 = new Actions(driver);
                    actions3.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();
                    Thread.Sleep(2500);

                    Actions actions4 = new Actions(driver);
                    actions4.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();

                    IWebElement confirmDetailsButtonXpath = driver.FindElement(By.XPath(PageObjects.confirmDetailsButtonXpath));
                    confirmDetailsButtonXpath.Click();
                    Thread.Sleep(2000);
                    break;

                case "submit":
                    IWebElement submitButtonXpath = driver.FindElement(By.Id(PageObjects.submitButtonId));
                    submitButtonXpath.Click();
                    Thread.Sleep(2000);
                    break;

                case "done":
                    IWebElement doneButtonXpath = driver.FindElement(By.XPath(PageObjects.doneButtonXpath));
                    doneButtonXpath.Click();
                    Thread.Sleep(2000);
                    break;

                default:
                    Assert.Fail("Incorrect button chosen");
                    break;

            }
        }

        [Given(@"user fills in the payment details ""(.*)""")]
        public void GivenUserFillsInThePaymentDetails(string status)
        {
            // scroll down the screen
            Actions actions6 = new Actions(driver);
            actions6.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();
            MiscHelperClass.WaitForAjax(driver);
            Thread.Sleep(5000);


            // fill in card payment details
            string cardExpiry;
            if (status == "successful")
            {
                cardExpiry = "12/24";
            }
            else
            {
                cardExpiry = "12/22";
            }

            // Wait for payment section to load
            MiscHelperClass.WaitForAjax(driver);
            Thread.Sleep(6000);
            bool isPaymentDetailsDisplayed = driver.FindElements(By.XPath("//label[text()='Zip Code']")).Count > 0;
            if (!isPaymentDetailsDisplayed)
            {                
                Thread.Sleep(4000);
                Actions actions8 = new Actions(driver);
                actions8.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();
            }

            // Switch to payment frame
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);           

            driver.SwitchTo().Frame(driver.FindElement(By.XPath(PageObjects.payment_iFrameXpath)));
            
            // Input payment details
            IWebElement cardHolderNameId = driver.FindElement(By.XPath(PageObjects.cardHolderNameXpath));
            cardHolderNameId.Click();
            cardHolderNameId.Clear();
            cardHolderNameId.SendKeys("Anne-Marie Test");


            IWebElement zipCodeId = driver.FindElement(By.Id(PageObjects.zipCodeId));
            zipCodeId.Click();
            zipCodeId.Clear();
            zipCodeId.SendKeys("92606");

            IWebElement cardNumberId = driver.FindElement(By.Id(PageObjects.cardNumberId));
            cardNumberId.Click();
            cardNumberId.Clear();
            cardNumberId.SendKeys("4111111111111111");

            IWebElement cardExpiryId = driver.FindElement(By.Id(PageObjects.cardExpiryId));
            cardExpiryId.Click();
            cardExpiryId.Clear();
            cardExpiryId.SendKeys(cardExpiry);


            IWebElement securityCodeId = driver.FindElement(By.Id(PageObjects.securityCodeId));
            securityCodeId.Click();
            securityCodeId.Clear();
            securityCodeId.SendKeys("999");

        }

        [Given(@"user inputs recipient email as ""(.*)""")]
        public void GivenUserInputsRecipientEmailAs(string email)
        {
            // scroll down the screen
            Actions actions7 = new Actions(driver);
            actions7.SendKeys(OpenQA.Selenium.Keys.End).Build().Perform();
            MiscHelperClass.WaitForAjax(driver);

            IWebElement recipientEmailAddressXpath = driver.FindElement(By.XPath(PageObjects.recipientEmailAddressInputXpath));
            recipientEmailAddressXpath.Click();
            recipientEmailAddressXpath.Clear();
            recipientEmailAddressXpath.SendKeys(email);
            ApplicationContext.ApplicationContext.recipientEmailAddress = email;
            Thread.Sleep(1000);
        }

        [Given(@"user inputs a message for recipient")]
        public void GivenUserInputsAMessageForRecipient()
        {
            IWebElement inputMessageXpath = driver.FindElement(By.XPath(PageObjects.messageForRecipient));
            inputMessageXpath.Click();
            inputMessageXpath.Clear();
            inputMessageXpath.SendKeys("Test - Recipient Message");
        }

        [Given(@"user inputs other amount as ""(.*)""")]
        public void GivenUserInputsOtherAmountAs(int amount)
        {
            IWebElement otherAmountInputXpath = driver.FindElement(By.XPath(PageObjects.otherAmountInputXpath));
            otherAmountInputXpath.Click();
            otherAmountInputXpath.Clear();
            otherAmountInputXpath.SendKeys(amount.ToString());
            ApplicationContext.ApplicationContext.landingPageTotal = "$" + amount.ToString();
            Thread.Sleep(1000);
        }


        [Given(@"user validates the ""(.*)"" validation message")]
        public void GivenUserValidatesTheValidationMessage(string errorMsg)
        {
            switch (errorMsg)
            {
                case "invalid card expiry date":
                    IWebElement cardExpiryMsgXpath = driver.FindElement(By.XPath(PageObjects.expiryDateErrorMsgXpath));
                    string actualCardExpiryMsgStr = cardExpiryMsgXpath.Text.Trim();
                    string expectedCardExpiryMsgStr = "The expiration date must be in the future";
                    MiscHelperClass.ValidateMethod(actualCardExpiryMsgStr, expectedCardExpiryMsgStr);
                    break;

                case "invalid email address":
                    IWebElement purchaseEmailErrorXpath = driver.FindElement(By.XPath(PageObjects.purchaseEmailErrorXpath));
                    string actualPurchaseMsgStr = purchaseEmailErrorXpath.Text.Trim();
                    string expectedPurchaseMsgStr = "Please enter a valid email";
                    MiscHelperClass.ValidateMethod(actualPurchaseMsgStr, expectedPurchaseMsgStr);

                    IWebElement recipientEmailErrorXpath = driver.FindElement(By.XPath(PageObjects.recipientEmailErrorXpath));
                    string actualRecipientMsgStr = recipientEmailErrorXpath.Text.Trim();
                    string expectedRecipientMsgStr = "Please enter a valid email";
                    MiscHelperClass.ValidateMethod(actualRecipientMsgStr, expectedRecipientMsgStr);
                    break;

                case "minimum amount error msg":
                    IWebElement minAmtValMsgXpath = driver.FindElement(By.XPath(PageObjects.minAmtValidationMsgXpath));
                    string actualMinAmtValMsgStr = minAmtValMsgXpath.Text.Trim();
                    string expectedMinAmtValMsgStr = PageObjects.expectedMinAmtValMsgXpath;
                    MiscHelperClass.ValidateMethod(actualMinAmtValMsgStr, expectedMinAmtValMsgStr);
                    break;

                default:
                    Assert.Fail("Incorrect validation message");
                    break;
            }

        }


    }
}
