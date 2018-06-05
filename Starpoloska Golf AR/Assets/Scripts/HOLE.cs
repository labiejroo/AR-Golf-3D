using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOLE : MonoBehaviour {

	public GameObject winningMessage;

	//void OnTriggerEnter(Collider col)
	//{
	//	if (col.gameObject.tag == "ball")
	//		winningMessage.SetActive (true);
	//}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "ball")
        {
            winningMessage.SetActive(true);
            WinningLvlDATA.Instance.FullFillDATA();
        }
			
	}

    //IEnumerator StayInHole()
    //{
    //    yield return new WaitForSeconds(1.2f);


    //}

	//void OnTriggerExit(Collider col)
	//{
	//	if (col.gameObject.tag == "ball")
	//		winningMessage.SetActive (false);
	//}
}
