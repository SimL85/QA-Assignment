Feature: FieldValidationBetField 

This feature is testing the allowded caracters in the bet field
  As a player
  I want to validate the bet field
  So that I can ensure that only valid characters are accepted
Background:
	Given Navigate to the slot game page

Scenario: Validate the bet field with valid characters
	Given Navigate to the slot game page
	When Enter <input> in the bet field
	Then The bet field should <result> and the alert should not be showed
Examples:
	| input | result      |
	| 1     | be accepted |
	| 2     | be accepted |
	| 3     | be accepted |
	| 4     | be accepted |
	| 5     | be accepted |
	| 6     | be accepted |
	| 7     | be accepted |
	| 8     | be accepted |
	| 9     | be accepted |

Scenario: Validate the bet field
	Given Navigate to the slot game page
	When Enter <input> in the bet field
	Then The bet field should <result> and the alert should be showed in case to be rejected

Examples:
    | input | result      |
    | a     | be rejected |
    | b     | be rejected |
    | c     | be rejected |
    | d     | be rejected |
    | e     | be rejected |
    | f     | be rejected |
    | g     | be rejected |
    | h     | be rejected |
    | i     | be rejected |
    | j     | be rejected |
    | k     | be rejected |
    | l     | be rejected |
    | m     | be rejected |
    | n     | be rejected |
    | o     | be rejected |
    | p     | be rejected |
    | q     | be rejected |
    | r     | be rejected |
    | s     | be rejected |
    | t     | be rejected |
    | u     | be rejected |
    | v     | be rejected |
    | w     | be rejected |
    | x     | be rejected |
    | y     | be rejected |
    | z     | be rejected |
    | A     | be rejected |
    | B     | be rejected |
    | Z     | be rejected |
    | abc   | be rejected |
    | !     | be rejected |
    | %     | be rejected |
    | $     | be rejected |
    | -10   | be rejected |
    | --    | be rejected |
    | 0     | be rejected |
    | 3.14  | be rejected |
    | 1e3   | be rejected |
    | 100   | be accepted |