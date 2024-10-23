Feature:  Skill Tab Test scenarios

As a Mars portal user 
I would like to create,edit and delete skill records
so that I can manage my skill profile successfully

@PostiveScenario @NegativeWithvalidInput 
Scenario: create Skill record with data
	Given I logged into Mars portal 
	And I navigate to Skill tab
	When I add a skill "<Skill>" and level "<Level>"
	Then the new "<Skill>" record should be created successfully

	Examples: 
	| Skill			  | Level        |
	| C#			  | Beginner     |
	| HeNNa ArtisT	  | Intermediate |
	| H7474 baker     | Expert       |
	| Math            | Expert       |

@NegativeWithInvalidInput
Scenario Outline: Error is displayed when a Invalid Skill record is created
Given I logged into Mars portal
And I navigate to Skill tab
When I add an invalid skill "<Invalid Skill>" and invalid level "<Invalid Level>"
Then the error message should be displayed successfully

Examples: 
| Invalid Skill | Invalid Level |
|               | Intermediate  |
| Nail Art      |               |
|  Math         |  23		    |

	Scenario: Edit Skill record with new data
	Given I logged into Mars portal 
	And I navigate to Skill tab
	When I edit an existing "<Skill>" and "<Level>" to "<Updated Skill>" and level "<Updated Level>"
	Then the new "<Updated Skill>" record should be displayed successfully

	Examples: 
	| Skill  |  Level    | Updated Skill | Updated Level |
	|Baking  | Expert    | Sewing        | Beginner      |
	|Coding  | Beginner  | Baking        | Expert        |

	Scenario Outline: delete an existing Skill record 
	Given I logged into Mars portal
	And I navigate to Skill tab
	When I have a "<Skill>" and "<Level>" record to delete
	Then the skill record should be deleted successfully
	Examples: 
	| Skill         | Level      |
	| Knitting		| Beginner   |
	| Reading       |  Expert    |