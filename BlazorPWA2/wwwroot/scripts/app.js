
(function () {
    var theme = localStorage.getItem('theme');
    if(theme){
        theme = theme.replace(new RegExp('\"', 'g'), '');
        var currentTheme = 'theme-' + theme;
        document.documentElement.className = currentTheme;
    } else {
        document.documentElement.className = 'theme-light';
    }
    
 })();

 /**
 * Sets the color theme the app should use
 * @param {theme that should be used} theme 
 */
function setTheme(theme){
    document.documentElement.className = 'theme-' + theme;
}

function fadeIn(){
    $(".page-body-content").fadeIn(200);
}

function fadeOut(){
    $(".page-body-content").fadeOut(200);
}

async function enableFCM(){
    const permission = await Notification.requestPermission();

    if(permission === 'granted'){
        enablePushNotificationsByClick();
    } else {
        console.log('Unable to get permission to notify.');
    }
}