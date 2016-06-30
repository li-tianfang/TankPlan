using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public  struct TankAction{
	public TankActionType action;
	public int count;
	public TankAction ( TankActionType action,int count){
		this.action=action;
		this.count=count;
	}
}
public enum TankActionType{
	Move,
	Turn,
	Fire,
	Rotate
}
public class TankListAction : TankBaseAction {

	public bool ExecuteMoveAction(){
		if (tank.CurrentStateList.Count <= 0) {
			return true;
		}
		float dic = tank.CurrentStateList [tank.CurrentMoveListIndex].count>0?1:-1;
		switch (tank.CurrentStateList [tank.CurrentMoveListIndex].action) {
		case TankActionType.Move:
			if ((tank.FrontCollider&&dic>0)||(tank.BackCollider&&dic<0)) {
				tank.CurrentMoveListIndex++;
				tank.CurrentMoveActionIndex = 0;
				if (tank.CurrentMoveListIndex >= tank.CurrentStateList.Count) {
					return true;
				}
				return false;
			}
			tank.CurrentMoveActionIndex++;
			Move (dic);
			break;
		case TankActionType.Turn:
			tank.CurrentMoveActionIndex++;
			TurnAround (dic);
			break;
		case TankActionType.Fire:
	//		tank.CurrentMoveActionIndex++;
			Fire ();
			break;
		}
		if (tank.CurrentMoveActionIndex >=Math.Abs(tank.CurrentStateList [tank.CurrentMoveListIndex].count)) {
			tank.CurrentMoveListIndex++;
			tank.CurrentMoveActionIndex = 0;
			if (tank.CurrentMoveListIndex >= tank.CurrentStateList.Count) {
				return true;
			}
		}
		return false;
	}

	public void Update(){
		if (tank.Hp>0) {
			if (ExecuteMoveAction ()) {
				tank.CurrentMoveActionIndex = 0;
				tank.CurrentMoveListIndex = 0;
				if (tank.tankState != TankState.Idle) {
					SetTankState (TankState.Idle);
				}
			}
		}
	}
	void Start(){
//		tank = new TankModel ();
//		tank.AttackedList = new List<TankAction> ();
//		tank.ColliderList = new List<TankAction> ();
//		tank.FindEnemyList = new List<TankAction> ();
//		tank.IdleList = new List<TankAction> ();
//		tank.CurrentStateList = new List<TankAction> ();
//		tank.Hp = 100;
//		tank.IdleList.Add(new TankAction(TankActionType.Move,-1000));
//		tank.IdleList.Add (new TankAction (TankActionType.Turn, 5));
//		tank.IdleList.Add (new TankAction (TankActionType.Fire, 1));
//		SetTankState (TankState.Idle);		
//		tank.CurrentMoveActionIndex = 0;
//		tank.CurrentMoveListIndex = 0;
//		tank.CurrentStateList = tank.IdleList;
	}
	public void SetTankState(TankState state){
		if (tank.tankState != state) {
			switch (state) {
			case TankState.Attacked:
				tank.CurrentMoveActionIndex = 0;
				tank.CurrentMoveListIndex = 0;
				tank.CurrentStateList = tank.AttackedList;
				break;
			case TankState.ColliderBoard:
				tank.CurrentMoveActionIndex = 0;
				tank.CurrentMoveListIndex = 0;
				tank.CurrentStateList = tank.ColliderList;
				break;
			case TankState.FindEnemy:
				tank.CurrentMoveActionIndex = 0;
				tank.CurrentMoveListIndex = 0;
				tank.CurrentStateList = tank.FindEnemyList;
				break;
			case TankState.Idle:
				tank.CurrentMoveActionIndex = 0;
				tank.CurrentMoveListIndex = 0;
				tank.CurrentStateList = tank.IdleList;
				break;
			}
		}
	}
}
