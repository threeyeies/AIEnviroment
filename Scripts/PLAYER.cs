using UnityEngine;
using System.Collections;
public class PLAYER : MonoBehaviour {
	public static float VIDA = 100;
	void Update (){
		if (VIDA <= 0) {
			Debug.Log ("murio");
		}
	}
}