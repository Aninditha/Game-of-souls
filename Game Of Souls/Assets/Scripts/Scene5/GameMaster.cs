using UnityEngine;
using System.Collections;
using System;

public class GameMaster : MonoBehaviour {

	public static void KillPlayer(Player5 player)
    {
        Destroy(player.gameObject);
    }
}
