using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjustarPosicao : MonoBehaviour
{
	public Transform player1;
	public Transform player2;

    // Update is called once per frame
    void Start()
    {
    }
    void Update()
    {
        float player1X = player1.transform.position.x;
        float player2X = player2.transform.position.x;

		float diff = player2X - player1X;

        var pc1 = player1.GetComponent<PlayerController>();
        var pc2 = player2.GetComponent<PlayerController>();

        if (diff > 0)
		{
			Flip(player1.transform, pc1.FlipNeeded);
			Flip(player2.transform, !pc2.FlipNeeded);

			player1.GetComponent<PlayerController>().ImpulseDirection = pc1.FlipNeeded ? -1f : 1f;
            player2.GetComponent<PlayerController>().ImpulseDirection = pc2.FlipNeeded ? 1f : -1f;

        } else if (diff < 0)
		{
			Flip(player1.transform, !pc1.FlipNeeded);
			Flip(player2.transform, pc2.FlipNeeded);

            player1.GetComponent<PlayerController>().ImpulseDirection = pc1.FlipNeeded ? 1f : -1f;
            player2.GetComponent<PlayerController>().ImpulseDirection = pc2.FlipNeeded ? -1f : 1f;
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
