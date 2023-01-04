function getArgs(tsFilePath) {
    const selector = `script[type="application/json"][data-role="module-args"][data-module-name="${tsFilePath}"]`;
    const content = document.querySelector(selector).text
    return JSON.parse(content)
}

args = getArgs("home/index")

msg = document.getElementById("message")
msg.textContent = `${args.name}, age ${args.age}`
