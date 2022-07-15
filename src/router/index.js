import {createRouter, createWebHashHistory, createWebHistory} from 'vue-router'
import HomeView from "@/views/HomeView";


const routes = [
  {
    path: '/',
    redirect:'/home',
  },
  {
    name:'home',
    path: '/home',
    component:HomeView
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
