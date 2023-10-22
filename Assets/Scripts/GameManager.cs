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
    public GameStates CurrentGameState = GameStates.Shop;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
