using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainGameScreen : MonoBehaviour {
	public string GameScene;
    private bool setAi = false;
	private AudioSource audio;
	public AudioClip creak;

	public GameObject ControlsScreen;

    public bool SetAI {
        get
        {
            Destroy(gameObject);
            return setAi;
        }
    }

	void Awake()
	{
		audio = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	private void Update()
	{
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            return;
        }
		if (Input.GetButtonDown ("A")) {
			//audio.PlayOneShot (creak);
			Time.timeScale = 1;
			//Invoke ("Load", creak.length/2);
			Load ();
		} else if (Input.GetButtonDown ("B")) {
			Application.Quit ();
		} else if (Input.GetButtonDown ("X")) {
			//audio.PlayOneShot (creak);
			Time.timeScale = 1;
			DontDestroyOnLoad (gameObject);
			setAi = true;
			//Invoke ("Load", creak.length/2);
			Load ();
		} else if (Input.GetButtonDown ("Y")) {
			ControlsScreen.SetActive (!ControlsScreen.activeSelf);
		}
	}

	private void Load()
	{
		SceneManager.LoadScene(GameScene, LoadSceneMode.Single);
	}
}
