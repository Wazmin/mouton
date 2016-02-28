using UnityEngine;
using System.Collections;

public class TriggerPorte : MonoBehaviour {
    public GameObject porte;
    private Animator animPorte;


    void OnTriggerEnter(Collider other)
    {
        animPorte.SetBool("devantPorte", true);
    }

    // Use this for initialization
    void Start () {
        animPorte = porte.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
