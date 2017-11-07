using System.Collections;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
   



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Boundry") || other.CompareTag ("Enemy"))
        {
            return;
        }

        if (explosion != null)
        {

            Instantiate(explosion, transform.position, transform.rotation);
        }

        if(other.CompareTag ("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            
            PlayerData.data.gameOver = true;
        }

        PlayerData.data.score += scoreValue;
      
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
	
}
