
import { getToken, onMessage } from 'firebase/messaging';
import { messaging } from './firebase';

const VAPID_KEY = 'BNsRTdeZ37ek5_vVKApZEUV6mRtBRn04Sx4BWSXu8s6KSHFEayE96q0NNCqZfENcmt1SuOxxRdoxwKfYxSzQcm0';

export async function requestNotificationsPermissions(){
    console.log('requesting notifications permissions ...');
    const permission = await Notification.requestPermission();

    if(permission === 'granted'){
        await saveMessagingDeviceToken();
    } else {
        console.log('Unable to get permission to notify.');
    }
}

export async function saveMessagingDeviceToken(){
    console.log('host: ', window.location.host);
    console.log('hostname: ', window.location.hostname);
    console.log('origin: ', window.location.origin);
    console.log('pathname: ', window.location.pathname);
    
    var path = window.location.origin;
    if(window.location.pathname && window.location.pathname.length > 0){
        path = path + window.location.pathname;
    }
    navigator.serviceWorker.register(path +  '/firebase-messaging-sw.js').then(async (registration) => {  
        registration = await navigator.serviceWorker.ready;

        const msg = await messaging();
        const fcmToken = await getToken(msg, { vapidKey: VAPID_KEY, serviceWorkerRegistration: registration });

    if(fcmToken){
        console.log('FCM Token: ', fcmToken);
        alert(fcmToken);
        localStorage.setItem('FCMToken', fcmToken);

        onMessage(msg, (message) => {
            console.log('New foreground notification');
            new Notification(message.notification.title, { body: message.notification.body });
        })
    }
    else{
        requestNotificationsPermissions();
    }
    });
}