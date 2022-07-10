<template>


	<register-top-item :title="$t('register.wel')" :sub-title="$t('register.welSub')"></register-top-item>


	<register-input-item :tip="$t('register.country')" style="margin-top: -20px">
		<template v-slot:img>
			<view class="input-icon iconfont icon-diqiu"></view>
		</template>
		<template v-slot:default>
			<view class="flex-row-between" style="position: relative" @click="countryPickerShow">
				<input disabled :placeholder="$t('register.countryTip')" class="input mgr"
					v-model="editItem.CountryName" />
				<view class="text-tip iconfont icon-xiala" style="font-size: 16px"></view>

				<picker style="position: absolute;width: 100%;height: 100%;z-index: 9999;top: 0;left: 0;"
					:range="countryList" :index="countryIndex" range-key="name" @change="countryChange"></picker>
			</view>
		</template>
	</register-input-item>

	<register-input-item :tip="$t('public.mail')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-youxiang"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('public.mailTip')" class="input" v-model="editItem.Username" />
		</template>
	</register-input-item>
	<register-input-item :tip="$t('public.nikename')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-youxiang"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('public.nikenameTip')" class="input" v-model="editItem.Nickname" />
		</template>
	</register-input-item>


	<!-- <register-input-item :tip="$t('register.code')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-yanzheng"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('register.codeTip')" class="input" v-model="editItem.Code" />
		</template>
	</register-input-item> -->

	<register-input-item :tip="$t('register.invCode')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-JC_054"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('register.invCodeTip')" class="input" v-model="editItem.InvCode" />
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

	<register-input-item :tip="$t('register.rePwd')" class="mgt">
		<template v-slot:img>
			<view class="input-icon iconfont icon-mima"></view>
		</template>
		<template v-slot:default>
			<input :placeholder="$t('register.rePwdTip')" class="input" v-model="editItem.ConfirmPassword" />
		</template>
	</register-input-item>


	<view class="mgt w100 margin-left-right-20 flex-row-start text-small">
		<el-checkbox v-model="isAgree"></el-checkbox>
		<view class="mgl text-grey">{{$t('register.registerTip')}}</view>
		<view class="mgl agree text-primary" @click="toAgree">{{$t('register.agree')}}</view>
	</view>


	<view class="button-primary margin-left-right-20 flex-row-center" @click="doRegister">
		{{$t('public.register')}}
	</view>

	<view class="mgt flex-row-center text-small" style="padding-bottom: 30px">
		<view class="mgr text-grey">{{$t('register.haveAccount')}}</view>
		<view class="text-primary" @click="toLogin">{{$t('public.login')}}</view>
	</view>

</template>

<script>
	import RegisterTopItem from "./register-top-item";
	import RegisterInputItem from "./register-input-item";
	export default {
		components: {
			RegisterInputItem,
			RegisterTopItem
		},
		data() {
			return {
				countryList: [{
						name: 'England',
						code: 'U.K.'
					},
					{
						name: 'United States',
						code: 'USA'
					},
					{
						name: '中国',
						code: 'zh'
					}
				],
				countryIndex: 0,
				editItem: {
					CountryName: '',
					countryCode: '',
					Username:'',
				},
				isAgree: false
			}
		},
		methods: {
			countryChange(e) {
				this.countryIndex = e.detail.value;
				let item = this.countryList[this.countryIndex];
				this.editItem.countryCode = item.code;
				this.editItem.CountryName = item.name;
			},
			toLogin() {
				// https://uniapp.dcloud.io/api/router.html#navigateto 自带路由
				uni.reLaunch({
					url: '/pages/login/login'
				})
			},
			toAgree() {
				uni.navigateTo({
					url: '/pages/register/agreement'
				})
			},
			showMsg(msg) {
				uni.showToast({
					title: msg,
					duration: 2000,
				})
			},
			doRegister() {
				if (this.isAgree == false) {
					this.showMsg(this.$t('registerandlog.gxxy'));
					return;
				}
				if(this.editItem.Username.split(" ").join("").length === 0){
					var msg=this.$t('registerandlog.sureuser');
					this.showMsg(msg)
					return;
				}
				if (this.editItem.Password == null || this.editItem.ConfirmPassword == null || this.editItem
					.ConfirmPassword == '' || this.editItem.Password == '') {
					this.showMsg(this.$t('registerandlog.srmm'));
					return;
				}
				if(this.editItem.Password.length<6){
					this.showMsg(this.$t('registerandlog.surepass'));
					return;
				}
				if (this.editItem.Password != this.editItem.ConfirmPassword) {
					this.showMsg(this.$t('registerandlog.surepass'));
					return;
				}
				var url = "/Account/RegisterAccount";
				this.ApiPost(url, this.editItem).then(res => {
					if(res.data=="register_success"){
					this.showMsg(this.$t('registerandlog.registersuc'));
					//注册成功后登录
					uni.navigateTo({
						url: '/pages/login/login'
					})
					return;
					}else{
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
