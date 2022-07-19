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
  },
  {
    name:'explore',
    path: '/explore'
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes,
  linkExactActiveClass: 'exact-active-link',
  linkActiveClass:'exact-active-link'
})

export default router
