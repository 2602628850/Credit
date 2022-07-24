<template>
	<!--我的-->
	<navigation-bar :title="$t('setUp.title')"></navigation-bar>
	<app-content-view :show-tab-bar="true" :show-navigation-bar="true">
		<view class="mine-item-box">
			<view style="border-bottom: 1px solid rgb(241, 241, 241)" class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('setUp.UserName')}}</view>
				</view>
				<view>{{UserInfo.username}}</view>
			</view>
			<view style="border-bottom: 1px solid rgb(241, 241, 241)" class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('setUp.InviteCode')}}</view>
				</view>
				<view class="right">{{UserInfo.invCode}}</view>
			</view>
		</view>
		<view class="mine-item-box">
			<view @click="SharedTo('/pages/mine/UserInfo')" style="border-bottom: 1px solid rgb(241, 241, 241)"
				class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('setUp.UserInfo')}}</view>
				</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view>
			<view @click="SharedTo('/pages/mine/changePwd')" style="border-bottom: 1px solid rgb(241, 241, 241)"
				class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('setUp.ChangePassword')}}</view>
				</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view>
		</view>
		<view class="mine-item-box">
			<view @click="changeLang()" style="border-bottom: 1px solid rgb(241, 241, 241)" class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('setUp.language')}}</view>
				</view>
				<view>{{language}}</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view>
		</view>

	</app-content-view>
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
				language:"English"
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
			goInfo() {
				uni.navigateTo({
					url: '/pages/mine/change-info'
				})
			},
			goLevel() {
				uni.navigateTo({
					url: '/pages/mine/level'
				})
			},
			GetUserinfo() {
				var url = "/User/GetUserInfo";
				this.ApiGet(url).then(res => {
					this.UserInfo = res.data
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
			},
			changeLang() {
				let oldLang = this.$StoreUtil.get('lang');
				if (!oldLang) {
					oldLang = 'en';
					this.language="中文";
				}

				if (oldLang == 'en') {
					this.$i18n.locale = 'zh';
					this.language="English";
					this.$StoreUtil.set('lang', 'zh');
				} else {
					this.$i18n.locale = 'en';
					this.language="中文";
					this.$StoreUtil.set('lang', 'en');
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
