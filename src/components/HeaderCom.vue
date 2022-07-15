<template>
  <main>
    <div>
      <div class="logo-container">
        <router-link to="/home">
          <UilTwitter to="/home" size="34px" class="logo"/>
        </router-link>
      </div>
      <nav>
        <router-link to="/home" class="nav-button">
          <div class="nav-icon">
            <uil-estate size="25px"/>
          </div>
          <div class="nav-titel">
            <span>Homepage</span>
          </div>
        </router-link>
        <router-link to="/explore" class="nav-button">
          <div class="nav-titel">
            <span>#</span>
          </div>
          <div class="nav-titel">
            <span>Explore</span>
          </div>
        </router-link>
        <div class="nav-button">
          <div class="nav-icon">
            <uil-bell size="25px"/>
          </div>
          <div class="nav-titel">
            <span>Notifications</span>
          </div>
        </div>
        <div class="nav-button">
          <div class="nav-icon">
            <uil-envelope size="25px"/>
          </div>
          <div class="nav-titel">
            <span>Messages</span>
          </div>
        </div>
        <div class="nav-button">
          <div class="nav-icon">
            <uil-bookmark size="25px"/>
          </div>
          <div class="nav-titel">
            <span>Bookmarks</span>
          </div>
        </div>
        <div class="nav-button">
          <div class="nav-icon">
            <uil-clipboard-notes size="25px"/>
          </div>
          <div class="nav-titel">
            <span>Lists</span>
          </div>
        </div>
        <div class="nav-button">
          <div class="nav-icon">
            <uil-user size="25px"/>
          </div>
          <div class="nav-titel">
            <span>Profile</span>
          </div>
        </div>
      </nav>
      <div>
        <div class="tweet-button">
          <span>Tweet</span>
        </div>
      </div>
    </div>
    <div class="user-container">
      <div class="profile-picture">
        <img src="../assets/oksCHBlQ_400x400.jpg"/>
      </div>
      <div class="usernames">
        <span class="username">Kaas</span>
        <span class="second-username">@kaas</span>
      </div>
      <div class="dots">
        <span>...</span>
      </div>
    </div>
  </main>
</template>

<script>
import {UilTwitter} from '@iconscout/vue-unicons'
import {UilEstate} from '@iconscout/vue-unicons'
import {UilBell} from '@iconscout/vue-unicons'
import {UilEnvelope} from '@iconscout/vue-unicons'
import {UilBookmark} from '@iconscout/vue-unicons'
import {UilClipboardNotes} from '@iconscout/vue-unicons'
import {UilUser} from '@iconscout/vue-unicons'

export default {
  name: "HeaderCom",
  components: {
    UilTwitter, UilEstate, UilBell, UilEnvelope, UilBookmark, UilClipboardNotes, UilUser
  }
}
</script>

<style scoped>
main {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: fit-content;
  padding-right: 10px;
  position: fixed;
  height: 100vh;
}

a {
  text-decoration: none;
}

img {
  max-width: 100%;
  height: auto;
  border-radius: 9999px;
}

.logo-container {
  text-align: start;
  margin-top: 10px;
  padding: 8px;
}

.logo {
  color: rgb(231, 233, 234);
  padding: 8px;
}

.logo:hover {
  background-color: #232323;
  border-radius: 50%;
  cursor: pointer;
}

.nav-icon {
  color: rgb(231, 233, 234);
}

.nav-titel {
  color: rgb(231, 233, 234);
  font-size: 20px;
  font-weight: 400;
  line-height: 24px;
}

.nav-button {
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 12px;
  width: fit-content;
  height: fit-content;
  margin-block: 4px;
}

.nav-button:hover {
  background-color: #232323;
  border-radius: 30px;
  cursor: pointer;

}

.tweet-button {
  color: white;
  font-size: 17px;
  line-height: 20px;
  font-weight: 700;
  background-color: rgb(29, 155, 240);
  min-width: 52px;
  min-height: 52px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 9999px;
  margin-block: 16px;
  width: 225px;
}

.tweet-button:hover {
  background-color: rgb(26, 140, 216);
  cursor: pointer;
}

.profile-picture {
  min-width: 40px;
  width: 40px;
}

.user-container {
  display: flex;
  padding: 12px;
  width: 200px;
  align-items: center;
  margin-bottom: 10px;
}

.usernames {
  display: flex;
  flex-direction: column;
  width: 100%;
  text-align: start;
  margin-left: 8px;
}

.username {
  color: rgb(231, 233, 234);
}

.second-username {
  color: rgb(113, 118, 123);
}

.user-container:hover {
  background-color: #232323;
  border-radius: 30px;
  cursor: pointer;

}

.dots {
  color: rgb(231, 233, 234);
  font-weight: bold;
  display: flex;
  margin-bottom: 10px;
}
</style>