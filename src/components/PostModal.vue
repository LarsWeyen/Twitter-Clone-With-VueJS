<template>
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
</template>

<script>
export default {
  name: "PostModal",
  methods:{
    onChange(){
      this.$emit('onChange')
    },
    onFileSelected(){
      this.$emit('onFileSelected')
    },
    postTweet(){
      this.$emit('postTweet')
    }
  }
}
</script>

<style scoped>

</style>