using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum TankState{
	Idle,
	ColliderBoard,
	Attacked,
	FindEnemy
}
public class TankModel{
	public int Hp=100;
	public List<TankAction> CurrentStateList;
	public List<TankAction> IdleList=new List<TankAction>();
	public List<TankAction> AttackedList=new List<TankAction>();
	public List<TankAction> FindEnemyList=new List<TankAction>();
	public List<TankAction> ColliderList=new List<TankAction>();
	public TankState tankState=TankState.ColliderBoard;
	public int CurrentMoveListIndex=0;
	public int CurrentMoveActionIndex = 0;
	public bool FrontCollider=false;
	public bool BackCollider=false;
}
