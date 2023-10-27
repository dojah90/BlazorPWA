
import { saveMessagingDeviceToken } from './messaging.js';

saveMessagingDeviceToken();







// Import the functions you need from the SDKs you need
//import firebase from "firebase/compat/app";
//import "firebase/compat/messaging";
// Your web app's Firebase configuration
/*const firebaseConfig = {
  apiKey: "AIzaSyBFCEysHG9HQt6bZTHx3hyJNw1VWZNaSgo",
  authDomain: "blazorpwa-cbd77.firebaseapp.com",
  projectId: "blazorpwa-cbd77",
  storageBucket: "blazorpwa-cbd77.appspot.com",
  messagingSenderId: "885380981579",
  appId: "1:885380981579:web:01ae45c2d51956ecb97ece"
};*/

// Initialize Firebase
//firebase.initializeApp(firebaseConfig);
//const messaging = firebase.messaging();

//getToken();
/*
messaging.onMessage(function (payload) {
  alert('message receiver');
  console.log('message received, ' + payload);
}, e => { console.log(e); });
*/
/*
function getToken(){
  messaging.getToken({vapidKey: "BNsRTdeZ37ek5_vVKApZEUV6mRtBRn04Sx4BWSXu8s6KSHFEayE96q0NNCqZfENcmt1SuOxxRdoxwKfYxSzQcm0"}).then((currentToken) => {
    if (currentToken) {
      console.log('Firebase token: ' + currentToken);
      localStorage.setItem('FCMToken', currentToken);

      messaging = firebase.messaging();
      messaging.onMessage(function (payload) {
        alert('message receiver');
        console.log('message received, ' + payload);
      }, e => { console.log(e); });
    } else {
      requestPermission();
    }
  }).catch((err) => {
    console.log('An error occurred while retrieving token. ', err);
  });
}

function requestPermission() {
  if (!("Notification" in window)) {
    console.log("This browser does not support desktop notification");
  } else if (Notification.permission === "granted") {
    getToken();
    // …
  } else if (Notification.permission !== "denied") {
    // We need to ask the user for permission
    Notification.requestPermission().then((permission) => {
      // If the user accepts, let's create a notification
      if (permission === "granted") {
        getToken();
      }
    });
  }
}
*/
