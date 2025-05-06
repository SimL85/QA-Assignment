Feature: FieldValidationBetField 

A short summary of the feature

Scenario: Validate the bet field
	Given Navigate to the slot game page
	When Enter <input> in the bet field
	Then The bet field should <result>
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
    | -10   | be accepted |
    | --    | be rejected |
    | 0     | be rejected |
    | 3.14  | be rejected |
    | 1e3   | be rejected |
    | 100   | be accepted |