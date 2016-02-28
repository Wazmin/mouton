using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
[RequireComponent (typeof (AudioSource))]

public class movieStarter : MonoBehaviour {

    public MovieTexture movie;
    Renderer r;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        r = GetComponent<Renderer>();
        r.material.mainTexture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
        Debug.Log("go video");
	}
	
	// Update is called once per frame
	void Update () {
        if (!movie.isPlaying)
        {
            SceneManager.LoadScene("Monde1");
        }
	}
}
