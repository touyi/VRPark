using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{

	void Start ()
    {
        GetComponent<Cardboard>().OnBackButton += () => { SceneManager.LoadScene(0); };
	}
	
	
}
