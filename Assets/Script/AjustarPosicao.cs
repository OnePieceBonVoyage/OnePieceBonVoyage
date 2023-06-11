using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarPosicao : MonoBehaviour
{
	public Transform player1;
	public Transform player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float player1X = player1.transform.position.x;
        float player2X = player2.transform.position.x;

		float diff = player2X - player1X;

		if (diff > 0)
		{
			Flip(player1.transform, true);
			Flip(player2.transform, true);
		} else if (diff < 0)
		{
			Flip(player1.transform, false);
			Flip(player2.transform, false);
		}
    }

	void Flip(Transform player, bool isFacingRight)
	{
		Vector3 scale = player.localScale;

		if (isFacingRight)
			scale.x = Mathf.Abs(scale.x);
		else
			scale.x = -Mathf.Abs(scale.x);

		player.localScale = scale;
	}
}
