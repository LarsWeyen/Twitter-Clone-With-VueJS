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
            <input @input="onChange" :maxlength="maxChar" v-model="postText" class="tweet-title-input" type="text"
                   placeholder="What are you up to?">
          </div>
          <div ref="imageContainer" class="image-container">

          </div>
          <div class="post-extras">
            <div class="functions">
              <div class="function">
                <label for="file">
                  <uil-scenery size="20px"/>
                </label>
                <input type="file" id="file" @change="onFileSelected" accept="image/*">
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
              <div class="progress-container" :class="postText.length > 0 ? 'visible' : ''">
                <div ref="progressBar" class="progress">
                  <div :class="postText.length >= (maxChar-20) ? 'visible' : ''" ref="valueContainer"
                       class="value-container"><span>{{ maxChar - postText.length }}</span></div>
                </div>

              </div>
              <div @click="postTweet" :class="postText.length > 0 ? 'active' : ''" class="tweet-button">
                <div><span>Tweet</span></div>
              </div>
            </div>

          </div>
        </div>
      </div>
      <post-com v-for="post in posts" :post="post" :key="post.PostID"/>
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
import axios from 'axios'


export default {
  name: "HomeView",
  data() {
    return {
      postText: '',
      maxChar: 280,
      selectedFile: null,
      posts: []
    }
  },
   created() {
    this.getTweets()
  },
  watch:{
    posts(){
      this.getTweets()
    }
  },
  methods: {
    async getTweets(){
      const res = await axios.get('https://localhost:44366/api/Posts')
      this.posts = res.data
    },
    postTweet() {
      if (this.postText.length > 0 && this.postText !== " ") {
        axios.post('https://localhost:44366/api/Posts', {
          title: this.postText,
          date: new Date(),
          image: this.selectedFile
        })
        this.selectedFile = null;
        while (this.$refs.imageContainer.firstChild) {
          this.$refs.imageContainer.removeChild(this.$refs.imageContainer.lastChild);
        }
        this.postText = '';
      }
    },
    onChange() {
      let progressValue = this.postText.length;
      this.$refs.progressBar.style.background = `conic-gradient(rgb(29, 155, 240) ${progressValue * 1.3}deg, #2E3235 ${progressValue * 1.3}deg)`;
    },
    onFileSelected(event) {
      const reader = new FileReader();
      reader.addEventListener("load", () => {
        this.selectedFile = reader.result;
        let img = new Image()
        img.src = this.selectedFile
        img.style.width = '100%';
        img.style.height = '100%';
        img.style.objectFit = 'contain';
        img.style.borderRadius = '1rem';

        let removeButton = document.createElement('div')
        removeButton.style.top = '4px';
        removeButton.style.left = '4px';
        removeButton.style.minHeight = '32px';
        removeButton.style.minWidth = '32px';
        removeButton.style.borderRadius = '50%';
        removeButton.style.position = 'absolute';
        removeButton.style.width = 'fit-content';
        removeButton.style.backgroundColor = 'rgba(0, 0, 0,.7)';
        removeButton.style.color = 'rgb(255, 255, 255)';
        removeButton.style.display = 'grid';
        removeButton.style.placeItems = 'center';
        removeButton.style.cursor = 'pointer';
        removeButton.classList.add('remove-button')

        removeButton.addEventListener('click', () => {
          while (this.$refs.imageContainer.firstChild) {
            this.$refs.imageContainer.removeChild(this.$refs.imageContainer.lastChild);
          }
        })
        let span = document.createElement('span')
        span.style.fontSize = '15px'
        span.innerText = 'X';

        removeButton.appendChild(span)
        while (this.$refs.imageContainer.firstChild) {
          this.$refs.imageContainer.removeChild(this.$refs.imageContainer.lastChild);
        }
        this.$refs.imageContainer.appendChild(img)
        this.$refs.imageContainer.appendChild(removeButton)

      })
      reader.readAsDataURL(event.target.files[0])

    }
  },

  components: {
    UilScenery, UilCameraPlus, UilAnalytics, UilSmile, UilCalender, PostCom
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

.active {
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

.flex {
  display: flex;
  align-items: center;
  gap: 1rem;
}

.added-image {
  width: 100%;
  height: 100%;
  object-fit: contain;
}

input[type="file"] {
  display: none;
}

label {
  height: 20px;
}

label:hover {
  cursor: pointer;
}

.charlimit {
  font-size: 14px;
  visibility: hidden;
}

.progress-container {
  position: relative;
  visibility: hidden;
}

.progress {
  width: 20px;
  height: 20px;
  background-color: orange;
  border-radius: 50%;
  display: grid;
  place-items: center;
}

.progress:before {
  content: '';
  position: absolute;
  height: 80%;
  width: 80%;
  background-color: black;
  border-radius: 50%;
}

.remove-button {
  top: 4px;
  left: 4px;
  min-height: 32px;
  min-width: 32px;
  border-radius: 50%;
  position: absolute;
  width: fit-content;
  background-color: red;
  color: red;
}

.value-container {
  visibility: hidden;
  position: relative;
  font-size: 10px;
  color: white;
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

.image-container {
  width: 100%;
  position: relative;
}

.user-post-container {
  flex: 1;
}

.visible {
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

.tweet-button:hover {
  background-color: rgb(26, 140, 216);
}

.function {
  padding: 6px;
  display: grid;
  place-items: center;
}

.function:hover {
  background-color: rgba(29, 155, 240, 0.1);
  color: rgb(29, 155, 240);
  border-radius: 50%;
  cursor: pointer;
}
</style>