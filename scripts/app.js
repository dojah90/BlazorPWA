
(function () {
    var theme = localStorage.getItem('theme');
    if(theme){
        if (theme.includes('theme-dark')) {
            setTheme('theme-dark');
        } else {
            setTheme('theme-light');
        }
    } else {
        setTheme('theme-light');
    }
    
 })();

 /**
 * Sets the color theme the app should use
 * @param {theme that should be used} theme 
 */
function setTheme(theme){
    document.documentElement.className = theme;
}

function fadeIn(){
    $(".page-body-content").fadeIn(200);
}

function fadeOut(){
    $(".page-body-content").fadeOut(200);
}