using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c5Sript : MonoBehaviour
{
    public float speed = 20.0f;
    private Rigidbody c5;
    public float upwardForce = 0.03f;
    public float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        c5 = GetComponent<Rigidbody>();

        //Destroy plane after x seconds
        StartCoroutine(timeOfFlight());
    }

    // Update is called once per frame
    void Update()
    {
        //Basic movement moves plane slightly above player 
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        c5.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);

        
    }
    IEnumerator timeOfFlight()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
