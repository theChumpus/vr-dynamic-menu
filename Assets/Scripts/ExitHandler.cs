using UnityEngine;
using System.Collections;

public class ExitHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Cardboard>().OnBackButton += ()=>{Application.Quit(); };
	}
}
