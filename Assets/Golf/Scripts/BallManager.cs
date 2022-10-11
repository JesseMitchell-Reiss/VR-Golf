using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallManager : MonoBehaviour
{
    public Vector3 lastLocation;

    public InputAction selectAction;

    private void Start()
    {
        lastLocation = this.transform.position;
        GameObject.FindObjectOfType<LevelManager>().score++;
        selectAction.Enable();
        selectAction.started += context => MoveToBall();
    }

    public void MoveToBall()
    {
        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude == 0 && Vector3.Distance(this.transform.position, FindObjectOfType<XROrigin>().gameObject.transform.position) >= 1)
        {
            GameObject XRSetup = FindObjectOfType<XROrigin>().gameObject;
            XRSetup.transform.position = this.transform.position + new Vector3(0f, 0.95f, 0f);
            lastLocation = this.transform.position;
            GameObject.FindObjectOfType<LevelManager>().score++;
        }
    }
    
    public void OutOfBounds()
    {
        this.transform.position = lastLocation;
        GameObject.FindObjectOfType<LevelManager>().score++;
    }
}
