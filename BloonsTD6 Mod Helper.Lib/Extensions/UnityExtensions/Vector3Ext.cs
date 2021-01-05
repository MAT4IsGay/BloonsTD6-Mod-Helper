using UnityEngine;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class Vector3Ext
    {
        public static Assets.Scripts.Simulation.SMath.Vector3 ToSMathVector(this Vector3 vector3)
        {
            return new Assets.Scripts.Simulation.SMath.Vector3(vector3);
        }
    }
}