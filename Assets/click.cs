/*
 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Prosto
public class click: MonoBehaviour {
    public int monsterNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {//마우스 좌측 클릭 발생 시.           
         GameObject tempObj = null;//임시 오브젝트 생성.           
         if (monsterNumber > 0 && monsterNumber < 6){
                tempObj = GameObject.Find("Monsters").transform.GetChild(monsterNumber-1).gameObject;                
                if (tempObj != null){//게임오브젝트를 성공적으로 받았다면.                   
                 Debug.Log("성공적으로 " + tempObj.name + " 오브젝트를 받았습니다.");                }
                else
                {
                    Debug.LogError(monsterNumber.ToString() + "번 몬스터를 얻는데 실패했습니다.");               
                }            
            }
            else
            {
                Debug.LogError("잘못된 몬스터 번호입니다.");
            }
        }
    }
}

 */
