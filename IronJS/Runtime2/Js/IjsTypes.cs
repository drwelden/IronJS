﻿using System;
using IronJS.Runtime.Js;
using IronJS.Runtime2.Js;

namespace IronJS.Runtime2.Js
{
    public static class IjsTypes
    {
        public static readonly Type Boolean = typeof(bool);
        public static readonly Type Integer = typeof(long);
        public static readonly Type Double = typeof(double);
        public static readonly Type String = typeof(string);
        public static readonly Type Object = typeof(IjsObj);
        public static readonly Type Dynamic = typeof(object);
        public static readonly Type Undefined = typeof(Undefined);
    }
}