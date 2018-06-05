using Academy.HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drop : Singleton<drop> {

    public GameObject startPanel;
    public Text counter;
    public AudioSource audioSource;
	// Use this for initialization
	void Start () {

        
    }
	
    public void StartDrop()
    {
        Invoke("Drop", 9f);
        StartCoroutine("CounterCountingDown");
        
    }

    public void PlayAudio()
    {

    }

    IEnumerator CounterCountingDown()
    {
        yield return new WaitForSeconds(1f);
        int a = int.Parse(counter.text);
        a--;
        counter.text = a.ToString();
        if (a > 0)
        {
            StartCoroutine("CounterCountingDown");
        }
        else
        {
            StartMenuScript.Instance.TurnOffmiddleCounter();
        }

    }
	// Update is called once per frame
	void Update () {
		
	}

	void Drop()
	{
        startPanel.SetActive(false);
		this.gameObject.transform.parent.GetComponent<Rigidbody> ().useGravity = true;
	
	}
}
