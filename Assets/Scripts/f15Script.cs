using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class f15Script : MonoBehaviour
{
    public float speed = 30.0f;
    private Rigidbody f15;
    public float upwardForce = 0.03f;
    public float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        f15 = GetComponent<Rigidbody>();

        //Destroy plane after x seconds
        StartCoroutine(timeOfFlight());
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement moves plane slightly above player 
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        f15.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);


    }
    IEnumerator timeOfFlight()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
