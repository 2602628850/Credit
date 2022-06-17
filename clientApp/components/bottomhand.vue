<template>
	<view style="padding: 5%;"></view>
	<view class="tab-bar">
		<view v-for="(item,index) in list" :key="index" class="tab-bar-item" >
			<span v-on:click="toAgree(item.pagePath,index)"><image class="tab_img" :src="selected === index ? item.selectedIconPath : item.iconPath"></image></span>
			<view class="tab_text" :style="{color: selected === index ? selectedColor : color}" style="font-size: 17px;margin-bottom: 15px;;" v-on:click="toAgree(item.pagePath,index)">{{item.text}}</view>
		</view>
	</view>
 
</template>
<script>
	export default {
		props: {
			selected: { // 当前选中的tab index
				type: Number,
				default: 0
			}
 
		},
		data() {
			return {
				color: "#333333",
				selectedColor: "green",
				list: [{
					pagePath: "/pages/index/indexPage",
					iconPath: "/static/image/tarbar/home.png",
					selectedIconPath: "/static/image/tarbar/choose/home.png",
					text: this.$t('Tabbar.home')
				}, {
					pagePath: "/pages/prohall/index",
					iconPath: "/static/image/tarbar/hall.png",
					selectedIconPath: "/static/image/tarbar/choose/hall.png",
					text: this.$t('Tabbar.hall')
				},
				 {
					pagePath: "/pages/index/index",
					iconPath: "/static/image/tarbar/team.png",
					selectedIconPath: "/static/image/tarbar/choose/team.png",
					text: this.$t('Tabbar.team')
				}, 
				{
					pagePath: "/pages/index/tes",
					iconPath: "/static/image/tarbar/mine.png",
					selectedIconPath: "/static/image/tarbar/choose/mine.png",
					text: this.$t('Tabbar.mine')
				},
				
				]
			}
		},
		methods: {
		toAgree(path,index) {
			uni.navigateTo({
				url:path
			})
		},
		}
	}
</script>
 
<style lang="scss">
	.tab-bar {
		position: fixed;
		bottom: 0;
		left: 0;
		right: 0;
		height: 100rpx;
		background: white;
		display: flex;
		justify-content: center;
		align-items: center;
		padding-bottom: env(safe-area-inset-bottom); // 适配iphoneX的底部
		.tab-bar-item {
			flex: 1;
			text-align: center;
			display: flex;
			justify-content: center;
			align-items: center;
			flex-direction: column;
 
			.tab_img {
				width: 37rpx;
				height: 41rpx;
			}
 
			.tab_text {
				font-size: 20rpx;
				margin-top: 9rpx;
			}
		}
	}
</style>