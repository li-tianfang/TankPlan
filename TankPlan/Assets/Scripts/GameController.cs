using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public static GameController Instance;
	public TankModel Tank1;
	public GameObject TankPrefab;
	public AddControl addController;
	void Start () {
		Instance = this;
		Tank1 = new TankModel ();
		DontDestroyOnLoad (gameObject);
	}
	public void ClickPlay(){
		GetData ();
		SceneManager.LoadScene ("Start");
		StartCoroutine (AddTank ());
	}
	IEnumerator AddTank(){
		yield return new WaitForSeconds (2);
		var tank1=GameObject.Instantiate (TankPrefab);
		tank1.GetComponent<TankBaseAction> ().tank = Tank1;
		tank1.transform.position = Vector3.zero;
		tank1.GetComponent<TankListAction> ().SetTankState (TankState.Idle);
	}
	public void GetData(){
		for (int i = 0; i<addController.actionName.Count; i++) {
			Tank1.IdleList.Add (AddTankActionType (addController.actionName [i], (int)addController.actionNum [i]));
		}
	}
	public TankAction AddTankActionType(string str,int num){
		switch (str) {
		case "ahead":
			return new TankAction (TankActionType.Move,num);
		case "back":
			return new TankAction (TankActionType.Move, -1 * num);
		case "trun":
			return new TankAction (TankActionType.Turn, num);
		case "fire":
			return new TankAction (TankActionType.Fire, num);
		}
		return new TankAction (TankActionType.Move, 0);
	}
}
