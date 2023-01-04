using Microsoft.AspNetCore.Html;
using System.Net;
using Newtonsoft.Json;

namespace dotnet_js_args.Helpers;

public static class JavaScriptHelper
{
    /// <summary>
    /// Pass arguments from the backend to a TS module, so they can be read with getArgs
    /// </summary>
    /// <param name="moduleName">
    /// The name of the module, relative to the _Scripts folder and without ".ts", "Articles/Edit"
    /// </param>
    /// <param name="args">A object to serialize as JSON and pass to the module</param>
    /// <returns>HTML</returns>
    public static HtmlString Args(string moduleName, IJavaScriptArgs args)
    {
        var obj = JsonConvert.SerializeObject(args);
        var str = $"<script type=\"application/json\" data-role=\"module-args\" data-module-name=\"{WebUtility.HtmlEncode(moduleName)}\">{obj}</script>";
        return new HtmlString(str);
    }
}

/// <summary>
/// A marker interface for classes which can be passed to the front end.
/// <seealso cref="JavaScriptHelper.Args(string, IJavaScriptArgs)"/>
/// </summary>
public interface IJavaScriptArgs { }

