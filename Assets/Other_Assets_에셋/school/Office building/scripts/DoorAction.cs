using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DoorAction 클래스는 플레이어의 입력을 처리하고 문이나 엘리베이터 버튼과 같은 상호작용 가능한 오브젝트에 반응합니다.
public class DoorAction : MonoBehaviour
{
    void Update()
    {
        // E 키를 누를 때마다 아래 로직을 실행합니다.
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit; // Raycast에 맞은 오브젝트의 정보를 저장할 변수

            // 플레이어의 위치에서 앞쪽으로 Raycast를 발사합니다.
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);

            // Raycast에 맞은 오브젝트가 문이면 해당 문의 ActionDoor 메서드를 호출합니다.
            if (hit.transform.tag == "door")
            {
                hit.transform.gameObject.GetComponent<Door>().ActionDoor();
            }

            // Raycast에 맞은 오브젝트가 엘리베이터 버튼이면 해당 버튼의 기능을 호출합니다.
            // 여기서는 1층부터 6층까지의 각 버튼에 대해 처리하고 있습니다.
            if(hit.collider.gameObject.name == "Button floor 1")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 1");
            }
            if (hit.collider.gameObject.name == "Button floor 2")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 2");
            }
            if (hit.collider.gameObject.name == "Button floor 3")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 3");
            }
            if (hit.collider.gameObject.name == "Button floor 4")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 4");
            }
            if (hit.collider.gameObject.name == "Button floor 5")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 5");
            }
            if (hit.collider.gameObject.name == "Button floor 6")
            {
                hit.transform.gameObject.GetComponent<pass_on_parent>().MyParent.GetComponent<evelator_controll>().AddTaskEve("Button floor 6");
            }
        }
	}
}
