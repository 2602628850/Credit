<template>
	<register-top-item :title="$t('register.wel')" :sub-title="$t('register.welSub')"></register-top-item>
	<register-input-item :tip="'国家'">
		<template v-slot:img>
			<view class="input-icon iconfont icon-diqiu"></view>
		</template>
		<template v-slot:default>
			<view class="flex-row-between" @click="countryPickerShow">
				<input disabled :placeholder="$t('register.countryTip')" class="input"/>
				<view class="text-tip iconfont icon-xiala" style="font-size: 16px"></view>
			</view>
		</template>
	</register-input-item>





	<picker-view class="picker-view" v-if="showCountry"></picker-view>
</template>

<script>
	import RegisterTopItem from "./register-top-item";
	import RegisterInputItem from "./register-input-item";
	export default {
		components: {RegisterInputItem, RegisterTopItem},
		data() {
			return {
				showCountry: '',
			}
		},
		methods: {
			countryPickerShow() {
				console.log('-------------')
				this.showCountry = true;
			},
			Login() {
				// https://uniapp.dcloud.io/api/router.html#navigateto 自带路由
				uni.navigateTo({
					url: '/pages/login'
				})
			},
			agreement() {
				uni.navigateTo({
					url: '/pages/register/agreement'
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
		font-size: 16px;
	}
</style>
