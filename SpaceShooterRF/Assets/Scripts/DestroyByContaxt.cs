using UnityEngine;
using System.Collections;

public class DestroyByContaxt : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary") 
		       {
			return;
	        	}
		//	Debug.Log (other.name);
		Destroy(other.gameObject);
		Destroy(gameObject);
		}
}
