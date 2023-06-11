using UnityEngine;

//Credit: Stan

public class HeadBob : MonoBehaviour
{
    public float walkingBobbingSpeed = 15f;
    public float bobbingAmount = 0.1f;

    float defaultYPosition = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultYPosition = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //Player is moving
        {
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultYPosition + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
            if (timer >= 16)
            {
                FindObjectOfType<AudioManager>().PlayAudio("PlayerWalk");
                timer = 0;
            }
		}

        else //Idle
        {
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultYPosition, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}