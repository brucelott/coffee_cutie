using UnityEngine;
using System.Collections;

public enum Ingredients  {
	none,
	hotCup, coldCup,
	expresso, 
	milk, 
	steam,
	plainSyrup, vanilla, mocha, 
	cap, cardboardCuff, 
	ice, lidAndStraw
	
}



// Since milk and type and type of container change with each drink they're in separate enums
public enum TypesOfMilk {
	none,
	milkNonFat,
	milk2percent,
	milkSoy, 


}

public enum TypesOfContainers { //since cold or hot are part of the drink here we only take care of the variable part
	none,
	forHere, 
	toGo, 

}