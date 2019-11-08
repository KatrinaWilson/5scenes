using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Text targetText;
    private int count = 0;

    public Camera cam;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    

    void start ()
    {
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    
    
    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            other.gameObject.SetActive(false);
            count += 1;
            targetText.text = "Targets Captured: " + count + " /4";
        }

      



    }




}
