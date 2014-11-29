Turing Machine simulator
=================
syntax to add instructions

```
AddTransition(
	string inStateName, string inSymbolName, 
	string finSymbolName, string direction, string finStateName);
```

where

	inStateName = name of initial state
	inSymbolName = initial symbol
	finSymbolName = symbol to write
	
	direction = "l"/"L" - move tape head to the left
				"r"/"R" - move tape head to the right
				"*" 	- don't move the tape head 
  
	finStateName = name of next state
  
  
there are 3 predefined states:

	"start" - start state, 
		set of transition functions should always include instruction with this state
	"halt" - machine halts 
	"accept" - machine halts and accepts
  
  
other halt and accept states can be created explicitly
