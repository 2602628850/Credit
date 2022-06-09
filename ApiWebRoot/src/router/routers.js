import {createRouter,createWebHashHistory} from 'vue-router' 
//-------路由加载都采用赖加载,避免首页加载页面过多出现卡顿,测试
 const App1 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demorouter/demo.vue')
 const App2 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demorouter/demoto.vue')
 const App3 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demoaxios/demo.vue')
//-------路由加载都采用赖加载,避免首页加载页面过多出现卡顿，测试
 //创建路由, hash 模式。
const router = createRouter({
  history: createWebHashHistory(),
  routes:[
 //--测试
   { path: '', redirect:"/vuedemo" },
   { path: '/vuedemo', component: App1 },
   { path: '/vuedemoto', component: App2 },
   { path: '/axioxdemo', component: App3 },
//--测试

  ]
})
export default router