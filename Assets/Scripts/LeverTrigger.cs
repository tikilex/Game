using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
public Animator animator;
public Animator anim;
public Animator ani;
public bool mechanism=false;
public int NumberMech=0;

private void Start()
{
GlobalValues.MechChecker1=false;
GlobalValues.MechChecker2=false;
}

private void Update()
{
if(GlobalValues.MechChecker1==true && GlobalValues.MechChecker2==true)
{
ani.SetTrigger("isTriggered");
}
}

private void OnTriggerEnter2D(Collider2D other)
{
if(other.tag == "Player")
{
    SoundManager.PlaySound("door");
    animator.SetTrigger("isTriggered");
    anim.SetTrigger("isTriggered");
}

if(mechanism==true)
{
if(other.tag == "physicbox" || other.tag == "SpawnPhysicbox")
{
anim.SetTrigger("isTriggered");
if(NumberMech==1)
{
GlobalValues.MechChecker1=true;
}
if(NumberMech==2)
{
GlobalValues.MechChecker2=true;
}
}
}
}

private void OnTriggerExit2D(Collider2D other)
{
if(mechanism==true)
{
if(other.tag == "physicbox" || other.tag == "SpawnPhysicbox")
{
anim.SetTrigger("isUnTriggered");
if(NumberMech==1)
{
GlobalValues.MechChecker1=false;
}
if(NumberMech==2)
{
GlobalValues.MechChecker2=false;
}
}
}
}

}