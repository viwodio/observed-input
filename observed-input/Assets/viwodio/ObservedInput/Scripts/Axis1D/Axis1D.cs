using UnityEngine;
using System.Collections;

namespace viwodio.InputSystem
{
    public class Axis1D : BaseValueInput<float>
    {

        public static Axis1D GetAxis1D(string inputKey)
        {
            return ObservedInput<Axis1D>.GetInput(inputKey);
        }
    }
}
