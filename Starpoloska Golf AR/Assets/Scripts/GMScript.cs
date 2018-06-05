using Academy.HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GMScript : Singleton<GMScript> {

    public AudioClip[] audioClips; //0-click,1-kick,2-background
    public AudioSource audioSource;
    public AudioSource audioSourceBG;

    public Slider slider;
	public  GameObject _ball;   
	public GameObject directionPointer;
    public Transform HolePosition;
    public GameObject Golfer;
    public GameObject placeForGolfer;
    public Animator animator;
    public DefaultTrackableEventHandler script;
    [HideInInspector]
    public bool anim1, anim2, anim3;

    public GameObject[] GameLevels;
    private int currentLevel = 0;
    private int nextLevel = 1;

    bool isBallHasBeenShoot = false;
    bool onlyOneShoot = false;
	bool isStarted = true;
	bool isSliderFull = false;
	float rotateDirection;

    public int overallPlayerScore;

    //Lvl1
    private int lvl1Par = 3;

    //lvl2
    private int lvl2Par = 4;


    void Start()
    {
        slider.value = 0f;
        PlayAudioBackGround();
       
       // animator = GetComponent<Animator>();
    }

    public void ChangeLevel()
    {
        if (GameUI.Instance.level.text != "2")
        {
            GameLevels[currentLevel].SetActive(false);
            GameLevels[nextLevel].SetActive(true);

            GameUI.Instance.NullShoots();
            currentLevel++;
            nextLevel++;
        }
    }

    public void PlayAudioClick()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    public void PlayAudioKick()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }
    public void PlayAudioBackGround()
    {
        audioSourceBG.clip = audioClips[2];
        audioSourceBG.Play();
    }
    

    public void ResetGame()
    {

    }

	Vector3 vec(Vector3 A, Vector3 B)
	{
		Vector3 jednostkowy = (B - A) / Vector3.Distance(A, B);
		return jednostkowy;
	}

	void RotateBallDirection()
	{
        
          
		_ball.transform.Rotate(new Vector3(0, rotateDirection, 0));	
	}

    void ShowBestWay()
    {
        //2.Raycast to the floor
        RaycastHit hitPoint;
        if (Physics.Raycast(_ball.transform.position, -Vector3.up, out hitPoint, 10f))
        {
            Vector3 hitPointOnTheFloor = hitPoint.point;
            Vector3 holePosition = HolePosition.position;

            Vector3 FinalDirection = vec(hitPointOnTheFloor, holePosition);

            directionPointer.transform.position = _ball.transform.position + FinalDirection / 200;
            directionPointer.transform.LookAt(HolePosition);
            Debug.Log("AAAAAAAAAAAA" + FinalDirection);
        }
    }

	public void RotateLeft()
	{
	
		rotateDirection -= 5f;
		RotateBallDirection ();
	}

	public void RotateRight()
	{

		rotateDirection += 5f;
		RotateBallDirection ();
	}

	public void StartStop()
	{
		isStarted = !isStarted;
        script.isStartedVuf = true;
        if (!isStarted)
		{
            
            animator.Play("golfer_fullswing", -1, 0);
            Debug.Log("seetingANimationBOOL");

        }

	
		if (isStarted == true) 
		{
            GameUI.Instance.AddShoot();
            PlayAudioKick();
            float force = slider.value;
			AddForceToSphere (force);

            isBallHasBeenShoot = true;
            onlyOneShoot = true;

            
		}


	}

    private void MoveGolferToNextPosition()
    {
        Golfer.transform.position = placeForGolfer.transform.position;
    }

    void AddForceToSphere(float _force)
	{
		//1.Turn Off Viusal oF Direction Indicator
		directionPointer.GetComponent<MeshRenderer> ().enabled = false;
        slider.value = 0;

		Vector3 dir = vec (_ball.transform.position, directionPointer.transform.position);
		_ball.GetComponent<Rigidbody>().AddForce(dir * _force *60);

	
	}
	
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (isStarted == false) {

            isBallHasBeenShoot = false;

			if (slider.value >= 0 && slider.value < 1 && isSliderFull == false) {
				slider.value += 0.01f;
			}
			if (slider.value == 1 || isSliderFull == true) {
				isSliderFull = true;
				slider.value -= 0.01f;
				if (slider.value == 0) {
					isSliderFull = false;
				}

			}

            
		}
	}




    private void Update()
    {
        if (_ball.GetComponent<Rigidbody>().IsSleeping() && isBallHasBeenShoot == true && onlyOneShoot == true )         
        {
            directionPointer.GetComponent<MeshRenderer>().enabled = true;
            _ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            ShowBestWay();
            onlyOneShoot = false;

            MoveGolferToNextPosition();
        }
       
    }
}
