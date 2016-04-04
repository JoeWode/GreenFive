using UnityEngine;
using System.Collections;
using Fungus;

public class doorOpen : MonoBehaviour {

    Animator anim;
    AudioSource sound;
    GameObject player;
    public Flowchart flowchart;
    public float doorDistance;
    public float openDistance = 6.0f;
    public bool isLocked = true;
    public bool isProximate = false;

	void Start () {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update() {
        doorDistance = Vector3.Distance(player.transform.position, transform.position);

        if (doorDistance < openDistance)
        {
            isProximate = true;
        }
        else {
            isProximate = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && isProximate && !isLocked) {
            if (!anim.GetBool("isOpen"))
            {
                anim.SetBool("isOpen", true);
                sound.Play();
            }
            else {
                anim.SetBool("isOpen", false);
                sound.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && isProximate && isLocked) {
            flowchart.ExecuteBlock("LockedDoor");
        }

    }
    
    void DoorSwitch()
    {
        isLocked = false;
        anim.SetBool("isOpen", true);
        sound.Play();
    }

}
