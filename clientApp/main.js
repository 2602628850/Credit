import App from './App'

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'

import * as API from '/common/js/API/API.js'


// #ifndef VUE3


import Vue from 'vue'

Vue.config.productionTip = false

App.mpType = 'app'
const app = new Vue({
    ...App
})

// #ifndef H5
app.$mount(); //为了兼容小程序及app端必须这样写才有效果
// #endif

// #endif

// #ifdef VUE3


import {createSSRApp} from 'vue'

export function createApp() {
    const app = createSSRApp(App)

    // 屏幕相关
    app.config.globalProperties.$windowHeight = uni.getSystemInfoSync().windowHeight;
    app.config.globalProperties.$windowWidth = uni.getSystemInfoSync().windowWidth;
    app.config.globalProperties.$screenHeight = uni.getSystemInfoSync().screenHeight;
    app.config.globalProperties.$screenWidth = uni.getSystemInfoSync().screenWidth;
    app.config.globalProperties.$statusBarHeight = uni.getSystemInfoSync().statusBarHeight;
    app.config.globalProperties.$pixelRatio = uni.getSystemInfoSync().windowWidth / 750;
    // API
    app.config.globalProperties.$Api = API;
    app.use(ElementPlus)

    return {
        app
    }
}


// #endif