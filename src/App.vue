<template>
  <div class="header">
    <header-com/>
  </div>

  <router-view/>
</template>

<script>
import HeaderCom from "@/components/HeaderCom";

export default {
  name: "app",
  components: {HeaderCom}
}
</script>

<style>
*{
  box-sizing: border-box;
}
body {
  margin: 0;
  padding: 0;
  font-family: -apple-system, sans-serif;
  background-color: rgb(0, 0, 0);
}

#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  display: grid;
  grid-template-columns: 241px 1fr;
  min-height: 100vh;
  width: 70%;
  margin: auto;

}
.header{
  width: 241px;
}
</style>
