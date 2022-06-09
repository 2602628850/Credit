import {createRouter,createWebHashHistory} from 'vue-router' 
//-------路由加载都采用赖加载,避免首页加载页面过多出现卡顿,测试
 const App1 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demorouter/demo.vue')
 const App2 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demorouter/demoto.vue')
 const App3 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demoaxios/demo.vue')
 const LoginPath =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/user/login.vue')
//-------路由加载都采用赖加载,避免首页加载页面过多出现卡顿，测试
 //创建路由, hash 模式。
const router = createRouter({
  history: createWebHashHistory(),
  routes:[
 //--测试
   { path: '', redirect:"/vuedemo" },
   { path: '/vuedemo', component: App1 },
   { path: '/vuedemoto', component: App2,name:"toapp2" },
   { path: '/axioxdemo', component: App3,name:"toapp3"  },
   //--测试
   { path: '/login', component: LoginPath,name:"LoginPath"  },

  ]
})
export default{
  router,
  install(Vue){
  //添加路由防守,防止未登录就随意进入系统页面,登录注册页面除外
router.beforeEach((to,form,next)=>{
  if(to.path.indexOf('/login') !=-1||to.path.indexOf('/register') !=-1){
    return next();
  }
  //Vue.ls.set('Access-Token','')
  var token=Vue.ls.get('Access-Token');
  if(!token){
    return next('/login');
  }else{
    return next();
  }
    
  })
  }
}