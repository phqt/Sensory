using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class DoorsAndKeys : MonoBehaviour {

	public DoorM DoorMode;
	public enum DoorM{Door, DoorToAnotherLocation, Teleport, CallFunction, AlwaysLocked, SliderDoor};

	public bool LockedWithKey = false;
	public int DoorID = 0;
	public bool AutoClose = false;
    public bool AutoOpen = false;
    public float AutoDistance = 2.0f;
	public float CloseAfter = 2.0f; private float CAV = 0.0f;
	public int Angle = -90;
    public int SlideRange = 1;
	public int Speed = 4;
	public int KeyItemID = 0;
	public string LoadLevel = "";
	public Transform ExitHere;
    public GameObject ScriptedObject;
    public string FunctionName;
    public bool RemoteOrKnob = false;

	public AudioClip LockedSound; private AudioSource ASourse;
	public AudioClip CloseSound;
    public AudioClip OpenSound;
	public AudioClip OpendWithKeySound;

    private int DoorState = 0;
    private bool SetPosition = false;
	private float ClickDelay = 0.0f, Diff = 0.0f;

	private Transform DoorT;
	private Vector3 StartXYZ;
	private Vector2 FromTo;
    private float distance = 100500.0f;

	private void PlayLockedSound() {ASourse.clip = LockedSound; ASourse.Play();}
	private void PlayCloseSound()  {ASourse.clip = CloseSound;  ASourse.Play();}
    private void PlayOpenSound()   {ASourse.clip = OpenSound;  ASourse.Play();}
	private void PlayOpenWithKey() {ASourse.clip = OpendWithKeySound;  ASourse.Play();}

	public void Click () { if (RemoteOrKnob==false) { Process(); } }
    public void RemoteClick () {Process();}
    public void Lock () { DoorMode = DoorM.AlwaysLocked; }

    void Process () {
        if (DoorMode != DoorM.AlwaysLocked){
            if (ClickDelay <= 0) {
                ClickDelay = 0.5f; if (LockedWithKey == false) { if (DoorState==0 || DoorState == 5) { PlayOpenSound(); } OpenClose(); }
                else {
                     if (W13Core.ItemTaken[KeyItemID] == true) {if (DoorState==0 || DoorState == 5) { PlayOpenWithKey(); }
                                                               OpenClose();}
                     else { PlayLockedSound(); }
                     }
                                 }
        } else { PlayLockedSound(); }
    }

	void OpenClose () {
		if (DoorMode==DoorM.DoorToAnotherLocation) {W13Core.LastEntredDoor = DoorID;
			                                        UnityEngine.SceneManagement.SceneManager.LoadScene(LoadLevel);}

            if (DoorMode == DoorM.Door && GetDif()<=0.5f) {SetDifDoor();}

            if (DoorMode == DoorM.SliderDoor && GetDif()<=0.1f) {SetDifSlide();}

        if (DoorMode == DoorM.Teleport) {
			if (W13Core.Player!=null && ExitHere!=null) {SetPosition = true;}
		}

        if (DoorMode == DoorM.CallFunction) {
            if (ScriptedObject!=null) { ScriptedObject.SendMessage(FunctionName);} else { Debug.Log("Nothing to call."); }
        }
        }

    void SetDifDoor () {if (DoorState == 3 || DoorState == 2) { FromTo.x = StartXYZ.y + Angle; DoorState = 4; FromTo.y = StartXYZ.y; }
                        if (DoorState == 0 || DoorState == 5) { FromTo.y = StartXYZ.y + Angle; DoorState = 1; CAV = CloseAfter; }}

    void SetDifSlide () {if (DoorState == 3 || DoorState == 2) { FromTo.x = StartXYZ.x - SlideRange; FromTo.y = StartXYZ.x; DoorState = 4; }
                         if (DoorState == 0 || DoorState == 5) { FromTo.y = StartXYZ.x - SlideRange; FromTo.x = StartXYZ.x; DoorState = 1; CAV = CloseAfter; }}

    float GetDif () {if (FromTo.x > FromTo.y) { Diff = FromTo.x - FromTo.y; } else { Diff = FromTo.y - FromTo.x; } return Diff; }

    void GetDist () {if (W13Core.Player != null) {distance = Vector3.Distance(W13Core.PlayerT.position, DoorT.position);}
                      else { W13Core.FindPlayer(); }}

    void AutoDoorProcess () {if (DoorState == 2 || DoorState == 3) { if (AutoClose == true && distance > AutoDistance) { if (CAV > 0) { CAV = CAV - Time.deltaTime; } else { OpenClose(); } } }
                             if (DoorState == 0 || DoorState == 5) { if (AutoOpen == true) { if (distance < AutoDistance) { Click(); } } }
                            }

	void Update () {if (ClickDelay>0) {ClickDelay = ClickDelay - Time.deltaTime;}

        if (DoorMode == DoorM.SliderDoor || DoorMode == DoorM.Door) { if (AutoOpen == true || AutoClose == true) { GetDist(); AutoDoorProcess(); }}

        if (DoorState == 4 || DoorState == 1) {

            if (DoorMode == DoorM.SliderDoor) { if (GetDif() > 0.1f) { FromTo.x = Mathf.Lerp(FromTo.x, FromTo.y, Time.deltaTime * Speed);
                                                DoorT.localPosition = new Vector3(FromTo.x, StartXYZ.y, StartXYZ.z); }
                                                else { if (DoorState == 4) { DoorState = 5; PlayCloseSound(); }
                                                       if (DoorState == 1) { DoorState = 2; } } }

            if (DoorMode == DoorM.Door) { if (GetDif() > 0.5f) { FromTo.x = Mathf.LerpAngle(FromTo.x, FromTo.y, Time.deltaTime * Speed);
                    DoorT.rotation = Quaternion.Euler(StartXYZ.x, FromTo.x, StartXYZ.z); }
                else { if (DoorState == 4) { DoorState = 5; }
                    if (DoorState == 1) { DoorState = 2; } } }

        }
	}

    private void LateUpdate() {
        if (SetPosition==true) {if (W13Core.CharContrloller!=null) { W13Core.CharContrloller.enabled = false; }
                                W13Core.Player.transform.position = ExitHere.position;
                                SetPosition = false;
                                if (W13Core.CharContrloller!= null) { W13Core.CharContrloller.enabled = true; }
        }
    }

    void Start () {
        if (GetComponent<AudioSource>() == null) { ASourse = this.gameObject.AddComponent(typeof(AudioSource)) as AudioSource; }
                                            else { ASourse = GetComponent<AudioSource>(); } 

		DoorT = this.gameObject.transform;
        if (DoorMode == DoorM.Door) { StartXYZ = DoorT.rotation.eulerAngles;
                                      FromTo.y = StartXYZ.y; FromTo.x = StartXYZ.y;}
        if (DoorMode == DoorM.SliderDoor) { StartXYZ = DoorT.localPosition; }
        

		if (DoorMode == DoorM.DoorToAnotherLocation) {
			if (W13Core.LastEntredDoor!=0) {
				if (W13Core.Player!=null && ExitHere!=null) {
					W13Core.Player.transform.position = ExitHere.position;
					W13Core.LastEntredDoor = 0; }
			}
		}
	}

}

#if UNITY_EDITOR
[CustomEditor(typeof(DoorsAndKeys))]
public class DoorsEditor : Editor {
	override public void OnInspectorGUI() {
		var DoorsAndKeys = target as DoorsAndKeys;

		DoorsAndKeys.DoorMode = (DoorsAndKeys.DoorM)EditorGUILayout.EnumPopup ("Door mode:", DoorsAndKeys.DoorMode);

		if (DoorsAndKeys.DoorMode == DoorsAndKeys.DoorM.DoorToAnotherLocation) {
			DoorsAndKeys.LoadLevel = EditorGUILayout.TextField ("Load level:", DoorsAndKeys.LoadLevel);
            DoorsAndKeys.ExitHere = (Transform)EditorGUILayout.ObjectField("Player appears here:", DoorsAndKeys.ExitHere, typeof(Transform), true);
            DoorsAndKeys.DoorID = EditorGUILayout.IntField ("Door ID:", DoorsAndKeys.DoorID);
		}

        if (DoorsAndKeys.DoorMode == DoorsAndKeys.DoorM.CallFunction) {
            DoorsAndKeys.ScriptedObject = (GameObject)EditorGUILayout.ObjectField("Object to call:", DoorsAndKeys.ScriptedObject, typeof(GameObject), true);
            DoorsAndKeys.FunctionName = EditorGUILayout.TextField("Function name", DoorsAndKeys.FunctionName);
        }

            if (DoorsAndKeys.DoorMode == DoorsAndKeys.DoorM.Teleport) {
			DoorsAndKeys.ExitHere = (Transform)EditorGUILayout.ObjectField ("Player appears here:", DoorsAndKeys.ExitHere, typeof(Transform), true);
		}

        if (DoorsAndKeys.DoorMode == DoorsAndKeys.DoorM.SliderDoor) {DoorsAndKeys.Speed = EditorGUILayout.IntField("Speed:", DoorsAndKeys.Speed);
                                                                     DoorsAndKeys.SlideRange = EditorGUILayout.IntField("Slide range:", DoorsAndKeys.SlideRange);}

        if (DoorsAndKeys.DoorMode == DoorsAndKeys.DoorM.Door) {DoorsAndKeys.Angle = EditorGUILayout.IntSlider("Angle:", DoorsAndKeys.Angle, -90, 90);
                                                               DoorsAndKeys.Speed = EditorGUILayout.IntField("Speed:", DoorsAndKeys.Speed);}

        if (DoorsAndKeys.DoorMode == DoorsAndKeys.DoorM.SliderDoor || DoorsAndKeys.DoorMode == DoorsAndKeys.DoorM.Door) {
            DoorsAndKeys.AutoClose = EditorGUILayout.Toggle("Auto close:", DoorsAndKeys.AutoClose);
            if (DoorsAndKeys.AutoClose == true) { DoorsAndKeys.CloseAfter = EditorGUILayout.FloatField("Close after:", DoorsAndKeys.CloseAfter); }

            DoorsAndKeys.AutoOpen = EditorGUILayout.Toggle("Auto open:", DoorsAndKeys.AutoOpen);
            if (DoorsAndKeys.AutoOpen == true) { DoorsAndKeys.AutoDistance = EditorGUILayout.FloatField("Opening distance:", DoorsAndKeys.AutoDistance); }

            DoorsAndKeys.CloseSound = (AudioClip)EditorGUILayout.ObjectField("Sound - Close:", DoorsAndKeys.CloseSound, typeof(AudioClip), true);
            if (DoorsAndKeys.LockedWithKey == false) { DoorsAndKeys.OpenSound = (AudioClip)EditorGUILayout.ObjectField("Sound - Open:", DoorsAndKeys.OpenSound, typeof(AudioClip), true); }
        }

        if (DoorsAndKeys.DoorMode != DoorsAndKeys.DoorM.AlwaysLocked)
        {
            DoorsAndKeys.LockedWithKey = EditorGUILayout.Toggle("Locked with key:", DoorsAndKeys.LockedWithKey);
            if (DoorsAndKeys.LockedWithKey == true)
            {
                DoorsAndKeys.KeyItemID = EditorGUILayout.IntField("Key item ID:", DoorsAndKeys.KeyItemID);
                DoorsAndKeys.LockedSound = (AudioClip)EditorGUILayout.ObjectField("Sound - Locked:", DoorsAndKeys.LockedSound, typeof(AudioClip), true);
                DoorsAndKeys.OpendWithKeySound = (AudioClip)EditorGUILayout.ObjectField("Sound - Opened with key:", DoorsAndKeys.OpendWithKeySound, typeof(AudioClip), true);
            }
        } else
        {
            DoorsAndKeys.LockedSound = (AudioClip)EditorGUILayout.ObjectField("Sound - Locked:", DoorsAndKeys.LockedSound, typeof(AudioClip), true);
        }

if (DoorsAndKeys.AutoOpen==false) {DoorsAndKeys.RemoteOrKnob = EditorGUILayout.Toggle ("Remote opening or knob:", DoorsAndKeys.RemoteOrKnob);}

		if(GUI.changed){EditorUtility.SetDirty(DoorsAndKeys); EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());}
    }

}
#endif
