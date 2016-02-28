using UnityEngine;
using System.Collections;

public class ForcerChute : MonoBehaviour {
    private GameObject[] player;
    private Transform rbPlayer;

    public float vitessechute;

     void OnTriggerStay(Collider other)
    {
        Vector3 tempPos = rbPlayer.position;
        tempPos.y -= (1 * vitessechute); 
        player[0].transform.position = tempPos;
    }

    // Use this for initialization
    void Start () {
	    player = GameObject.FindGameObjectsWithTag("MainCamera");
        rbPlayer = player[0].GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
