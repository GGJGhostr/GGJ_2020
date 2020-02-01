using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLACEHOLDER
{

    public class Bullets : MonoBehaviour, IHackable
    {
        public void ComputeHackFromString(string data, dynamic value)
        {
            switch(data)
            {
                case "speed":
                    DoAFloatThing(value);
                    break;
                case "damage":
                    DoABoolThing(value);
                    break;
                case "size":
                    DoAIntThing(value);
                    break;
            }
        }

        private void DoAFloatThing(float value)
        {
            Debug.Log("float is: " + value.ToString());
        }

        private void DoABoolThing(bool value)
        {
            Debug.Log("bool is: " + value.ToString());
        }

        private void DoAIntThing(int value)
        {
            Debug.Log("int is: " + value.ToString());
        }

    }

}