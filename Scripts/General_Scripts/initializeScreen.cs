using UnityEngine;
using System.Collections;

public class initializeScreen : MonoBehaviour {

    AnimatedTextureUV anim;

	void Start () {
        anim = GetComponent<AnimatedTextureUV>();
        anim._uvTieX = 4;
        anim._uvTieY = 3;
    }
	
	void Update () {
        if (anim._uvTieX == 4 && anim._uvTieY == 3) {
            anim._uvTieX = 3;
            anim._uvTieY = 4;
        }
	}
}
