using UnityEngine;
using System;

public class GuiScript : MonoBehaviour 
{

	public CustomGuiButton milkSoy;
	public CustomGuiButton milkWhole;
	public CustomGuiButton milkTwoPercent;
	
	void OnGUI() 
	{
		if(milkSoy.OnMouseClick()){ 
			Debug.Log("clicked milkSoy");
		}
		else if(milkWhole.OnMouseClick()){ 
			Debug.Log("clicked milkWhole");
		}
		else if(milkTwoPercent.OnMouseClick()){ 
			Debug.Log("clicked milkTwoPercent");
		}
	}
	
}

[Serializable] // Exposes public variables of custom class to Unity's Inspector.
public class CustomGuiButton
{
	public GUIStyle style = new GUIStyle();
	public Vector2 position = new Vector2(100,100);
	
	public bool OnMouseClick(){
		return GUI.Button(new Rect(position.x, 
								   position.y, 
								   style.normal.background.width,
								   style.normal.background.height),
						  "", 
						  style);
	}
}		