using UnityEngine;

public class FreezeMonsterScript : MonoBehaviour
{
    public Rigidbody monsRigid;
    public Transform monsTrans;
    public Transform playTrans;
    public int monsSpeed;
    public float stopDistance = 2f;

    private void FixedUpdate()
    {
        Vector3 directionToPlayer = (playTrans.position - monsTrans.position).normalized;

        if (IsPlayerLookingAtMonster())
        {
            monsRigid.velocity = Vector3.zero;
        }
        else
        {
            monsRigid.velocity = directionToPlayer * monsSpeed * Time.deltaTime;
        }

        monsTrans.LookAt(playTrans);
    }

    private bool IsPlayerLookingAtMonster()
    {
        //calculates players direction from the monster
        Vector3 directionToMonster = (monsTrans.position - playTrans.position).normalized;

        //calculates the angle of players looking dot relative to the monster
        float dotProduct = Vector3.Dot(playTrans.forward, directionToMonster);

        //check the angle to determine if player is looking at the monster
        return dotProduct > 0.5f;
    }
}
