using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//https://www.youtube.com/watch?v=F-3nxJ2ANXg&ab_channel=GameDevChef
//https://github.com/GameDevChef/BehaviourTrees

[System.Serializable]
public abstract class Node
{
    protected NodeState _nodeState; // Stav uzlu, kter� z�st�v� po posledn�m zpracov�n�
    /*ID a NICK slou�� pro ov��en�, jak prob�halo rozhodov�n�. 
	Tato ��st byla vytvo�ena b�hem v�voje a v samotn� ��sti aplikace nem� vyu��t�.
	*/
    protected int id; //Pro p�ehazov�n� na prvn� pozici v sekvenci a nazp�t
    protected string nick = "default"; // Debugovac� ��ely
    protected int original_id;  //Pro p�ehazov�n� na prvn� pozici v sekvenci a nazp�t
    protected Animal character;//Ka�d� uzel m� odkaz na sv�ho majitele.
    /// <summary>
    /// Vr�can� posledn�ho stavu zpracov�n�
    /// </summary>
    public NodeState NodeState { get { return _nodeState; } }
    /// <summary>
    /// Z�sk�n� ID
    /// </summary>
    public int GetID { get { return id; } }
    /// <summary>
    /// Nastaven� ID
    /// </summary>
    /// <param name="_id"></param>
    public void SetID(int _id) { id = _id; }
    /// <summary>
    /// Z�sk�n� Popisu
    /// </summary>
    /// <returns></returns>
    public string GetNick() { return nick; }
    /// <summary>
    /// Zpracov�n� uzlu
    /// </summary>
    /// <returns>Stav zpracov�n�</returns>
    public abstract NodeState Evaluate();
}

/// <summary>
/// V�sledn� stav zpracovan�ho uzlu
/// </summary>
public enum NodeState
{
    RUNNING, SUCCESS, FAILURE,
}
