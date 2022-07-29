<template>
	<navigation-bar :title="$t('changepwd.title')"></navigation-bar>
	<app-content-view :show-tab-bar="true" :show-navigation-bar="true">
		<register-input-item :tip="$t('changepwd.oldpwd')" class="mgt">
			<template v-slot:img>
				<view class="input-icon iconfont icon-mima"></view>
			</template>
			<template v-slot:default>
				<input  class="input" v-model="editItem.oldPwd" type="password"  />
			</template>
		</register-input-item>

		<register-input-item :tip="$t('changepwd.newpwd')" class="mgt">
			<template v-slot:img>
				<view class="input-icon iconfont icon-mima"></view>
			</template>
			<template v-slot:default>
				<input  class="input" v-model="editItem.newPwd" type="password"  />
			</template>
		</register-input-item>

		<register-input-item :tip="$t('changepwd.confirmpwd')" class="mgt">
			<template v-slot:img>
				<view class="input-icon iconfont icon-mima"></view>
			</template>
			<template v-slot:default>
				<input class="input" v-model="editItem.ConfirmPwd" type="password" />
			</template>
		</register-input-item>
		<view class="mgt w100 margin-left-right-20 flex-row-start text-small">
			<view class="mgl agree text-primary"></view>
		</view>
		<view class="button-primary margin-left-right-20 flex-row-center" @click="doRegister">
			{{$t('changepwd.button')}}
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
				countryIndex: 0,
				editItem: {oldPwd:'',newPwd:'' }, 
			}
		},
		created() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			return;
			}
		},
		methods: { 
			showMsg(msg) {
				uni.showToast({
					title: msg,
					duration: 2000,
				})
			},
			doRegister() {
				if (this.editItem.newPwd == null || this.editItem.ConfirmPwd == null || this.editItem
					.ConfirmPwd == '' || this.editItem.newPwd == '') {
					this.showMsg(this.$t('registerandlog.srmm'));
					return;
				}
				if (this.editItem.newPwd.length < 6) {
					this.showMsg(this.$t('registerandlog.surepass'));
					return;
				}
				if (this.editItem.newPwd != this.editItem.ConfirmPwd) {
					this.showMsg(this.$t('registerandlog.surepass'));
					return;
				}
				var url = "/User/UpdateUserPwd";
				this.ApiPost(url, this.editItem).then(res => {
					if (res.data == "register_success") {
						this.showMsg(this.$t('registerandlog.registersuc'));
						//注册成功后登录
						uni.navigateTo({
							url: '/pages/login/login'
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
