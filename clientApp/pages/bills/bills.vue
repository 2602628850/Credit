<template>
	<!--我的-->
	<navigation-bar :title="$t('bills.title')"></navigation-bar>
	<app-content-view :show-tab-bar="true" :show-navigation-bar="true"> 
		<view class="mine-item-box">
			<view @click="SharedTo('/pages/statistic/RechargeRecord')" style="border-bottom: 1px solid rgb(241, 241, 241)"
				class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('bills.RechargeRecord')}}</view>
				</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view>
			<view @click="SharedTo('/pages/statistic/WithdrawalRecord')" style="border-bottom: 1px solid rgb(241, 241, 241)"
				class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('bills.WithdrawalRecord')}}</view>
				</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view>
			<view @click="SharedTo('/pages/statistic/moneychangerecord')" style="border-bottom: 1px solid rgb(241, 241, 241)"
				class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('bills.CapitalChangeRecord')}}</view>
				</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view>
			<view @click="SharedTo('/pages/integral/currentintegral')" style="border-bottom: 1px solid rgb(241, 241, 241)"
				class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('bills.IntegralRecord')}}</view>
				</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view>
		</view>
		<view class="mine-item-box">
			<view @click="SharedTo( )" style="border-bottom: 1px solid rgb(241, 241, 241)"
				class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('bills.ChaKaRecord')}}</view>
				</view>
				<view class="mine-cell-img text-tip iconfont icon-right"></view>
			</view> 
		</view>
		<view class="mine-item-box">
			<view @click="SharedTo('/pages/integral/inteorder')" style="border-bottom: 1px solid rgb(241, 241, 241)"
				class="mine-cell-item flex-row-between">
				<view style="flex: 1" class="flex-row-start mgr">
					<view class="mgl text-color">{{$t('bills.OrderRecord')}}</view>
				</view>
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
			}
		},
		created() {
			if (!uni.getStorageSync('token')) {
			uni.reLaunch({
				url:'/pages/login/login'
			})
			return;
			}
		},
		methods: { 
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
