# Example of how to pass C# Variables to JS Files


1. From within your view, you create a custom type inside a `@function` block

    ```cs
    @functions {
        public record HomeArgs(string name, int age) : IJavaScriptArgs { }
    }
    ```

2. You can place your JS code in a scripts section if you prefer to control where it lands in the DOM:

    ```cs
    @section Scripts {

    }
    ```

3. You then call `@JavaScriptHelper.Args` and pass in your path and object you'd like serialized:

    ```cs
    @JavaScriptHelper.Args("home/index", new HomeArgs("Kyle", 35))
    ```

4. This will render the following raw html (script block) on your page:

    ```html
    <script type="application/json" data-role="module-args" data-module-name="home/index">
      {"name":"Kyle","age":35}
    </script>
    ```

5. Then call the script for the page however you like:

    ```html
    <script type="text/javascript" src="@Url.Content("/js/home.js")"></script>
    ```

6. Inside of the script, we can retrieve args by finding the inserted JSON and parsing it's contents.  A helper function can grab the args based on path

    ```js
    function getArgs(tsFilePath) {
        const selector = `script[type="application/json"][data-role="module-args"][data-module-name="${tsFilePath}"]`;
        const content = document.querySelector(selector).text
        return JSON.parse(content)
    }
    ```

7. And then we can invoke that function to receive the serialized args from within our JS script

    ```js
    args = getArgs("home/index") // {"name":"Kyle","age":35}
    ```


Run the project locally with `dotnet run` to try it out!
