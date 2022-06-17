<template>
	<view class="register-top-back-view">
		<navigation-bar></navigation-bar>

		<view style="margin: 20px 20px auto 20px;color: white">
			<view style="font-size: 25px;font-weight: bold">{{title}}</view>
			<view class="mgt" style="font-size: 14px">{{subTitle}}</view>
		</view>
	</view>
</template>

<script>
	import NavigationBar from "../../components/login-navigation-bar";
	export default {
		name: "register-top-item",
		props: {
			title: {
				type: String,
				default: ''
			},
			subTitle: {
				type: String,
				default: ''
			}
		},
		components: {NavigationBar}
	}
</script>

<style scoped>
	.register-top-back-view {
		background-image: url("/static/Icons/register/register-top-bg.png");
		background-repeat: no-repeat;
		/*background-position: center;*/
		/*background-attachment: fixed;*/
		background-size: 100% 100%;
		height: 215px;
	}
</style>