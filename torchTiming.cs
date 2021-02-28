using UnityEngine;

public class torchTiming : MonoBehaviour
{
    public float timerTime = 20.0; 
    public bool holdingATorch = false; 
    public Transform handObject; 

    void FireMechanic(int OnOrOff = 1) 
    {
        if (OnOrOff = 1) 
        {
            ParticleSystem fire = GetComponent<ParticleSystem>();
            fire.time = timerTime; 
            do
            {
                fire.Play(); 
                timerTime = timerTime - Time.deltaTime * 10; 
            } while (timerTime <= 0); 
            if (timerTime <= 0) { fire.Stop(); } 
        }
        else if (OnOrOff = 0) 
        {
            fire = GetComponent<ParticleSystem>(); 
            fire.Stop(); 
            timerTime = 0;
        }
    }

    void Pickup()
    {
        holdingATorch = true; 
        GetComponent<BoxCollider>().enabled = false; 
        GetComponent<Rigidbody>().useGravity = false; 
        this.transform.position = handObject.position;
        this.transform.parent = GameObject.Find("HandObject").transform; 
        foreach (Transform item in transform)
        {
            if (item.gameObject.CompareTag("Holdable Torch")) { item.gameObject.SetActive(true); } 
            else { item.gameObject.SetActive(false); } 
        }
    }

    void Leave()
    {
        holdingATorch = false; 
        GetComponent<BoxCollider>().enabled = true;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }

    void Uptade()
    {
        void OnMouseDown() 
        {
            if (gameObject.CompareTag("Holdable Torch")) { Pickup(); FireMechanic(1); } 
            if (gameObject.CompareTag("Unholdable Torch")) 
            {
                if (holdingATorch = true) { timerTime = 20.0; }
            }
            else { if (holdingATorch = true) { Leave(); FireMechanic(0); } } 
        }
    }
}