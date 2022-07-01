<template>
	<register-top-item :title="$t('login.wel')" :sub-title="$t('login.welSub')"></register-top-item>



	<register-input-item :tip="$t('public.mail')" style="margin-top: -20px">
		<template v-slot:img>
			<view class="input-icon iconfont icon-youxiang"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('public.mailTip')" class="input" v-model="editItem.Username" />
		</template>
	</register-input-item>


	<register-input-item :tip="$t('public.pwd')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-mima"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('public.pwdTip')" class="input" v-model="editItem.Password" />
		</template>
	</register-input-item>

	<view class="flex-row-start margin-left-right-20 mgt mgb text-small">
		<el-switch v-model="rememberAccount" class="ml-2" style="--el-switch-on-color: #00875a;" />
		<view class="mgl text-grey">{{$t('login.remember')}}</view>
	</view>


	<view class="button-primary margin-left-right-20 flex-row-center" @click="doLogin">
		{{$t('public.login')}}
	</view>

	<view class="mgt button-second margin-left-right-20 flex-row-center" @click="toRegister">
		{{$t('login.register')}}
	</view>

</template>

<script>
	import RegisterTopItem from "../register/register-top-item";
	import RegisterInputItem from "../register/register-input-item";
	// import {
	// 	get,
	// 	post
	// } from '@/common/js/API/Query.js'
	export default {
		name: "login",
		components: {
			RegisterInputItem,
			RegisterTopItem
		},
		data() {
			return {
				editItem: {},
				rememberAccount: true,
			}
		},
		methods: {
			// https://uniapp.dcloud.io/api/router.html#navigateto 自带路由
			doLogin() {
				var url = "/Account/UserLogin";
				this.ApiPost(url, this.editItem).then(res => {
					if(res.data==null){
						uni.showToast({
							title:this.$t('registerandlog.loginresult'),
							duration:2000,
						})
						
					}else{
						//登录成功,缓存token
						this.$StoreUtil.set('token',res.data.token);
						//跳首页
						uni.navigateTo({
						url: '/pages/index/indexPage'
						})
					}
				})
				
				
			},
			toRegister() {
				uni.reLaunch({
					url: '/pages/register/index'
				});
			},
			changeLang() {
				let oldLang = this.$StoreUtil.get('lang');
				if (!oldLang) {
					oldLang = 'en';
				}

				if (oldLang == 'en') {
					this.$i18n.locale = 'zh';
					this.$StoreUtil.set('lang', 'zh');
				} else {
					this.$i18n.locale = 'en';
					this.$StoreUtil.set('lang', 'en');
				}
			}
		},
	}
</script>

<style scoped>
	.input-placeholder {
		font-size: 12px;
	}

	.uni-input-input {
		font-size: 12px;
	}
</style>
