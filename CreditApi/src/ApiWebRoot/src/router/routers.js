import {createRouter,createWebHashHistory} from 'vue-router' 
//路由加载都采用赖加载,避免首页加载页面过多出现卡顿
 const App1 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/routerdemo/demo.vue')
 const App2 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/routerdemo/demoto.vue')
//创建路由, hash 模式。
const router = createRouter({
  history: createWebHashHistory(),
  routes:[
   { path: '', redirect:"/vuedemo" },
   { path: '/vuedemo', component: App1 },
   { path: '/vuedemoto', component: App2 },

  ]
})
export default router