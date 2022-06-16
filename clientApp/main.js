import App from './App'

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'

import * as API from '/common/js/API/API.js'
import * as storeUtil from "./common/js/Utils/StoreUtil";

// 多语言
import i18n from './i18n'


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

    app.config.globalProperties.$windowHeight = uni.getSystemInfoSync().windowHeight;
    app.config.globalProperties.$windowWidth = uni.getSystemInfoSync().windowWidth > 500 ? 500 : uni.getSystemInfoSync().windowWidth;
    app.config.globalProperties.$screenHeight = uni.getSystemInfoSync().screenHeight;
    app.config.globalProperties.$screenWidth = uni.getSystemInfoSync().screenWidth > 500 ? 500 : uni.getSystemInfoSync().screenWidth;
    app.config.globalProperties.$statusBarHeight = uni.getSystemInfoSync().statusBarHeight;
    app.config.globalProperties.$pixelRatio = uni.getSystemInfoSync().windowWidth / 750;
    // 多语言
    app.config.globalProperties.$i18n = i18n;
    // API
    app.config.globalProperties.$Api = API;
    // 工具
    app.config.globalProperties.$StoreUtil = storeUtil;

    app.use(ElementPlus)
    app.use(i18n)

    return {
        app
    }
}


// #endif