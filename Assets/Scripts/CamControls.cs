/**
    Need to be placed on a camera GameObject
    allow to turn arround and zoom on the parent
    GameObject witch the camera is attached
    desfontaines.vncent@Gmail.com
**/

using UnityEngine;
using System.Collections;

public class CamControls : MonoBehaviour {
    public float horizontalRotationSpeed;
    public float verticalRotationSpeed;

    Transform parentCam;

    float m_MousseXInputValue;
    float m_MousseYInputValue;

    // Use this for initialization
    void Start () {
        parentCam = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
        m_MousseXInputValue = Input.GetAxis("Mouse X");
        m_MousseYInputValue = Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            rotateArround();
            zoom();
        }
    }

    void rotateArround()
    {
            transform.RotateAround(parentCam.transform.position, Vector3.Cross(parentCam.transform.up,(parentCam.position-transform.position)), verticalRotationSpeed * -m_MousseYInputValue * Time.deltaTime);
            transform.RotateAround(parentCam.transform.position, parentCam.transform.up, horizontalRotationSpeed * m_MousseXInputValue * Time.deltaTime);
      
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(verticalRotationSpeed * -m_MousseYInputValue * Time.deltaTime, horizontalRotationSpeed * m_MousseXInputValue * Time.deltaTime, 0.0f));
    }
    void backCentred()
    {

    }

    void zoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 ) // forward
        {
            transform.Translate(Vector3.Normalize(parentCam.position - transform.position) * Input.GetAxis("Mouse ScrollWheel"), Space.World);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
         {
            transform.Translate(Vector3.Normalize(parentCam.position - transform.position) * Input.GetAxis("Mouse ScrollWheel"), Space.World);
        }
    }
}
