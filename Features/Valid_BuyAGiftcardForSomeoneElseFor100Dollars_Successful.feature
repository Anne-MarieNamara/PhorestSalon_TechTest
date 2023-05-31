Feature: Valid_BuyAGiftcardForSomeoneElseFor100Dollars_Successful
	Buy a giftcard for someone else for $100 dollars


Scenario: Valid_BuyAGiftcardForSomeoneElseFor100Dollars_Successful
Given user logs onto giftcard screen
And user validates the "giftcard" screen
And user chooses "$100" amount
And user chooses "send to someone else" as recipient
And user inputs purchaser email as "annmarie.namara@gmail.com"
And user inputs recipient email as "mstest@test.com"
And user inputs a message for recipient
And user inputs first name as "Ms"
And user inputs surname as "Test"
And user validates "$100" amount as the total
And user clicks the "checkout" button
And user validates the "summary for someone else" screen
And user clicks the "confirm details" button
And user fills in the payment details "successful"
And user clicks the "submit" button
And user validates the "confirmation" screen
And user clicks the "done" button