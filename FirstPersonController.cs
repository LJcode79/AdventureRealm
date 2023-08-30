using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstPersonController : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	public LayerMask ground;
	public Transform feet;
    public GameObject walkSound;
    public GameObject controls;
    AudioSource walk;

	private Vector3 direction;
	private Rigidbody rbody;
	//private AudioSource audio;

	private float rotationSpeed = 1f;
	private float minY = -60f;
	private float maxY = 60f;
	private float rotationY = 0f;
	private float rotationX = 0f;
    //int walkplay;
    int showControls;
    TextMeshProUGUI ctrlTxt;

    // Use this for initialization
    void Start () {
		speed = 5.0f;
		//jumpHeight = 3.0f;
		rbody = GetComponent<Rigidbody>();
		//audio = GetComponent<AudioSource>();
        walk = walkSound.GetComponent<AudioSource>();
        //walkplay = 0;
        ctrlTxt = controls.GetComponent<TextMeshProUGUI>();
        ctrlTxt.text = "Press P for controls";
    }
	
    void toggleCtrls()
    {
        //if (ctrlTxt.text == "Controls: wasd- move \nspace - jump \ntab- inventory \ng- drop \ne- pick up \nhold left click- use bow \nr- reload \nscroll wheel/ numbers - change weapon")
        //{
            //ctrlTxt.text = "";
        //}
        if(ctrlTxt.text == "Press P for controls")
        {
            ctrlTxt.text = "Controls: wasd- move \ntab- inventory/objectives \ng- drop \ne- pick up \nleft click- swing sword \nhold left click- use bow \nr- reload \nscroll wheel/ numbers - change weapon";
        }
        else
        {
            ctrlTxt.text = "Press P for controls";
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("p");
            toggleCtrls();
            //ctrlTxt = "Controls: wasd- move \nspace - jump \ntab- inventory \ng- drop \ne- pick up \nhold left click- use bow \nr- reload \nscroll wheel/ numbers - change weapon";
        }
        //walk.enabled = false;
        /*
        walkplay = 0;
        if (walkplay == 1)
        {
            walk.Play();
        }
        else
        {
            walk.Pause();
        }
        */

        direction = Vector3.zero;
		direction.x = Input.GetAxis("Horizontal");
		direction.z = Input.GetAxis("Vertical");
		direction = direction.normalized;
        if (direction.x != 0)
        {
            if (!walk.isPlaying)
            {
                walk.Play();
            }
            //walkplay = 1;
            //walk.enabled = true;
            //walk.Play();
            rbody.MovePosition(rbody.position + transform.right * direction.x * speed * Time.deltaTime);
        }
        if (direction.z != 0)
        {
            if(!walk.isPlaying)
            {
                walk.Play();
            }
            //walkplay = 1;
            //walk.enabled = true;
            //walk.Play();
            rbody.MovePosition(rbody.position + transform.forward * direction.z * speed * Time.deltaTime);
        }

		rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
		rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
		rotationY = Mathf.Clamp(rotationY, minY, maxY);
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


        //bool isGrounded = Physics.CheckSphere(feet.position, 0.1f, ground, QueryTriggerInteraction.Ignore);
        //bool isGrounded = OnTriggerEnter(Collider other);
        //
        //Debug.Log("TEST" + isGrounded);
        /*
        Debug.Log("TEST" + isGrounded);
        if (Input.GetButtonDown("Jump") && isGrounded) {
			//audio.Play();
			rbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
		}
        */
    }
}
