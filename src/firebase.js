import firebase from "firebase";
import {ref, onUnmounted} from "vue";
import {initializeApp} from "firebase/app";

const firebaseConfig = {
    apiKey: "AIzaSyA-gLVBp--Z3Fcc0IStK291hiX9q3iT10A",
    authDomain: "twitter-clone-d3ebb.firebaseapp.com",
    projectId: "twitter-clone-d3ebb",
    storageBucket: "twitter-clone-d3ebb.appspot.com",
    messagingSenderId: "866018298381",
    appId: "1:866018298381:web:f1df252861cd6aaf1e6344"
};

// Initialize Firebase
const firebaseApp = initializeApp(firebaseConfig);

const db = firebaseApp.firestore()
const usersCollection = db.collection('users')

export const createUser = user => {
    return usersCollection.add(user)
}

export const getUser = async id => {
    const user = await usersCollection.doc(id).get()
    return user.exists ? user.data() : null
}

export const updateUser = (id, user) => {
    return usersCollection.doc(id).update(user)
}

export const deleteUser = id => {
    return usersCollection.doc(id).delete()
}

export const useLoadUsers = () => {
    const users = ref([])
    const close = usersCollection.onSnapshot(snapshot =>{
        users.value = snapshot.docs.map(doc => ({id:doc.id,...doc.data()}))
    })
    onUnmounted(close)
    return users
}