using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game { //don't need ": Monobehaviour" because we are not attaching it to a game object

	public static Game current;
	public Character username;
	public Character lastname;
	public Character type;

	public Game () {
		username = new Character();
		lastname = new Character();
		type = new Character();
	}
		
}
