import {createRouter, createWebHashHistory, createWebHistory} from 'vue-router'
import HomeView from "@/views/HomeView";
import ShowPost from "@/views/ShowPost";

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
  },
  {
    path: '/:username/:id',
    name: 'ShowPost',
    component: ShowPost,
    props:true,
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes,
  linkExactActiveClass: 'exact-active-link',
  linkActiveClass:'exact-active-link'
})

export default router
