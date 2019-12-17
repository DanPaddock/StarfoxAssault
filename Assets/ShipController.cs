using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipController : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float speed = 4f;
    [Tooltip("In m")] [SerializeField] float range_x = 5f;
    [Tooltip("In m")] [SerializeField] float range_y = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float throw_x = CrossPlatformInputManager.GetAxis("Horizontal");
        float throw_y = CrossPlatformInputManager.GetAxis("Vertical");

        float offset_x = throw_x * speed * Time.deltaTime;
        float offset_y = throw_y * speed * Time.deltaTime;

        float pos_x = transform.localPosition.x + offset_x;
        float pos_y = transform.localPosition.y + offset_y;

        float modified_x = Mathf.Clamp(pos_x, -range_x, range_x);
        float modified_y = Mathf.Clamp(pos_y, -range_y, range_y);
        transform.localPosition = new Vector3(modified_x, modified_y, transform.localPosition.z);
    }
}
