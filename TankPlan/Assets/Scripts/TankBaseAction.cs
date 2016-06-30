using UnityEngine;
using System.Collections;


public class TankBaseAction : MonoBehaviour {
	public GameObject Bullet;
	public void Move(float dic){ 
		transform.Translate (0,0.03f*dic, 0, Space.Self);
	}
	public TankModel tank;
	public void TurnAround(float dic){
		transform.Rotate (new Vector3 (0, 0, 1f*dic));
	}
	private float intervalTime=0.3f;
	private float time=0;
	public void Fire(){
		time += Time.deltaTime;
		if (time > intervalTime) {
			print (intervalTime);
			var bullet=Instantiate (Bullet)as GameObject;
			bullet.transform.position = transform.TransformVector (Vector3.up*Dis) + transform.position;
			bullet.GetComponent<Rigidbody2D> ().AddForce (transform.TransformVector (Vector3.up)*40f);
			bullet.GetComponent<Bullet> ().Self = gameObject;
			time = 0;
			tank.CurrentMoveActionIndex++;
		}
	}
	private float Dis=0.1f;
	public bool Scan(){
		var rayhit=Physics2D.Raycast(transform.TransformVector(Vector3.up*Dis)+transform.position,transform.TransformVector(Vector3.up));
		Debug.DrawLine(transform.TransformVector(Vector3.up*Dis)+transform.position,transform.TransformVector(Vector3.up*5)+transform.position);
		if (rayhit .transform!=null) {
			if (rayhit.transform.tag=="Tank" && rayhit.transform!=transform) {
				print ("检测到坦克了!");
				return true;
			}
		}
		return false;
	}
	public void FixedUpdate(){
		Scan ();
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.transform.tag == "Tank") {
			print ("碰到坦克了!!!");
		} else {
			Vector2 colliderPos = transform.InverseTransformPoint (collision.contacts [0].point);
		//	if (colliderPos.y < transform.position.y) {
			if (colliderPos.y > 0) {
				tank.FrontCollider = true;
				print ("碰到前方");
		//	} else if (colliderPos.y > transform.position.y) {
			} else if (colliderPos.y < 0) {
				tank.BackCollider = true;
				print ("碰到后方");
			}
		}
	}
	void OnCollisionExit2D(Collision2D collision){
		Vector2 colliderPos = transform.InverseTransformPoint (collision.contacts [0].point);
		//if (colliderPos.y < transform.position.y) {
		if (colliderPos.y > 0) {
			print ("碰撞前方离开");
			tank.FrontCollider = false;
		//} else if (colliderPos.y > transform.position.y) {
		} else if (colliderPos.y <0) {
			print ("碰撞后方离开");
			tank.BackCollider = false;
		}
	}
}
