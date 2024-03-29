﻿using System;
using Xamarin.Forms;

namespace studybuddyv2
{
    public static class Constants
    {
        public static string BaseAddress = "https://10.0.2.2:3500";
        public static string ApiVersion = "/api/v1";
        public static string LoginPath = "/auth/login";
        public static string RegisterPath = "/auth/create";
        public static string CreateAssignmentPath = "/assignments/create";
        public static string AssignmentsPath = "/assignments";
        public static string CreateDeliverablePath = "/deliverables/submit";
    }
}
