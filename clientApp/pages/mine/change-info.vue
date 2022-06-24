<template>
<!--	修改个人信息-->
	<navigation-bar :title="$t('mineInfo.title')"></navigation-bar>
	<app-content-view :show-navigation-bar="true" style="background-color: white;">
		<view style="height: 1px"></view>
		<view style="margin-top: 20px;margin-bottom: 20px;" class="flex-row-center">
			<view style="position: relative">
				<image class="mine-user-info-image" :src="'/static/logo.png'"></image>
				<view class="mine-user-info-img-sm text-white bg-primary flex-row-center iconfont icon-xiangce"></view>
			</view>
		</view>
		<register-input-item :tip="$t('public.nickname')">
			<template v-slot:img>
				<view class="iconfont icon-geren" style="font-size: 18px"></view>
			</template>
			<template v-slot:default>
				<input />
			</template>
		</register-input-item>

		<view class="button-primary mine-user-info-button flex-row-center">{{$t('public.submit')}}</view>
	</app-content-view>
</template>

<script>
	import NavigationBar from "../../components/navigation-bar";
	import AppContentView from "../../components/app-content-view";
	import RegisterInputItem from "../register/register-input-item";
	export default {
		name: "change-info",
		components: {RegisterInputItem, AppContentView, NavigationBar}
	}
</script>

<style scoped>
	.mine-user-info-image {
		width: 120px;
		height: 120px;
		border-radius: 50%;
	}
	.mine-user-info-img-sm {
		position: absolute;
		bottom: 8px;
		right: 8px;
		width: 30px;
		height: 30px;
		border-radius: 50%;
		border-width: 2px;
		border-color: white;
		border-style: solid;
		font-size: 20px;
		box-sizing: border-box;
	}

	.mine-user-info-button {
		height: 44px;
		margin: 40px 20px 0px 20px;
	}
</style>