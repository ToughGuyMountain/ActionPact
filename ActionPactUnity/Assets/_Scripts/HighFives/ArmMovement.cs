using UnityEngine;
using System.Collections;

public class ArmMovement : MonoBehaviour {

	public bool forward;
	public float speed = 0.1f;
	public GUIText meter;
	public ArmMovement otherArm;
	public TextMesh resultTextMesh;

	private float progress;
	private float multiplier = 2.5f;
	private float realityOffset = 0.0f;
	private float realityOffsetAcceleration;
	private float realityOffsetSpeed = 0.2f;
	private Vector3 originalPosition;
	private float meterPixelOffsetReferencePoint;
	private bool shownResults = false;

	void Start () {
		originalPosition = this.transform.position;
		if (Random.Range(0, 2) == 1) {
			realityOffsetAcceleration = 0.5f;
		} else {
			realityOffsetAcceleration = -0.5f;
		}
		meterPixelOffsetReferencePoint = meter.pixelOffset.x;
	}
	
	void Update () {

		if (progress < Mathf.PI) {

			if (forward) {
				this.transform.position = new Vector3(originalPosition.x + (Mathf.Sin(progress/6) * multiplier*4.0f), 
				                                      originalPosition.y + (Mathf.Sin(progress/3) * multiplier),
				                                      originalPosition.z + (Mathf.Sin(progress/6) * multiplier*7.0f));
			} else {
				this.transform.position = new Vector3(originalPosition.x - (Mathf.Sin(Mathf.PI-progress/6) * multiplier*4.0f), 
				                                      originalPosition.y + (Mathf.Sin(Mathf.PI-progress/3) * multiplier),
				                                      originalPosition.z - (Mathf.Sin(Mathf.PI-progress/6) * multiplier*7.0f));
			}
			progress += speed * Time.deltaTime;
		
			float currentAcceleration = realityOffsetAcceleration;

			if (forward) {
				if (Input.GetKey (KeyCode.A)) {
					realityOffsetAcceleration += realityOffsetSpeed*10*Time.deltaTime;
				} else if (Input.GetKey (KeyCode.D)) {
					realityOffsetAcceleration -= realityOffsetSpeed*10*Time.deltaTime;				
				} else {
					updateRealityOffsetAccelration();
				}

				if (Mathf.Abs(realityOffset + realityOffsetAcceleration) < 90) {
					realityOffset += realityOffsetAcceleration;
				} else {
					realityOffsetAcceleration = 0;
				}
				this.transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, realityOffset);
				
			} else {
				if (Input.GetKey ("left")) {
					realityOffsetAcceleration -= realityOffsetSpeed*10*Time.deltaTime;
				} else if (Input.GetKey ("right")) {
					realityOffsetAcceleration += realityOffsetSpeed*10*Time.deltaTime;
				} else {
					updateRealityOffsetAccelration();
				}

				if (Mathf.Abs(realityOffset + realityOffsetAcceleration) < 90) {
					realityOffset += realityOffsetAcceleration;
				} else {
					realityOffsetAcceleration = 0;
				}
				this.transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -realityOffset);
			}
			if (forward) {
				meter.pixelOffset = new Vector2(meterPixelOffsetReferencePoint - realityOffset/2, meter.pixelOffset.y);
			} else {
				meter.pixelOffset = new Vector2(meterPixelOffsetReferencePoint + realityOffset/2, meter.pixelOffset.y);
			}
		} else {
			if (forward) {
				float otherMeterValue = otherArm.getMeterValue();
				if (getMeterValue() > - 25 && getMeterValue() < 25 && otherMeterValue > -25 && otherMeterValue < 25) {
					Debug.Log("THIS IS A WINNER");
				} else {
					Debug.Log("LOSER");
				}
			}
		}
	}

	void updateRealityOffsetAccelration() {
		if (Mathf.Abs(realityOffsetAcceleration) < 90) {
			if (realityOffsetAcceleration < 0.0) {
				realityOffsetAcceleration -= realityOffsetSpeed*5*Time.deltaTime; 
			}
			if (realityOffsetAcceleration > 0.0) {
				realityOffsetAcceleration += realityOffsetSpeed*5*Time.deltaTime;
			}
		}
	}

	public float getMeterValue() {
		return realityOffset;
	}
}
