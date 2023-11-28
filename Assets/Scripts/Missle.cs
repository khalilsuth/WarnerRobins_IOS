using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public float speed = 30.0f;
    public float time = 2f;
    private Rigidbody missle;
    public float upwardForce = .01f;
    public float forwardForce = .3f;
    // Start is called before the first frame update
    void Start()
    {
        missle = GetComponent<Rigidbody>();

        StartCoroutine(timeOfFlight());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        missle.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
        missle.AddForce(Vector3.forward * -forwardForce, ForceMode.Impulse);
    }
    IEnumerator timeOfFlight()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
