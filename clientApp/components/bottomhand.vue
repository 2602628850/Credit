<template>
	<view class="tab-bar flex-row-between">
		<view v-for="(item,index) in list" :key="index" class="tab-bar-item flex-column-center" >
			<span v-on:click="toAgree(item.pagePath,index)"><image class="tab_img" :src="selected === index ? item.selectedIconPath : item.iconPath"></image></span>
			<view class="tab_text" :style="{color: selected === index ? selectedColor : color}" v-on:click="toAgree(item.pagePath,index)">{{item.text}}</view>
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
					pagePath: "/pages/mine/mine",
					iconPath: "/static/image/tarbar/mine.png",
					selectedIconPath: "/static/image/tarbar/choose/mine.png",
					text: this.$t('Tabbar.mine')
				},
				
				]
			}
		},
		methods: {
		toAgree(path,index) {
			uni.redirectTo({
				url:path
			})
		},
		}
	}
</script>
 
<style lang="scss" scoped>
	@import "/common/css/flex.css";

	.tab-bar {
		height: 49px;
		width: 100%;
		border-top-width: 1px;
		border-top-style: solid;
		border-top-color: #f1f1f1;
		box-sizing: border-box;
	}

	.tab-bar-item {
		width: 24%;
	}

	.tab_img {
		width: 20px;
		height: 20px;
	}

	.tab_text {
		font-size: 14px;
	}



	//.tab-bar {
	//	//position: fixed;
	//	bottom: 0;
	//	left: 0;
	//	right: 0;
	//	height: 49px;
	//	background: white;
	//	display: flex;
	//	justify-content: center;
	//	align-items: center;
	//	padding-bottom: env(safe-area-inset-bottom); // 适配iphoneX的底部
	//	.tab-bar-item {
	//		flex: 1;
	//		text-align: center;
	//		display: flex;
	//		justify-content: center;
	//		align-items: center;
	//		flex-direction: column;
	//
	//		.tab_img {
	//			width: 20px;
	//			height: 20px;
	//		}
	//
	//		.tab_text {
	//			font-size: 20px;
	//			margin-top: 9px;
	//		}
	//	}
	//}
</style>