using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ModelExt
    {
        public static T Duplicate<T> (this T model) where T : Model
        {
            return model.Clone().TryCast<T>();
        }
    }
}