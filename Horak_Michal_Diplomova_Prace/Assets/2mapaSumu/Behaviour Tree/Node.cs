using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//https://www.youtube.com/watch?v=F-3nxJ2ANXg&ab_channel=GameDevChef
//https://github.com/GameDevChef/BehaviourTrees

[System.Serializable]
public abstract class Node
{
    protected NodeState _nodeState; // Stav uzlu, který zùstává po posledním zpracování
    /*ID a NICK slouží pro ovìøení, jak probíhalo rozhodování. 
	Tato èást byla vytvoøena bìhem vývoje a v samotné èásti aplikace nemá využítí.
	*/
    protected int id; //Pro pøehazování na první pozici v sekvenci a nazpìt
    protected string nick = "default"; // Debugovací úèely
    protected int original_id;  //Pro pøehazování na první pozici v sekvenci a nazpìt
    protected Animal character;//Každý uzel má odkaz na svého majitele.
    /// <summary>
    /// Vrácaní posledního stavu zpracování
    /// </summary>
    public NodeState NodeState { get { return _nodeState; } }
    /// <summary>
    /// Získání ID
    /// </summary>
    public int GetID { get { return id; } }
    /// <summary>
    /// Nastavení ID
    /// </summary>
    /// <param name="_id"></param>
    public void SetID(int _id) { id = _id; }
    /// <summary>
    /// Získání Popisu
    /// </summary>
    /// <returns></returns>
    public string GetNick() { return nick; }
    /// <summary>
    /// Zpracování uzlu
    /// </summary>
    /// <returns>Stav zpracování</returns>
    public abstract NodeState Evaluate();
}

/// <summary>
/// Výsledný stav zpracovaného uzlu
/// </summary>
public enum NodeState
{
    RUNNING, SUCCESS, FAILURE,
}
