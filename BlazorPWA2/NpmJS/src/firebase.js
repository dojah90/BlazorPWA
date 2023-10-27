
import { initializeApp } from 'firebase/app';
import { getMessaging, isSupported } from 'firebase/messaging';

const firebaseConfig = {
    apiKey: "AIzaSyBFCEysHG9HQt6bZTHx3hyJNw1VWZNaSgo",
    authDomain: "blazorpwa-cbd77.firebaseapp.com",
    projectId: "blazorpwa-cbd77",
    storageBucket: "blazorpwa-cbd77.appspot.com",
    messagingSenderId: "885380981579",
    appId: "1:885380981579:web:01ae45c2d51956ecb97ece"
  };

  export const app = initializeApp(firebaseConfig);
  export const messaging = async () => await isSupported() && getMessaging(app);