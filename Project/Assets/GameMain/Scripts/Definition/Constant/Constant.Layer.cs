using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FYProject
{
    public static partial class Constant
    {
        public static class Layer
        {
            public const string DefaultLayerName = "Default";
            public static readonly int DefaultLayerId = LayerMask.NameToLayer(DefaultLayerName);

            public const string UILayerName = "UI";
            public static readonly int UILayerId = LayerMask.NameToLayer(UILayerName);
        }
    }
}
