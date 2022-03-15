import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Person  from '../views/PersonView.vue'
import Login  from '../views/LoginView.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/Home',
    name: 'Home',
    component: HomeView
  },
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/Person',
    name: 'Cadastro de Pessoas',
    component: Person
  }
  // {
  //   path: "/about",
  //   name: "about",
  //   // route level code-splitting
  //   // this generates a separate chunk (about.[hash].js) for this route
  //   // which is lazy-loaded when the route is visited.
  //   component: () =>
  //     import(/* webpackChunkName: "about" */ "../views/AboutView.vue"),
  // },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
