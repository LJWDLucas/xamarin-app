﻿using System;
using Xamarin.Forms;

namespace studybuddyv2
{
    public static class Constants
    {
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:3500" : "https://localhost:3500";
        public static string LoginPath = "/auth/login";
        public static string RegisterPath = "/auth/create";
    }
}