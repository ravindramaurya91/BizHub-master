﻿namespace Blazor.BizHub.WasmVideo.SignalRServer.Shared
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string? value) =>
            value is null || value is { Length: 0 };
    }
}