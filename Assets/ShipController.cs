﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipController : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float speed = 4f;
    [Tooltip("In m")] [SerializeField] float range_x = 5f;
    [Tooltip("In m")] [SerializeField] float range_y = 3f;

    [SerializeField] float pos_pitch_factor = -5f;
    [SerializeField] float control_pitch_factor = -20f;

    [SerializeField] float pos_yaw_factor = 5f;
    [SerializeField] float control_roll_factor = -20f;

    float throw_x;
    float throw_y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * pos_pitch_factor;
        float pitchDueToThrow = throw_y * control_pitch_factor;
        float pitch = pitchDueToPosition + pitchDueToThrow;

        float yaw = transform.localPosition.x * pos_yaw_factor;

        float roll = throw_x * control_roll_factor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        throw_x = CrossPlatformInputManager.GetAxis("Horizontal");
        throw_y = CrossPlatformInputManager.GetAxis("Vertical");

        float offset_x = throw_x * speed * Time.deltaTime;
        float offset_y = throw_y * speed * Time.deltaTime;

        float pos_x = transform.localPosition.x + offset_x;
        float pos_y = transform.localPosition.y + offset_y;

        float modified_x = Mathf.Clamp(pos_x, -range_x, range_x);
        float modified_y = Mathf.Clamp(pos_y, -range_y, range_y);
        transform.localPosition = new Vector3(modified_x, modified_y, transform.localPosition.z);
    }
}