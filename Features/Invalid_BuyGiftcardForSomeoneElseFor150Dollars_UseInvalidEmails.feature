Feature: Invalid_BuyGiftcardForSomeoneElseFor150Dollars_UseInvalidEmails
	


Scenario: Invalid_BuyGiftcardForSomeoneElseFor150Dollars_UseInvalidEmails
Given user logs onto giftcard screen
And user validates the "giftcard" screen
And user chooses "$150" amount
And user chooses "send to someone else" as recipient
And user inputs purchaser email as "12345678890!!!???~#"
And user inputs recipient email as "1235798=-;'[]#/."
And user validates the "invalid email address" validation message