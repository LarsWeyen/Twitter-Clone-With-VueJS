<template>
  <div class="post" >
    <article @click.self="goToPost">
      <div class="user-picture-container" @click.self="goToPost">
        <div class="user-picture">
          <img :src="profilePicture"/>
        </div>
      </div>
      <div class="post-rightside" >
        <div class="post-header" @click.self="goToPost">
          <div class="post-username">
            <span>{{ username }}</span>
          </div>
          <div class="post-name">
            <span>@{{ name }}</span>
          </div>
          <div class="between">
            <span>·</span>
          </div>
          <div class="post-date">
            <span>{{ postedTime }}</span>
          </div>
        </div>
        <div class="post-sub" @click.self="goToPost">
          <div class="post-text">
            <span>{{ post.Title }}</span>
          </div>
          <div class="post-image">
            <img class="postImage" v-if="post.Image" :src="post.Image" alt="">
          </div>
          <div class="post-buttons" @click.self="goToPost">
            <div class="post-button">
              <div class="button-icon post-comments">
                <uil-comment size="19px"/>
              </div>
              <span>{{ post.commentCount }}</span>
            </div>
            <div class="post-button">
              <div class="button-icon post-retweets">
                <uil-repeat size="19px"/>
              </div>
              <span>{{ post.retweetCount }}</span>
            </div>
            <div class="post-button">
              <div class="button-icon post-likes">
                <uil-heart-alt size="19px"/>
              </div>
              <span>{{ post.likeCount }}</span>
            </div>
            <div class="post-button">
              <div class="button-icon post-share">
                <uil-upload size="19px"/>
              </div>
            </div>
          </div>
        </div>
      </div>
    </article>
  </div>
</template>

<script>
import {UilComment, UilHeartAlt, UilRepeat, UilUpload} from '@iconscout/vue-unicons'
import axios from "axios";

export default {
  name: "PostCom",
  data() {
    return {
      username: null,
      profilePicture: null,
      name: null
    }
  },
  props: {
    post: {
      type: Object,
      required: true
    }
  },
  created() {
    this.getUser()
  },
  methods: {
    goToPost(){
      this.$router.push({name:'ShowPost',params:{username:this.post.Username,id:this.post.PostID}})
    },
    async getUser() {
      const payload = {
        UserID: 0,
        Username:this.post.Username
      }
      const res = await axios.post('https://localhost:44366/api/GetAccount', payload)
      this.username = res.data[0].Username;
      this.profilePicture = res.data[0].ProfilePicture;
      this.name = res.data[0].Name;
    },
  },
  computed: {
    postedTime() {
      let seconds = Math.floor((new Date() - new Date(this.post.Date)) / 1000);
      let interval = seconds / 31536000;
      if (interval > 1) {
        return new Date(this.post.Date).toString().split(' ').slice(1, 4).join(' ');
      }
      interval = seconds / 2592000;
      if (interval > 1) {
        return new Date(this.post.Date).toString().split(' ').slice(1, 4).join('-');
      }
      interval = seconds / 86400;
      if (interval > 1) {
        return Math.floor(interval) + " d";
      }
      interval = seconds / 3600;
      if (interval > 1) {
        return Math.floor(interval) + " h";
      }
      interval = seconds / 60;
      if (interval > 1) {
        return Math.floor(interval) + " m";
      }
      return Math.floor(seconds) + " s";
    }
  },
  components: {
    UilComment, UilRepeat, UilHeartAlt, UilUpload
  }
}
</script>

<style scoped>

img {
  max-width: 100%;
  height: auto;
  border-radius: 50%;
}

.post {
  width: 100%;
  border-bottom: 1px solid rgb(47, 51, 54);
}

.post:hover {
  background-color: rgba(255, 255, 255, 0.03);
  cursor: pointer;
}

.user-picture-container {
  flex-basis: 48px;
  margin-right: 12px;
  flex-grow: 0;
}

.user-picture {
  width: 48px;
}
.user-picture img{
  aspect-ratio: 1/1;
}
article {
  padding-inline: 16px;
  padding-top: 12px;
  display: flex;
  width: 100%;
}

.post-rightside {
  width: 100%;
  padding-bottom: 12px;
}

.post-header {
  display: flex;
  gap: 1rem;
}

.post-text {
  text-align: start;
  color: rgb(231, 233, 234);
  font-size: 15px;
  font-weight: 400;
  line-height: 20px;
}
.post-name{
  color: rgb(113, 118, 123);
  font-size: 15px;
  font-weight: 400;
  line-height: 20px;
}
.post-image {
  margin-top: 12px;
}

.postImage {
  width: 100%;
  height: 100%;
  object-fit: contain;
  border-radius: 1rem !important;
}

.post-button {
  display: flex;
  align-items: center;
  gap: 8px;
}

.post-buttons {
  display: flex;
  justify-content: space-between;
  max-width: 425px;
  margin-top: 12px;
}

.button-icon {
  padding: 8px;
  display: grid;
  place-items: center;
}

.button-icon:hover {
  border-radius: 50%;
  cursor: pointer;
}

.post-comments:hover {
  background-color: rgba(29, 155, 240, 0.1);
  color: rgb(29, 155, 240);
}

.post-comments:hover + span {
  color: rgb(29, 155, 240);
}

.post-retweets:hover {
  background-color: rgba(0, 186, 124, 0.1);
  color: rgb(0, 186, 124);
}

.post-retweets:hover + span {
  color: rgb(0, 186, 124);
}

.post-likes:hover {
  background-color: rgba(249, 24, 128, 0.1);
  color: rgb(249, 24, 128);
}

.post-likes:hover + span {
  color: rgb(249, 24, 128);
}

.post-share:hover {
  background-color: rgba(29, 155, 240, 0.1);
  color: rgb(29, 155, 240);
}

.post-username {
  color: rgb(231, 233, 234);
  font-weight: 700;
  font-size: 15px;
}

.between {
  color: rgb(113, 118, 123);
  font-weight: 400;
  font-size: 20px;
  text-align: justify;
  line-height: 20px;
}

.post-date {
  color: rgb(113, 118, 123);
  font-weight: 400;
  font-size: 15px;
}


</style>