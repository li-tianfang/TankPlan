using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;



public class AddControl : MonoBehaviour {
	//public List<GameObject> list = new List<GameObject>();
	private int actionSequen = 0;
	private GameObject btn;
	public List<GameObject> list = new List<GameObject>();
	public List<String> actionName = new List<String>();
	public List<float> actionNum = new List<float>();
	private float 
		fireMax = 10,
		fireMin = 1,
		moveMax = 500,
		moveMin = 1,
		turnMax = 360,
		turnMin = 1;


	// Use this for initialization
	void Start () {
		GameObject btn = GameObject.Find ("BTN_AddAction");
	

	}

	public  void CreatAction(){
		actionSequen = transform.parent.childCount;
		GameObject go = Resources.Load ("TankAction",typeof(GameObject))as GameObject;
		go = Instantiate (go);
		GameObject Par = GameObject.Find ("Content");
		go.transform.SetParent (Par.transform);
		go.transform.SetSiblingIndex (Par.transform.childCount-2);
		list.Add (go);
		list[actionSequen-1].transform.GetChild(0).GetComponent<Text>().text=actionSequen.ToString();
		GameObject typeChoose= GameObject.Find ("Dropdown");
		list [actionSequen - 1].transform.GetChild (3).GetComponent<Text> ().text = typeChoose.transform.GetChild (0).GetComponent<Text> ().text;
		go.transform.GetChild(1).GetComponent<Button> ().onClick.AddListener (() => {
			list.Remove(go);
			Destroy(go);
			SetSequen();

		});

		GetActionData ();
	}

	public void GetActionData(){
		
		switch(list [actionSequen - 1].transform.GetChild (3).GetComponent<Text> ().text){
		case "ahead":
			list [actionSequen - 1].transform.GetChild (2).GetComponent<Slider>().minValue = moveMin;
			list [actionSequen - 1].transform.GetChild (2).GetComponent<Slider>().maxValue = moveMax;
			//print ("");
			break;
		case "back":
			list [actionSequen - 1].transform.GetChild (2).GetComponent<Slider>().minValue = moveMin;
			list [actionSequen - 1].transform.GetChild (2).GetComponent<Slider>().maxValue = moveMax;
			break;
		case "trun":
			list [actionSequen - 1].transform.GetChild (2).GetComponent<Slider>().minValue = turnMin;
			list [actionSequen - 1].transform.GetChild (2).GetComponent<Slider>().maxValue = turnMax;
			break;
		case"fire":
			list [actionSequen - 1].transform.GetChild (2).GetComponent<Slider>().minValue = fireMin;
			list [actionSequen - 1].transform.GetChild (2).GetComponent<Slider>().maxValue = fireMax;
			break;
		}
		for(int i=0;i<list.Count;i++){
			actionName.Add (list [i].transform.GetChild (3).GetComponent<Text> ().text);
			actionNum.Add (list [i].transform.GetChild (2).GetComponent<Slider>().value);

			}
		
		for(int i=0;i<actionName.Count;i++){

			Debug.Log (actionName[i]);
		}
		for(int i=0;i<actionNum.Count;i++){

			Debug.Log (actionNum[i]);
		}
	}
	public void SetSequen(){
//		Jisuan (12, num=> {
//		
//			print(num);
//		});

		for (int i = 0; i < list.Count; i++) {
			list [i].transform.GetChild (0).GetComponent<Text> ().text = ""+(i + 1);
		}
	}
	void Update () {
		
	}

}
