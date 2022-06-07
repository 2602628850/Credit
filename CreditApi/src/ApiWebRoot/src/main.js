import { createApp } from 'vue'
import App from './App.vue'
import router from './router/routers.js'
import ElementPlus from 'element-plus';
import 'element-plus/dist/index.css';
const app=createApp(App);
//挂载路由
app.use(router)
//全局引用element-plus(ui)
app.use(ElementPlus)
app.mount('#app')
