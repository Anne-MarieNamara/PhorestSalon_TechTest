Feature: Valid_BuyAGiftcardForYourselfFor150Dollars_Successful
	Buy a giftcard for yourself for $150


Scenario: Valid_BuyAGiftcardForYourselfFor150Dollars_Successful
Given user logs onto giftcard screen
And user validates the "giftcard" screen
And user chooses "$150" amount
And user chooses "send to me" as recipient
And user inputs purchaser email as "annmarie.namara@gmail.com"
And user inputs first name as "Anne-Marie"
And user inputs surname as "McNamara"
And user validates "$150" amount as the total
And user clicks the "checkout" button
And user validates the "summary for yourself" screen
And user clicks the "confirm details" button
And user fills in the payment details "successful"
And user clicks the "submit" button
And user validates the "confirmation" screen
And user clicks the "done" button