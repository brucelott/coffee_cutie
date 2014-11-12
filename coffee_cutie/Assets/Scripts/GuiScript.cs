using UnityEngine;
using System;

public class GuiScript : MonoBehaviour {

	public CustomGuiButton milkSoy;
	public CustomGuiButton milkWhole;
	public CustomGuiButton milkTwoPercent;
	
	void Start(){
		milkSoy.init();
		milkWhole.init();
		milkTwoPercent.init();
	}
	
	void OnGUI() {
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

[Serializable] // This exposes public variables to Unity's Inspector.
public class CustomGuiButton{
	public GUIStyle style = new GUIStyle();
	public Texture2D image;
	public int X = 100;
	public int Y = 100;
	
	public void init(){
		style.normal.background = image;
	}
	
	public bool OnMouseClick(){
		return GUI.Button(new Rect(X,Y, image.width,image.height), "", style);
	}
}		