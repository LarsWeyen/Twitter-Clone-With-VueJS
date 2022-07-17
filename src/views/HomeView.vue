<template>
  <div class="container">
    <div class="posts">
      <div style="position: relative">
        <div class="page-title" id="title">
          <h1>Homepage</h1>
        </div>
        <div class="box">

        </div>
      </div>
      <div class="user-post">
        <div class="user-picture">
          <img src="../assets/oksCHBlQ_400x400.jpg"/>
        </div>
        <div class="user-post-container">
          <div class="input-container">
            <input :maxlength="maxChar" v-model="postText" class="tweet-title-input" type="text" placeholder="What are you up to?">
          </div>
          <div class="post-extras">
            <div class="functions">
              <div class="function">
                <uil-scenery size="20px"/>
              </div>
              <div class="function">
                <uil-camera-plus size="20px"/>
              </div>
              <div class="function">
                <uil-analytics size="20px"/>
              </div>
              <div class="function">
                <uil-smile size="20px"/>
              </div>
              <div class="function">
                <uil-calender size="20px"/>
              </div>
            </div>
            <div class="flex">
              <div class="charlimit" :class="postText.length > 0 ? 'visible' : ''"><span>{{maxChar - postText.length}}</span></div>
              <div @click="postTweet" :class="postText.length > 0 ? 'active' : ''" class="tweet-button">
                <div><span>Tweet</span></div>
              </div>
            </div>

          </div>
        </div>
      </div>
      <post-com v-for="post in posts" :post="post"/>
    </div>
    <div class="side-bar">

    </div>
  </div>
</template>

<script>
import {UilScenery} from '@iconscout/vue-unicons'
import {UilCameraPlus} from '@iconscout/vue-unicons'
import {UilAnalytics} from '@iconscout/vue-unicons'
import {UilSmile} from '@iconscout/vue-unicons'
import {UilCalender} from '@iconscout/vue-unicons'
import PostCom from "@/components/PostCom";

export default {
  name: "HomeView",
  data(){
    return{
      postText:'',
      maxChar:280,
      posts:[
        {
          id:1,
          text:'Lets go first post!',
          image:'https://www.kaas.nl/wp-content/uploads/2020/03/133035_Maasdam.png',
          date: new Date().setHours(new Date().getHours() -5),
          commentCount:5,
          likeCount:3,
          retweetCount:7
        },
        {
          id:2,
          text:'woep woep ez clap',
          image:null,
          date: new Date().setMonth(new Date().getMonth() -2),
          commentCount:1,
          likeCount:7,
          retweetCount:2
        }
      ]
    }
  },
  methods:{
    postTweet(){
      if(this.postText.length>0 && this.postText !== " "){
        this.posts.push({text:this.postText,date: new Date()})
      }
    }
  },
  components: {
    UilScenery, UilCameraPlus, UilAnalytics, UilSmile, UilCalender,PostCom
  }
}
</script>

<style scoped>
* {
  box-sizing: border-box;
}

.container {
  display: grid;
  grid-template-columns: 600px 1fr;
  height: 200vh;
}

.page-title {
  position: fixed;
  height: 53px;
  backdrop-filter: blur(10px);
  width: 100%;
}
.active{
  opacity: 1 !important;
  cursor: pointer;
}
h1 {
  color: rgb(231, 233, 234);
  font-size: 20px;
  font-weight: 700;
  text-align: start;
  padding-left: 14px;
}

img {
  max-width: 100%;
  height: auto;
  border-radius: 9999px;
}
.flex{
  display: flex;
  align-items: center;
  gap: 1rem;
}
.charlimit{
  font-size: 14px;
  visibility: hidden;
}
.box {
  height: 53px;
}

.posts {
  max-width: 600px;
  width: 100%;
  border-right: 1px solid rgb(47, 51, 54);
  border-left: 1px solid rgb(47, 51, 54);
}

.functions {
  display: flex;
  gap: 1em;
}

.user-post {
  padding-left: 16px;
  padding-right: 16px;
  display: flex;
  width: 100%;
  border-bottom: 1px solid rgb(47, 51, 54);
}

.user-picture {
  width: 48px;
  padding-top: 4px;
}

.input-container {
  width: 100%;
  padding: 12px;
  text-align: start;
}

.tweet-title-input {
  overflow: hidden;
  padding-bottom: 2px;
  padding-top: 2px;
  position: relative;
  white-space: pre-wrap;
  background: transparent;
  border: none;
  outline: none;
  color: white;
  width: 500px;
  height: 28px;
  font-size: 20px;
}

.user-post-container {
  flex: 1;
}
.visible{
  visibility: visible;
}
.post-extras {
  display: flex;
  justify-content: space-between;
  align-items: center;

}

.tweet-button {
  color: white;
  font-size: 15px;
  line-height: 20px;
  font-weight: 700;
  opacity: 0.6;
  background-color: rgb(29, 155, 240);
  min-width: 36px;
  min-height: 36px;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 9999px;
  margin-block: 16px;
 width: fit-content;
  padding-left: 16px;
  padding-right: 16px;
}
.tweet-button:hover{
  background-color: rgb(26, 140, 216);
}
.function{
  padding: 6px;
  display: grid;
  place-items: center;
}
.function:hover{
  background-color: rgba(29, 155, 240,0.1);
  color: rgb(29, 155, 240);
  border-radius: 50%;
  cursor: pointer;
}
</style>