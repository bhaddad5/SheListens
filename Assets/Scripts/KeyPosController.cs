using UnityEngine;
using System.Collections;
using System; //This allows the IComparable Interface
using System.Collections.Generic;

public class KeyPosController : MonoBehaviour {

	List<Vector3> keyPositions = new List<Vector3>();
    private bool keyPickedUp = false;

	void Start()
	{
		keyPositions.Add(new Vector3(1.4f, 0.564f, .463f));
		keyPositions.Add(new Vector3(-1.094f, -0.185f, 1.276f));
		keyPositions.Add(new Vector3(1.608f, 0.751f, -0.842f));
		keyPositions.Add(new Vector3(1.412f, -0.044f, -1.562f));
	}

	public void RespawnKey()
	{
        if (!keyPickedUp)
        {
            Vector3 newPos = keyPositions[UnityEngine.Random.Range(0, keyPositions.Count)];
            if (newPos == transform.position)
            {
                RespawnKey();
            }
            else
            {
                transform.position = newPos;
            }
        }
	}

    public void setKeypickedUp(bool up)
    {
        keyPickedUp = up;
    }
}
