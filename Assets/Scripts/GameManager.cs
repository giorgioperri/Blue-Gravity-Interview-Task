using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    Gameplay,
    Shop,
    Inventory
}

public class GameManager : PersistentSingleton<GameManager>
{
    public GameStates CurrentGameState = GameStates.Gameplay;
}
