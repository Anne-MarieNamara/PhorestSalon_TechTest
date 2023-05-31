Feature: Invalid_BuyGiftcardForYourself_TryZeroAmount
	Validating the error message which displays when you try to 
	input $0 for a giftcard

Scenario: Invalid_BuyGiftcardForYourself_TryZeroAmount
Given user logs onto giftcard screen
And user validates the "giftcard" screen
And user chooses "other" amount
And user inputs other amount as "0"
And user validates the "minimum amount error msg" validation message