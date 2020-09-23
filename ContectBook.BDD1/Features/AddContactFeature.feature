Feature: AddContactFeature
	In order to add a contact 
	As a user 
	I want to be told to add the contact 

@mytag
Scenario Outline: Add Contact with all valid details
	When I create a contact with the following details '<FirstName>','<LastName>','<DOB>','<Emails>','<PhoneNos>'
	Then the contact should be created with status code 'Created'

	Examples:
		| Scenario | FirstName | LastName | DOB        | Emails        | PhoneNos |
		|          | Harshit   | Agarwal  | 01-06-1991 | abc@gmail.com | 123456   |