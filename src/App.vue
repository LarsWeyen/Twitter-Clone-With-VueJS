<template>
  <div v-if="isLoggedIn" class="logged-in-container">
    <div class="header">
      <header-com :user="user"/>
    </div>
    <router-view :user="user"/>
  </div>
  <div v-else class="start-screen">
    <main>
      <div class="left-side">
        <uil-twitter class="logo" size="390"/>
      </div>
      <div class="right-side">
        <div class="container">
          <uil-twitter class="logo" size="65"/>
          <div class="title">
            <span>What's happening now</span>
          </div>
          <div class="sub-title">
            <span>Join Twitter today</span>
          </div>
          <div class="register-container" v-if="isRegistering">
            <h4>Email</h4>
            <input v-model="email" type="email" id="email">
            <h4>@Account name</h4>
            <input v-model="username" type="text" id="username">
            <h4>What should people call you?</h4>
            <input v-model="name" type="text" id="name">
            <h4>Password</h4>
            <input v-model="password" type="password" id="password">
            <h4>Confirm password</h4>
            <input v-model="confirmpwd" type="password" id="confirm-pwd">
            <button @click="Register">Register</button>
            <button @click="isRegistering=false">Back</button>
          </div>
          <div class="login-container" v-if="isLoggingIn">
            <h4>Email</h4>
            <input v-model="loginEmail" type="text">
            <h4>Password</h4>
            <input v-model="loginPwd" type="password">
            <button @click="Login">Login</button>
            <button @click="isLoggingIn= false">Back</button>
          </div>
          <div v-if="isLoggingIn==false && isRegistering==false" class="buttons-container">
            <div class="google-register-button">
              <div class="google-register">
                <div class="google-logo-container"><img :src="require('@/assets/1534129544.png')" class="google-logo"
                                                        alt="google logo"></div>
                <span>Register with Google</span>
              </div>
            </div>
            <div class="apple-register-button">
              <div class="apple-register">
                <div class="apple-logo-container"><img :src="require('@/assets/Apple_logo_black.svg.png')"
                                                       class="apple-logo"
                                                       alt="apple logo"></div>
                <span>Register with Apple</span>
              </div>
            </div>
            <div class="line-break-container">
              <div class="line-break">
                <div class="line-container">
                  <div class="line"></div>
                </div>
                <div class="line-break-middle">
                  <span>or</span>
                </div>
                <div class="line-container">
                  <div class="line"></div>
                </div>
              </div>
            </div>
            <div class="register-button" @click="isRegistering = true; isLoggingIn= false">
              <div class="button">
                <span>Register with a phone number or email address</span>
              </div>
            </div>
            <div class="conditions">
              <span>By registering, you agree to the Terms and Conditions and Privacy Policy , including the use of cookies .</span>
            </div>
            <div class="login-container">
              <div class="login-text"><span>Do you already have an account?</span></div>
              <div class="login-button" @click="isLoggingIn = true; isRegistering= false">
                <span>Login</span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>
    <footer>
      <span>Over</span>
      <span>Helpcentrum</span>
      <span>Algemene voorwaarden</span>
      <span>Privacybeleid</span>
      <span>Cookiebeleid</span>
      <span>Toegankelijkheid</span>
      <span>Advertentie-info</span>
      <span>Blog</span>
      <span>Status</span>
      <span>Banen</span>
      <span>Merkhulpmiddelen</span>
      <span>Reclame</span>
      <span>Marketing</span>
      <span>Twitter voor bedrijven</span>
      <span>Ontwikkelaars</span>
      <span>Overzicht</span>
      <span>Instellingen</span>
      <span>© 2022 Twitter, Inc.</span>
    </footer>
  </div>
</template>

<script>
import HeaderCom from "@/components/HeaderCom";
import {UilTwitter} from '@iconscout/vue-unicons'
import axios from "axios";

export default {
  name: "app",
  data() {
    return {
      isLoggedIn: false,
      isRegistering: false,
      email: null,
      name: null,
      username: null,
      password: null,
      confirmpwd: null,
      user: null,
      isLoggingIn: false,
      loginEmail: null,
      loginPwd: null
    }
  },
  created() {
    this.isLoggedIn = !!localStorage.getItem('Username');
    if (this.isLoggedIn) {
      this.getUser()
    }
  },
  methods: {
    async getUser() {
      const payload = {
        Username: localStorage.getItem('Username'),
        UserID: 0
      }
      const res = await axios.post('https://localhost:44366/api/GetAccount', payload)
      this.user = res.data[0]
    },
    Register() {
      const AccountDetails = {
        Username: this.username,
        Name: this.name,
        Email: this.email,
        Password: this.password,
      }
      axios.post('https://localhost:44366/api/AccountCreate', AccountDetails)
          .then(response => {
            if (response.data !== "Email is used!") {
              if (response.data !== "Username is used!") {
                this.isLoggedIn = true
                localStorage.setItem('Username', response.data[0].Username)
                this.getUser()
              } else {
                alert('Username is used!')
              }
            } else {
              alert('email is used!')
            }
          })
    },
    Login() {
      const details = {
        Email: this.loginEmail,
        Password: this.loginPwd
      }
      axios.post('https://localhost:44366/api/AccountLogin', details)
          .then(response => {
            localStorage.setItem('Username', response.data.Username)
            this.isLoggedIn = true;
            this.getUser()
          })
    }
  },
  components: {HeaderCom, UilTwitter}
}
</script>

<style>
* {
  box-sizing: border-box;
  font-family: -apple-system, sans-serif;
}

body {
  margin: 0;
  padding: 0;

  background-color: rgb(0, 0, 0);
}

img {
  max-width: 100%;
  height: auto;
}

.logged-in-container {
  display: grid;
  grid-template-columns: 241px 1fr;
  min-height: 100vh;
  width: 70%;
  margin: auto;
}

#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  min-height: 937px;
}

.header {
  width: 241px;
}

.exact-active-link span {
  color: rgb(231, 233, 234);
  font-size: 20px;
  font-weight: 700;
}

.logo {
  color: rgb(255, 255, 255);
}

.right-side .logo {
  padding-bottom: 12px;
  color: rgb(214, 217, 219);
}

.start-screen {
  height: 100%;
}

main {
  display: flex;
  flex: 1 1 auto;
  height: 100%;
}

.left-side {
  background-size: cover;
  background-repeat: no-repeat;
  background-image: url("assets/lohp_1302x955.png");
  background-position: center center;
  height: 94vh;
  width: 100%;
  min-height: 45vh;
  display: grid;
  place-items: center;
}

.right-side {
  display: flex;
  min-width: 45vw;
  justify-content: center;
  padding: 16px;
}

.container {
  display: flex;
  justify-content: start;
  flex-direction: column;
  min-width: 437px;
  max-width: 760px;
  width: 100%;
  padding-inline: 20px;
  color: rgb(255, 255, 255);;
}

.title {
  line-height: 84px;
  letter-spacing: -1.2px;
  font-size: 64px;
  font-weight: 700;
  margin-bottom: 48px;
  margin-top: 48px;
  overflow-wrap: break-word;
  max-width: 720px;
  text-align: start;
}

.sub-title {
  margin-bottom: 32px;
  line-height: 36px;
  font-size: 31px;
  font-weight: 700;
  text-align: start;
}

.apple-register-button, .google-register-button {
  width: 300px;
  outline-style: none;
  min-width: 36px;
  min-height: 36px;
  max-width: 380px;
  margin-bottom: 20px;
  background-color: rgba(255, 255, 255, 1.00);
  padding-left: 16px;
  padding-right: 16px;
  border: 1px rgb(51, 54, 57) solid;
  border-radius: 9999px;
  display: flex;

  justify-content: center;
}

.google-logo-container {
  width: 20px;
  height: 20px;
  margin-right: 4px;
  color: rgb(15, 20, 25);
}

.apple-logo-container {
  width: 15px;
  margin-right: 4px;
  color: rgb(15, 20, 25);
}

.google-register, .apple-register, .register-button {
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
}

.google-register, .apple-register span {
  color: rgb(15, 20, 25);
  font-size: 15px;
  line-height: 20px;
  font-weight: 700;
}

.line-break-container {
  width: 300px;
  max-width: 380px;
  margin-bottom: 4px;
  margin-top: 4px;
}

.line-break {
  display: flex;
  flex-direction: row;
  margin: 4px -4px;
  align-items: center;
}

.line-container {
  margin-left: 4px;
  margin-right: 4px;
  flex: 1;
}

.line {
  background-color: rgb(47, 51, 54);
  height: 1px;
}

.register-button {
  background-color: rgb(29, 155, 240);
  border: rgba(0, 0, 0, 0) solid 1px;
  border-radius: 9999px;
  width: 300px;
  margin-bottom: 8px;
  height: 40px;
  outline-style: none;
  min-width: 36px;
  min-height: 36px;
  max-width: 380px;
  padding-left: 16px;
  padding-right: 16px;
  display: flex;
  align-items: center;
}

.button {
  max-width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.conditions {
  color: rgb(113, 118, 123);
  line-height: 12px;
  font-size: 11px;
  font-weight: 400;
  width: 300px;
  max-width: 380px;
  margin-bottom: 20px;
  text-align: start;
}

.login-container {
  margin-top: 40px;
}

.login-text {
  color: rgb(231, 233, 234);
  font-size: 17px;
  max-width: 380px;
  margin-bottom: 20px;
  font-weight: 700;
  line-height: 20px;
  text-align: start;
}

.login-button {
  border: rgb(83, 100, 113) solid 1px;
  border-radius: 9999px;
  width: 300px;
  margin-bottom: 8px;
  height: 40px;
  outline-style: none;
  min-width: 36px;
  min-height: 36px;
  max-width: 380px;
  padding-left: 16px;
  padding-right: 16px;
  color: rgb(29, 155, 240);
  display: flex;
  align-items: center;
  justify-content: center;
}

footer {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  flex-direction: row;
  padding: 12px 16px;
}

footer span {
  color: rgb(113, 118, 123);
  font-size: 13px;
  padding-right: 16px;
  font-weight: 400;
  line-height: 16px;
  margin-bottom: 4px;
  margin-top: 4px;
}

.button span {
  max-width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.register-container {
  display: flex;
  flex-direction: column;
  justify-content: start;
  max-width: 370px;
}
</style>
