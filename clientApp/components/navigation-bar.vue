<template>
	<view :style="{height: statusBarHeight}"></view>
<!--通用导航栏-->
	<view class="navi flex-row-between" :style="{backgroundColor: barColor,color: titleColor}" style="position: relative;">
		<view v-if="showBack" class="navi-back-icon mgl iconfont icon-back" @click="goBack"></view>
		<view style="position: absolute;top: 0;left: 0;width: 100%;z-index: 0;height: 49px;" class="flex-row-center">{{title}}</view>
	</view>


</template>

<script>
	export default {
		name: "navigation-bar",
		props: {
			barColor: {
				type: String,
				default: '#00875a'
			},
			titleColor: {
				type: String,
				default: 'white'
			},
			title: {
				type: String,
				default: ''
			},
			showBack: {
				type: Boolean,
				default: true
			}
		},
		data() {
			return {
				statusBarHeight: '0px',
			}
		},
		methods: {
			 goBack() {
				uni.navigateBack({
					delta: 1
				})
			}
			// goBack() {
			// 	const pages = getCurrentPages()
			// 	// 有可返回的页面则直接返回，uni.navigateBack  默认返回失败之后会自动刷新页面 ，无法继续返回
			// 	if (pages.length > 1) {
			// 	 uni.navigateBack(1)
			// 	 return;
			// 	}
			// 	// vue router 可以返回uni.navigateBack失败的页面 但是会重新加载 
			// 	let a = this.$router.go(-1)
			// 	// router.go失败之后则重定向到首页 
			// 	if (a == undefined) {
			// 	 uni.reLaunch({
			// 	  url: "/pages/index/indexPage"
			// 	 })
			// 	}
			// 	return;
			// }

		},
		created() {
			this.statusBarHeight = this.$safeTop;
			if (this.statusBarHeight <= 0) {
				this.statusBarHeight = 0;
			}
			this.statusBarHeight += 'px';
		}
	}
</script>

<style scoped>
	.navi {
		height: 49px;
	}
	.navi-back-icon {
		font-size: 30px;
		z-index: 1;
	}
</style>