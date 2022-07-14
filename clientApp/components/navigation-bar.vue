<template>
	<view :style="{height: statusBarHeight}"></view>
<!--通用导航栏-->
	<view class="navi flex-row-between" :style="{backgroundColor: barColor,color: titleColor}" style="position: relative;">
		<view v-if="showBack" class="navi-back-icon mgl iconfont icon-back" @click="goBack"></view>
		<view style="position: absolute;top: 0;left: 0;width: 100%;z-index: 0;height: 49px;" class="flex-row-center">{{title}}</view>
	<view style="margin-left: 73%;z-index: 1;font-size: 13px;" @click="Laout">{{$t('login.lauout')}}</view>&nbsp;
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
			},
			Laout(){
				//退出登录
				this.$StoreUtil.set('token','');
				uni.reLaunch({
					url: '/pages/login/login'
				})
			}

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