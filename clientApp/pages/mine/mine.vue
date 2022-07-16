<template>
	<!--我的-->
	<navigation-bar :title="$t('mine.title')" :show-back="false"></navigation-bar>
	<app-content-view :show-tab-bar="true" :show-navigation-bar="true">
		<view class="mine-item-box flex-row-between">
			<image class="mine-header-img" :src="UserInfo.headImage" @click="goInfo"></image>
			<view class="flex-column-center mgr mgl" style="flex: 1;align-items: flex-start">
				<view>{{UserInfo.username}}</view>
				<view class="flex-row-start text-grey" v-on:click="copyUrl()">
					<view>{{UserInfo.invCode}}</view>
					<image class="mine-inv-img mgl" :src="'/static/Icons/mine/v1.png'"></image>
				</view>
			</view>
			<image class="mine-level-img" :src="'/static/Icons/mine/v1.png'" @click="goLevel"></image>
		</view>


		<view class="mine-item-box">
			<view class="text-small text-grey">{{$t('mine.balance')}}</view>
			<view class="flex-row-start mgt" style="height: 30px">
				<view class="text-26 text-primary">{{UserInfo.balance}}</view>
				<view class="text-primary mgl flex-column-end text-small" style="font-weight: bold;height: 100%">USD
				</view>
			</view>
			<view class="text-small text-tip mgt">
				≈ 30000 THB
			</view>
			<view class="flex-row-between" style="margin-top: 20px">
				<view class="mine-button mine-button-primary text-primary flex-row-center">{{$t('public.recharge')}}
				</view>
				<view class="mine-button mine-button-second text-primary flex-row-center">{{$t('public.withdraw')}}
				</view>
			</view>
		</view>


		<view class="mine-item-box" v-for="item in bottomItems">
			<view v-for="(cell,index) in item" @click="SharedTo(cell.url)" class="mine-cell-item flex-row-between"
				:style="getLineStyle(item,index)">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mine-cell-img" :class="cell.image" :style="{color: cell.imageColor}"></view>
					<view class="mgl text-color">{{cell.title}}</view>
				</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view>
		</view>

		<view style="height: 1px"></view>

	</app-content-view>
	<bottomhand :selected="4"></bottomhand>
</template>

<script>
	import NavigationBar from "../../components/navigation-bar";
	import AppContentView from "../../components/app-content-view";
	import Bottomhand from "../../components/bottomhand";
	export default {
		name: "mine",
		components: {
			Bottomhand,
			AppContentView,
			NavigationBar
		},
		data() {
			return {
				UserInfo: {},
				bottomItems: [
					[{
							title: this.$t('mine.purse'),
							image: ['iconfont', 'icon-qianbao'],
							imageColor: '#00875a',
							url: ''
						},
						{
							title: this.$t('mine.financial'),
							image: ['iconfont', 'icon-caiwubaobiao'],
							imageColor: '#00875a',
							url: '/pages/bills/bills'
						},
						{
							title: this.$t('mine.setUp'),
							image: ['iconfont', 'icon-shezhi'],
							imageColor: '#00875a',
							url: '/pages/mine/Setting'
						}
					],
					[{
						title: this.$t('mine.paper'),
						image: ['iconfont', 'icon-bangzhuzhongxin'],
						imageColor: '#666666',
						url: ''
					}],
					[{
						title: this.$t('mine.service'),
						image: ['iconfont', 'icon-lianxi'],
						imageColor: '#666666',
						url: ''
					}]
				]
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
			copyUrl() {
				let content =this.UserInfo.invCode;
				content = typeof content === 'string' ? content : content.toString()
				//#ifndef H5
				uni.setClipboardData({
					data: content,
					success: function() {
						uni.showToast({
							title: this.$t('share.copyresult'),
							duration:2000
						});
					},
					fail:function(){
						uni.showToast({
							title: '复制失败,请重新尝试!',
							icon:"none",
							duration:2000
						});
					}
				});
				//#endif
			
				// #ifdef H5
				if(!document.queryCommandSupported('copy')){
					error('浏览器不支持')
				}
				let textarea = document.createElement("textarea")
				textarea.value = content
				textarea.readOnly = "readOnly"
				document.body.appendChild(textarea)
				textarea.select() // 选择对象
				textarea.setSelectionRange(0, content.length) //核心
				let result = document.execCommand("copy") // 执行浏览器复制命令
				if(result){
					uni.showToast({
						title: this.$t('share.copyresult'),
						duration:2000
					});
				}	
				textarea.remove()
				// #endif
			},
			goInfo() {
				uni.navigateTo({
					url: '/pages/mine/change-info'
				})
			},
			GetUserinfo() {
				var url = "/User/GetUserInfo";
				this.ApiGet(url).then(res => {
					this.UserInfo = res.data
				})
			},
			goLevel() {
				uni.navigateTo({
					url: '/pages/mine/level'
				})
			},
			SharedTo(uri) {
				uni.navigateTo({
					url: uri
				})
			},
			getLineStyle(item, index) {
				if (item.length == 1) {
					return {}
				}
				if (index == item.length - 1) {
					return {}
				}
				return {
					borderBottomStyle: 'solid',
					borderBottomWidth: '1px',
					borderBottomColor: '#f1f1f1'
				}
			}
		}
	}
</script>

<style scoped>
	.mine-item-box {
		margin: 20px;
		padding: 15px;
		border-radius: 15px;
		box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
		background-color: white;
	}


	.mine-header-img {
		height: 48px;
		width: 48px;
		border-radius: 50%;
	}

	.mine-level-img {
		height: 30px;
		width: 45px;
	}

	.mine-inv-img {
		height: 15px;
		width: 15px;
	}

	.mine-button {
		border-radius: 15px;
		font-size: 15px;
		height: 44px;
		width: calc(50% - 10px);
	}

	.mine-button-primary {
		background-color: #e2ffee;
	}

	.mine-button-second {
		background-color: #f4f5f7;
	}

	.mine-cell-item {
		height: 50px;
	}

	.mine-cell-img {
		width: 20px;
		height: 20px;
		font-size: 20px;
	}
</style>
