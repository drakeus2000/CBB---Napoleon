using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	private float dragSpeed = 0.0025f;
	private float timeDragStarted;
	private Vector3 previousPosition = Vector3.zero;
	public bool franceball_clickedon = false;
	public Transform player;
	Vector3 original_location;
	float offsetX;
	float offsetY;
	public GameObject player_go;
	Vector3 pos;
	public bool firedball = false;

	void Awake (){
		original_location = transform.position;
		player_go = GameObject.FindGameObjectWithTag ("Damager");

	}

	public void Start () {



		player = player_go.transform;

		if (player_go == null) {
			Debug.Log ("Cannot find player");
			return;
		}

		
		offsetX = (transform.position.x - player.position.x)/2;
		
	}

    // Update is called once per frame
    void Update(){

		if ((player != null) && firedball && !franceball_clickedon){
				
				pos = transform.position;
				pos.x = Mathf.Clamp(player.position.x + offsetX, -2,11.6f);
				pos.y = Mathf.Clamp(player.position.y, 0, 2.715f);
				transform.position = pos;
		}

		if (Input.GetMouseButtonDown(0) && !franceball_clickedon)  
            {
               // timeDragStarted = Time.time;
                dragSpeed = 0.02f;
                previousPosition = Input.mousePosition;
            }
            //we calculate time difference in order for the following code
            //NOT to run on single taps ;)
		else if (Input.GetMouseButton(0) && Time.time - timeDragStarted > 0.05f && !franceball_clickedon)
            {
                //find the delta of this point with the previous frame
                Vector3 input = Input.mousePosition;
                float deltaX = (previousPosition.x - input.x)  * dragSpeed;
                float deltaY = (previousPosition.y - input.y)  * dragSpeed;
                //clamp the values so that we drag within limits
                float newX = Mathf.Clamp(transform.position.x + deltaX, -2, 12f);
                float newY = Mathf.Clamp(transform.position.y + deltaY, 0, 2.715f);
                //move camera
                transform.position = new Vector3(
                    newX,
                    newY,
                    transform.position.z);

                previousPosition = input;
                //some small acceleration ;)
      //          if(dragSpeed < 0.1f) dragSpeed += 0.001f;
            }
        }
	public void update_franceball(){
		franceball_clickedon = !franceball_clickedon;
	}
	public void fired_franceball(){
		firedball = !firedball;
	}

	public void restore_camera(){
		transform.position = original_location;
		fired_franceball ();
        Start ();
	}
}



