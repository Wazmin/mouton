using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerTpScene : MonoBehaviour {
    public string nomDeLaScene;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nomDeLaScene);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
