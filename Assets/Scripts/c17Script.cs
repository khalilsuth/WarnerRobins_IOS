using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c17Script : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20.0f;
    private Rigidbody c17;
    public float upwardForce = 0.3f;
    public float time = 5f;
    public float leftForce = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        c17 = GetComponent<Rigidbody>();

        //Destroy plane after x seconds
        StartCoroutine(timeOfFlight());
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement moves plane slightly above player 
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        c17.AddForce(Vector3.left * leftForce, ForceMode.Impulse);
        c17.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);


    }
    IEnumerator timeOfFlight()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
