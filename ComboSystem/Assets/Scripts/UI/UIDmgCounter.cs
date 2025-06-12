using TMPro;
using UnityEngine;

public class UIDmgCounter : IAttackObserver, IObserver
{
    private float dmgCounter = 0f;
    private TextMeshProUGUI textField;

    public UIDmgCounter(TextMeshProUGUI textField)
    {
        this.textField = textField;
    }
    
    public void Update(IAttackSubject attackSubject, float dmg)
    {
        dmgCounter += dmg;
        textField.text = dmgCounter.ToString();
    }

    public void Update(ISubject subject)
    {
        dmgCounter = 0f; 
        textField.text = dmgCounter.ToString();
    }
}
