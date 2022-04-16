import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Events  from '../views/EventsView.vue'
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
    path: '/Eventos',
    name: 'Eventos',
    component: Events
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

router.beforeEach((to, from, next) => {
  // redirect to login page if not logged in and trying to access a restricted page
  if (to.path == '/Logout') {
    localStorage.clear()
  }
  const publicPages = ['/']
  const authRequired = !publicPages.includes(to.path)
  const loggedIn = localStorage.getItem('Authorization')

  if (authRequired && !loggedIn) {
    console.log('Rota 1.0 Sem token')
    return next('/')
  }
  console.log('Rota 1.1 token:', localStorage.getItem('Authorization'))
  next()
})
