import App from './App'

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'

import * as API from '/common/js/API/API.js'
import * as storeUtil from "./common/js/Utils/StoreUtil";
import constUtil from "/common/js/const/Const"
import * as langUtil from "/common/js/Utils/LangUtil"

// 多语言

import {createI18n} from "vue-i18n"

import zh from '/i18n/text-zh'
import en from '/i18n/text-en'
import tabBar from '@/components/bottomhand.vue'
import NavigationBar from "@/components/navigation-bar.vue";
const i18n = createI18n({
    globalInjection: true,
    locale: langUtil.getLang() || "en",
    messages: {
        zh: zh,
        en: en,
    },
})

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
    app.config.globalProperties.$windowWidth = uni.getSystemInfoSync().windowWidth > 906 ? 500 : uni.getSystemInfoSync().windowWidth;
    app.config.globalProperties.$screenHeight = uni.getSystemInfoSync().screenHeight;
    app.config.globalProperties.$screenWidth = uni.getSystemInfoSync().screenWidth > 960 ? 500 : uni.getSystemInfoSync().screenWidth;
    app.config.globalProperties.$statusBarHeight = uni.getSystemInfoSync().statusBarHeight;
    app.config.globalProperties.$pixelRatio = uni.getSystemInfoSync().windowWidth / 750;
    // 多语言
    app.config.globalProperties.$i18n = i18n;
    // API
    app.config.globalProperties.$Api = API;
    // 工具
    app.config.globalProperties.$StoreUtil = storeUtil;
    app.config.globalProperties.$Const = constUtil;
    app.config.globalProperties.$LangUtil = langUtil;

    app.use(ElementPlus)
    app.use(i18n)
	app.component('tabBar', tabBar)
	//将顶部导航栏注册到main里面，就不用在每个页面在单独去注册引用了,页面就可以直接调用了
	app.component('NavigationBar', NavigationBar)

    return {
        app
    }
}


// #endif