import {createRouter,createWebHashHistory} from 'vue-router' 
//-------路由加载都采用赖加载,避免首页加载页面过多出现卡顿,测试
//  const App =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demorouter/demo.vue')
 const App2 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demorouter/demoto.vue')
 const App3 =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/demo/demorouter/demo.vue')
//-------路由加载都采用赖加载,避免首页加载页面过多出现卡顿，测试
const IndexPath =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/creditindex/index.vue')
const LoginPath =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/user/login.vue')
const RegisterPath =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/user/register.vue') 
const UserAgreementPath =()=>import (/* webpackChunkName: "pageFirst" */ './../vues/user/useragreement.vue') 
//创建路由, hash 模式。
const router = createRouter({
  history: createWebHashHistory(),
  routes:[
    { path: '', redirect:"/indexPath" },
    {
       path: '/indexPath', component: IndexPath,
       children:[
        {path:'',redirect:"/indexPath/axioxdemo"},
        {path:'axioxdemo',component:App3,name:"toapp3"},
        {path:'vuedemoto',component:App2,name:"toapp2"}
      
       ]
    },
   { path: '/login', component: LoginPath,name:"LoginPath"  },
   { path: '/register', component: RegisterPath,name:"RegisterPath"  },
   { path: '/register', component: UserAgreementPath,name:"UserAgreementPath"  },

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