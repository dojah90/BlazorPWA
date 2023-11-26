
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

export async function saveMessagingDeviceToken() {

    const registration = await navigator.serviceWorker.ready;

    if (!'pushManager' in registration) {
        console.log('Push Notifications not supported');
    }
    
    var path = window.location.origin;
    var pathname = window.location.pathname;
    var baseAdresses = ['news', 'chat', 'home', 'contacts', 'settings'];

    if(pathname && pathname.length > 0 && baseAdresses.includes(pathname) == false){
        path = path + window.location.pathname;
    }

    navigator.serviceWorker.register(path +  '/firebase-messaging-sw.js').then(async (registration) => {  
        registration = await navigator.serviceWorker.ready;

        console.log('Try get FCM Token ...');
        const msg = await messaging();
        
        if(msg){
            console.log('Firebase messaging initialized, try get Firebase FCM Token ...');
            const fcmToken = await getToken(msg, { vapidKey: VAPID_KEY, serviceWorkerRegistration: registration });

            if(fcmToken){
                console.log('FCM Token: ', fcmToken);
                localStorage.setItem("FCMToken", "\"" + fcmToken + "\"");
    
                onMessage(msg, (message) => {
                    console.log('New foreground notification');
                    registration.showNotification(message.notification.title, { body: message.notification.body });
                    //new Notification(message.notification.title, { body: message.notification.body });
                });
            }
            else{
                console.log('Request notifications permissions ...');
                requestNotificationsPermissions();
            }
        }
        else{
            console.log('Could not initialize Firebase Messaging : log');
            console.error('Could not initialize Firebase Messaging');
        }
    });
}