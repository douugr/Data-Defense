﻿using UnityEngine;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
	public float scrollSpeed = 1f;
	public float minimumY = 10f;
	public float maximumY = 80f;
	private bool doMovement = true;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		doMovement = !doMovement;

		if(!doMovement)
		return;

		if(Input.GetKey("w"))
		{
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if(Input.GetKey("s"))
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if(Input.GetKey("a"))
		{
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}
		if(Input.GetKey("d"))
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;

		pos.y -= scroll * 100 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minimumY, maximumY);

		transform.position = pos;
		
	}
}