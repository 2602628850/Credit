import { createApp } from 'vue'
import App from './App.vue'
import router from './router/routers.js'
import ElementPlus from 'element-plus';
import 'element-plus/dist/index.css';
import Axios from  './commjs/axios.js'
import vueis from "./commjs/vueis.js"
import * as icons from '@element-plus/icons-vue'
import Qs from 'qs'
const app=createApp(App);
//挂在vue-Is
app.use(vueis)
app.config.globalProperties.appls=app.ls;//main引用的js里面不能直接用this.appIs获取,只能通过install传参使用(Vue.ls.get('')),其他地方可以使用this.appIs
//挂载路由
app.use(router.router)
//启用路由防卫,防止未登录就进入系统页面
app.use(router.install)
//全局引用element-plus(ui)
app.use(ElementPlus)
//注册全局的axios,其它地方都通过this.$Http来取Axios对象
app.use(Axios)
app.config.globalProperties.$Http = Axios.Axios
//格式化参数
app.config.globalProperties.Qs = Qs
Object.keys(icons).forEach(key => {
  app.component(key, icons[key])
})
app.mount('#app')
