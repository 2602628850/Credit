<template>
	<navigation-bar :title="$t('setUserInfo.title')"></navigation-bar>
	<app-content-view :show-tab-bar="true" :show-navigation-bar="true" >  
		<register-input-item :tip="$t('setUserInfo.nickname')" class="mgt">
			<template v-slot:img>
				<view class="input-icon iconfont icon-youxiang"></view>
			</template>
			<template v-slot:default>
				<input   class="input" v-model="editItem.nickname" v />
			</template>
		</register-input-item> 
		<view class="mgt w100 margin-left-right-20 flex-row-start text-small"> 
			<view class="mgl agree text-primary" ></view>
		</view>
		<view class="button-primary margin-left-right-20 flex-row-center" @click="doRegister">
			{{$t('setUserInfo.button')}}
		</view>
	</app-content-view>
</template>

<script>
	import RegisterTopItem from "../register/register-top-item";
	import RegisterInputItem from "../register/register-input-item";
	export default {
		components: {
			RegisterInputItem,
			RegisterTopItem
		},
		data() {
			return {  
				editItem: {
					Nickname: '',
				},
			}
		},
		mounted() {
			if (!uni.getStorageSync('token')) {
				uni.reLaunch({
					url: '/pages/login/login'
				})
			}
			this.GetUserinfo()
		},
		methods: { 
			showMsg(msg) {
				uni.showToast({
					title: msg,
					duration: 2000,
				})
			},
			GetUserinfo() {
				var url = "/User/GetUserInfo";
				this.ApiGet(url).then(res => {
					this.editItem = res.data
				})
			},
			doRegister() { 
				if (this.editItem.nickname.split(" ").join("").length === 0) {
					var msg = this.$t('setUserInfo.msge');
					this.showMsg(msg)
					return;
				} 
				var url = "/User/UpdateUser";
				this.ApiPost(url, this.editItem).then(res => {
					if (res.data == "success") {
						this.showMsg(this.$t('setUserInfo.msg'));
						//注册成功后登录
						uni.navigateTo({
							url: '/pages/mine/mine'
						})
						return;
					} else {
						this.showMsg(res.data);
					}

				})

			}
		}
	}
</script>

<style>
	.input-icon {
		font-size: 18px;
	}

	.input {
		height: 44px;
		font-size: 16px;
		flex: 1;
	}

	.input-placeholder {
		font-size: 12px;
	}

	.uni-input-input {
		font-size: 12px;
	}

	.agree {
		box-sizing: border-box;
		border-bottom-color: #00875a;
		border-bottom-style: solid;
		border-bottom-width: 1px;
	}
</style>
