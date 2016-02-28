using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (ApplicationModel.reuni)
        {
            transform.Find("Player").gameObject.SetActive(false);
            transform.Find("Player1AfterWin").gameObject.SetActive(true);
            transform.Find("Cihine").gameObject.SetActive(true);
            transform.Find("Updated+stargates").transform.Find("Trigger TP Monde").gameObject.SetActive(false);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
