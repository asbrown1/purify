﻿using UnityEngine;
using System.Collections;

public class LockCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
