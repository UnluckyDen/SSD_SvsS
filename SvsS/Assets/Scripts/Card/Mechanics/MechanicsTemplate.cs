using Card.Data;
using UnityEngine;

namespace Card.Mechanics
{
    public class MechanicsTemplate : MonoBehaviour
    {
        void AddDamage(int count)
        {
            if (count == 0) return;
        }

        void ApplyDamage()
        {
            
        }

        void AddHeal(int count)
        {
            if (count == 0) return;
        }

        void ApplyHeal()
        {
            
        }

        void AddMana(int count)
        {
            if (count == 0) return;
        }

        void DrawCard(int count)
        {
            if (count == 0) return;
        }

        void DiscardCards(int count)
        {
            if (count == 0) return;
        }

        void GetTargetCard(CardData card)
        {
            if (card==null) return;
            
        }

        void TestEffect(string message)
        {
            if (message == "") return;
            Debug.Log(message: message);
        }
        
    }
}
