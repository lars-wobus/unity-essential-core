# Contributing
When contributing to the animation module, please create a new issue. Do not use other communication channels to discuss changes.

## Pull Requests
* Ensure that pull requests does not introduce new compiler errors.
* All dependencies should be solved.
* When you decide not to upload external plugins:
    * enclose affected code by preprocessor directives
    * or use the Conditional Attribute

## Code Convetion
* Custom behhavioural scripts does not inherit from MonoBehaviour
* Custom behhavioural scripts must inherit from a base class
* Custom behhavioural scripts does not contain an Update or FixedUpdate function
* Custom behhavioural scripts must have at least one public method to set the animation progress
* Abstract classes must implement at least one interface
* Abstract classes must have the suffix <i>Base</i>
