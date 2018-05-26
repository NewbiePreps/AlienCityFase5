using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestart : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 1;

    void Start()
    {
        curHealth = maxHealth;
    }


    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == "armadilhas")
        {
            curHealth = curHealth - 1;
        }
    }

    void Update()
    {

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Finish")
        {
            Die();
        }
    }

    void Die()
    {
        //Restart
        Application.LoadLevel(Application.loadedLevel);
    }


    public void Damage(int dmg)
    {
        curHealth -= dmg;

    }
}
