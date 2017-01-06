using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour {

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	public bool gripButtonDown = false;
	public bool gripButtonUp = false;
	public bool gripButtonPressed = false;

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	public bool triggerButtonDown = false;
	public bool triggerButtonUp = false;
	public bool triggerButtonPressed = false;

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device controller {get { return SteamVR_Controller.Input((int) trackedObj.index);}}

	public float acc = 10;
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>(); 
	}
	
	// Update is called once per frame
	void Update () {

		if (controller == null)
			return;

		gripButtonDown = controller.GetPressDown(gripButton);
		gripButtonUp = controller.GetPressUp(gripButton);
		gripButtonPressed = controller.GetPress(gripButton);

		triggerButtonDown = controller.GetPressDown(triggerButton);
		triggerButtonUp = controller.GetPressUp(triggerButton);
		triggerButtonPressed = controller.GetPress(triggerButton);

		if (triggerButtonDown) {
			GameObject b = Instantiate (bullet, trackedObj.transform.position, trackedObj.transform.rotation) as GameObject;
			b.GetComponent<Rigidbody> ().AddForce (b.transform.forward * acc);
		}
	}
}
