import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/HomeView.vue' // Import your components
import GameManagementView from '../views/GameManagementView.vue'
import GameCreateView from '../views/GameCreateView.vue'
// import History from '../views/History.vue'
// import Leaderboard from '../views/Leaderboard.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/games',
    name: 'Game Management',
    component: GameManagementView
  },
  {
    path: '/games/create',
    name: 'Create Game',
    component: GameCreateView
  },
//   {
//     path: '/history',
//     name: 'History',
//     component: History
//   },
//   {
//     path: '/leaderboard',
//     name: 'Leaderboard',
//     component: Leaderboard
//   }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

export default router