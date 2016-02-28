using UnityEngine;
using System.Collections;

public class Trainee : MonoBehaviour {
    public float timeTrainee;
    private float timer;


	// Use this for initialization
	void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        
	    if((Time.time - timer) > timeTrainee)
        {
            Destroy(this.gameObject);
        }
	}
}
