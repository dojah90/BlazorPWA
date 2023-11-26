
import { saveMessagingDeviceToken } from './messaging.js';

document.addEventListener('DOMContentLoaded', async () => {
  if(navigator.userAgent.match(/(iPod|iPhone|iPad)/)){
    if( Notification.permission !== "granted"){
      let elm = await waitForElm('.fcmButton');
    elm.style.display = "inherit";
    elm.addEventListener('click', function () {
      enablePushNotificationsByClick();
    });
    } else {
      saveMessagingDeviceToken();
    }    
  }  
});

if(navigator.userAgent.match(/(iPod|iPhone|iPad)/)){
  console.log('Device is an apple mobile device');
}
else{
  saveMessagingDeviceToken();
}


function waitForElm(selector) {
  return new Promise(resolve => {
      if (document.querySelector(selector)) {
          return resolve(document.querySelector(selector));
      }

      const observer = new MutationObserver(mutations => {
          if (document.querySelector(selector)) {
              observer.disconnect();
              resolve(document.querySelector(selector));
          }
      });

      observer.observe(document.body, {
          childList: true,
          subtree: true
      });
  });
}


export async function enablePushNotificationsByClick(){
  console.log('Try enable Firebase Messaging');
  await saveMessagingDeviceToken();
  let elm = await waitForElm('.fcmButton');
  elm.style.display = "none";
}