using UnityEngine;
using UnityEngine.UI;

public class ClickOnOff : MonoBehaviour
{
    public Image CaseOff;
    public  Sprite CaseOn;
    bool State = false;
   public void ButtonPressed(){
        
        if(State == false){
            CaseOff.sprite = CaseOn;
            State = true;
        }
        else{
            
        }

   }
}
