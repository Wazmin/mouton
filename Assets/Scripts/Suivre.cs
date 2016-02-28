using UnityEngine;
using System.Collections;

public class Suivre : MonoBehaviour {

    public float vitesse;

    Animator anim;
    int runHash = Animator.StringToHash("run");

    private Transform sauveur;
    private bool sauveurTrouve;
    Rigidbody rb;

    Vector3 directionSauveur;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sauveurTrouve = false;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (sauveurTrouve)
        {
            ApplicationModel.reuni = true;
            //mise a jour de la direction
            directionSauveur = Vector3.Normalize(sauveur.transform.position - transform.position);
            if (Vector3.Distance(transform.position, sauveur.transform.position) > 5)
            {
                rb.AddForce(directionSauveur * vitesse, ForceMode.Acceleration);
                transform.LookAt(sauveur.transform.position);
                anim.SetTrigger(runHash);
            }
            else
            {
                anim.SetBool(runHash, false);
                transform.LookAt(sauveur.transform.position);
            }
        }
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (!sauveurTrouve)
        {
            sauveur = other.GetComponent<Transform>();
            sauveurTrouve = true;
            directionSauveur = Vector3.Normalize(sauveur.transform.position - transform.position);
                
        }
    }
}
