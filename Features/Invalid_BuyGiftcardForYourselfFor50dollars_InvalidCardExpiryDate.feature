Feature: Invalid_BuyGiftcardForYourselfFor50dollars_InvalidCardExpiryDate
	Simple calculator for adding two numbers

Scenario: Invalid_BuyGiftcardForYourselfFor50dollars_InvalidCardExpiryDate
Given user logs onto giftcard screen
And user validates the "giftcard" screen
And user chooses "$100" amount
And user chooses "send to me" as recipient
And user inputs purchaser email as "annmarie.namara@gmail.com"
And user inputs first name as "Anne-Marie"
And user inputs surname as "McNamara"
And user validates "$100" amount as the total
And user clicks the "checkout" button
And user validates the "summary for yourself" screen
And user clicks the "confirm details" button
And user fills in the payment details "fail - invalid card expiry date"
And user clicks the "submit" button
And user validates the "invalid card expiry date" validation message