using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour {
    private bool isDestroying = false;
	// Use this for initialization
	void Start () {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (!isDestroying)
        {
            Debug.Log(collision.gameObject.name);
            if (collision.gameObject.name == "Alien")
            {
                Destroy(gameObject, 3f);
            }
            isDestroying = true;
        }
    }
}
