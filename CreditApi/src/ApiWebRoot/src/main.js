import { createApp } from 'vue'
import App from './App.vue'
import router from './router/routers.js'
import ElementPlus from 'element-plus';
import 'element-plus/dist/index.css';
import AxiosObj from  './commjs/axios.js'
import vueis from "./commjs/vueis.js"
const app=createApp(App);
//挂载路由
app.use(router)
//全局引用element-plus(ui)
app.use(ElementPlus)
//注册全局的axios,其它地方都通过this.$Http来取Axios对象
app.use(AxiosObj)
app.config.globalProperties.$Http = AxiosObj.Axios
//挂在vue-Is
app.use(vueis)
app.config.globalProperties.appls=app.ls;//main引用的js里面不能直接用this.appIs获取,只能通过install传参使用(Vue.ls.get('')),其他地方可以使用this.appI
app.mount('#app')
