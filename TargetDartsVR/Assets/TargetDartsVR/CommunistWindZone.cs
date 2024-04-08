using UnityEngine;

public class CommunistWindZone : MonoBehaviour
{
    public float max_wind_strength = 0.5f;
    public float min_wind_strength = 0f;
    public float wind_strength = 0f;
    public int direction = 1;
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("DartPoint"))
        {
            
            Rigidbody dartRigidbody = other.transform.parent.GetComponent<Rigidbody>();
            if (dartRigidbody != null)
            {
                //Debug.Log("GOTHERE");
                // Apply wind force in the direction of the fan
                dartRigidbody.AddForce(Vector3.left * wind_strength * direction);
            }
        }
    }
}