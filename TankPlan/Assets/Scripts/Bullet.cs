using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject Self;
	void OnTriggerEnter2D(Collider2D other) {
		print ("子弹碰撞");
		if (other.gameObject.tag == "Tank" && other.gameObject != Self) {
			other.GetComponent<TankListAction> ().tank.Hp -= 5;
			Destroy(gameObject);  
		} else if (other.gameObject.tag == "Board") {
			Destroy(gameObject);
		}
	}
}