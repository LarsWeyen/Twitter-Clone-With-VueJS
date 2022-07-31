<template>
  <main>
    <div class="header">
      <header-com/>
    </div>

    <router-view/>
  </main>
</template>

<script>
import HeaderCom from "@/components/HeaderCom";

export default {
  name: "OverView",
  components:{
    HeaderCom
  }
}
</script>

<style scoped>
.header{
  width: 241px;
}
main{
  text-align: center;
  color: #2c3e50;
  display: grid;
  grid-template-columns: 241px 1fr;
  min-height: 100vh;
  width: 70%;
  margin: auto;
}
</style>