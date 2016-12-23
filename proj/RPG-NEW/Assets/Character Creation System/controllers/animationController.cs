using UnityEngine;
using System.Collections;

public class animationController : MonoBehaviour {

    public Animator FemaleAnim;
    public Animator MaleAnim;
    float animSpeed;
    bool selectedCharacter; 

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
        if (!selectedCharacter)
        {
            FemaleAnim.SetBool("chosenCharacter", false);
            MaleAnim.SetBool("chosenCharacter", false);
            animSpeed+=.1f;
            if (animSpeed > 10000f)
            {
                animSpeed = 0f;
            }
            FemaleAnim.SetFloat("Blend", animSpeed);
            MaleAnim.SetFloat("Blend", animSpeed);
        }
        else
        {
            FemaleAnim.SetBool("chosenCharacter", true);
            MaleAnim.SetBool("chosenCharacter", true);
        }
	}
}
