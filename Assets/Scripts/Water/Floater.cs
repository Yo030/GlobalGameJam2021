using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = .5f;

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);

        //float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);

        if (transform.position.y < 0f) //cambiar el 0f por algún valor para determinar la altura del agua
        {
            float displacementMulitiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;   //al valor de la altura del agua hay que restarle el transform.position.y ej: waveHeight - transform.position.y 
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMulitiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMulitiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMulitiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
