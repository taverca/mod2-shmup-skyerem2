using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    [Header("Inscribed")]
    public float rotationsPerSecond = 0.1f;

    [Header("Dynamic")]
    public int levelShown = 0; // This is set between lines // c & d

    public GameObject myHero; 
    // This non-public variable will not appear in the Inspector
    Material mat;                                                             // a

    void Start()
    {
        mat = GetComponent<Renderer>().material;                              // b
    }

    void Update()
    {
        // Read the current shield level from the Hero Singleton
        
      Hero hero1 = myHero.GetComponent<Hero>();
      Hero2 hero2 = myHero.GetComponent<Hero2>();
      float shieldLevel = 0;

          if (hero1 == null)
        {
            shieldLevel = hero2.shieldLevel;
        }
        else
        {
            shieldLevel = hero1.shieldLevel;
        }

        int currLevel = Mathf.FloorToInt(shieldLevel);   
            // c
                                                                            // If this is different from levelShown...
        if (levelShown != currLevel)
        {
            levelShown = currLevel;
            // Adjust the texture offset to show different shield level
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);       // d
        }
        // Rotate the shield a bit every frame in a time-based way
        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f;               // e
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
