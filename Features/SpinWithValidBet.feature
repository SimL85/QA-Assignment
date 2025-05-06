Feature: SpinWithValidBet

Slot Machine - Spin With Valid Bet
  As a player
  I want to spin the slot machine with a valid bet
  So that I can see my balance decrease and the reels spin

Scenario: Spin the reels with a valid bet
    Given Navigate to the slot game page
	And Enter a bet of <Bet>
    When Click the spin button and chek the initial balamce is decresed
    Then The result should reflect the correct amount and message	

Examples:
	| Bet		 |
	| 50         |
	| 100        |
	| 200        |
	| 500        |
	| 1000       |
