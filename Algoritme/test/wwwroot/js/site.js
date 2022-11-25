// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ClickTop() {
    let imageTop = document.getElementById('img-top');
    let imageMiddle = document.getElementById('img-middle');
    let imageLower = document.getElementById('img-bottum');
    var SetValue = document.getElementById('SetValue');

    SetValue.SetValue = 1;
    imageTop.scr = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAABmJLR0QA/wD/AP+gvaeTAAACEElEQVR4nO3bvW7UQBiF4TNA46EhtFRcTmhSRVuAlDTcEZcASNwUf9p67QYostGkWCE2wpDYm/WcmXkfyZIlS+NPfuXpRgIAAAAAAADKEHIP8OA28VUIeifpZe5RJCmd/Jz0jasLEvq4lvQi9xy/TQ3y6FiDYJ7qgqSkt5K+5J5jruq2rMUN3XlI4aOkJ2OP2bKWdEeMOQgy19CtRmJsD12WIHPs/oz3uh3jOqVweejSBJlqfJu6Tilc6PmPD4cuT5ApjhxDIsj9LRBDIsj9LBRDIsjdFowhEeT/Fo4hEeTfMsSQCDIuUwyJIH/LGEMiyG2ZY0gE+cMghkSQHZMYEkGsYkitBzGLIbUcxDCG1GoQ0xhSi0GMY0itBTGPIbUUpIAYUitBCokhtRCkoBhS7UEKiyHVHKTAGFKtQQqNIdUYpOAYUm1BCo8h1RTEJ8bXvftij0UcZuhWoY9XoY9p77rS0K0Wn2UTT0Mf16GPa23i6eLvz27ozkdibLV5+jr3aO0hhhFiGCGGEWIYIYYRYhghhhFiGCGGEWIYIYYRYhghhhFiGCGGEWIYIYYRYhghhhFiGCGGEWIYIYYRYhghhhFiGCGGEWIYIYYRYhghhhFiGCGGEWIYIYaRPp6NxMhzwBJS6ON3YhzPnHPqj/futymkN3r269NDDYSpdlvWt9DHz+rjWe5xAAAAAAAAAORxA7XJ7gEraYk+AAAAAElFTkSuQmCC';
    
}

function ClickMiddle() {
    let imageTop = document.getElementById('img-top');
    let imageMiddle = document.getElementById('img-middle');
    let imageLower = document.getElementById('img-bottum');
    var SetValue = document.getElementById('SetValue');

    SetValue.SetValue = 2;
}

function ClickLower() {
    let imageTop = document.getElementById('img-top');
    let imageMiddle = document.getElementById('img-middle');
    let imageLower = document.getElementById('img-bottum');
    var SetValue = document.getElementById('SetValue');

    SetValue.SetValue = 3;
}


//imageMiddle.src = 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAABmJLR0QA/wD/AP+gvaeTAAADdUlEQVR4nO3b34tUZRzH8fd311nUMIQUJGRnEheyq/IPyLRslTK0glYv9kJvSoqoey+7qJu6UQjtwoow2Eo0NkREbwSJJYSwgpWd5yySFYYmZLm/vt2kO+fM6M5sz/Gsnc8LBnbm4TzPl/1wnjPnOc+AiIiIiIiIiIiIiIiIiIiIiIiIiIiIyH3EE573wC8e+M3rDBRdT+l5IPGA//ua8jo78xinK49O/6emG/7uxvjYAztiD6JA2vc6MNnwfhFwxANbYw6iQNpkNYaBAWCq4eMe4AsPbIw1jgLpgNX4EmMPMNPw8RLgax/jyShjxOikbDywGzhE+v93nS6etl5GCiqr3DzhzYZvXbdeVz3wRNG1lZYH9rUI5VcPrCu6ttLywDstQrnkCWuKrq20PPBei1ASH6PaaV+6qEfgjjHOAZxX0w2MYmywGpfb7UtfeyMww+llL/BRuoE+nBN+iYfa7it2cWXmTjcJn0LT4uN5jE1W5epcfegMiciMaa4wiHM80/Q4zrD/xLI5+8iptlLzC/TwAEehaZ3rLIvpt1X8eadjFUhO/GeWMsEwsCHdwEmm2GZ93Gx1nKasnNjD3GCSFzC+TTewmQpHfIRKq+MUSI6sj+vM0A98l2nazgo+c2dR9hgFkjN7hGtMsgX4IdP0MuMcck9ncPsa4nWewjgIrL0Hdcqs/VR5wwyHxkACPwKPFlZWmRkfWJW3QFPWgjMbiPMacLG4UkprP728feuN7kPuAR9lJRXOAI+lGozD9LLbbPaRsALJmddZjnEKWJ9pGqLKTrPUpgldQ/LkozxIFydoDuMoV9iVDQN0huRmvksnTXeK8t/5BXqYYIhsGHCWJeywVa3DAE1Z0fkIFZYyRPNK7zn+ZuvdVnoBuvMrrXzc6WaSTzBeyjSdx3jW1vLHXH1oyorEHSPhQ7JPC53vqfCMrZ77aSFoyori9iYH2JNuYBSj31bze7t9KZAYEt5t2nEC4zibO9lxIhFoo9wCoq2kC0hem611pz4Pef4cQRf1DnnCIHCQdBg3mGFbjN+G6AzpgAdeBD4nff/2F/Cc1TgdYwwF0iavswXjGKS270wA263GN7HG0ZTVLuN90mFMAQMxwwAFMl/TOINW46uiCyktD2z0wJgHLnudV4quR0RERERERERERERERERERERERERERPL1D59fXBr3X4bvAAAAAElFTkSuQmCC'
