// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CruzadeManagement : MonoBehaviour
// {
//     public List<Minion2> party = new List<Minion2>();
//     public Minion2 firstMinion;
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(PauseControl.gameIsPaused){
//             return;
//         }
//         verifyFirstMinion();
//         jump();
//     }


//     private void verifyFirstMinion()
//     {
//         //firstMinion = party[0];
//         foreach (Minion2 minion in party)
//         {

//             if (minion.transform.position.x > firstMinion.transform.position.x)
//             {
//                 firstMinion = minion;
//             }
//         }
//     }

//     private void jump(){
//         // if(firstMinion.jump()){
//             firstMinion.jump();
//             foreach(Minion2 minion in party){
//                 if(minion == firstMinion){
//                     continue;
//                 }
                
//                 minion.willJumpAtPos = firstMinion.willJumpAtPos;
//                 minion.hasPartyJumped = false;
//             }
//         // }
//     }
// }
