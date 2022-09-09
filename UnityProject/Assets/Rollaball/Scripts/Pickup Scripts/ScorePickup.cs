using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : BasePickup
{
    private Vector3 rotationVector = new Vector3(45, 0, 0);             //rotation vector for our pickup object
    GameController gameController = null;
    public int rewardPoints = 1;                                        //if updated, update the score requirement for the BoostPadScript

    void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }

    protected override void PickupAction(Player player)
    {
        player.TryGetComponent<GameController>(out gameController);
        //if so, give the player a point
        player.points += rewardPoints;
        if (gameController.requiredPickups.Contains(this.gameObject))
        {
            gameController.requiredPickups.Remove(this.gameObject);
        }
    }


}
