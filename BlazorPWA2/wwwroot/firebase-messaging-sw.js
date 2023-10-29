

importScripts('https://www.gstatic.com/firebasejs/8.2.0/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/8.2.0/firebase-messaging.js');

const firebaseConfig = {
    apiKey: "AIzaSyBFCEysHG9HQt6bZTHx3hyJNw1VWZNaSgo",
    authDomain: "blazorpwa-cbd77.firebaseapp.com",
    projectId: "blazorpwa-cbd77",
    storageBucket: "blazorpwa-cbd77.appspot.com",
    messagingSenderId: "885380981579",
    appId: "1:885380981579:web:01ae45c2d51956ecb97ece"
  };

  firebase.initializeApp(firebaseConfig);
  const msgng = firebase.messaging();

  messaging.setBackgroundMessageHandler(function(payload) {
    console.log(
        "[firebase-messaging-sw.js] Received background message ",
        payload,
    );
    // Customize notification here
    const notificationTitle = "Background Message Title";
    const notificationOptions = {
        body: "Background Message body.",
        icon: "/itwonders-web-logo.png",
    };

    return self.registration.showNotification(
        notificationTitle,
        notificationOptions,
    );
});

/*
// Initialize the Firebase app in the service worker by passing in the
// messagingSenderId.
firebase.initializeApp({
    apiKey: "AIzaSyBFCEysHG9HQt6bZTHx3hyJNw1VWZNaSgo",
  authDomain: "blazorpwa-cbd77.firebaseapp.com",
  projectId: "blazorpwa-cbd77",
  storageBucket: "blazorpwa-cbd77.appspot.com",
  messagingSenderId: "885380981579",
  appId: "1:885380981579:web:01ae45c2d51956ecb97ece"
});

// Retrieve an instance of Firebase Messaging so that it can handle background
// messages.
const messaging = firebase.messaging();

*/