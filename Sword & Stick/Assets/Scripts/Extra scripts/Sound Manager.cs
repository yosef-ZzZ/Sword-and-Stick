using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerAttackSound, playerDamageSound, skeletonDamageSound;
    static AudioSource audioScr;

    // Start is called before the first frame update
    void Start()
    {
        playerAttackSound = Resources.Load<AudioClip> ("SwordSlash");
        playerDamageSound = Resources.Load<AudioClip> ("PlayerDamage");
        skeletonDamageSound = Resources.Load<AudioClip> ("SkeletonDamage");

        audioScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case "SwordSlash":
                audioScr.PlayOneShot (playerAttackSound);
                break;
            case "PlayerDamage":
                audioScr.PlayOneShot (playerDamageSound);
                break;
        }
    }
}
