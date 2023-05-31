Feature: Invalid_BuyGiftcardForYourself_Try2000DollarsAmount
	Checking validation for max dollar amount

Scenario: Invalid_BuyGiftcardForYourself_TryZeroAmount
Given user logs onto giftcard screen
And user validates the "giftcard" screen
And user chooses "other" amount
And user inputs other amount as "2000"
And user validates the "minimum amount error msg" validation message