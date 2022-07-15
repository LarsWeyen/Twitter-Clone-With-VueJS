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
        <div>
          <div class="input-container">
            <input type="text">
          </div>
          <div class="post-extras">
            <div class="functions">
              <div>
                <uil-scenery size="20px"/>
              </div>
              <div>
                <uil-camera-plus size="20px"/>
              </div>
              <div>
                <uil-analytics size="20px"/>
              </div>
              <div>
                <uil-smile size="20px"/>
              </div>
              <div>
                <uil-calender size="20px"/>
              </div>
            </div>
            <div class="confirm-button">
              <div><span>Tweet</span></div>
            </div>
          </div>
        </div>
      </div>
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

export default {
  name: "HomeView",
  components: {
    UilScenery, UilCameraPlus, UilAnalytics, UilSmile, UilCalender
  }
}
</script>

<style scoped>
.container {
  display: grid;
  grid-template-columns: 600px 1fr;
  height: 200vh;
}

.page-title {
  position: fixed;
  height: 53px;
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
.box{
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

}

.user-picture {
  width: 48px;
  margin-right: 12px;
  padding-top: 4px;
}

.input-container {
  width: 100%;
}
</style>